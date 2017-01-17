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
    public partial class UpdateSubLedger : Form
    {
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int ledgerId;
        public UpdateSubLedger()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtULedgerName.Text = "";
            txtUSubLedgerId.Text = "";
            txtUSubLedgerName.Text = "";
            txtUPreviousSubLedgerId.Text = "";
            
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
           

            
            if (txtUSubLedgerName.Text == "")
            {
                MessageBox.Show("Please enter Sub Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUSubLedgerName.Focus();
                return;
            }
           

            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = @"Update SubLedger set SubLedger.PreviousSubLedgerId=@d1,SubLedger.LedgerId=@d2,SubLedger.SubLedgerName=@d3 where SubLedger.SubLedgerId='" + txtUSubLedgerId.Text + "'";
                //string cb = String.Format("Update SubLedger Set  PreviousSubLedgerId='" + txtUPreviousSubLedgerId.Text + "',LedgerId='" + txtULedgerId.Text + "',SubLedgerName='" + txtUSubLedgerName.Text + "',SubLedger.TypeofLedger='" + txtUTypeOfLedger.Text + "' Where SubLedgerId='"+txtUSubLedgerId.Text+"'");
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtUPreviousSubLedgerId.Text);
                cmd.Parameters.AddWithValue("@d2", ledgerId);
                cmd.Parameters.AddWithValue("@d3", txtUSubLedgerName.Text);
                

                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                updateButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubLedger frm = new SubLedger();
            frm.Show();
        }

        private void txtULedgerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  Ledger.LedgerId  from Ledger where Ledger.LedgerName='" + txtULedgerName.Text + "' ";
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

        private void UpdateSubLedger_Load(object sender, EventArgs e)
        {
           // backButton.Focus();
            txtUSubLedgerId.Focus();
        }

        private void txtUSubLedgerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtULedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtULedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUPreviousSubLedgerId.Focus();
                e.Handled = true;
            }
        }

        private void txtUPreviousSubLedgerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUSubLedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtUSubLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateButton_Click(this, new EventArgs());
            }
        }
    }
}
