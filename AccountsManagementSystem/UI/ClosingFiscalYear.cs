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

namespace AccountsManagementSystem.UI
{
    public partial class ClosingFiscalYear : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public static string MId;
        public string b, c, x;
        public decimal d = 0, k = 0;
        public ClosingFiscalYear()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
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
                string cb = "Update FiscalYears set ClosingDate=@d1,Statuss=@d2 where FiscalYear='" + cmbFiscalYear.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d2", "Close");
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("This Fiscal Year Successfully Closed ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbFiscalYear.SelectedIndex = -1;
                cmbFiscalYear.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetFiscalYear()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(FiscalYears.FiscalYear) from FiscalYears where FiscalYears.Statuss!='Close' order by FiscalYears.FiscalId desc";
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
        private void ClosingFiscalYear_Load(object sender, EventArgs e)
        {
            GetFiscalYear();
        }

        private void cmbTypeOfFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
