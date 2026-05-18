namespace OnlineQuizSystem
{
    partial class frmStudentDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSelectQuiz = new System.Windows.Forms.Label();
            this.cmbSelectQuiz = new System.Windows.Forms.ComboBox();
            this.btnStartQuiz = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(203, 29);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(180, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome [StudentName]";
            // 
            // lblSelectQuiz
            // 
            this.lblSelectQuiz.AutoSize = true;
            this.lblSelectQuiz.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectQuiz.Location = new System.Drawing.Point(232, 85);
            this.lblSelectQuiz.Name = "lblSelectQuiz";
            this.lblSelectQuiz.Size = new System.Drawing.Size(95, 20);
            this.lblSelectQuiz.TabIndex = 1;
            this.lblSelectQuiz.Text = "Select a Quiz";
            
            // 
            // cmbSelectQuiz
            // 
            this.cmbSelectQuiz.FormattingEnabled = true;
            this.cmbSelectQuiz.Location = new System.Drawing.Point(104, 123);
            this.cmbSelectQuiz.Name = "cmbSelectQuiz";
            this.cmbSelectQuiz.Size = new System.Drawing.Size(360, 28);
            this.cmbSelectQuiz.TabIndex = 2;
            // 
            // btnStartQuiz
            // 
            this.btnStartQuiz.BackColor = System.Drawing.Color.DarkCyan;
            this.btnStartQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartQuiz.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartQuiz.ForeColor = System.Drawing.Color.White;
            this.btnStartQuiz.Location = new System.Drawing.Point(104, 215);
            this.btnStartQuiz.Name = "btnStartQuiz";
            this.btnStartQuiz.Size = new System.Drawing.Size(162, 36);
            this.btnStartQuiz.TabIndex = 3;
            this.btnStartQuiz.Text = "Start Quiz";
            this.btnStartQuiz.UseVisualStyleBackColor = false;
            this.btnStartQuiz.Click += new System.EventHandler(this.btnStartQuiz_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.BackColor = System.Drawing.Color.DarkCyan;
            this.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResults.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResults.ForeColor = System.Drawing.Color.White;
            this.btnViewResults.Location = new System.Drawing.Point(303, 215);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(161, 36);
            this.btnViewResults.TabIndex = 4;
            this.btnViewResults.Text = "View My Results";
            this.btnViewResults.UseVisualStyleBackColor = false;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DarkCyan;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(216, 294);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(121, 31);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmStudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnStartQuiz);
            this.Controls.Add(this.cmbSelectQuiz);
            this.Controls.Add(this.lblSelectQuiz);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmStudentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Quiz System - Student Dashboard";
         
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSelectQuiz;
        private System.Windows.Forms.ComboBox cmbSelectQuiz;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Button btnLogout;
    }
}