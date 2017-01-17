using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DbGateway;
using AccountsManagementSystem.LogInUI;

namespace AccountsManagementSystem.UI
{
    public partial class NewEntryForFiscalYear : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string exFiscalYear, startDate, endDate, oPeningDate, b, c,userId, fullName;
        public int fiscalId, myFiscalId;
        public NewEntryForFiscalYear()
        {
            InitializeComponent();
        }

        private void ManageDate()
        {

           
                exFiscalYear = cmbFiscalYear.Text;
                string[] s = exFiscalYear.Split('-');
                b = s[0];
                c = s[1];
                startDate = "1-July-" + b;
                endDate = "30-Jun-" + c;
                oPeningDate = "1-July-" + b;
            
           

        }
        private void GetUserName()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select Name From Registration where UserId='" + userId + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                fullName = (rdr.GetString(0));
            }
        }

        private void GetFiscalId()
        {
            string text = cmbFiscalYear.Text;
            string myString = (text.Length > 1) ? text.Substring(text.Length - 2, 2) : text;
            myFiscalId = Convert.ToInt32(myString);

        }

        private void CreateNewFiscalYear()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "INSERT INTO BalanceFiscal([LedgerId],[FiscalId],[Balance]) SELECT LedgerId,@d1,0 FROM Ledger";
                cmd=new SqlCommand(qry,con);
                cmd.Parameters.AddWithValue("@d1",myFiscalId);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input String was not in a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cmbFiscalYear.Text == "")
            {
                MessageBox.Show("Please select Fiscal Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFiscalYear.Focus();
                return;
            }


            try
            {
              
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select FiscalYear from FiscalYears where FiscalYear='" + cmbFiscalYear.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    exFiscalYear = (rdr.GetString(0));
                    MessageBox.Show("Fiscal Year Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFiscalYear.Text = "";
                    cmbFiscalYear.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                    
                }    
                
                      
                if (cmbFiscalYear.Text == "Preopening" || cmbFiscalYear.Text == "2014-2015")
                {
                    GetUserName();
                    String sDate = txtEndDate.Text;
                    DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                    String dy = datevalue.Day.ToString();
                    String mn = datevalue.Month.ToString();
                    String yy = datevalue.Year.ToString();

                    string text = yy;
                    string myString = (text.Length > 1) ? text.Substring(text.Length - 2, 2) : text;
                    myFiscalId = Convert.ToInt32(myString);

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into FiscalYears(FiscalId,FiscalYear,StartDate,EndDate,OpeningDate,Statuss,OpenBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", myFiscalId);
                    cmd.Parameters.AddWithValue("@d2", cmbFiscalYear.Text);
                    cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(txtStartDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtEndDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d5", Convert.ToDateTime(txtStartDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d6", "Open");
                    cmd.Parameters.AddWithValue("@d7", fullName);
                    cmd.ExecuteReader();
                    con.Close();
                    CreateNewFiscalYear();
                    MessageBox.Show("Fiscal Year successfully Open", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFiscalYear.SelectedIndex = -1;
                }
                else
                {
                    GetFiscalId();
                    GetUserName();
                    ManageDate();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into FiscalYears(FiscalId,FiscalYear,StartDate,EndDate,OpeningDate,Statuss,OpenBy) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", myFiscalId);
                    cmd.Parameters.AddWithValue("@d2", cmbFiscalYear.Text);
                    cmd.Parameters.AddWithValue("@d3", startDate);
                    cmd.Parameters.AddWithValue("@d4", endDate);
                    cmd.Parameters.AddWithValue("@d5", oPeningDate);
                    cmd.Parameters.AddWithValue("@d6", "Open");
                    cmd.Parameters.AddWithValue("@d7", fullName);
                    cmd.ExecuteReader();
                    con.Close();
                    CreateNewFiscalYear();
                    MessageBox.Show("Fiscal Year successfully Open", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFiscalYear.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStartDate.Focus();
            if (cmbFiscalYear.Text == "Preopening" || cmbFiscalYear.Text == "2014-2015")
            {
                labelStartDate.Visible = true;
                txtStartDate.Visible = true;
                labelEndDate.Visible = true;
                txtEndDate.Visible = true;
            }
            else
            {
                labelStartDate.Visible = false;
                txtStartDate.Visible = false;
                labelEndDate.Visible = false;
                txtEndDate.Visible = false;
            }
            
        }

        private void NewEntryForFiscalYear_Load(object sender, EventArgs e)
        {
            labelStartDate.Visible = false;
            txtStartDate.Visible = false;
            labelEndDate.Visible = false;
            txtEndDate.Visible = false;
            userId = frmLogin.uId.ToString();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
