namespace OnlineQuizSystem
{
    partial class frmReports
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
            this.cmbSelectQuiz = new System.Windows.Forms.ComboBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lvReports = new System.Windows.Forms.ListView();
            this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(217, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quiz Reports";
            // 
            // cmbSelectQuiz
            // 
            this.cmbSelectQuiz.FormattingEnabled = true;
            this.cmbSelectQuiz.Location = new System.Drawing.Point(179, 68);
            this.cmbSelectQuiz.Name = "cmbSelectQuiz";
            this.cmbSelectQuiz.Size = new System.Drawing.Size(175, 28);
            this.cmbSelectQuiz.TabIndex = 1;
            this.cmbSelectQuiz.SelectedIndexChanged += new System.EventHandler(this.cmbSelectQuiz_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(332, 320);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(119, 29);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lvReports
            // 
            this.lvReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.lvReports.FullRowSelect = true;
            this.lvReports.GridLines = true;
            this.lvReports.HideSelection = false;
            this.lvReports.Location = new System.Drawing.Point(99, 112);
            this.lvReports.MultiSelect = false;
            this.lvReports.Name = "lvReports";
            this.lvReports.Size = new System.Drawing.Size(374, 186);
            this.lvReports.TabIndex = 4;
            this.lvReports.UseCompatibleStateImageBehavior = false;
            this.lvReports.View = System.Windows.Forms.View.Details;
           
            // 
            // Column1
            // 
            this.Column1.Text = "Username";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.Text = "Score";
            this.Column2.Width = 100;
            // 
            // Column4
            // 
            this.Column4.Text = "Percentage";
            // 
            // Column5
            // 
            this.Column5.Text = "date_time";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkCyan;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(162, 320);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(135, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lvReports);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.cmbSelectQuiz);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Students Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbSelectQuiz;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ListView lvReports;
        private System.Windows.Forms.ColumnHeader Column1;
        private System.Windows.Forms.ColumnHeader Column2;
        private System.Windows.Forms.ColumnHeader Column4;
        private System.Windows.Forms.ColumnHeader Column5;
        private System.Windows.Forms.Button btnExport;
    }
}