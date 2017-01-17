using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DAO;
using AccountsManagementSystem.DbGateway;
using System.Security.Cryptography;

namespace AccountsManagementSystem.LogInUI
{
    public partial class frmRegistration : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        ConnectionString cs = new ConnectionString();
        public string readyPassword;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

        }

        public  string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            string readyPassword1 = Convert.ToBase64String(inArray);
            readyPassword = readyPassword1;
            return readyPassword1;
        }

       
        private void registerInlineButton_Click(object sender, EventArgs e)
        {           
            if (cmbUserType.Text == "")
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUserType.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please  type your designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDesignation.Focus();
                return;
            }
            if (txtDepartment.Text == "")
            {
                MessageBox.Show("Please type your Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartment.Focus();
                return;
            }
            if (txtContact_no.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact_no.Focus();
                return;
            }
            if (txtEmail_Address.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail_Address.Focus();
                return;
            }

           
            try
            {

                
               string clearText = txtPassword.Text.Trim();
                //string cipherText = Encrypt(clearText, true);
               string password = clearText;
                EncodePasswordToBase64(password);

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select username from registration where username=@find";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 30, "username"));
                cmd.Parameters["@find"].Value = txtUsername.Text;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtUsername.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct1 = "select Email from registration where Email='" + txtEmail_Address.Text + "'";

                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Email ID Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail_Address.Text = "";
                    txtEmail_Address.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Registration(Username,UsertYpe,Passwords,ContactNo,Email,Name,Designation,Department,JoiningDate) VALUES ('" + txtUsername.Text + "','" + cmbUserType.Text + "','" + readyPassword + "','" + txtContact_no.Text + "','" + txtEmail_Address.Text + "','" + txtName.Text + "','" + txtDesignation.Text + "','" + txtDepartment.Text + "','" + System.DateTime.Now + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                registerInlineButton.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtUsername.Text = "";
            cmbUserType.SelectedIndex = -1;
            txtPassword.Text = "";
            txtContact_no.Text = "";
            txtName.Text = "";
            txtDesignation.Text = "";
            txtDepartment.Text = "";
            txtEmail_Address.Text = "";
            registerInlineButton.Enabled = true;

            txtUsername.Focus();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void delete_records()
        {

            try
            {
                if (txtUsername.Text == "admin")
                {
                    MessageBox.Show("Admin Account can not be deleted", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "delete from Registration where Username='" + txtUsername.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Autocomplete();
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    Autocomplete();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Autocomplete()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT username FROM registration", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "registration");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["Username"].ToString());

                }
                txtUsername.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtUsername.AutoCompleteCustomSource = col;
                txtUsername.AutoCompleteMode = AutoCompleteMode.Suggest;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUserType.Focus();
                e.Handled = true;
            }
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
                e.Handled = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDesignation.Focus();
                e.Handled = true;
            }
        }

        private void designationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDepartment.Focus();
                e.Handled = true;
            }
        }

        private void departmentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact_no.Focus();
                e.Handled = true;
            }
        }

        private void txtContact_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail_Address.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                registerInlineButton_Click(this, new EventArgs());
            }
        }

       

        private void txtEmail_Address_Validating(object sender, CancelEventArgs e)
        {            
          string emailId=  txtEmail_Address.Text.Trim();
                Regex mRegxExpression;

                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("E-mail address format is not correct.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtEmail_Address.Focus();

                }
            }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            string userId = txtUsername.Text.Trim();
            Regex mRegxExpression;

            mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

            if (!mRegxExpression.IsMatch(userId))
            {

                MessageBox.Show("User Id must be your email Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();

            }
        }

        private void txtContact_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && (e.KeyChar != (char)(Keys.Delete) || e.KeyChar == Char.Parse(".")))
            {
                e.Handled = true;


            }
        }       
    }
}
