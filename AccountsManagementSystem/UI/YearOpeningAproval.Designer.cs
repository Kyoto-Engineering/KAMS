namespace AccountsManagementSystem.UI
{
    partial class YearOpeningAproval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearOpeningAproval));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonApproved = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalDebitBalance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalCreditBalance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year Opening Trial Balance";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.Blue;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(21, 150);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(640, 312);
            this.listView1.TabIndex = 82;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Ledger Name";
            this.columnHeader11.Width = 276;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Ledger Id";
            this.columnHeader12.Width = 114;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Amount";
            this.columnHeader16.Width = 83;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "LID";
            this.columnHeader17.Width = 65;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "AGRelId";
            this.columnHeader18.Width = 92;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader6,
            this.columnHeader9});
            this.listView2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.ForeColor = System.Drawing.Color.Blue;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(679, 148);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(648, 312);
            this.listView2.TabIndex = 83;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ledger Name";
            this.columnHeader3.Width = 321;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ledger Id";
            this.columnHeader5.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "LID";
            this.columnHeader6.Width = 47;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "AGRelId";
            this.columnHeader9.Width = 87;
            // 
            // buttonApproved
            // 
            this.buttonApproved.BackColor = System.Drawing.Color.Yellow;
            this.buttonApproved.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApproved.ForeColor = System.Drawing.Color.Blue;
            this.buttonApproved.Location = new System.Drawing.Point(570, 482);
            this.buttonApproved.Name = "buttonApproved";
            this.buttonApproved.Size = new System.Drawing.Size(168, 71);
            this.buttonApproved.TabIndex = 84;
            this.buttonApproved.Text = "Approved";
            this.buttonApproved.UseVisualStyleBackColor = false;
            this.buttonApproved.Click += new System.EventHandler(this.buttonApproved_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Blue;
            this.buttonClose.Location = new System.Drawing.Point(1276, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 56);
            this.buttonClose.TabIndex = 85;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 94;
            this.label2.Text = "Total Debit";
            // 
            // txtTotalDebitBalance
            // 
            this.txtTotalDebitBalance.BackColor = System.Drawing.Color.LightGray;
            this.txtTotalDebitBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDebitBalance.ForeColor = System.Drawing.Color.Red;
            this.txtTotalDebitBalance.Location = new System.Drawing.Point(475, 115);
            this.txtTotalDebitBalance.Name = "txtTotalDebitBalance";
            this.txtTotalDebitBalance.ReadOnly = true;
            this.txtTotalDebitBalance.Size = new System.Drawing.Size(186, 29);
            this.txtTotalDebitBalance.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1011, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 96;
            this.label3.Text = "Total Credit";
            // 
            // txtTotalCreditBalance
            // 
            this.txtTotalCreditBalance.BackColor = System.Drawing.Color.LightGray;
            this.txtTotalCreditBalance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCreditBalance.ForeColor = System.Drawing.Color.Red;
            this.txtTotalCreditBalance.Location = new System.Drawing.Point(1141, 111);
            this.txtTotalCreditBalance.Name = "txtTotalCreditBalance";
            this.txtTotalCreditBalance.ReadOnly = true;
            this.txtTotalCreditBalance.Size = new System.Drawing.Size(186, 29);
            this.txtTotalCreditBalance.TabIndex = 95;
            // 
            // YearOpeningAproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1346, 565);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalCreditBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalDebitBalance);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApproved);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YearOpeningAproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YearOpeningAproval";
            this.Load += new System.EventHandler(this.YearOpeningAproval_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button buttonApproved;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalDebitBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalCreditBalance;
    }
}