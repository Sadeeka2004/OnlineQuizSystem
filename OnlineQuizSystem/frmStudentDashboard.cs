using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL connector

namespace OnlineQuizSystem
{
    public partial class frmStudentDashboard : Form
    {
        private string currentUser;

        public frmStudentDashboard(string username)
        {
            InitializeComponent();
            currentUser = username;
            lblWelcome.Text = $"Welcome, {username}";
            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            cmbSelectQuiz.Items.Clear();

            try
            {
                DatabaseConnection.ConnectDatabase();

                // ✅ Corrected column name
                string query = "SELECT quiz_title FROM quizzes";
                MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> quizList = new List<string>();
                while (reader.Read())
                {
                    // ✅ Updated field reference
                    quizList.Add(reader["quiz_title"].ToString());
                }

                reader.Close();

                if (quizList.Count == 0)
                {
                    MessageBox.Show("No quizzes are currently available. Please contact your admin.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSelectQuiz.Enabled = false;
                }
                else
                {
                    cmbSelectQuiz.Items.AddRange(quizList.ToArray());
                    cmbSelectQuiz.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSelectQuiz.Enabled = false;
            }
            finally
            {
                DatabaseConnection.conn.Close();
            }
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            if (cmbSelectQuiz.SelectedItem == null)
            {
                MessageBox.Show("Please select a quiz to start.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedQuiz = cmbSelectQuiz.SelectedItem.ToString();

            // Open Take Quiz form
            frmTakeQuiz takeQuiz = new frmTakeQuiz(currentUser, selectedQuiz);
            takeQuiz.Show();
            this.Close();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            frmResults results = new frmResults(currentUser, "Student");
            results.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}