using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmManageQuestions : Form
    {
        int selectedQuizId = -1;

        public frmManageQuestions()
        {
            InitializeComponent();
            InitializeForm();
        }

        // New constructor to receive quizId and quizName
        public frmManageQuestions(int quizId, string quizName) : this()
        {
            selectedQuizId = quizId;

            // Load quizzes and select the given quiz
            for (int i = 0; i < cmbQuiz.Items.Count; i++)
            {
                string item = cmbQuiz.Items[i].ToString();
                if (item.Contains($"| {quizName}"))
                {
                    cmbQuiz.SelectedIndex = i;
                    break;
                }
            }
        }

        private void InitializeForm()
        {
            // Load quiz list
            LoadQuizNames();

            // Correct answer dropdown setup
            cmbCorrect.Items.AddRange(new string[] { "1", "2", "3", "4" });

            // Placeholder setup
            txtQuestion.Text = "Enter your question here...";
            txtQuestion.ForeColor = Color.Gray;
            txtQuestion.GotFocus += RemovePlaceholder;
            txtQuestion.LostFocus += SetPlaceholder;

            txtOption1.Text = "Option 1"; txtOption1.ForeColor = Color.Gray;
            txtOption2.Text = "Option 2"; txtOption2.ForeColor = Color.Gray;
            txtOption3.Text = "Option 3"; txtOption3.ForeColor = Color.Gray;
            txtOption4.Text = "Option 4"; txtOption4.ForeColor = Color.Gray;

            txtOption1.GotFocus += RemoveOptionPlaceholder;
            txtOption2.GotFocus += RemoveOptionPlaceholder;
            txtOption3.GotFocus += RemoveOptionPlaceholder;
            txtOption4.GotFocus += RemoveOptionPlaceholder;

            txtOption1.LostFocus += SetOptionPlaceholder;
            txtOption2.LostFocus += SetOptionPlaceholder;
            txtOption3.LostFocus += SetOptionPlaceholder;
            txtOption4.LostFocus += SetOptionPlaceholder;

            cmbQuiz.SelectedIndexChanged += cmbQuiz_SelectedIndexChanged;
        }

        private void LoadQuizNames()
        {
            cmbQuiz.Items.Clear();
            cmbQuiz.Items.Add("Select Quiz");
            cmbQuiz.SelectedIndex = 0;

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = "SELECT id, quiz_title FROM quizzes ORDER BY quiz_title ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string display = $"{reader["id"]} | {reader["quiz_title"]}";
                        cmbQuiz.Items.Add(display);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading quizzes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void cmbQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbQuiz.SelectedIndex <= 0)
            {
                selectedQuizId = -1;
                lstQuestions.Items.Clear();
                return;
            }

            string selectedItem = cmbQuiz.SelectedItem.ToString();
            string[] parts = selectedItem.Split('|');
            if (parts.Length >= 2)
                int.TryParse(parts[0].Trim(), out selectedQuizId);

            LoadQuestions();
        }

        private void LoadQuestions()
        {
            lstQuestions.Items.Clear();
            if (selectedQuizId == -1) return;

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = @"SELECT id, question_text, option_a, option_b, option_c, option_d, correct_option
                                 FROM questions WHERE quiz_id=@qid ORDER BY id ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@qid", selectedQuizId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string display = $"{reader["id"]} | {reader["question_text"]} | A: {reader["option_a"]}, B: {reader["option_b"]}, C: {reader["option_c"]}, D: {reader["option_d"]} | Correct: {reader["correct_option"]}";
                            lstQuestions.Items.Add(display);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading questions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        // Placeholder handlers
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtQuestion.Text == "Enter your question here...")
            {
                txtQuestion.Text = "";
                txtQuestion.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                txtQuestion.Text = "Enter your question here...";
                txtQuestion.ForeColor = Color.Gray;
            }
        }

        private void RemoveOptionPlaceholder(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.ForeColor == Color.Gray)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void SetOptionPlaceholder(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb == txtOption1) tb.Text = "Option 1";
                else if (tb == txtOption2) tb.Text = "Option 2";
                else if (tb == txtOption3) tb.Text = "Option 3";
                else if (tb == txtOption4) tb.Text = "Option 4";
                tb.ForeColor = Color.Gray;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedQuizId == -1)
            {
                MessageBox.Show("Please select a quiz first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string question = txtQuestion.Text.Trim();
            string opt1 = txtOption1.Text.Trim();
            string opt2 = txtOption2.Text.Trim();
            string opt3 = txtOption3.Text.Trim();
            string opt4 = txtOption4.Text.Trim();
            string correct = cmbCorrect.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(question) || string.IsNullOrEmpty(opt1) ||
                string.IsNullOrEmpty(opt2) || string.IsNullOrEmpty(opt3) ||
                string.IsNullOrEmpty(opt4) || string.IsNullOrEmpty(correct) ||
                question == "Enter your question here..." || opt1 == "Option 1" ||
                opt2 == "Option 2" || opt3 == "Option 3" || opt4 == "Option 4")
            {
                MessageBox.Show("Please fill in all fields with valid values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = @"INSERT INTO questions (quiz_id, question_text, option_a, option_b, option_c, option_d, correct_option)
                                 VALUES (@qid, @q, @o1, @o2, @o3, @o4, @correct)";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@qid", selectedQuizId);
                    cmd.Parameters.AddWithValue("@q", question);
                    cmd.Parameters.AddWithValue("@o1", opt1);
                    cmd.Parameters.AddWithValue("@o2", opt2);
                    cmd.Parameters.AddWithValue("@o3", opt3);
                    cmd.Parameters.AddWithValue("@o4", opt4);
                    cmd.Parameters.AddWithValue("@correct", correct);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Question added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding question: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void ClearInputs()
        {
            txtQuestion.Text = "Enter your question here...";
            txtQuestion.ForeColor = Color.Gray;

            txtOption1.Text = "Option 1"; txtOption1.ForeColor = Color.Gray;
            txtOption2.Text = "Option 2"; txtOption2.ForeColor = Color.Gray;
            txtOption3.Text = "Option 3"; txtOption3.ForeColor = Color.Gray;
            txtOption4.Text = "Option 4"; txtOption4.ForeColor = Color.Gray;

            cmbCorrect.SelectedIndex = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedQuizId == -1 || lstQuestions.SelectedItem == null)
            {
                MessageBox.Show("Please select a quiz and a question to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedLine = lstQuestions.SelectedItem.ToString();
            string[] parts = selectedLine.Split('|');
            if (parts.Length < 2) return;

            if (!int.TryParse(parts[0].Trim(), out int questionId)) return;

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = "DELETE FROM questions WHERE id=@qid LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@qid", questionId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Question deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuestions();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting question: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminDashboard admin = new frmAdminDashboard("Admin");
            admin.Show();
        }
    }
}