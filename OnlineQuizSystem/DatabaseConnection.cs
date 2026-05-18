using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OnlineQuizSystem
{
    public static class DatabaseConnection
    {
        // Global MySQL connection object
        public static MySqlConnection conn;

        // Connection parameters
        private static readonly string server = "localhost";
        private static readonly string database = "OnlineQuizSystem";
        private static readonly string uid = "root";
        private static readonly string password = "";

        // Connection string – no SSL to avoid compatibility issues
        private static readonly string connString =
            "Server=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + password + ";";

        // Open database connection
        public static void ConnectDatabase()
        {
            try
            {
                if (conn == null)
                {
                    conn = new MySqlConnection(connString);
                }

                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                string msg;
                if (ex.Number == 0)
                    msg = "Cannot connect to server. Make sure MySQL is running.";
                else if (ex.Number == 1045)
                    msg = "Invalid username/password. Check your credentials.";
                else
                    msg = "Database connection failed: " + ex.Message;

                MessageBox.Show(msg, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; // Ensure calling code knows connection failed
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Close database connection safely
        public static void CloseDatabase()
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing database connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}