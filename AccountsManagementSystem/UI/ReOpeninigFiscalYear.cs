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
    public partial class ReOpeninigFiscalYear : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();

        public ReOpeninigFiscalYear()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (cmbReOpenFiscalYear.Text == "")
            {
                MessageBox.Show("Please select Fiscal Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbReOpenFiscalYear.Focus();
                return;
            }


            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update FiscalYears set ClosingDate=@d1,Statuss=@d2 where FiscalYear='" + cmbReOpenFiscalYear.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d2", "Open");
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Re-Open this Fiscal Year", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbReOpenFiscalYear.SelectedIndex = -1;
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
                string ct = "Select RTRIM(FiscalYears.FiscalYear) from FiscalYears where FiscalYears.Statuss!='Open' order by FiscalYears.FiscalId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbReOpenFiscalYear.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReOpeninigFiscalYear_Load(object sender, EventArgs e)
        {
            GetFiscalYear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
