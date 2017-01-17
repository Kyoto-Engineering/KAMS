namespace AccountsManagementSystem.UI
{
    partial class SubLedgerEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubLedgerEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSubLedgerName = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.txtSVoucherNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSEntrydate = new System.Windows.Forms.DateTimePicker();
            this.txtFundRequisitionNo = new System.Windows.Forms.TextBox();
            this.txtSCredit = new System.Windows.Forms.TextBox();
            this.txtSDebit = new System.Windows.Forms.TextBox();
            this.txtSParticulars = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSubLedgerName);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.txtSVoucherNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtSEntrydate);
            this.groupBox1.Controls.Add(this.txtFundRequisitionNo);
            this.groupBox1.Controls.Add(this.txtSCredit);
            this.groupBox1.Controls.Add(this.txtSDebit);
            this.groupBox1.Controls.Add(this.txtSParticulars);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(39, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 411);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbSubLedgerName
            // 
            this.cmbSubLedgerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubLedgerName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubLedgerName.FormattingEnabled = true;
            this.cmbSubLedgerName.Location = new System.Drawing.Point(232, 36);
            this.cmbSubLedgerName.Name = "cmbSubLedgerName";
            this.cmbSubLedgerName.Size = new System.Drawing.Size(268, 30);
            this.cmbSubLedgerName.TabIndex = 0;
            this.cmbSubLedgerName.SelectedIndexChanged += new System.EventHandler(this.cmbSubLedgerName_SelectedIndexChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Olive;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Blue;
            this.saveButton.Location = new System.Drawing.Point(382, 325);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(118, 61);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // txtSVoucherNo
            // 
            this.txtSVoucherNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSVoucherNo.Location = new System.Drawing.Point(232, 162);
            this.txtSVoucherNo.Name = "txtSVoucherNo";
            this.txtSVoucherNo.Size = new System.Drawing.Size(268, 29);
            this.txtSVoucherNo.TabIndex = 3;
            this.txtSVoucherNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSVoucherNo_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(86, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 22);
            this.label8.TabIndex = 27;
            this.label8.Text = "Voucher No";
            // 
            // txtSEntrydate
            // 
            this.txtSEntrydate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSEntrydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtSEntrydate.Location = new System.Drawing.Point(232, 77);
            this.txtSEntrydate.Name = "txtSEntrydate";
            this.txtSEntrydate.Size = new System.Drawing.Size(268, 32);
            this.txtSEntrydate.TabIndex = 1;
            this.txtSEntrydate.ValueChanged += new System.EventHandler(this.txtSEntrydate_ValueChanged);
            // 
            // txtFundRequisitionNo
            // 
            this.txtFundRequisitionNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFundRequisitionNo.Location = new System.Drawing.Point(232, 121);
            this.txtFundRequisitionNo.Name = "txtFundRequisitionNo";
            this.txtFundRequisitionNo.Size = new System.Drawing.Size(268, 29);
            this.txtFundRequisitionNo.TabIndex = 2;
            this.txtFundRequisitionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFundRequisitionNo_KeyDown);
            // 
            // txtSCredit
            // 
            this.txtSCredit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSCredit.Location = new System.Drawing.Point(232, 280);
            this.txtSCredit.Name = "txtSCredit";
            this.txtSCredit.Size = new System.Drawing.Size(268, 29);
            this.txtSCredit.TabIndex = 6;
            this.txtSCredit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSCredit_KeyDown);
            this.txtSCredit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSExpence_KeyPress);
            // 
            // txtSDebit
            // 
            this.txtSDebit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDebit.Location = new System.Drawing.Point(232, 240);
            this.txtSDebit.Name = "txtSDebit";
            this.txtSDebit.Size = new System.Drawing.Size(268, 29);
            this.txtSDebit.TabIndex = 5;
            this.txtSDebit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDebit_KeyDown);
            this.txtSDebit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSReceive_KeyPress);
            // 
            // txtSParticulars
            // 
            this.txtSParticulars.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSParticulars.Location = new System.Drawing.Point(232, 204);
            this.txtSParticulars.Name = "txtSParticulars";
            this.txtSParticulars.Size = new System.Drawing.Size(268, 29);
            this.txtSParticulars.TabIndex = 4;
            this.txtSParticulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSParticulars_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fund Requisition No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(119, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Credit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Debit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Particulars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Entry Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sub Ledger Name";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.closeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Blue;
            this.closeButton.Location = new System.Drawing.Point(630, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(60, 36);
            this.closeButton.TabIndex = 31;
            this.closeButton.Text = "Close";
            this.closeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(20, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(461, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "Create New Entry For SubLedger Accounts";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(569, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 36);
            this.button3.TabIndex = 33;
            this.button3.Text = "Min";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SubLedgerEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(692, 505);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubLedgerEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubLedgerEntry";
            this.Load += new System.EventHandler(this.SubLedgerEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSubLedgerName;
        private System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox txtSVoucherNo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DateTimePicker txtSEntrydate;
        public System.Windows.Forms.TextBox txtFundRequisitionNo;
        public System.Windows.Forms.TextBox txtSCredit;
        public System.Windows.Forms.TextBox txtSDebit;
        public System.Windows.Forms.TextBox txtSParticulars;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
    }
}