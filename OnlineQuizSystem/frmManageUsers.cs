using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void lblTitle_Click(object sender, EventArgs e) { }

        // Load all users from the database
        private void LoadUsers()
        {
            lstUsers.Items.Clear();

            try
            {
                DatabaseConnection.ConnectDatabase();

                string query = "SELECT username, role FROM users ORDER BY username ASC";
                MySqlCommand cmd = new MySqlCommand(query, DatabaseConnection.conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string role = reader["role"].ToString();
                        lstUsers.Items.Add($"{username} ({role})");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DatabaseConnection.conn != null && DatabaseConnection.conn.State == System.Data.ConnectionState.Open)
                    DatabaseConnection.conn.Close();
            }
        }

        // Delete selected user and their results
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedUser = lstUsers.SelectedItem.ToString();
            string usernameToDelete = selectedUser.Split('(')[0].Trim();

            if (usernameToDelete.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Cannot delete the main admin user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseConnection.ConnectDatabase();

                // Delete user's results first
                string deleteResultsQuery = "DELETE FROM results WHERE username=@username";
                using (MySqlCommand cmdResults = new MySqlCommand(deleteResultsQuery, DatabaseConnection.conn))
                {
                    cmdResults.Parameters.AddWithValue("@username", usernameToDelete);
                    cmdResults.ExecuteNonQuery();
                }

                // Delete user
                string deleteUserQuery = "DELETE FROM users WHERE username=@username";
                using (MySqlCommand cmdUser = new MySqlCommand(deleteUserQuery, DatabaseConnection.conn))
                {
                    cmdUser.Parameters.AddWithValue("@username", usernameToDelete);
                    cmdUser.ExecuteNonQuery();
                }

                MessageBox.Show("User and their results deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DatabaseConnection.conn != null && DatabaseConnection.conn.State == System.Data.ConnectionState.Open)
                    DatabaseConnection.conn.Close();
            }
        }

        // Open registration form to add a new user
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            register.Show();
        }

        // Go back to admin dashboard
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminDashboard admin = new frmAdminDashboard("Admin");
            admin.Show();
        }

        private void frmManageUsers_Load(object sender, EventArgs e) { }
    }
}