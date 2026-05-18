using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineQuizSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseConnection.ConnectDatabase();

                string query = "SELECT role FROM users WHERE username=@username AND password=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        MessageBox.Show($"Login successful! Welcome {role}: {username}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            frmAdminDashboard adminForm = new frmAdminDashboard(username);
                            adminForm.Show();
                        }
                        else
                        {
                            frmStudentDashboard studentForm = new frmStudentDashboard(username);
                            studentForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtUsername.Focus();
                    }
                }
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister register = new frmRegister();
            register.Show();
        }
    }
}