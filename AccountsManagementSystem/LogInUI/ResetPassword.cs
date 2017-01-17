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

namespace AccountsManagementSystem.LogInUI
{
    public partial class ResetPassword : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string testUserType, usertType1, readyPassword;
        public ResetPassword()
        {
            InitializeComponent();
        }
        public void FilUserNameForAdmin()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(UserName) from Registration where UserType != 'SuperAdmin' and  UserType !='Admin' order by UserId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbUserName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FilUserNameForSuperAdmin()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(UserName) from Registration  order by UserId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbUserName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetPassword_Load(object sender, EventArgs e)
        {
            testUserType = frmLogin.userType;
            if (testUserType == "SuperAdmin")
            {
                FilUserNameForSuperAdmin();
            }
            if (testUserType == "Admin")
            {
                FilUserNameForAdmin();
            }
            
           
        }

        private void GetUserType()
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "Select  UserType from Registration  where UserName='"+cmbUserName.Text+"' ";
            cmd=new SqlCommand(qry,con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                usertType1 = (rdr.GetString(0));
            }
            con.Close();
        }

        private void UpdateUserPassword()
        {
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
                string cb = "Update Registration set Passwords=@d1 where UserName='" + cmbUserName.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", readyPassword);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Reset Password", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserName.SelectedIndex=-1;
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            if (cmbUserName.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUserName.Focus();
                return;
            }
            
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            GetUserType();
           

            try
            {
                

                if (testUserType == "SuperAdmin" && usertType1 == "SuperAdmin")
                {
                    UpdateUserPassword();
                }
                if (testUserType == "SuperAdmin" && usertType1 == "Admin")
                {
                    UpdateUserPassword();
                }
                if (testUserType == "SuperAdmin" && usertType1 == "User")
                {
                    UpdateUserPassword();
                }                
                if (testUserType == "Admin" && usertType1 == "User")
                {
                    UpdateUserPassword();
                }
                if (testUserType == "Admin" && usertType1 == "SuperAdmin")
                {
                   
                    MessageBox.Show("You  can not   Reset this Password", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbUserName.SelectedIndex = -1;
                    txtPassword.Clear();
                }
                if (testUserType == "Admin" && usertType1 == "Admin")
                {

                    MessageBox.Show("You  can not   Reset this Password", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbUserName.SelectedIndex = -1;
                    txtPassword.Clear();
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
