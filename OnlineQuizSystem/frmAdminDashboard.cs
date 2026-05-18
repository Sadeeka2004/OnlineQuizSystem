using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OnlineQuizSystem
{
    public partial class frmAdminDashboard : Form
    {
        private string currentUser;
        public frmAdminDashboard(string username)
        {
            InitializeComponent();
            currentUser = username;
            lblWelcome.Text = $"Welcome, Admin: {currentUser}";
        }


        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmManageUsers manageUsers = new frmManageUsers();
            manageUsers.Show();
        }

        private void btnManageQuizzes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmManageQuizzes manageQuizzes = new frmManageQuizzes();
            manageQuizzes.Show();
        }

        private void btnManageQuestions_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmManageQuestions manageQuestions = new frmManageQuestions();
            manageQuestions.Show();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReports reports = new frmReports();
            reports.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        { 
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

