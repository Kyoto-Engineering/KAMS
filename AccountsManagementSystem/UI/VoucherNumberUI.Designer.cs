namespace AccountsManagementSystem.UI
{
    partial class VoucherNumberUI
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
            this.submitButton = new System.Windows.Forms.Button();
            this.voucherNoEndPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.voucherNoStartPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.submitButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(285, 217);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(125, 63);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // voucherNoEndPoint
            // 
            this.voucherNoEndPoint.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucherNoEndPoint.Location = new System.Drawing.Point(231, 153);
            this.voucherNoEndPoint.Margin = new System.Windows.Forms.Padding(5);
            this.voucherNoEndPoint.MaxLength = 50;
            this.voucherNoEndPoint.Name = "voucherNoEndPoint";
            this.voucherNoEndPoint.Size = new System.Drawing.Size(233, 32);
            this.voucherNoEndPoint.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(118, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "End Point";
            // 
            // voucherNoStartPoint
            // 
            this.voucherNoStartPoint.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voucherNoStartPoint.Location = new System.Drawing.Point(231, 105);
            this.voucherNoStartPoint.Margin = new System.Windows.Forms.Padding(5);
            this.voucherNoStartPoint.MaxLength = 50;
            this.voucherNoStartPoint.Name = "voucherNoStartPoint";
            this.voucherNoStartPoint.Size = new System.Drawing.Size(233, 32);
            this.voucherNoStartPoint.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Voucher No Start Point";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Book Number";
            // 
            // txtBookNumber
            // 
            this.txtBookNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNumber.Location = new System.Drawing.Point(231, 49);
            this.txtBookNumber.MaxLength = 50;
            this.txtBookNumber.Name = "txtBookNumber";
            this.txtBookNumber.Size = new System.Drawing.Size(233, 32);
            this.txtBookNumber.TabIndex = 25;
            // 
            // VoucherNumberUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(647, 353);
            this.Controls.Add(this.txtBookNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voucherNoEndPoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.voucherNoStartPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.submitButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoucherNumberUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoucherNumberUI";
            this.Load += new System.EventHandler(this.VoucherNumberUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox voucherNoEndPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox voucherNoStartPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookNumber;
    }
}