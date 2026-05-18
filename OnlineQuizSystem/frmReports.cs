using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmReports : Form
    {
        bool isFormLoaded = false;

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // Setup ListView columns
            lvReports.Columns.Clear();
            lvReports.Columns.Add("Username", 150);
            lvReports.Columns.Add("Score", 80);
            lvReports.Columns.Add("Percentage", 80);
            lvReports.Columns.Add("Date", 120);
            lvReports.View = View.Details;
            lvReports.FullRowSelect = true;
            lvReports.Items.Clear();

            LoadQuizzes();

            isFormLoaded = true;
        }

        private void LoadQuizzes()
        {
            cmbSelectQuiz.Items.Clear();
            cmbSelectQuiz.Items.Add("-- Select a Quiz --");
            cmbSelectQuiz.SelectedIndex = 0;

            try
            {
                DatabaseConnection.ConnectDatabase();

                string query = "SELECT quiz_title FROM quizzes ORDER BY quiz_title ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbSelectQuiz.Items.Add(reader["quiz_title"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void cmbSelectQuiz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;

            lvReports.Items.Clear();

            string selectedQuiz = cmbSelectQuiz.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedQuiz) || selectedQuiz == "-- Select a Quiz --")
                return;

            try
            {
                DatabaseConnection.ConnectDatabase();

                // Get quiz ID
                int quizId = -1;
                string quizIdQuery = "SELECT id FROM quizzes WHERE quiz_title=@quizTitle LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(quizIdQuery, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@quizTitle", selectedQuiz);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        quizId = Convert.ToInt32(result);
                }

                if (quizId == -1)
                {
                    MessageBox.Show("Selected quiz not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get total number of questions
                int totalQuestions = 0;
                string totalQuery = "SELECT COUNT(*) FROM questions WHERE quiz_id=@quizId";
                using (MySqlCommand totalCmd = new MySqlCommand(totalQuery, DatabaseConnection.conn))
                {
                    totalCmd.Parameters.AddWithValue("@quizId", quizId);
                    totalQuestions = Convert.ToInt32(totalCmd.ExecuteScalar());
                }

                // Get results
                string resultQuery = @"SELECT username, score, date_time
                                       FROM results
                                       WHERE quiz_id=@quizId";
                List<ListViewItem> items = new List<ListViewItem>();
                using (MySqlCommand resultCmd = new MySqlCommand(resultQuery, DatabaseConnection.conn))
                {
                    resultCmd.Parameters.AddWithValue("@quizId", quizId);
                    using (MySqlDataReader reader = resultCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader["username"].ToString();
                            int score = Convert.ToInt32(reader["score"]);
                            string date = reader["date_time"].ToString();
                            double percentage = totalQuestions > 0 ? (double)score / totalQuestions * 100 : 0;

                            ListViewItem item = new ListViewItem(username);
                            item.SubItems.Add(score.ToString());
                            item.SubItems.Add($"{percentage:0.00}%");
                            item.SubItems.Add(date);

                            items.Add(item);
                        }
                    }
                }

                if (items.Count > 0)
                    lvReports.Items.AddRange(items.ToArray());
                else
                    MessageBox.Show("No attempts found for this quiz yet.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lvReports.Items.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "StudentReports.csv";
                sfd.Title = "Export Reports to CSV";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            // Write column headers
                            List<string> headers = new List<string>();
                            foreach (ColumnHeader column in lvReports.Columns)
                            {
                                headers.Add(column.Text);
                            }
                            sw.WriteLine(string.Join(",", headers));

                            // Write each row
                            foreach (ListViewItem item in lvReports.Items)
                            {
                                List<string> row = new List<string>();
                                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                                {
                                    // Escape commas by wrapping text in quotes if needed
                                    string text = subItem.Text.Contains(",") ? $"\"{subItem.Text}\"" : subItem.Text;
                                    row.Add(text);
                                }
                                sw.WriteLine(string.Join(",", row));
                            }
                        }

                        MessageBox.Show("Export successful!", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}