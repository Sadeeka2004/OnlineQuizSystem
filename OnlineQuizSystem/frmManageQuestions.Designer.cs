namespace OnlineQuizSystem
{
    partial class frmManageQuestions
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
            this.cmbQuiz = new System.Windows.Forms.ComboBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtOption1 = new System.Windows.Forms.TextBox();
            this.txtOption2 = new System.Windows.Forms.TextBox();
            this.txtOption3 = new System.Windows.Forms.TextBox();
            this.txtOption4 = new System.Windows.Forms.TextBox();
            this.cmbCorrect = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstQuestions = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(210, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Questions";
            // 
            // cmbQuiz
            // 
            this.cmbQuiz.FormattingEnabled = true;
            this.cmbQuiz.Location = new System.Drawing.Point(29, 44);
            this.cmbQuiz.Name = "cmbQuiz";
            this.cmbQuiz.Size = new System.Drawing.Size(530, 28);
            this.cmbQuiz.TabIndex = 1;
            // 
            // txtQuestion
            // 
            this.txtQuestion.AcceptsReturn = true;
            this.txtQuestion.Location = new System.Drawing.Point(29, 78);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestion.Size = new System.Drawing.Size(530, 27);
            this.txtQuestion.TabIndex = 2;
            // 
            // txtOption1
            // 
            this.txtOption1.AcceptsReturn = true;
            this.txtOption1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOption1.Location = new System.Drawing.Point(29, 111);
            this.txtOption1.Multiline = true;
            this.txtOption1.Name = "txtOption1";
            this.txtOption1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOption1.Size = new System.Drawing.Size(120, 27);
            this.txtOption1.TabIndex = 3;
            // 
            // txtOption2
            // 
            this.txtOption2.AcceptsReturn = true;
            this.txtOption2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOption2.Location = new System.Drawing.Point(155, 111);
            this.txtOption2.Multiline = true;
            this.txtOption2.Name = "txtOption2";
            this.txtOption2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOption2.Size = new System.Drawing.Size(130, 27);
            this.txtOption2.TabIndex = 4;
            // 
            // txtOption3
            // 
            this.txtOption3.AcceptsReturn = true;
            this.txtOption3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOption3.Location = new System.Drawing.Point(291, 111);
            this.txtOption3.Multiline = true;
            this.txtOption3.Name = "txtOption3";
            this.txtOption3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOption3.Size = new System.Drawing.Size(132, 27);
            this.txtOption3.TabIndex = 5;
            // 
            // txtOption4
            // 
            this.txtOption4.AcceptsReturn = true;
            this.txtOption4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOption4.Location = new System.Drawing.Point(429, 111);
            this.txtOption4.Multiline = true;
            this.txtOption4.Name = "txtOption4";
            this.txtOption4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOption4.Size = new System.Drawing.Size(130, 27);
            this.txtOption4.TabIndex = 6;
            // 
            // cmbCorrect
            // 
            this.cmbCorrect.FormattingEnabled = true;
            this.cmbCorrect.Location = new System.Drawing.Point(214, 153);
            this.cmbCorrect.Name = "cmbCorrect";
            this.cmbCorrect.Size = new System.Drawing.Size(121, 28);
            this.cmbCorrect.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(173, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(197, 34);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add Question";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstQuestions
            // 
            this.lstQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstQuestions.FormattingEnabled = true;
            this.lstQuestions.HorizontalScrollbar = true;
            this.lstQuestions.IntegralHeight = false;
            this.lstQuestions.ItemHeight = 20;
            this.lstQuestions.Location = new System.Drawing.Point(29, 227);
            this.lstQuestions.Name = "lstQuestions";
            this.lstQuestions.ScrollAlwaysVisible = true;
            this.lstQuestions.Size = new System.Drawing.Size(530, 84);
            this.lstQuestions.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkCyan;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(134, 317);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 35);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete Question ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(330, 317);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 35);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmManageQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstQuestions);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbCorrect);
            this.Controls.Add(this.txtOption4);
            this.Controls.Add(this.txtOption3);
            this.Controls.Add(this.txtOption2);
            this.Controls.Add(this.txtOption1);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.cmbQuiz);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmManageQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Online Quiz System - Manage Questions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbQuiz;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtOption1;
        private System.Windows.Forms.TextBox txtOption2;
        private System.Windows.Forms.TextBox txtOption3;
        private System.Windows.Forms.TextBox txtOption4;
        private System.Windows.Forms.ComboBox cmbCorrect;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstQuestions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
    }
}