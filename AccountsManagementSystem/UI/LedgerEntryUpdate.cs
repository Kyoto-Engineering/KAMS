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
using CrystalDecisions.Shared.Json;

namespace AccountsManagementSystem.UI
{
    public partial class LedgerEntryUpdate : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int ledgerId, transactionId;
        public Nullable<decimal> debit, credit;
        public int  fiscalULE4Year;
        public LedgerEntryUpdate()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtEntryId.Text = "";
            txtLedgerName.Text = "";
            txtTransactiondate.MinDate = FiscalYear.startDate;
            txtTransactiondate.MaxDate = FiscalYear.endDate;
            if (DateTime.UtcNow.ToLocalTime() > txtTransactiondate.MaxDate)
            {
                txtTransactiondate.Value = txtTransactiondate.MaxDate;

            }
            else
            {
                txtTransactiondate.Value = DateTime.Now;
            }
            txtParticulars.Text = "";
            txtRequisitionNo.Text = "";
            txtVoucherNo.Text = "";
            txtExpence.Text = "";
            txtReceive.Text = "";

        }

        private void UpdateTransactionDate()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update TransactionRecord  Set TransactionDate=@d1 where TransactionId='" + transactionId + "'";
                cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtTransactiondate.Value,System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.ExecuteReader();
                con.Close();
     

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateButton_Click(object sender, EventArgs e)
        {


            if (txtLedgerName.Text == "")
            {
                MessageBox.Show("Please enter  Ledger ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLedgerName.Focus();
                return;
            }
            if (txtParticulars.Text == "")
            {
                MessageBox.Show("Please Type your Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParticulars.Focus();
                return;
            }
            decimal? debit = !string.IsNullOrEmpty(txtReceive.Text) ? decimal.Parse(txtReceive.Text.Replace(",", "")) : (decimal?)null;
            decimal? credit = !string.IsNullOrEmpty(txtExpence.Text) ? decimal.Parse(txtExpence.Text.Replace(",", "")) : (decimal?)null;           
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update LedgerEntry set FundRequisitionNo=@d2,VoucherNo=@d3,Particulars=@d4 where LedgerEntryId='" + txtEntryId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;              
                cmd.Parameters.AddWithValue("@d2", txtRequisitionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtVoucherNo.Text);               
                cmd.Parameters.AddWithValue("@d4", txtParticulars.Text);               
                rdr = cmd.ExecuteReader();
                con.Close();
                GetTransactionId();
                UpdateTransactionDate();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);               
                Reset();
                updateButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                              this.Hide();
                JournalForLedgerEntry frm=new JournalForLedgerEntry();
                                  frm.Show();

        }

        private void txtLedgerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  Ledger.LedgerId  from Ledger where Ledger.LedgerName='" + txtLedgerName.Text + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetTransactionId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  LedgerEntry.TransactionId  from LedgerEntry where LedgerEntry.LedgerEntryId ='" + txtEntryId.Text + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    transactionId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTransactiondate_ValueChanged(object sender, EventArgs e)
        {
            //GetTransactionId();
        }

        private void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRequisitionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtVoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void LedgerEntryUpdate_Load(object sender, EventArgs e)
        {
            fiscalULE4Year = FiscalYear.phiscalYear;
            txtEntryId.Focus();

            txtTransactiondate.MinDate = FiscalYear.startDate;
            txtTransactiondate.MaxDate = FiscalYear.endDate;

            if (DateTime.UtcNow.ToLocalTime() > txtTransactiondate.MaxDate)
            {
                txtTransactiondate.Value = txtTransactiondate.MaxDate;

            }
            else
            {
                txtTransactiondate.Value = DateTime.Now;
            }

        }

        private void txtEntryId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTransactiondate.Focus();
                e.Handled = true;
            }
        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRequisitionNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVoucherNo.Focus();
                e.Handled = true;
            }
        }
        private void txtVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtParticulars.Focus();
                e.Handled = true;
            }
        }

        private void txtParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReceive.Focus();
                e.Handled = true;
            }
        }

        private void txtReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtExpence.Focus();
                e.Handled = true;
            }
        }

        private void txtExpence_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    updateButton_Click(this, new EventArgs());
            //}
        }

        
    }
}
