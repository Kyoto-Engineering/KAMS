namespace AccountsManagementSystem.UI
{
    partial class PreYearOpeningTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreYearOpeningTransaction));
            this.btnNewYearOpeningTransaction = new System.Windows.Forms.Button();
            this.btnApproveTrialBalance = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewYearOpeningTransaction
            // 
            this.btnNewYearOpeningTransaction.BackColor = System.Drawing.Color.Purple;
            this.btnNewYearOpeningTransaction.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewYearOpeningTransaction.ForeColor = System.Drawing.Color.White;
            this.btnNewYearOpeningTransaction.Location = new System.Drawing.Point(161, 282);
            this.btnNewYearOpeningTransaction.Name = "btnNewYearOpeningTransaction";
            this.btnNewYearOpeningTransaction.Size = new System.Drawing.Size(125, 82);
            this.btnNewYearOpeningTransaction.TabIndex = 0;
            this.btnNewYearOpeningTransaction.Text = "New  Year  Opening Transaction";
            this.btnNewYearOpeningTransaction.UseVisualStyleBackColor = false;
            this.btnNewYearOpeningTransaction.Click += new System.EventHandler(this.btnNewYearOpeningTransaction_Click);
            // 
            // btnApproveTrialBalance
            // 
            this.btnApproveTrialBalance.BackColor = System.Drawing.Color.Purple;
            this.btnApproveTrialBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveTrialBalance.ForeColor = System.Drawing.Color.White;
            this.btnApproveTrialBalance.Location = new System.Drawing.Point(342, 282);
            this.btnApproveTrialBalance.Name = "btnApproveTrialBalance";
            this.btnApproveTrialBalance.Size = new System.Drawing.Size(125, 82);
            this.btnApproveTrialBalance.TabIndex = 1;
            this.btnApproveTrialBalance.Text = "Approve Trial Balance";
            this.btnApproveTrialBalance.UseVisualStyleBackColor = false;
            this.btnApproveTrialBalance.Click += new System.EventHandler(this.btnApproveTrialBalance_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(529, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PreYearOpeningTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(610, 480);
            this.ControlBox = false;
            this.Controls.Add(this.btnApproveTrialBalance);
            this.Controls.Add(this.btnNewYearOpeningTransaction);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreYearOpeningTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreYearOpeningTransaction";
            this.Load += new System.EventHandler(this.PreYearOpeningTransaction_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewYearOpeningTransaction;
        private System.Windows.Forms.Button btnApproveTrialBalance;
        private System.Windows.Forms.Button button1;
    }
}