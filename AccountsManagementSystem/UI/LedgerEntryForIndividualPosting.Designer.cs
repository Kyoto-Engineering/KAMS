namespace AccountsManagementSystem.UI
{
    partial class LedgerEntryForIndividualPosting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedgerEntryForIndividualPosting));
            this.label1 = new System.Windows.Forms.Label();
            this.group1 = new System.Windows.Forms.GroupBox();
            this.txtInd1Particulars = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVoucherNoD = new System.Windows.Forms.ComboBox();
            this.txtInd1Entrydate = new System.Windows.Forms.DateTimePicker();
            this.txtInd1TransactionType = new System.Windows.Forms.TextBox();
            this.cmbInd1LedgerName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInd1RequisitionNo = new System.Windows.Forms.TextBox();
            this.txtIndDebitBalance = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInd2Particulars = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbVoucherNoC = new System.Windows.Forms.ComboBox();
            this.txtInd2TransactionType = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIndCrdeitBalance = new System.Windows.Forms.TextBox();
            this.txtInd2FundRequisition = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbInd2LedgerName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.group1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(421, -3);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Individual Posting";
            // 
            // group1
            // 
            this.group1.BackColor = System.Drawing.Color.Green;
            this.group1.Controls.Add(this.txtInd1Particulars);
            this.group1.Controls.Add(this.textBox1);
            this.group1.Controls.Add(this.label7);
            this.group1.Controls.Add(this.cmbVoucherNoD);
            this.group1.Controls.Add(this.txtInd1Entrydate);
            this.group1.Controls.Add(this.txtInd1TransactionType);
            this.group1.Controls.Add(this.cmbInd1LedgerName);
            this.group1.Controls.Add(this.label14);
            this.group1.Controls.Add(this.label9);
            this.group1.Controls.Add(this.label8);
            this.group1.Controls.Add(this.txtInd1RequisitionNo);
            this.group1.Controls.Add(this.txtIndDebitBalance);
            this.group1.Controls.Add(this.label6);
            this.group1.Controls.Add(this.label4);
            this.group1.Controls.Add(this.label3);
            this.group1.Controls.Add(this.label2);
            this.group1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group1.ForeColor = System.Drawing.Color.Yellow;
            this.group1.Location = new System.Drawing.Point(30, 56);
            this.group1.Name = "group1";
            this.group1.Size = new System.Drawing.Size(470, 503);
            this.group1.TabIndex = 0;
            this.group1.TabStop = false;
            this.group1.Text = "Ledger Details";
            // 
            // txtInd1Particulars
            // 
            this.txtInd1Particulars.Location = new System.Drawing.Point(202, 226);
            this.txtInd1Particulars.Name = "txtInd1Particulars";
            this.txtInd1Particulars.Size = new System.Drawing.Size(234, 160);
            this.txtInd1Particulars.TabIndex = 16;
            this.txtInd1Particulars.Text = "";
            this.txtInd1Particulars.Enter += new System.EventHandler(this.txtInd1Particulars_TextChanged);
            this.txtInd1Particulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInd1Particulars_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(202, 441);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 29);
            this.textBox1.TabIndex = 14;
            this.textBox1.Visible = false;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 22);
            this.label7.TabIndex = 15;
            this.label7.Text = "Bill/Invoice No";
            this.label7.Visible = false;
            // 
            // cmbVoucherNoD
            // 
            this.cmbVoucherNoD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVoucherNoD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVoucherNoD.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoucherNoD.FormattingEnabled = true;
            this.cmbVoucherNoD.Location = new System.Drawing.Point(203, 174);
            this.cmbVoucherNoD.Name = "cmbVoucherNoD";
            this.cmbVoucherNoD.Size = new System.Drawing.Size(233, 34);
            this.cmbVoucherNoD.TabIndex = 13;
            this.cmbVoucherNoD.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherNo_SelectedIndexChanged);
            this.cmbVoucherNoD.Enter += new System.EventHandler(this.cmbVoucherNoD_Enter);
            this.cmbVoucherNoD.Leave += new System.EventHandler(this.cmbVoucherNoD_Leave);
            // 
            // txtInd1Entrydate
            // 
            this.txtInd1Entrydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtInd1Entrydate.Location = new System.Drawing.Point(202, 92);
            this.txtInd1Entrydate.Name = "txtInd1Entrydate";
            this.txtInd1Entrydate.Size = new System.Drawing.Size(235, 26);
            this.txtInd1Entrydate.TabIndex = 1;
            this.txtInd1Entrydate.ValueChanged += new System.EventHandler(this.txtInd1Entrydate_ValueChanged);
            // 
            // txtInd1TransactionType
            // 
            this.txtInd1TransactionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtInd1TransactionType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInd1TransactionType.ForeColor = System.Drawing.Color.Blue;
            this.txtInd1TransactionType.Location = new System.Drawing.Point(203, 20);
            this.txtInd1TransactionType.Name = "txtInd1TransactionType";
            this.txtInd1TransactionType.ReadOnly = true;
            this.txtInd1TransactionType.Size = new System.Drawing.Size(234, 29);
            this.txtInd1TransactionType.TabIndex = 0;
            // 
            // cmbInd1LedgerName
            // 
            this.cmbInd1LedgerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInd1LedgerName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInd1LedgerName.FormattingEnabled = true;
            this.cmbInd1LedgerName.Location = new System.Drawing.Point(113, 55);
            this.cmbInd1LedgerName.Name = "cmbInd1LedgerName";
            this.cmbInd1LedgerName.Size = new System.Drawing.Size(324, 30);
            this.cmbInd1LedgerName.TabIndex = 0;
            this.cmbInd1LedgerName.SelectedIndexChanged += new System.EventHandler(this.cmbInd1LedgerName_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Ledger Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(74, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "TransactionType";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Voucher No";
            // 
            // txtInd1RequisitionNo
            // 
            this.txtInd1RequisitionNo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInd1RequisitionNo.Location = new System.Drawing.Point(202, 131);
            this.txtInd1RequisitionNo.Name = "txtInd1RequisitionNo";
            this.txtInd1RequisitionNo.Size = new System.Drawing.Size(234, 29);
            this.txtInd1RequisitionNo.TabIndex = 2;
            this.txtInd1RequisitionNo.Enter += new System.EventHandler(this.txtInd1RequisitionNo_Enter);
            this.txtInd1RequisitionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInd1RequisitionNo_KeyDown);
            this.txtInd1RequisitionNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInd1RequisitionNo_KeyPress);
            // 
            // txtIndDebitBalance
            // 
            this.txtIndDebitBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndDebitBalance.Location = new System.Drawing.Point(202, 400);
            this.txtIndDebitBalance.Name = "txtIndDebitBalance";
            this.txtIndDebitBalance.Size = new System.Drawing.Size(234, 29);
            this.txtIndDebitBalance.TabIndex = 5;
            this.txtIndDebitBalance.Enter += new System.EventHandler(this.txtIndDebitBalance_Enter);
            this.txtIndDebitBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIndDebitBalance_KeyDown);
            this.txtIndDebitBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndDebitBalance_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fund Requisition No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Debit Balance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Particulars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transaction Date";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Controls.Add(this.txtInd2Particulars);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cmbVoucherNoC);
            this.groupBox2.Controls.Add(this.txtInd2TransactionType);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtIndCrdeitBalance);
            this.groupBox2.Controls.Add(this.txtInd2FundRequisition);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbInd2LedgerName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(519, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 502);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contra Ledger Details";
            // 
            // txtInd2Particulars
            // 
            this.txtInd2Particulars.Location = new System.Drawing.Point(200, 217);
            this.txtInd2Particulars.Name = "txtInd2Particulars";
            this.txtInd2Particulars.Size = new System.Drawing.Size(243, 165);
            this.txtInd2Particulars.TabIndex = 74;
            this.txtInd2Particulars.Text = "";
            this.txtInd2Particulars.Enter += new System.EventHandler(this.txtInd2Particulars_TextChanged);
            this.txtInd2Particulars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInd2Particulars_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(198, 433);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 29);
            this.textBox2.TabIndex = 72;
            this.textBox2.Visible = false;
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(58, 440);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 22);
            this.label16.TabIndex = 73;
            this.label16.Text = "Bill/Invoice No";
            this.label16.Visible = false;
            // 
            // cmbVoucherNoC
            // 
            this.cmbVoucherNoC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVoucherNoC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVoucherNoC.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoucherNoC.FormattingEnabled = true;
            this.cmbVoucherNoC.Location = new System.Drawing.Point(200, 173);
            this.cmbVoucherNoC.Name = "cmbVoucherNoC";
            this.cmbVoucherNoC.Size = new System.Drawing.Size(243, 32);
            this.cmbVoucherNoC.TabIndex = 71;
            this.cmbVoucherNoC.SelectedIndexChanged += new System.EventHandler(this.cmbVoucherNoC_SelectedIndexChanged);
            this.cmbVoucherNoC.Enter += new System.EventHandler(this.cmbVoucherNoC_Enter);
            this.cmbVoucherNoC.Leave += new System.EventHandler(this.cmbVoucherNoC_Leave);
            // 
            // txtInd2TransactionType
            // 
            this.txtInd2TransactionType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtInd2TransactionType.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInd2TransactionType.ForeColor = System.Drawing.Color.Blue;
            this.txtInd2TransactionType.Location = new System.Drawing.Point(199, 26);
            this.txtInd2TransactionType.Name = "txtInd2TransactionType";
            this.txtInd2TransactionType.ReadOnly = true;
            this.txtInd2TransactionType.Size = new System.Drawing.Size(244, 29);
            this.txtInd2TransactionType.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(32, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 22);
            this.label15.TabIndex = 70;
            this.label15.Text = "TransactionType";
            // 
            // txtIndCrdeitBalance
            // 
            this.txtIndCrdeitBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndCrdeitBalance.Location = new System.Drawing.Point(198, 388);
            this.txtIndCrdeitBalance.Name = "txtIndCrdeitBalance";
            this.txtIndCrdeitBalance.Size = new System.Drawing.Size(248, 29);
            this.txtIndCrdeitBalance.TabIndex = 4;
            this.txtIndCrdeitBalance.TextChanged += new System.EventHandler(this.txtDebitBalance_TextChanged);
            this.txtIndCrdeitBalance.Enter += new System.EventHandler(this.txtIndCrdeitBalance_Enter);
            this.txtIndCrdeitBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIndCrdeitBalance_KeyDown);
            this.txtIndCrdeitBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndCrdeitBalance_KeyPress);
            // 
            // txtInd2FundRequisition
            // 
            this.txtInd2FundRequisition.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInd2FundRequisition.Location = new System.Drawing.Point(200, 119);
            this.txtInd2FundRequisition.Name = "txtInd2FundRequisition";
            this.txtInd2FundRequisition.Size = new System.Drawing.Size(243, 29);
            this.txtInd2FundRequisition.TabIndex = 1;
            this.txtInd2FundRequisition.Enter += new System.EventHandler(this.txtInd2FundRequisition_Enter);
            this.txtInd2FundRequisition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInd2FundRequisition_KeyDown);
            this.txtInd2FundRequisition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInd2FundRequisition_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(56, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 22);
            this.label13.TabIndex = 65;
            this.label13.Text = "Credit Balance";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(81, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 22);
            this.label12.TabIndex = 64;
            this.label12.Text = "Particulars";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(74, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 22);
            this.label11.TabIndex = 63;
            this.label11.Text = "Voucher No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 22);
            this.label10.TabIndex = 62;
            this.label10.Text = "Fund Requisition No";
            // 
            // cmbInd2LedgerName
            // 
            this.cmbInd2LedgerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInd2LedgerName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInd2LedgerName.FormattingEnabled = true;
            this.cmbInd2LedgerName.Location = new System.Drawing.Point(123, 71);
            this.cmbInd2LedgerName.Name = "cmbInd2LedgerName";
            this.cmbInd2LedgerName.Size = new System.Drawing.Size(320, 30);
            this.cmbInd2LedgerName.TabIndex = 0;
            this.cmbInd2LedgerName.SelectedIndexChanged += new System.EventHandler(this.cmbInd2LedgerName_SelectedIndexChanged);
            this.cmbInd2LedgerName.Enter += new System.EventHandler(this.cmbInd2LedgerName_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 22);
            this.label5.TabIndex = 60;
            this.label5.Text = "Ledger Name";
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(427, 565);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(139, 62);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.closeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Blue;
            this.closeButton.Location = new System.Drawing.Point(969, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(65, 44);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(910, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 46);
            this.button3.TabIndex = 1;
            this.button3.Text = "Min";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // LedgerEntryForIndividualPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1038, 639);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.group1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "LedgerEntryForIndividualPosting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LedgerEntryForIndividualPosting";
            this.Load += new System.EventHandler(this.LedgerEntryForIndividualPosting_Load);
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox group1;
        private System.Windows.Forms.TextBox txtInd1TransactionType;
        private System.Windows.Forms.ComboBox cmbInd1LedgerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtInd1RequisitionNo;
        public System.Windows.Forms.TextBox txtIndDebitBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInd2TransactionType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIndCrdeitBalance;
        private System.Windows.Forms.TextBox txtInd2FundRequisition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbInd2LedgerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DateTimePicker txtInd1Entrydate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cmbVoucherNoD;
        private System.Windows.Forms.ComboBox cmbVoucherNoC;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox txtInd1Particulars;
        private System.Windows.Forms.RichTextBox txtInd2Particulars;
    }
}