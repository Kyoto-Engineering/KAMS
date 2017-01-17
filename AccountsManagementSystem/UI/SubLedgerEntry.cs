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
    public partial class SubLedgerEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int subLedgerId;
        public SubLedgerEntry()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            cmbSubLedgerName.SelectedIndex = -1;
            txtSEntrydate.Value = System.DateTime.Today;
            txtFundRequisitionNo.Text = "";
            txtSVoucherNo.Text = "";
            txtSParticulars.Text = "";
            txtSDebit.Text = "";
            txtSCredit.Text = "";

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cmbSubLedgerName.Text == "")
            {
                MessageBox.Show("Please select  Ledger ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSubLedgerName.Focus();
                return;
            }
            if (txtSEntrydate.Text == "")
            {
                MessageBox.Show("Please select entry date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSEntrydate.Focus();
                return;
            }
            if (txtSParticulars.Text == "")
            {
                MessageBox.Show("Please enter Ledger Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSParticulars.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SubLedgerEntry(SubLedgerId,FundRequisitionNo,VoucherNo,EntryDate,Particulars,Debit,Credit) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", subLedgerId);
                cmd.Parameters.AddWithValue("@d2", txtFundRequisitionNo.Text);
                cmd.Parameters.AddWithValue("@d3", txtSVoucherNo.Text);
                cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtSEntrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d5", txtSParticulars.Text);
                cmd.Parameters.AddWithValue("@d6", txtSDebit.Text);
                cmd.Parameters.AddWithValue("@d7", txtSCredit.Text);
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

        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(SubLedgerName) from SubLedger order by SubLedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSubLedgerName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SubLedgerEntry_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
                      this.Hide();
            JournalForSubLedgerEntry  frm=new JournalForSubLedgerEntry();
                     frm.Show();
        }

        private void txtSReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtSExpence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void cmbSubLedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSEntrydate.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  SubLedger.SubLedgerId  from SubLedger where SubLedger.SubLedgerName='" + cmbSubLedgerName.Text + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    subLedgerId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtSDebit.Focus();
                e.Handled = true;
            }
        }

        private void txtSDebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSCredit.Focus();
                e.Handled = true;
            }
        }

        private void txtSCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(this, new EventArgs());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
