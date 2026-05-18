using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmManageQuizzes : Form
    {
        public frmManageQuizzes()
        {
            InitializeComponent();

            // Setup placeholders
            txtQuizName.Text = "Enter Quiz Name...";
            txtQuizName.ForeColor = Color.Gray;
            txtQuizName.GotFocus += RemovePlaceholder;
            txtQuizName.LostFocus += SetPlaceholder;

            txtDuration.Text = "Duration in minutes";
            txtDuration.ForeColor = Color.Gray;
            txtDuration.GotFocus += RemoveDurationPlaceholder;
            txtDuration.LostFocus += SetDurationPlaceholder;

            LoadQuizzes();
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtQuizName.Text == "Enter Quiz Name...")
            {
                txtQuizName.Text = "";
                txtQuizName.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuizName.Text))
            {
                txtQuizName.Text = "Enter Quiz Name...";
                txtQuizName.ForeColor = Color.Gray;
            }
        }

        private void RemoveDurationPlaceholder(object sender, EventArgs e)
        {
            if (txtDuration.ForeColor == Color.Gray)
            {
                txtDuration.Text = "";
                txtDuration.ForeColor = Color.Black;
            }
        }

        private void SetDurationPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDuration.Text))
            {
                txtDuration.Text = "Duration in minutes";
                txtDuration.ForeColor = Color.Gray;
            }
        }

        private void LoadQuizzes()
        {
            lstQuizzes.Items.Clear();

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = "SELECT id, quiz_title, duration FROM quizzes ORDER BY quiz_title ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string quizName = reader["quiz_title"].ToString();
                        string duration = reader["duration"].ToString();
                        string display = $"{quizName} | {duration} min"; // ID hidden
                        lstQuizzes.Items.Add(display);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string quizName = txtQuizName.Text.Trim();
            string durationText = txtDuration.Text.Trim();

            if (string.IsNullOrEmpty(quizName) || string.IsNullOrEmpty(durationText) ||
                quizName == "Enter Quiz Name..." || durationText == "Duration in minutes")
            {
                MessageBox.Show("Please enter valid quiz name and duration.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(durationText, out int duration) || duration <= 0)
            {
                MessageBox.Show("Duration must be a positive integer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection.ConnectDatabase();
                string query = "INSERT INTO quizzes (quiz_title, duration) VALUES (@title, @duration)";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@title", quizName);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.ExecuteNonQuery();
                }

                // Get the newly added quiz ID
                int newQuizId = 0;
                string idQuery = "SELECT id FROM quizzes WHERE quiz_title=@title ORDER BY id DESC LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(idQuery, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@title", quizName);
                    object result = cmd.ExecuteScalar();
                    if (result != null) newQuizId = Convert.ToInt32(result);
                }

                MessageBox.Show("Quiz added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadQuizzes();

                // Ask if admin wants to add questions now
                DialogResult dr = MessageBox.Show("Do you want to add questions for this quiz now?", "Add Questions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes && newQuizId > 0)
                {
                    frmManageQuestions mqForm = new frmManageQuestions(newQuizId, quizName);
                    mqForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding quiz: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void ClearInputs()
        {
            txtQuizName.Text = "Enter Quiz Name...";
            txtQuizName.ForeColor = Color.Gray;

            txtDuration.Text = "Duration in minutes";
            txtDuration.ForeColor = Color.Gray;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstQuizzes.SelectedItem == null)
            {
                MessageBox.Show("Please select a quiz to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selected = lstQuizzes.SelectedItem.ToString();
            string[] parts = selected.Split('|');
            if (parts.Length < 2) return;

            string quizName = parts[0].Trim();

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete the quiz '{quizName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                DatabaseConnection.ConnectDatabase();

                // Get quiz ID by name
                int quizId = 0;
                string idQuery = "SELECT id FROM quizzes WHERE quiz_title=@title LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(idQuery, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@title", quizName);
                    object result = cmd.ExecuteScalar();
                    if (result != null) quizId = Convert.ToInt32(result);
                }

                if (quizId == 0)
                {
                    MessageBox.Show("Quiz not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Delete associated questions
                string qQuery = "DELETE FROM questions WHERE quiz_id=@qid";
                using (MySqlCommand qCmd = new MySqlCommand(qQuery, DatabaseConnection.conn))
                {
                    qCmd.Parameters.AddWithValue("@qid", quizId);
                    qCmd.ExecuteNonQuery();
                }

                // Delete quiz
                string query = "DELETE FROM quizzes WHERE id=@qid";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@qid", quizId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Quiz deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadQuizzes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting quiz: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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