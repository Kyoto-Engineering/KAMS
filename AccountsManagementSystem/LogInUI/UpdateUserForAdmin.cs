using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DbGateway;

namespace AccountsManagementSystem.LogInUI
{
    public partial class UpdateUserForAdmin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public UpdateUserForAdmin()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            cmbUserName.SelectedIndex = -1;
            cmbUserType.SelectedIndex = -1;
            designationTextBox.Clear();
            departmentTextBox.Clear();
            txtContact_no.Clear();
            txtEmail_Address.Clear();
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (cmbUserName.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUserName.Focus();
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
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "update registration set Designation=@d1, Department=@d2,ContactNo=@d3,Email=@d4,UserType=@d5 where UserName='" + cmbUserName.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", designationTextBox.Text);
                cmd.Parameters.AddWithValue("@d2", departmentTextBox.Text);
                cmd.Parameters.AddWithValue("@d3", txtContact_no.Text);
                cmd.Parameters.AddWithValue("@d4", txtEmail_Address.Text);
                cmd.Parameters.AddWithValue("@d5", cmbUserType.Text);
                cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Successfully updated", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbUserName.Text = cmbUserName.Text.TrimEnd();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  UserType, Designation,Department,ContactNo,Email FROM Registration WHERE UserName = '" + cmbUserName.Text.Trim() + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cmbUserType.Text = (rdr.GetString(0).Trim());
                    designationTextBox.Text = (rdr.GetString(1).Trim());
                    departmentTextBox.Text = (rdr.GetString(2).Trim());
                    txtContact_no.Text = (rdr.GetString(3).Trim());
                    txtEmail_Address.Text = (rdr.GetString(4).Trim());
                }

                if ((rdr != null))
                {
                    rdr.Close();
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
        private void UpdateUserForAdmin_Load(object sender, EventArgs e)
        {
            FilUserNameForSuperAdmin();
        }

        private void txtEmail_Address_Validating(object sender, CancelEventArgs e)
        {
            string emailId = txtEmail_Address.Text.Trim();
            Regex mRegxExpression;

            mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

            if (!mRegxExpression.IsMatch(emailId))
            {

                MessageBox.Show("Please Insert Valid email Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail_Address.Clear();
                txtEmail_Address.Focus();

            }
        }

        private void txtContact_no_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}


        }
    }
}
