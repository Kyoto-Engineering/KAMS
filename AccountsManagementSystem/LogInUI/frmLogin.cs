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
using AccountsManagementSystem.DbGateway;
using AccountsManagementSystem.UI;

namespace AccountsManagementSystem.LogInUI
{
    public partial class frmLogin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr,rdr1,testReader;
        ConnectionString cs=new ConnectionString();
        public static int uId;
        public static string userType;
        public string readyPassword,dbPassword,dbUserName;
        
        public frmLogin()
        {
            InitializeComponent();
        }       
        private void oKButton_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            try
            {

                string clearText = txtPassword.Text.Trim();
                string password = clearText;
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                string readyPassword1 = Convert.ToBase64String(inArray);
                readyPassword = readyPassword1;

                
               con = new SqlConnection(cs.DBConn);
               con.Open();
               string qry = "SELECT Username,passwords FROM Registration WHERE Username = '"+txtUserName.Text+"' AND passwords = '"+readyPassword+"'";
               cmd = new SqlCommand(qry, con);
               rdr1= cmd.ExecuteReader();
                if (rdr1.Read() == true)
                {
                    dbUserName = (rdr1.GetString(0));
                    dbPassword = (rdr1.GetString(1));


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select usertype,UserId from Registration where Username='" + txtUserName.Text + "' and Passwords='" + readyPassword+ "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    userType = (rdr.GetString(0));
                    uId = (rdr.GetInt32(1));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (dbUserName==txtUserName.Text && dbPassword==readyPassword && userType.Trim() == "SuperAdmin")
                {
                    this.Hide();
                    FiscalYear frm = new FiscalYear();
                    frm.Show();

                }
                if (dbUserName == txtUserName.Text && dbPassword == readyPassword && userType.Trim() == "Admin")
                {
                    this.Hide();
                    FiscalYear frm = new FiscalYear();
                    frm.Show();

                }
                if (dbUserName == txtUserName.Text && dbPassword == readyPassword && userType.Trim() == "User")
                {
                    this.Hide();
                    FiscalYear frm = new FiscalYear();
                    frm.Show();

                }

                }
                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();
                }
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                oKButton_Click(this, new EventArgs());
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
