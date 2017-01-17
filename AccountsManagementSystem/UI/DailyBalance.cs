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
    public partial class DailyBalance : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string ledgerId;
        public DailyBalance()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (cmbLedgerName.Text == "")
            {
                MessageBox.Show("Please Select Ledger Name", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLedgerName.Focus();
            }
            if (txtBalance.Text == "")
            {
                MessageBox.Show("Please Enter Balance", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBalance.Focus();
            }
            try
            {
               
               // RecordOfCreatedBy();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into DailyBalance(Dates,LedgerId,Balance) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d2", ledgerId);
                cmd.Parameters.AddWithValue("@d3", txtBalance.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbLedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(Ledger.LedgerId) from Ledger WHERE Ledger.LedgerName = '" + cmbLedgerName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId = (rdr.GetString(0));
                }
               con.Close();
               }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtBalance.Focus();
        }
        public void LedgerNameFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger  order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbLedgerName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DailyBalance_Load(object sender, EventArgs e)
        {
            LedgerNameFill();
            txtDate.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
             frm.Show();
        }

        private void Reset()
        {
            txtDate.Value = this.txtDate.MaxDate;
            cmbLedgerName.SelectedIndexChanged -= cmbLedgerName_SelectedIndexChanged;
            cmbLedgerName.Items.Clear();
            cmbLedgerName.SelectedIndex = -1;
            cmbLedgerName.SelectedIndexChanged += cmbLedgerName_SelectedIndexChanged;
            txtBalance.Clear();
            LedgerNameFill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
