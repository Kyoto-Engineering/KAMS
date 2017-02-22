using AccountsManagementSystem.DbGateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.UI;

namespace AccountsManagementSystem.LogInUI
{
    public partial class ChangePassword : Form
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public string testcUserType, readyPassword,oldPassword1;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            testcUserType = frmLogin.userType;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                int RowsAffected = 0;
                
                if ((txtOldPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter old password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPassword.Focus();
                    return;
                }
                if ((txtNewPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Focus();
                    return;
                }
                if ((txtConfirmPassword.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Please confirm new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmPassword.Focus();
                    return;
                }
                if ((txtNewPassword.TextLength < 5))
                {
                    MessageBox.Show("The New Password Should be of Atleast 5 Characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }
                else if ((txtNewPassword.Text != txtConfirmPassword.Text))
                {
                    MessageBox.Show("Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtOldPassword.Focus();
                    return;
                }
                else if ((txtOldPassword.Text == txtNewPassword.Text))
                {
                    MessageBox.Show("Password is same..Re-enter new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Focus();
                    return;
                }
                string clearText = txtOldPassword.Text.Trim();
                byte[] bytes1 = Encoding.Unicode.GetBytes(clearText);
                byte[] inArray1 = HashAlgorithm.Create("SHA1").ComputeHash(bytes1);
                string oldPassword = Convert.ToBase64String(inArray1);
                oldPassword1 = oldPassword;
                string password = txtNewPassword.Text.Trim();
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                string readyPassword1 = Convert.ToBase64String(inArray);
                readyPassword = readyPassword1;


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Update Registration set Passwords =@d1  where  Passwords = '" + oldPassword1 + "'";
                cmd = new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@d1", readyPassword);
                RowsAffected = cmd.ExecuteNonQuery();
                if ((RowsAffected > 0))
                {
                    MessageBox.Show("Successfully changed", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();                   
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    frmLogin LoginForm1 = new frmLogin();
                    LoginForm1.Show();
                    LoginForm1.txtUserName.Text = "";
                    LoginForm1.txtPassword.Text = "";
                   // LoginForm1.ProgressBar1.Visible = false;
                    LoginForm1.txtUserName.Focus();
                }
                else
                {
                    MessageBox.Show("Old password does not matched", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtOldPassword.Focus();
                }
                if ((con.State == ConnectionState.Open))
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (testcUserType == "SuperAdmin")
            {
               
               this.Dispose();
                MainUI frm =new MainUI();
                frm.Show();
            }
            if (testcUserType == "Admin")
            {
                this.Dispose();
                MainUIForAdmin frm =new MainUIForAdmin();
                frm.Show();
            }
            if (testcUserType == "User")
            {
                this.Dispose();
                MainUIForUser frm =new MainUIForUser();
                frm.Show();
            }
        }
    }
}
