using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmTakeQuiz : Form
    {
        string currentUser, currentQuiz;
        int currentQuizId = 0;
        int currentQuizDuration = 0; // in minutes
        int totalSeconds = 0;

        List<Question> questions = new List<Question>();
        bool[] answered; // track which questions already scored
        int currentIndex = 0;
        int score = 0;
        bool timeUp = false;

        public frmTakeQuiz(string username, string quizName)
        {
            InitializeComponent();
            currentUser = username;
            currentQuiz = quizName;
            lblQuizTitle.Text = "Quiz: " + quizName;

            bool loaded = LoadQuizDetails() && LoadQuestions();
            if (!loaded)
            {
                MessageBox.Show("Quiz not available. Returning to Dashboard...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStudentDashboard dashboard = new frmStudentDashboard(currentUser);
                dashboard.Show();
                this.Load += (s, e) => this.Close();
                return;
            }

            // prepare timer
            totalSeconds = currentQuizDuration * 60;
            lblTimer.Text = FormatTime(totalSeconds);

            quizTimer.Interval = 1000;
            quizTimer.Tick += QuizTimer_Tick;
            quizTimer.Start();

            // prepare answered array
            answered = new bool[questions.Count];

            DisplayQuestion();
            btnSubmit.Enabled = false;
        }

        private bool LoadQuizDetails()
        {
            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = "SELECT id, duration FROM quizzes WHERE quiz_title=@quizTitle";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@quizTitle", currentQuiz);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentQuizId = Convert.ToInt32(reader["id"]);
                            currentQuizDuration = Convert.ToInt32(reader["duration"]);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading quiz details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
            return false;
        }

        private bool LoadQuestions()
        {
            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = @"SELECT question_text, option_a, option_b, option_c, option_d, correct_option 
                                 FROM questions WHERE quiz_id=@quizId ORDER BY id ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@quizId", currentQuizId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                QuestionText = reader["question_text"].ToString(),
                                Option1 = reader["option_a"].ToString(),
                                Option2 = reader["option_b"].ToString(),
                                Option3 = reader["option_c"].ToString(),
                                Option4 = reader["option_d"].ToString(),
                                CorrectAnswer = reader["correct_option"].ToString()
                            });
                        }
                    }
                }

                return questions.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading questions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
            return false;
        }

        private void DisplayQuestion()
        {
            if (currentIndex < questions.Count)
            {
                var q = questions[currentIndex];
                lblQuestion.Text = q.QuestionText;
                rdoOption1.Text = q.Option1;
                rdoOption2.Text = q.Option2;
                rdoOption3.Text = q.Option3;
                rdoOption4.Text = q.Option4;
                lblProgress.Text = $"Question {currentIndex + 1} of {questions.Count}";
                ClearSelection();

                if (timeUp)
                {
                    rdoOption1.Enabled = rdoOption2.Enabled = rdoOption3.Enabled = rdoOption4.Enabled = false;
                    btnNext.Enabled = btnSubmit.Enabled = false;
                }
            }
        }

        private void ClearSelection()
        {
            rdoOption1.Checked = false;
            rdoOption2.Checked = false;
            rdoOption3.Checked = false;
            rdoOption4.Checked = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (timeUp) return;

            if (!EvaluateCurrentAnswer(skipWarning: false)) return;

            if (currentIndex == questions.Count - 1)
            {
                MessageBox.Show("You have reached the last question. Click Submit to finish the quiz.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNext.Enabled = false;
                btnSubmit.Enabled = true;
                return;
            }

            currentIndex++;
            DisplayQuestion();
        }

        private bool EvaluateCurrentAnswer(bool skipWarning = false)
        {
            int selectedOption = GetSelectedOptionIndex();
            if (selectedOption == -1)
            {
                if (!skipWarning)
                {
                    MessageBox.Show("Please select an answer before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }

            if (answered.Length > currentIndex && answered[currentIndex])
                return true; // already evaluated

            string correctAnswer = questions[currentIndex].CorrectAnswer.Trim();
            if (correctAnswer == selectedOption.ToString())
                score++;

            if (answered.Length > currentIndex)
                answered[currentIndex] = true;

            if (score > questions.Count) score = questions.Count;

            return true;
        }

        private int GetSelectedOptionIndex()
        {
            if (rdoOption1.Checked) return 1;
            if (rdoOption2.Checked) return 2;
            if (rdoOption3.Checked) return 3;
            if (rdoOption4.Checked) return 4;
            return -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            quizTimer.Stop();
            timeUp = true; // prevent further interactions

            EvaluateCurrentAnswer(skipWarning: false);

            if (score > questions.Count) score = questions.Count;
            if (score < 0) score = 0;

            SaveResult();

            double percentage = (questions.Count > 0) ? ((double)score / questions.Count * 100.0) : 0.0;
            MessageBox.Show(
                $"Quiz Completed!\nYour Score: {score}/{questions.Count}\n" +
                $"Percentage: {percentage:0.00}%",
                "Quiz Completed", MessageBoxButtons.OK, MessageBoxIcon.Information
            );

            this.Hide();
            frmResults results = new frmResults(currentUser, "Student");
            results.Show();
        }

        private void SaveResult()
        {
            int total = questions.Count;

            try
            {
                DatabaseConnection.ConnectDatabase();

                string schemaQuery = @"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
                                       WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'results'";
                List<string> cols = new List<string>();
                using (MySqlCommand scmd = new MySqlCommand(schemaQuery, DatabaseConnection.conn))
                using (MySqlDataReader r = scmd.ExecuteReader())
                {
                    while (r.Read())
                        cols.Add(r.GetString(0).ToLower());
                }

                var insertCols = new List<string>();
                var paramPairs = new Dictionary<string, object>();

                if (cols.Contains("username"))
                {
                    insertCols.Add("username");
                    paramPairs.Add("@username", currentUser);
                }

                if (cols.Contains("quiz_id"))
                {
                    insertCols.Add("quiz_id");
                    paramPairs.Add("@quizid", currentQuizId);
                }
                else if (cols.Contains("quiz_title"))
                {
                    insertCols.Add("quiz_title");
                    paramPairs.Add("@quiz", currentQuiz);
                }

                if (cols.Contains("score"))
                {
                    insertCols.Add("score");
                    paramPairs.Add("@score", score);
                }

                string totalCol = null;
                if (cols.Contains("total_questions")) totalCol = "total_questions";
                else if (cols.Contains("total")) totalCol = "total";
                else if (cols.Contains("total_q")) totalCol = "total_q";
                else if (cols.Contains("totalquestions")) totalCol = "totalquestions";

                if (!string.IsNullOrEmpty(totalCol))
                {
                    insertCols.Add(totalCol);
                    paramPairs.Add("@total", total);
                }

                string dateCol = null;
                if (cols.Contains("date_time")) dateCol = "date_time";
                else if (cols.Contains("date")) dateCol = "date";
                else if (cols.Contains("datetime")) dateCol = "datetime";

                if (!string.IsNullOrEmpty(dateCol))
                {
                    insertCols.Add(dateCol);
                    paramPairs.Add("@datetime", DateTime.Now);
                }

                if (insertCols.Count == 0)
                {
                    MessageBox.Show("Results table does not have expected columns. Cannot save result.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string colList = string.Join(", ", insertCols);
                string paramList = string.Join(", ", insertCols.ConvertAll(c =>
                {
                    switch (c.ToLower())
                    {
                        case "username": return "@username";
                        case "quiz_id": return "@quizid";
                        case "quiz_title": return "@quiz";
                        case "score": return "@score";
                        case "total_questions":
                        case "total":
                        case "total_q":
                        case "totalquestions": return "@total";
                        case "date_time":
                        case "date":
                        case "datetime": return "@datetime";
                        default: return "@" + c;
                    }
                }));

                string insertSql = $"INSERT INTO results ({colList}) VALUES ({paramList})";
                using (MySqlCommand ins = new MySqlCommand(insertSql, DatabaseConnection.conn))
                {
                    foreach (var p in paramPairs)
                        ins.Parameters.AddWithValue(p.Key, p.Value);
                    ins.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving result: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            if (totalSeconds <= 0)
            {
                quizTimer.Stop();
                timeUp = true;

                rdoOption1.Enabled = rdoOption2.Enabled = rdoOption3.Enabled = rdoOption4.Enabled = false;
                btnNext.Enabled = btnSubmit.Enabled = false;

                MessageBox.Show("Time is up! Quiz will be submitted automatically.", "Time Up", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EvaluateCurrentAnswer(skipWarning: true);
                SaveResult();

                frmResults results = new frmResults(currentUser, "Student");
                results.Show();
                this.Hide();
                return;
            }

            totalSeconds--;
            lblTimer.Text = FormatTime(totalSeconds);
        }

        private string FormatTime(int seconds)
        {
            int min = seconds / 60;
            int sec = seconds % 60;
            return $"{min:D2}:{sec:D2}";
        }

        private class Question
        {
            public string QuestionText { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string CorrectAnswer { get; set; }
        }
    }
}