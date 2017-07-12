namespace AccountsManagementSystem.LogInUI
{
    partial class frmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistration));
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.txtEmail_Address = new System.Windows.Forms.TextBox();
            this.txtContact_no = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.registerInlineButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserRegistrationForm = new System.Windows.Forms.GroupBox();
            this.txtUsername = new wmgCMS.WaterMarkTextBox();
            this.UserRegistrationForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(119, 231);
            this.txtDepartment.MaxLength = 50;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(281, 26);
            this.txtDepartment.TabIndex = 5;
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.departmentTextBox_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Department";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(119, 192);
            this.txtDesignation.MaxLength = 50;
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(281, 26);
            this.txtDesignation.TabIndex = 4;
            this.txtDesignation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.designationTextBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Designation";
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "SuperAdmin",
            "Admin",
            "User"});
            this.cmbUserType.Location = new System.Drawing.Point(119, 82);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(281, 27);
            this.cmbUserType.TabIndex = 1;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            // 
            // txtEmail_Address
            // 
            this.txtEmail_Address.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail_Address.Location = new System.Drawing.Point(119, 303);
            this.txtEmail_Address.MaxLength = 50;
            this.txtEmail_Address.Name = "txtEmail_Address";
            this.txtEmail_Address.Size = new System.Drawing.Size(281, 26);
            this.txtEmail_Address.TabIndex = 7;
            this.txtEmail_Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_Address_KeyDown);
            this.txtEmail_Address.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Address_Validating);
            // 
            // txtContact_no
            // 
            this.txtContact_no.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact_no.Location = new System.Drawing.Point(119, 267);
            this.txtContact_no.MaxLength = 11;
            this.txtContact_no.Name = "txtContact_no";
            this.txtContact_no.Size = new System.Drawing.Size(281, 26);
            this.txtContact_no.TabIndex = 6;
            this.txtContact_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContact_no_KeyDown);
            this.txtContact_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_no_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(119, 153);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(281, 26);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(119, 117);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(281, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // registerInlineButton
            // 
            this.registerInlineButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerInlineButton.Location = new System.Drawing.Point(398, 387);
            this.registerInlineButton.Name = "registerInlineButton";
            this.registerInlineButton.Size = new System.Drawing.Size(135, 75);
            this.registerInlineButton.TabIndex = 0;
            this.registerInlineButton.Text = "Register";
            this.registerInlineButton.UseVisualStyleBackColor = true;
            this.registerInlineButton.Click += new System.EventHandler(this.registerInlineButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "ContactNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // UserRegistrationForm
            // 
            this.UserRegistrationForm.Controls.Add(this.txtUsername);
            this.UserRegistrationForm.Controls.Add(this.txtDepartment);
            this.UserRegistrationForm.Controls.Add(this.label8);
            this.UserRegistrationForm.Controls.Add(this.txtDesignation);
            this.UserRegistrationForm.Controls.Add(this.label7);
            this.UserRegistrationForm.Controls.Add(this.cmbUserType);
            this.UserRegistrationForm.Controls.Add(this.txtEmail_Address);
            this.UserRegistrationForm.Controls.Add(this.txtContact_no);
            this.UserRegistrationForm.Controls.Add(this.txtName);
            this.UserRegistrationForm.Controls.Add(this.txtPassword);
            this.UserRegistrationForm.Controls.Add(this.label6);
            this.UserRegistrationForm.Controls.Add(this.label5);
            this.UserRegistrationForm.Controls.Add(this.label4);
            this.UserRegistrationForm.Controls.Add(this.label3);
            this.UserRegistrationForm.Controls.Add(this.label2);
            this.UserRegistrationForm.Controls.Add(this.label1);
            this.UserRegistrationForm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRegistrationForm.Location = new System.Drawing.Point(91, 18);
            this.UserRegistrationForm.Name = "UserRegistrationForm";
            this.UserRegistrationForm.Size = new System.Drawing.Size(442, 355);
            this.UserRegistrationForm.TabIndex = 2;
            this.UserRegistrationForm.TabStop = false;
            this.UserRegistrationForm.Text = "UserRegistrationForm";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(119, 48);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(281, 26);
            this.txtUsername.TabIndex = 16;
            this.txtUsername.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtUsername.WaterMarkText = "Please Type email Id as  user name ";
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // frmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(676, 492);
            this.Controls.Add(this.registerInlineButton);
            this.Controls.Add(this.UserRegistrationForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegistration";
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.UserRegistrationForm.ResumeLayout(false);
            this.UserRegistrationForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.TextBox txtEmail_Address;
        private System.Windows.Forms.TextBox txtContact_no;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button registerInlineButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox UserRegistrationForm;
        private wmgCMS.WaterMarkTextBox txtUsername;
    }
}