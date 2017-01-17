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
    public partial class OnlyUpdateForLedgerEntry : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
         ConnectionString cs=new ConnectionString();
        public decimal curBalance;
        public OnlyUpdateForLedgerEntry()
        {
            InitializeComponent();
        }

        private void GetCurrentId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct = "select Balances from LedgerEntry where  LedgerEntry.LedgerEntryId='" + cmbEntryId.Text + "'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                curBalance = (rdr.GetDecimal(0));

            }   
            con.Close();      

        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (cmbEntryId.Text == "")
            {
                MessageBox.Show("You must select Entry Id", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbEntryId.Focus();
                return;
            }
            if (txtOUBalance.Text == "")
            {
                MessageBox.Show("Please  enter Balance", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOUBalance.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update LedgerEntry set Balances=@d1 where LedgerEntryId='" + cmbEntryId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtOUBalance.Text);
                rdr = cmd.ExecuteReader();
                con.Close();
                GetCurrentId();
                MessageBox.Show("Successfully updated. The Current banace is:"+curBalance, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOUBalance.Text = "";
                cmbEntryId.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EntryIdComboFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(LedgerEntry.LedgerEntryId) from LedgerEntry  order by LedgerEntryId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbEntryId.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OnlyUpdateForLedgerEntry_Load(object sender, EventArgs e)
        {
            EntryIdComboFill();
        }

        private void txtOUBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void cmbEntryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOUBalance.Focus();
        }

        private void txtOUBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateButton_Click(this, new EventArgs());
            }
        }
    }
}
