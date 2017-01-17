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
    public partial class UpdateTempLedger : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public UpdateTempLedger()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtTempULedgerName.Text = "";
            txtTempULedgerId.Text = "";
            txtTUEntrydate.Value = System.DateTime.Today;
            txtTUFundRequisitionNo.Text = "";
            txtTUVoucherNo.Text = "";
            txtTUParticulars.Text = "";
            txtTUReceive.Text = "";
            txtTUExpence.Text = "";
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
             if (txtTempULedgerName.Text == "")
            {
                MessageBox.Show("Please enter  Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTempULedgerName.Focus();
                return;
            }
            if (txtTUParticulars.Text == "")
            {
                MessageBox.Show("Please Type your Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTUParticulars.Focus();
                return;
            }
            

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update TemporaryLedger set TempLedgerName=@d1,EntryDate=@d2,FundRequisitionNo=@d3,VoucherNo=@d4,Particulars=@d5,Debit=@d6,Credit=@d7 where TempLedgerId='" + txtTempULedgerId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtTempULedgerName.Text);
                cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(txtTUEntrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d3", txtTUFundRequisitionNo.Text);
                cmd.Parameters.AddWithValue("@d4", txtTUVoucherNo.Text);
                cmd.Parameters.AddWithValue("@d5", txtTUParticulars.Text);
                cmd.Parameters.AddWithValue("@d6", txtTUReceive.Text);
                cmd.Parameters.AddWithValue("@d7", txtTUExpence.Text);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Autocomplete();
                Reset();
                this.Hide();
    TemporaryLedgerNewEntry frm=new TemporaryLedgerNewEntry();
                frm.Show();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTUReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTUExpence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
                
            }
        }

        private void UpdateTempLedger_Load(object sender, EventArgs e)
        {
            txtTempULedgerId.Focus();
        }

        private void txtTempULedgerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTempULedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtTempULedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTempULedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtTUEntrydate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTUFundRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTUVoucherNo.Focus();
                e.Handled = true;
            }
        }

        private void txtTUVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTUParticulars.Focus();
                e.Handled = true;
            }
        }

        private void txtTUParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTUReceive.Focus();
                e.Handled = true;
            }
        }

        private void txtTUReceive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTUExpence.Focus();
                e.Handled = true;
            }
        }

        private void txtTUExpence_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(this, new EventArgs());
            }
        }

        private void txtTUEntrydate_ValueChanged(object sender, EventArgs e)
        {
            txtTUFundRequisitionNo.Focus();
        }
        }
    
}
