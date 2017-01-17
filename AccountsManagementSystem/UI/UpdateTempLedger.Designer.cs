namespace AccountsManagementSystem.UI
{
    partial class UpdateTempLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateTempLedger));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTempULedgerName = new System.Windows.Forms.TextBox();
            this.txtTempULedgerId = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtTUVoucherNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTUEntrydate = new System.Windows.Forms.DateTimePicker();
            this.txtTUFundRequisitionNo = new System.Windows.Forms.TextBox();
            this.txtTUExpence = new System.Windows.Forms.TextBox();
            this.txtTUReceive = new System.Windows.Forms.TextBox();
            this.txtTUParticulars = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelhk = new System.Windows.Forms.Label();
            this.labelh = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTempULedgerName);
            this.groupBox1.Controls.Add(this.txtTempULedgerId);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.txtTUVoucherNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtTUEntrydate);
            this.groupBox1.Controls.Add(this.txtTUFundRequisitionNo);
            this.groupBox1.Controls.Add(this.txtTUExpence);
            this.groupBox1.Controls.Add(this.txtTUReceive);
            this.groupBox1.Controls.Add(this.txtTUParticulars);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(54, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 482);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 33;
            this.label1.Text = "TempLedgerId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 22);
            this.label7.TabIndex = 32;
            this.label7.Text = "TempLedger Name";
            // 
            // txtTempULedgerName
            // 
            this.txtTempULedgerName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempULedgerName.Location = new System.Drawing.Point(232, 86);
            this.txtTempULedgerName.Name = "txtTempULedgerName";
            this.txtTempULedgerName.Size = new System.Drawing.Size(268, 32);
            this.txtTempULedgerName.TabIndex = 1;
            this.txtTempULedgerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempULedgerName_KeyDown);
            // 
            // txtTempULedgerId
            // 
            this.txtTempULedgerId.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempULedgerId.Location = new System.Drawing.Point(232, 38);
            this.txtTempULedgerId.Name = "txtTempULedgerId";
            this.txtTempULedgerId.Size = new System.Drawing.Size(268, 29);
            this.txtTempULedgerId.TabIndex = 0;
            this.txtTempULedgerId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTempULedgerId_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Olive;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Blue;
            this.saveButton.Location = new System.Drawing.Point(382, 394);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(118, 61);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Update";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtTUVoucherNo
            // 
            this.txtTUVoucherNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUVoucherNo.Location = new System.Drawing.Point(232, 215);
            this.txtTUVoucherNo.Name = "txtTUVoucherNo";
            this.txtTUVoucherNo.Size = new System.Drawing.Size(268, 29);
            this.txtTUVoucherNo.TabIndex = 4;
            this.txtTUVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUVoucherNo_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(86, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 22);
            this.label8.TabIndex = 27;
            this.label8.Text = "Voucher No";
            // 
            // txtTUEntrydate
            // 
            this.txtTUEntrydate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUEntrydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTUEntrydate.Location = new System.Drawing.Point(232, 130);
            this.txtTUEntrydate.Name = "txtTUEntrydate";
            this.txtTUEntrydate.Size = new System.Drawing.Size(268, 32);
            this.txtTUEntrydate.TabIndex = 2;
            this.txtTUEntrydate.ValueChanged += new System.EventHandler(this.txtTUEntrydate_ValueChanged);
            this.txtTUEntrydate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUEntrydate_KeyDown);
            // 
            // txtTUFundRequisitionNo
            // 
            this.txtTUFundRequisitionNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUFundRequisitionNo.Location = new System.Drawing.Point(232, 174);
            this.txtTUFundRequisitionNo.Name = "txtTUFundRequisitionNo";
            this.txtTUFundRequisitionNo.Size = new System.Drawing.Size(268, 29);
            this.txtTUFundRequisitionNo.TabIndex = 3;
            this.txtTUFundRequisitionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUFundRequisitionNo_KeyDown);
            // 
            // txtTUExpence
            // 
            this.txtTUExpence.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUExpence.Location = new System.Drawing.Point(232, 333);
            this.txtTUExpence.Name = "txtTUExpence";
            this.txtTUExpence.Size = new System.Drawing.Size(268, 29);
            this.txtTUExpence.TabIndex = 7;
            this.txtTUExpence.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUExpence_KeyDown);
            this.txtTUExpence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTUExpence_KeyPress);
            // 
            // txtTUReceive
            // 
            this.txtTUReceive.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUReceive.Location = new System.Drawing.Point(232, 293);
            this.txtTUReceive.Name = "txtTUReceive";
            this.txtTUReceive.Size = new System.Drawing.Size(268, 29);
            this.txtTUReceive.TabIndex = 6;
            this.txtTUReceive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUReceive_KeyDown);
            this.txtTUReceive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTUReceive_KeyPress);
            // 
            // txtTUParticulars
            // 
            this.txtTUParticulars.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTUParticulars.Location = new System.Drawing.Point(232, 257);
            this.txtTUParticulars.Name = "txtTUParticulars";
            this.txtTUParticulars.Size = new System.Drawing.Size(268, 29);
            this.txtTUParticulars.TabIndex = 5;
            this.txtTUParticulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTUParticulars_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fund Requisition No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(111, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Credit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Debit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Particulars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Entry Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(244, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 22);
            this.label9.TabIndex = 35;
            this.label9.Text = "Update Temp Ledger";
            // 
            // labelhk
            // 
            this.labelhk.AutoSize = true;
            this.labelhk.Location = new System.Drawing.Point(7, 526);
            this.labelhk.Name = "labelhk";
            this.labelhk.Size = new System.Drawing.Size(41, 13);
            this.labelhk.TabIndex = 36;
            this.labelhk.Text = "label10";
            this.labelhk.Visible = false;
            // 
            // labelh
            // 
            this.labelh.AutoSize = true;
            this.labelh.Location = new System.Drawing.Point(7, 539);
            this.labelh.Name = "labelh";
            this.labelh.Size = new System.Drawing.Size(41, 13);
            this.labelh.TabIndex = 37;
            this.labelh.Text = "label11";
            this.labelh.Visible = false;
            // 
            // UpdateTempLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(662, 571);
            this.ControlBox = false;
            this.Controls.Add(this.labelh);
            this.Controls.Add(this.labelhk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateTempLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateTempLedger";
            this.Load += new System.EventHandler(this.UpdateTempLedger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        public  System.Windows.Forms.TextBox txtTempULedgerName;
        public  System.Windows.Forms.TextBox txtTempULedgerId;
        private System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox txtTUVoucherNo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker txtTUEntrydate;
        public System.Windows.Forms.TextBox txtTUFundRequisitionNo;
        public System.Windows.Forms.TextBox txtTUExpence;
        public System.Windows.Forms.TextBox txtTUReceive;
        public System.Windows.Forms.TextBox txtTUParticulars;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        public  System.Windows.Forms.Label labelhk;
        public  System.Windows.Forms.Label labelh;
        private System.Windows.Forms.Label label1;
    }
}