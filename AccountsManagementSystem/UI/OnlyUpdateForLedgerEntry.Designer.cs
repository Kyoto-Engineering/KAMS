namespace AccountsManagementSystem.UI
{
    partial class OnlyUpdateForLedgerEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEntryId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOUBalance = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Entry Id";
            // 
            // cmbEntryId
            // 
            this.cmbEntryId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntryId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEntryId.FormattingEnabled = true;
            this.cmbEntryId.Location = new System.Drawing.Point(202, 34);
            this.cmbEntryId.Name = "cmbEntryId";
            this.cmbEntryId.Size = new System.Drawing.Size(212, 27);
            this.cmbEntryId.TabIndex = 0;
            this.cmbEntryId.SelectedIndexChanged += new System.EventHandler(this.cmbEntryId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balance";
            // 
            // txtOUBalance
            // 
            this.txtOUBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOUBalance.Location = new System.Drawing.Point(202, 103);
            this.txtOUBalance.Name = "txtOUBalance";
            this.txtOUBalance.Size = new System.Drawing.Size(212, 29);
            this.txtOUBalance.TabIndex = 1;
            this.txtOUBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOUBalance_KeyDown);
            this.txtOUBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOUBalance_KeyPress);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Red;
            this.updateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.Blue;
            this.updateButton.Location = new System.Drawing.Point(251, 161);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(126, 54);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // OnlyUpdateForLedgerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(560, 325);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.txtOUBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEntryId);
            this.Controls.Add(this.label1);
            this.Name = "OnlyUpdateForLedgerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlyUpdateForLedgerEntry";
            this.Load += new System.EventHandler(this.OnlyUpdateForLedgerEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEntryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOUBalance;
        private System.Windows.Forms.Button updateButton;
    }
}