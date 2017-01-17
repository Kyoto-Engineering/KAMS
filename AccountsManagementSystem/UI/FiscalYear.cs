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
    public partial class FiscalYear : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
       
        public string b, c, x;
        public decimal d=0,k=0;
        public static int  phiscalYear;
        public int  loadFiscalYear;
        public static DateTime startDate, endDate,startDate1,endDate1;
        public static string fUserId, fUserType;
        public FiscalYear()
        {
            InitializeComponent();
        }

        private void FiscalYear_Load(object sender, EventArgs e)
        {
            fUserId = frmLogin.uId.ToString();
            fUserType = frmLogin.userType;
            cmbFiscalYear.Focus();
            cmbFiscalYeaFill();

        }
        private void GetFiscalId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cty4 = "SELECT FiscalId FROM FiscalYears where  FiscalYears.FiscalYear='"+cmbFiscalYear.Text+"'";
            cmd = new SqlCommand(cty4);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                loadFiscalYear = (rdr.GetInt32(0));

            }
            con.Close();

        }
        private void GetTransactionDateRange()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cty4 = "SELECT StartDate,EndDate FROM FiscalYears where  FiscalYears.FiscalYear='" + cmbFiscalYear.Text + "'";
            cmd = new SqlCommand(cty4);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                startDate1 = (rdr.GetDateTime(0));
                endDate1 = (rdr.GetDateTime(1));

            }
            con.Close();

        }
        private void goButton_Click(object sender, EventArgs e)
        {
            


            if (cmbFiscalYear.Text == "")
            {
                MessageBox.Show("Please Select Fiscal Year", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetFiscalId();
            GetTransactionDateRange();
            phiscalYear = loadFiscalYear;
            startDate = startDate1;
            endDate = endDate1;

            if (fUserType.Trim() == "SuperAdmin")
            {
                this.Hide();
                MainUI frm = new MainUI();
                frm.Show();
                

            }
            if (fUserType.Trim() == "Admin")
            {
                this.Hide();
                MainUIForAdmin frm = new MainUIForAdmin();
                frm.Show();
                


            }


            if (fUserType.Trim() == "User")
            {
               this.Hide();
               MainUIForUser frm = new MainUIForUser();
                frm.Show();
                

            }

                 
        
        }
        public void cmbFiscalYeaFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(FiscalYear) from FiscalYears Where FiscalYears.Statuss='Open' order by FiscalId asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbFiscalYear.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
