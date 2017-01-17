namespace AccountsManagementSystem.UI
{
    partial class FiscalYearManagementUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createFiscalYearButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonCloseingFiscalYear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCloseingFiscalYear);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.createFiscalYearButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 466);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // createFiscalYearButton
            // 
            this.createFiscalYearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.createFiscalYearButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createFiscalYearButton.ForeColor = System.Drawing.Color.White;
            this.createFiscalYearButton.Location = new System.Drawing.Point(6, 34);
            this.createFiscalYearButton.Name = "createFiscalYearButton";
            this.createFiscalYearButton.Size = new System.Drawing.Size(106, 50);
            this.createFiscalYearButton.TabIndex = 10;
            this.createFiscalYearButton.Text = "Open New Fiscal Year ";
            this.createFiscalYearButton.UseVisualStyleBackColor = false;
            this.createFiscalYearButton.Click += new System.EventHandler(this.createFiscalYearButton_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(6, 205);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 51);
            this.button5.TabIndex = 13;
            this.button5.Text = "Re-Opening  Fiscal Year";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonCloseingFiscalYear
            // 
            this.buttonCloseingFiscalYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonCloseingFiscalYear.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseingFiscalYear.ForeColor = System.Drawing.Color.Blue;
            this.buttonCloseingFiscalYear.Location = new System.Drawing.Point(2, 110);
            this.buttonCloseingFiscalYear.Name = "buttonCloseingFiscalYear";
            this.buttonCloseingFiscalYear.Size = new System.Drawing.Size(110, 54);
            this.buttonCloseingFiscalYear.TabIndex = 14;
            this.buttonCloseingFiscalYear.Text = "Closing  Fiscal Year";
            this.buttonCloseingFiscalYear.UseVisualStyleBackColor = false;
            this.buttonCloseingFiscalYear.Click += new System.EventHandler(this.buttonCloseingFiscalYear_Click);
            // 
            // FiscalYearManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(881, 482);
            this.Controls.Add(this.groupBox1);
            this.Name = "FiscalYearManagementUI";
            this.Text = "FiscalYearManagementUI";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createFiscalYearButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonCloseingFiscalYear;
    }
}