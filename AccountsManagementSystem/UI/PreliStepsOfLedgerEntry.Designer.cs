namespace AccountsManagementSystem.UI
{
    partial class PreliStepsOfLedgerEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreliStepsOfLedgerEntry));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEntryType = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.labelBatch = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.noOfDebitEntryLabel = new System.Windows.Forms.Label();
            this.NoOfCreditEntityLabel = new System.Windows.Forms.Label();
            this.txtNumOfDebitEntry = new System.Windows.Forms.TextBox();
            this.txtNumOfCreditEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Types Of Entry or Posting";
            // 
            // cmbEntryType
            // 
            this.cmbEntryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntryType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEntryType.FormattingEnabled = true;
            this.cmbEntryType.Items.AddRange(new object[] {
            "Individual Posting",
            "Batch Posting"});
            this.cmbEntryType.Location = new System.Drawing.Point(282, 39);
            this.cmbEntryType.Name = "cmbEntryType";
            this.cmbEntryType.Size = new System.Drawing.Size(251, 30);
            this.cmbEntryType.TabIndex = 0;
            this.cmbEntryType.SelectedIndexChanged += new System.EventHandler(this.cmbEntryType_SelectedIndexChanged);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.submitButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.Blue;
            this.submitButton.Location = new System.Drawing.Point(422, 268);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(111, 61);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Go";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatch.Location = new System.Drawing.Point(142, 96);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(112, 22);
            this.labelBatch.TabIndex = 3;
            this.labelBatch.Text = "Select Batch";
            this.labelBatch.Visible = false;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Items.AddRange(new object[] {
            "One Debit Many Credit",
            "One Credit Many Debit",
            "Multiple Debit Multiple Credit"});
            this.cmbBatch.Location = new System.Drawing.Point(282, 94);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(251, 30);
            this.cmbBatch.TabIndex = 1;
            this.cmbBatch.Visible = false;
            this.cmbBatch.SelectedIndexChanged += new System.EventHandler(this.cmbBatch_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(282, 270);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(108, 56);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // noOfDebitEntryLabel
            // 
            this.noOfDebitEntryLabel.AutoSize = true;
            this.noOfDebitEntryLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfDebitEntryLabel.Location = new System.Drawing.Point(49, 163);
            this.noOfDebitEntryLabel.Name = "noOfDebitEntryLabel";
            this.noOfDebitEntryLabel.Size = new System.Drawing.Size(207, 22);
            this.noOfDebitEntryLabel.TabIndex = 6;
            this.noOfDebitEntryLabel.Text = "Number  Of Debit Entry";
            this.noOfDebitEntryLabel.Visible = false;
            // 
            // NoOfCreditEntityLabel
            // 
            this.NoOfCreditEntityLabel.AutoSize = true;
            this.NoOfCreditEntityLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoOfCreditEntityLabel.Location = new System.Drawing.Point(46, 209);
            this.NoOfCreditEntityLabel.Name = "NoOfCreditEntityLabel";
            this.NoOfCreditEntityLabel.Size = new System.Drawing.Size(210, 22);
            this.NoOfCreditEntityLabel.TabIndex = 7;
            this.NoOfCreditEntityLabel.Text = "Number Of Credit Entry";
            this.NoOfCreditEntityLabel.Visible = false;
            // 
            // txtNumOfDebitEntry
            // 
            this.txtNumOfDebitEntry.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOfDebitEntry.Location = new System.Drawing.Point(282, 161);
            this.txtNumOfDebitEntry.Name = "txtNumOfDebitEntry";
            this.txtNumOfDebitEntry.Size = new System.Drawing.Size(251, 29);
            this.txtNumOfDebitEntry.TabIndex = 2;
            this.txtNumOfDebitEntry.Visible = false;
            this.txtNumOfDebitEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumOfDebitEntry_KeyDown);
            this.txtNumOfDebitEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOfDebitEntry_KeyPress);
            // 
            // txtNumOfCreditEntry
            // 
            this.txtNumOfCreditEntry.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOfCreditEntry.Location = new System.Drawing.Point(282, 209);
            this.txtNumOfCreditEntry.Name = "txtNumOfCreditEntry";
            this.txtNumOfCreditEntry.Size = new System.Drawing.Size(251, 29);
            this.txtNumOfCreditEntry.TabIndex = 3;
            this.txtNumOfCreditEntry.Visible = false;
            this.txtNumOfCreditEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOfCreditEntry_KeyPress);
            // 
            // PreliStepsOfLedgerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(721, 391);
            this.Controls.Add(this.txtNumOfCreditEntry);
            this.Controls.Add(this.txtNumOfDebitEntry);
            this.Controls.Add(this.NoOfCreditEntityLabel);
            this.Controls.Add(this.noOfDebitEntryLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.cmbBatch);
            this.Controls.Add(this.labelBatch);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.cmbEntryType);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreliStepsOfLedgerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreliStepsOfLedgerEntry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreliStepsOfLedgerEntry_FormClosed);
            this.Load += new System.EventHandler(this.PreliStepsOfLedgerEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEntryType;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label labelBatch;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label noOfDebitEntryLabel;
        private System.Windows.Forms.Label NoOfCreditEntityLabel;
        private System.Windows.Forms.TextBox txtNumOfDebitEntry;
        private System.Windows.Forms.TextBox txtNumOfCreditEntry;
    }
}