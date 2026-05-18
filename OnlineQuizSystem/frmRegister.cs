using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            // Check for empty fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseConnection.ConnectDatabase();

                // Check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username=@username";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, DatabaseConnection.conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Insert new user
                string insertQuery = "INSERT INTO users (username, password, role) VALUES (@username, @password, @role)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, DatabaseConnection.conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@role", role);
                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DatabaseConnection.CloseDatabase();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
        }
    }
}