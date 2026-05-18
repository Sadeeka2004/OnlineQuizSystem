namespace OnlineQuizSystem
{
    partial class frmTakeQuiz
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
            this.components = new System.ComponentModel.Container();
            this.lblQuizTitle = new System.Windows.Forms.Label();
            this.rdoOption1 = new System.Windows.Forms.RadioButton();
            this.rdoOption2 = new System.Windows.Forms.RadioButton();
            this.rdoOption3 = new System.Windows.Forms.RadioButton();
            this.rdoOption4 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.quizTimer = new System.Windows.Forms.Timer(this.components);
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pnlQuestion = new System.Windows.Forms.Panel();
            this.pnlQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuizTitle
            // 
            this.lblQuizTitle.AutoSize = true;
            this.lblQuizTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblQuizTitle.Location = new System.Drawing.Point(26, 9);
            this.lblQuizTitle.Name = "lblQuizTitle";
            this.lblQuizTitle.Size = new System.Drawing.Size(83, 20);
            this.lblQuizTitle.TabIndex = 0;
            this.lblQuizTitle.Text = "Quiz Name";
            // 
            // rdoOption1
            // 
            this.rdoOption1.AutoSize = true;
            this.rdoOption1.Location = new System.Drawing.Point(29, 113);
            this.rdoOption1.Name = "rdoOption1";
            this.rdoOption1.Size = new System.Drawing.Size(87, 24);
            this.rdoOption1.TabIndex = 2;
            this.rdoOption1.TabStop = true;
            this.rdoOption1.Text = "Option A";
            this.rdoOption1.UseVisualStyleBackColor = true;
            // 
            // rdoOption2
            // 
            this.rdoOption2.AutoSize = true;
            this.rdoOption2.Location = new System.Drawing.Point(29, 159);
            this.rdoOption2.Name = "rdoOption2";
            this.rdoOption2.Size = new System.Drawing.Size(86, 24);
            this.rdoOption2.TabIndex = 3;
            this.rdoOption2.TabStop = true;
            this.rdoOption2.Text = "Option B";
            this.rdoOption2.UseVisualStyleBackColor = true;
            // 
            // rdoOption3
            // 
            this.rdoOption3.AutoSize = true;
            this.rdoOption3.Location = new System.Drawing.Point(29, 207);
            this.rdoOption3.Name = "rdoOption3";
            this.rdoOption3.Size = new System.Drawing.Size(86, 24);
            this.rdoOption3.TabIndex = 4;
            this.rdoOption3.TabStop = true;
            this.rdoOption3.Text = "Option C";
            this.rdoOption3.UseVisualStyleBackColor = true;
            // 
            // rdoOption4
            // 
            this.rdoOption4.AutoSize = true;
            this.rdoOption4.Location = new System.Drawing.Point(29, 251);
            this.rdoOption4.Name = "rdoOption4";
            this.rdoOption4.Size = new System.Drawing.Size(88, 24);
            this.rdoOption4.TabIndex = 5;
            this.rdoOption4.TabStop = true;
            this.rdoOption4.Text = "Option D";
            this.rdoOption4.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkCyan;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(130, 296);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(128, 33);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next Question";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(308, 296);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(126, 33);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit Quiz";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(446, 332);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(126, 20);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "Question Number";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Location = new System.Drawing.Point(496, 9);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(47, 20);
            this.lblTimer.TabIndex = 9;
            this.lblTimer.Text = "Timer";
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestion.Location = new System.Drawing.Point(14, 12);
            this.lblQuestion.MaximumSize = new System.Drawing.Size(480, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(120, 20);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "Current Question";
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuestion.AutoScroll = true;
            this.pnlQuestion.Controls.Add(this.lblQuestion);
            this.pnlQuestion.Location = new System.Drawing.Point(12, 50);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Size = new System.Drawing.Size(560, 57);
            this.pnlQuestion.TabIndex = 10;
            // 
            // frmTakeQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.pnlQuestion);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.rdoOption4);
            this.Controls.Add(this.rdoOption3);
            this.Controls.Add(this.rdoOption2);
            this.Controls.Add(this.rdoOption1);
            this.Controls.Add(this.lblQuizTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmTakeQuiz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Quiz";
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuizTitle;
        private System.Windows.Forms.RadioButton rdoOption1;
        private System.Windows.Forms.RadioButton rdoOption2;
        private System.Windows.Forms.RadioButton rdoOption3;
        private System.Windows.Forms.RadioButton rdoOption4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer quizTimer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel pnlQuestion;
    }
}