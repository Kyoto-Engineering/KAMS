namespace AccountsManagementSystem.UI
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonVoucherNumber = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.journalButton = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnregistration = new System.Windows.Forms.Button();
            this.ledgerEntryButton = new System.Windows.Forms.Button();
            this.ledgerButton = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(382, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accounts Management System";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.buttonVoucherNumber);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.journalButton);
            this.groupBox1.Controls.Add(this.btnReports);
            this.groupBox1.Controls.Add(this.btnregistration);
            this.groupBox1.Controls.Add(this.ledgerEntryButton);
            this.groupBox1.Controls.Add(this.ledgerButton);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 623);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(15, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 62);
            this.button4.TabIndex = 15;
            this.button4.Text = "Fiscal Year Management";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // buttonVoucherNumber
            // 
            this.buttonVoucherNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonVoucherNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoucherNumber.ForeColor = System.Drawing.Color.Blue;
            this.buttonVoucherNumber.Location = new System.Drawing.Point(14, 245);
            this.buttonVoucherNumber.Name = "buttonVoucherNumber";
            this.buttonVoucherNumber.Size = new System.Drawing.Size(107, 70);
            this.buttonVoucherNumber.TabIndex = 14;
            this.buttonVoucherNumber.Text = "Add VoucherNo";
            this.buttonVoucherNumber.UseVisualStyleBackColor = false;
            this.buttonVoucherNumber.Click += new System.EventHandler(this.buttonVoucherNumber_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(14, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 62);
            this.button2.TabIndex = 10;
            this.button2.Text = "Year Opening Transaction";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // journalButton
            // 
            this.journalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.journalButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.journalButton.ForeColor = System.Drawing.Color.Blue;
            this.journalButton.Location = new System.Drawing.Point(15, 189);
            this.journalButton.Name = "journalButton";
            this.journalButton.Size = new System.Drawing.Size(110, 50);
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
            this.btnReports.Location = new System.Drawing.Point(14, 133);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(110, 50);
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
            this.btnregistration.Location = new System.Drawing.Point(14, 484);
            this.btnregistration.Name = "btnregistration";
            this.btnregistration.Size = new System.Drawing.Size(110, 51);
            this.btnregistration.TabIndex = 6;
            this.btnregistration.Text = "User Management";
            this.btnregistration.UseVisualStyleBackColor = false;
            this.btnregistration.Click += new System.EventHandler(this.btnregistration_Click);
            // 
            // ledgerEntryButton
            // 
            this.ledgerEntryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ledgerEntryButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ledgerEntryButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledgerEntryButton.ForeColor = System.Drawing.Color.Blue;
            this.ledgerEntryButton.Location = new System.Drawing.Point(15, 70);
            this.ledgerEntryButton.Name = "ledgerEntryButton";
            this.ledgerEntryButton.Size = new System.Drawing.Size(113, 57);
            this.ledgerEntryButton.TabIndex = 1;
            this.ledgerEntryButton.Text = "Ledger Entry";
            this.ledgerEntryButton.UseVisualStyleBackColor = false;
            this.ledgerEntryButton.Click += new System.EventHandler(this.ledgerEntryButton_Click);
            // 
            // ledgerButton
            // 
            this.ledgerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ledgerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ledgerButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledgerButton.ForeColor = System.Drawing.Color.Blue;
            this.ledgerButton.Location = new System.Drawing.Point(15, 7);
            this.ledgerButton.Name = "ledgerButton";
            this.ledgerButton.Size = new System.Drawing.Size(113, 59);
            this.ledgerButton.TabIndex = 0;
            this.ledgerButton.Text = "Ledger Creation";
            this.ledgerButton.UseVisualStyleBackColor = false;
            this.ledgerButton.Click += new System.EventHandler(this.ledgerButton_Click);
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(30, 645);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 20);
            this.lblUser.TabIndex = 2;
            this.lblUser.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(985, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(924, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 49);
            this.button3.TabIndex = 8;
            this.button3.Text = "Min";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Blue;
            this.button5.Location = new System.Drawing.Point(14, 541);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 67);
            this.button5.TabIndex = 16;
            this.button5.Text = "Change Password";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackgroundImage = global::AccountsManagementSystem.Properties.Resources.Accounting__System_66;
            this.ClientSize = new System.Drawing.Size(1078, 660);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ledgerEntryButton;
        private System.Windows.Forms.Button ledgerButton;
        public  System.Windows.Forms.TextBox lblUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnregistration;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button journalButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonVoucherNumber;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}