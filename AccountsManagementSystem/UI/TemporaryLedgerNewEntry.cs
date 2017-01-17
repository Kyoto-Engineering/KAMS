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
    public partial class TemporaryLedgerNewEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public TemporaryLedgerNewEntry()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtTempLedgerName.Text="";
            txtTEntrydate.Value = System.DateTime.Today;
            txtTFundRequisitionNo.Text = "";
            txtTVoucherNo.Text = "";
            txtTParticulars.Text = "";
            txtTDebit.Text = "";
            txtTCredit.Text = "";

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (txtTempLedgerName.Text == "")
            {
                MessageBox.Show("Please enter Temporary  Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTempLedgerName.Focus();
                return;
            }
            if (txtTEntrydate.Text == "")
            {
                MessageBox.Show("Please select entry date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTEntrydate.Focus();
                return;
            }
            if (txtTParticulars.Text == "")
            {
                MessageBox.Show("Please enter particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTParticulars.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into TemporaryLedger(TempLedgerName,EntryDate,FundRequisitionNo,VoucherNo,Particulars,Debit,Credit) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtTempLedgerName.Text);
                cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(txtTEntrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d3", txtTFundRequisitionNo.Text);
                cmd.Parameters.AddWithValue("@d4", txtTVoucherNo.Text);
                cmd.Parameters.AddWithValue("@d5", txtTParticulars.Text);
                cmd.Parameters.AddWithValue("@d6", txtTDebit.Text);
                cmd.Parameters.AddWithValue("@d7", txtTCredit.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(TemporaryLedger.TempLedgerId),RTRIM(TemporaryLedger.TempLedgerName),RTRIM(TemporaryLedger.EntryDate),RTRIM(TemporaryLedger.FundRequisitionNo),RTRIM(TemporaryLedger.VoucherNo),RTRIM(TemporaryLedger.Particulars),RTRIM(TemporaryLedger.Debit),RTRIM(TemporaryLedger.Credit) from TemporaryLedger  order by TempLedgerId desc", con);
                // cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(LedgerEntry.EntryDate),RTRIM(LedgerEntry.LedgerId),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Receives),RTRIM(LedgerEntry.Expences) from LedgerEntry  order by LedgerEntryId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TemporaryLedgerNewEntry_Load(object sender, EventArgs e)
        {
            txtTempLedgerName.Focus();
            GetData();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
             frm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                UpdateTempLedger frm = new UpdateTempLedger();
                frm.Show();
                frm.txtTempULedgerId.Text = dr.Cells[0].Value.ToString();
                frm.txtTempULedgerName.Text = dr.Cells[1].Value.ToString();
                frm.txtTUEntrydate.Text = dr.Cells[2].Value.ToString();
                frm.txtTUFundRequisitionNo.Text = dr.Cells[3].Value.ToString();
                frm.txtTUVoucherNo.Text = dr.Cells[4].Value.ToString();
                frm.txtTUParticulars.Text = dr.Cells[5].Value.ToString();
                frm.txtTUReceive.Text = dr.Cells[6].Value.ToString();
                frm.txtTUExpence.Text = dr.Cells[7].Value.ToString();
                frm.labelh.Text = frm.labelhk.Text;
           }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTExpence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTempLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            txtTEntrydate.Focus();
        }

        private void txtTEntrydate_ValueChanged(object sender, EventArgs e)
        {
            txtTFundRequisitionNo.Focus();
        }

        private void txtTFundRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTVoucherNo.Focus();
                e.Handled = true;
            }
        }

        private void txtTVoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTParticulars.Focus();
                e.Handled = true;
            }
        }

        private void txtTParticulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTDebit.Focus();
                e.Handled = true;
            }
        }

        private void txtTDebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTCredit.Focus();
                e.Handled = true;
            }
        }

        private void txtTCredit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(this, new EventArgs());
            }
        }
    }
}
