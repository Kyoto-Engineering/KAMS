namespace AccountsManagementSystem.UI
{
    partial class VoucherNoLoader
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
            this.txtAccountNo2 = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.chequeEndNoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chequeStartNoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAccountNo2
            // 
            this.txtAccountNo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtAccountNo2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountNo2.Location = new System.Drawing.Point(18, 235);
            this.txtAccountNo2.Name = "txtAccountNo2";
            this.txtAccountNo2.Size = new System.Drawing.Size(28, 13);
            this.txtAccountNo2.TabIndex = 24;
            // 
            // newButton
            // 
            this.newButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.newButton.Location = new System.Drawing.Point(2, 235);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(10, 38);
            this.newButton.TabIndex = 22;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.White;
            this.loadButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.Green;
            this.loadButton.Location = new System.Drawing.Point(280, 161);
            this.loadButton.Margin = new System.Windows.Forms.Padding(5);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(195, 62);
            this.loadButton.TabIndex = 20;
            this.loadButton.Text = "Load VoucherNo";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // chequeEndNoTextBox
            // 
            this.chequeEndNoTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chequeEndNoTextBox.Location = new System.Drawing.Point(242, 97);
            this.chequeEndNoTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.chequeEndNoTextBox.Name = "chequeEndNoTextBox";
            this.chequeEndNoTextBox.Size = new System.Drawing.Size(233, 29);
            this.chequeEndNoTextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(129, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "End Point";
            // 
            // chequeStartNoTextBox
            // 
            this.chequeStartNoTextBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chequeStartNoTextBox.Location = new System.Drawing.Point(242, 49);
            this.chequeStartNoTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.chequeStartNoTextBox.Name = "chequeStartNoTextBox";
            this.chequeStartNoTextBox.Size = new System.Drawing.Size(233, 29);
            this.chequeStartNoTextBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Voucher No Start Point";
            // 
            // VoucherNoLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 283);
            this.Controls.Add(this.txtAccountNo2);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.chequeEndNoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chequeStartNoTextBox);
            this.Controls.Add(this.label2);
            this.Name = "VoucherNoLoader";
            this.Text = "VoucherNoLoader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccountNo2;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox chequeEndNoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chequeStartNoTextBox;
        private System.Windows.Forms.Label label2;
    }
}