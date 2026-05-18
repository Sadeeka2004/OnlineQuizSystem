using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmResults : Form
    {
        private string currentUser;
        private string currentRole;

        public frmResults()
        {
            InitializeComponent();
        }

        public frmResults(string username, string role) : this()
        {
            currentUser = username;
            currentRole = role ?? "Student";
            lblTitle.Text = $"Quiz Results - {currentUser}";
            SetupDataGridView();
            LoadUserResults();
        }

        private void SetupDataGridView()
        {
            dgvResults.Columns.Clear();
            dgvResults.AutoGenerateColumns = false;

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "QuizName", HeaderText = "Quiz Name", Width = 150 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateTime", HeaderText = "Date & Time", Width = 180 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "Score", HeaderText = "Score", Width = 80 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalQuestions", HeaderText = "Total Questions", Width = 110 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "Percentage", HeaderText = "Percentage", Width = 90 });

            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadUserResults()
        {
            dgvResults.Rows.Clear();

            try
            {
                DatabaseConnection.ConnectDatabase();

                // Step 1: Load all results into a list first
                string resultQuery = "SELECT r.quiz_id, q.quiz_title, r.score, r.date_time " +
                                     "FROM results r " +
                                     "INNER JOIN quizzes q ON r.quiz_id = q.id " +
                                     "WHERE r.username = @username " +
                                     "ORDER BY r.date_time DESC";

                var resultList = new List<(int quizId, string quizTitle, int score, DateTime dt)>();

                using (MySqlCommand cmd = new MySqlCommand(resultQuery, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@username", currentUser);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultList.Add((
                                Convert.ToInt32(reader["quiz_id"]),
                                reader["quiz_title"].ToString(),
                                Convert.ToInt32(reader["score"]),
                                Convert.ToDateTime(reader["date_time"])
                            ));
                        }
                    }
                }

                // Step 2: For each result, get total questions and calculate percentage
                foreach (var r in resultList)
                {
                    int totalQuestions = 0;
                    string totalQuery = "SELECT COUNT(*) FROM questions WHERE quiz_id=@qid";
                    using (MySqlCommand totalCmd = new MySqlCommand(totalQuery, DatabaseConnection.conn))
                    {
                        totalCmd.Parameters.AddWithValue("@qid", r.quizId);
                        totalQuestions = Convert.ToInt32(totalCmd.ExecuteScalar());
                    }

                    double pct = totalQuestions > 0 ? (r.score * 100.0 / totalQuestions) : 0.0;

                    dgvResults.Rows.Add(
                        r.quizTitle,
                        r.dt.ToString("yyyy-MM-dd HH:mm:ss"),
                        r.score.ToString(),
                        totalQuestions.ToString(),
                        pct.ToString("0.00") + "%"
                    );
                }

                if (dgvResults.Rows.Count == 0)
                    MessageBox.Show("No quiz attempts found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading results: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (currentRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                new frmAdminDashboard(currentUser).Show();
            else
                new frmStudentDashboard(currentUser).Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"{currentUser}_results.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            sw.WriteLine("QuizName,DateTime,Score,TotalQuestions,Percentage");
                            foreach (DataGridViewRow row in dgvResults.Rows)
                            {
                                if (row.IsNewRow) continue;
                                var c0 = row.Cells["QuizName"].Value?.ToString() ?? "";
                                var c1 = row.Cells["DateTime"].Value?.ToString() ?? "";
                                var c2 = row.Cells["Score"].Value?.ToString() ?? "";
                                var c3 = row.Cells["TotalQuestions"].Value?.ToString() ?? "";
                                var c4 = row.Cells["Percentage"].Value?.ToString() ?? "";
                                sw.WriteLine($"{c0},{c1},{c2},{c3},{c4}");
                            }
                        }
                        MessageBox.Show("Exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private class ResultRecord
        {
            public string QuizName { get; set; }
            public string DateTime { get; set; }
            public string Score { get; set; }
            public string TotalQuestions { get; set; }
            public string Percentage { get; set; }
        }
    }
}