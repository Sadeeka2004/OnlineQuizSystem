namespace OnlineQuizSystem
{
    partial class frmManageQuizzes
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstQuizzes = new System.Windows.Forms.ListBox();
            this.txtQuizName = new System.Windows.Forms.TextBox();
            this.btnAddQuiz = new System.Windows.Forms.Button();
            this.btnDeleteQuiz = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpQuizDate = new System.Windows.Forms.DateTimePicker();
            this.lblQuizDate = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblQuizDuration = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(232, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(121, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Quizzes";
            // 
            // lstQuizzes
            // 
            this.lstQuizzes.FormattingEnabled = true;
            this.lstQuizzes.ItemHeight = 20;
            this.lstQuizzes.Location = new System.Drawing.Point(98, 57);
            this.lstQuizzes.Name = "lstQuizzes";
            this.lstQuizzes.Size = new System.Drawing.Size(363, 84);
            this.lstQuizzes.TabIndex = 1;
            // 
            // txtQuizName
            // 
            this.txtQuizName.Location = new System.Drawing.Point(98, 162);
            this.txtQuizName.Name = "txtQuizName";
            this.txtQuizName.Size = new System.Drawing.Size(363, 27);
            this.txtQuizName.TabIndex = 2;
            // 
            // btnAddQuiz
            // 
            this.btnAddQuiz.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAddQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddQuiz.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddQuiz.ForeColor = System.Drawing.Color.White;
            this.btnAddQuiz.Location = new System.Drawing.Point(12, 316);
            this.btnAddQuiz.Name = "btnAddQuiz";
            this.btnAddQuiz.Size = new System.Drawing.Size(173, 33);
            this.btnAddQuiz.TabIndex = 3;
            this.btnAddQuiz.Text = "Add Quiz";
            this.btnAddQuiz.UseVisualStyleBackColor = false;
            this.btnAddQuiz.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteQuiz
            // 
            this.btnDeleteQuiz.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDeleteQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuiz.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteQuiz.ForeColor = System.Drawing.Color.White;
            this.btnDeleteQuiz.Location = new System.Drawing.Point(215, 316);
            this.btnDeleteQuiz.Name = "btnDeleteQuiz";
            this.btnDeleteQuiz.Size = new System.Drawing.Size(184, 33);
            this.btnDeleteQuiz.TabIndex = 4;
            this.btnDeleteQuiz.Text = "Delete Selected Quiz";
            this.btnDeleteQuiz.UseVisualStyleBackColor = false;
            this.btnDeleteQuiz.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(426, 316);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 33);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpQuizDate
            // 
            this.dtpQuizDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpQuizDate.Location = new System.Drawing.Point(98, 210);
            this.dtpQuizDate.Name = "dtpQuizDate";
            this.dtpQuizDate.Size = new System.Drawing.Size(200, 27);
            this.dtpQuizDate.TabIndex = 6;
            // 
            // lblQuizDate
            // 
            this.lblQuizDate.AutoSize = true;
            this.lblQuizDate.BackColor = System.Drawing.Color.Transparent;
            this.lblQuizDate.Location = new System.Drawing.Point(334, 215);
            this.lblQuizDate.Name = "lblQuizDate";
            this.lblQuizDate.Size = new System.Drawing.Size(75, 20);
            this.lblQuizDate.TabIndex = 7;
            this.lblQuizDate.Text = "Quiz Date";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(98, 259);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(200, 27);
            this.txtDuration.TabIndex = 8;
            // 
            // lblQuizDuration
            // 
            this.lblQuizDuration.AutoSize = true;
            this.lblQuizDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblQuizDuration.Location = new System.Drawing.Point(334, 262);
            this.lblQuizDuration.Name = "lblQuizDuration";
            this.lblQuizDuration.Size = new System.Drawing.Size(102, 20);
            this.lblQuizDuration.TabIndex = 9;
            this.lblQuizDuration.Text = "Duration(min)";
            // 
            // frmManageQuizzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblQuizDuration);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblQuizDate);
            this.Controls.Add(this.dtpQuizDate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteQuiz);
            this.Controls.Add(this.btnAddQuiz);
            this.Controls.Add(this.txtQuizName);
            this.Controls.Add(this.lstQuizzes);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmManageQuizzes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Quiz System - Manage Quizzes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstQuizzes;
        private System.Windows.Forms.TextBox txtQuizName;
        private System.Windows.Forms.Button btnAddQuiz;
        private System.Windows.Forms.Button btnDeleteQuiz;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DateTimePicker dtpQuizDate;
        private System.Windows.Forms.Label lblQuizDate;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblQuizDuration;
    }
}