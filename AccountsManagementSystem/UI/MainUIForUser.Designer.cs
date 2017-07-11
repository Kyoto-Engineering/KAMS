namespace AccountsManagementSystem.UI
{
    partial class MainUIForUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUIForUser));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.journalButton = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnregistration = new System.Windows.Forms.Button();
            this.ledgerEntryButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(380, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Accounts Management System";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.journalButton);
            this.groupBox1.Controls.Add(this.btnReports);
            this.groupBox1.Controls.Add(this.btnregistration);
            this.groupBox1.Controls.Add(this.ledgerEntryButton);
            this.groupBox1.Location = new System.Drawing.Point(22, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 623);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // journalButton
            // 
            this.journalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.journalButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journalButton.ForeColor = System.Drawing.Color.Blue;
            this.journalButton.Location = new System.Drawing.Point(15, 221);
            this.journalButton.Name = "journalButton";
            this.journalButton.Size = new System.Drawing.Size(110, 73);
            this.journalButton.TabIndex = 8;
            this.journalButton.Text = "Journal";
            this.journalButton.UseVisualStyleBackColor = false;
            this.journalButton.Click += new System.EventHandler(this.journalButton_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReports.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.Blue;
            this.btnReports.Location = new System.Drawing.Point(18, 133);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(110, 67);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnregistration
            // 
            this.btnregistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnregistration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistration.ForeColor = System.Drawing.Color.Blue;
            this.btnregistration.Location = new System.Drawing.Point(15, 321);
            this.btnregistration.Name = "btnregistration";
            this.btnregistration.Size = new System.Drawing.Size(110, 67);
            this.btnregistration.TabIndex = 6;
            this.btnregistration.Text = "Change Password";
            this.btnregistration.UseVisualStyleBackColor = false;
            this.btnregistration.Click += new System.EventHandler(this.btnregistration_Click);
            // 
            // ledgerEntryButton
            // 
            this.ledgerEntryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ledgerEntryButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ledgerEntryButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledgerEntryButton.ForeColor = System.Drawing.Color.Blue;
            this.ledgerEntryButton.Location = new System.Drawing.Point(15, 28);
            this.ledgerEntryButton.Name = "ledgerEntryButton";
            this.ledgerEntryButton.Size = new System.Drawing.Size(113, 80);
            this.ledgerEntryButton.TabIndex = 1;
            this.ledgerEntryButton.Text = "Ledger Entry";
            this.ledgerEntryButton.UseVisualStyleBackColor = false;
            this.ledgerEntryButton.Click += new System.EventHandler(this.ledgerEntryButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.logOutButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.ForeColor = System.Drawing.Color.Blue;
            this.logOutButton.Location = new System.Drawing.Point(971, 7);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(100, 64);
            this.logOutButton.TabIndex = 3;
            this.logOutButton.Text = "LogOut";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.Location = new System.Drawing.Point(197, 623);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(35, 13);
            this.lblUser2.TabIndex = 4;
            this.lblUser2.Text = "label2";
            this.lblUser2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "PNL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainUIForUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AccountsManagementSystem.Properties.Resources.Accounting__System_66;
            this.ClientSize = new System.Drawing.Size(1082, 648);
            this.ControlBox = false;
            this.Controls.Add(this.lblUser2);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUIForUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUIForUser";
            this.Load += new System.EventHandler(this.MainUIForUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button journalButton;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnregistration;
        private System.Windows.Forms.Button ledgerEntryButton;
        private System.Windows.Forms.Button logOutButton;
        public  System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.Button button1;
    }
}