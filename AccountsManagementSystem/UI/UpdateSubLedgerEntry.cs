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
    public partial class UpdateSubLedgerEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int subLedgerId;
        public UpdateSubLedgerEntry()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (txtSubLedgerName.Text == "")
            {
                MessageBox.Show("Please select Sub Ledger ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubLedgerName.Focus();
                return;
            }
            if (txtSParticulars.Text == "")
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSParticulars.Focus();
                return;
            }
            if (txtSEntrydate.Text == "")
            {
                MessageBox.Show("Please select Current date ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSEntrydate.Focus();
                return;
            }

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update SubLedgerEntry set SubLedgerId=@d1,FundRequisitionNo=@d2,VoucherNo=@d3,EntryDate=@d4,Particulars=@d5,Debit=@d6,Credit=@d7 where SubLedgerEntryId='" + txtSubLedgerEntryId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", subLedgerId);
                cmd.Parameters.AddWithValue("@d2", txtFundRequisitionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtSVoucherNo.Text);
                cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtSEntrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d5", txtSParticulars.Text);
                cmd.Parameters.AddWithValue("@d6", txtSReceive.Text);
                cmd.Parameters.AddWithValue("@d7", txtSExpence.Text);

                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            txtSubLedgerName.Text = "";
            txtSubLedgerEntryId.Text = "";
            txtFundRequisitionNo.Text = "";
            txtSVoucherNo.Text = "";
            txtSParticulars.Text = "";
            txtSEntrydate.Value = System.DateTime.Today;
            txtSReceive.Text = "";
            txtSExpence.Text = "";
            updateButton.Enabled = false;

        }
        private void backButton_Click(object sender, EventArgs e)
        {
                  this.Hide();
            JournalForSubLedgerEntry frm=new JournalForSubLedgerEntry();
                   frm.Show();
        }

        private void txtSubLedgerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select SubLedger.SubLedgerId from SubLedger where SubLedgerName='"+txtSubLedgerName.Text+"'";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    subLedgerId = (rdr.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSubLedgerEntry_Load(object sender, EventArgs e)
        {
            //backButton.Focus();
            txtSubLedgerEntryId.Focus();
        }

        private void txtSubLedgerEntryId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubLedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtSubLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSEntrydate.Focus();
                e.Handled = true;
            }
        }

        private void txtSEntrydate_ValueChanged(object sender, EventArgs e)
        {

            txtFundRequisitionNo.Focus();
             
            
        }

        private void txtFundRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSVoucherNo.Focus();
                e.Handled = true;
            }
        }

        private void txtSVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSParticulars.Focus();
                e.Handled = true;
            }
        }

        private void txtSParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSReceive.Focus();
                e.Handled = true;
            }
        }

        private void txtSReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSExpence.Focus();
                e.Handled = true;
            }
        }

        private void txtSExpence_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(this, new EventArgs());
            }
        }
    }
}
