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
    public partial class ThreeParamUpdateForm : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public ThreeParamUpdateForm()
        {
            InitializeComponent();
        }

        private void FillLedgerEntryId()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select RTRIM(LedgerEntry.LedgerEntryId) from LedgerEntry  order by  LedgerEntryId desc";
                cmd=new SqlCommand(query,con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbLedgerEntryId.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ThreeParamUpdateForm_Load(object sender, EventArgs e)
        {
            FillLedgerEntryId();
            cmbLedgerEntryId.Focus();
        }

        private void Reset()
        {
            cmbLedgerEntryId.SelectedIndex = -1;
            txtFundRequisition.Text = "";
            txtVoucherNo.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFundRequisition.Text == "")
            {
                MessageBox.Show("Please Enter  Fund Requisition Number", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtFundRequisition.Focus();
                return;
            }
            if (txtVoucherNo.Text == "")
            {
                MessageBox.Show("Please Enter  Voucher Number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVoucherNo.Focus();
                return;
            }
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update LedgerEntry  Set FundRequisitionNo=@d1,VoucherNo=@d2 where LedgerEntryId='"+cmbLedgerEntryId.Text+"'";
                cmd=new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@d1", txtFundRequisition.Text);
                cmd.Parameters.AddWithValue("@d2", txtVoucherNo.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully  Udated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbLedgerEntryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFundRequisition.Focus();
        }

        private void txtFundRequisition_KeyDown(object sender, KeyEventArgs e)
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
                button1_Click(this, new EventArgs());
            }
        }
        }
    }

