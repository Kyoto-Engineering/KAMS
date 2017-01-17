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
    public partial class SubLedger : Form
    {
        private SqlConnection con;
        private SqlDataReader rdr;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
        public int ledgerId;
        public SubLedger()
        {
            InitializeComponent();
        }

        public void FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(LedgerName) from Ledger order by LedgerId desc";
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
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SubLedger.SubLedgerId),RTRIM(Ledger.LedgerName),RTRIM(SubLedger.PreviousSubLedgerId),RTRIM(SubLedger.SubLedgerName) from Ledger,SubLedger  where SubLedger.LedgerId=Ledger.LedgerId  order by SubLedgerId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubLedger_Load(object sender, EventArgs e)
        {
            FillCombo();
            GetData();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cmbLedgerName.Text == "")
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLedgerName.Focus();
                return;
            }
            
            if (txtSubLedgerName.Text == "")
            {
                MessageBox.Show("Please enter Sub Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSubLedgerName.Focus();
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select SubLedgerName from SubLedger where SubLedgerName='" + txtSubLedgerName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("This Sub Ledger  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSubLedgerName.Text = "";
                    txtSubLedgerName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into SubLedger(PreviousSubLedgerId,LedgerId,SubLedgerName) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtPreviousSubLedgerId.Text);
                cmd.Parameters.AddWithValue("@d2", ledgerId);
                cmd.Parameters.AddWithValue("@d3", txtSubLedgerName.Text);
               
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                GetData();
                //Autocomplete();
               // saveButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            cmbLedgerName.SelectedIndex = -1;
            txtPreviousSubLedgerId.Text = "";
            txtSubLedgerName.Text = "";
          
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                UpdateSubLedger frm=new UpdateSubLedger();
                frm.Show();
                frm.txtUSubLedgerId.Text = dr.Cells[0].Value.ToString();
                frm.txtULedgerName.Text = dr.Cells[1].Value.ToString();
                frm.txtUPreviousSubLedgerId.Text = dr.Cells[2].Value.ToString();
                frm.txtUSubLedgerName.Text = dr.Cells[3].Value.ToString();
               // frm.txtUTypeOfLedger.Text = dr.Cells[4].Value.ToString();
                labelr.Text = labelk.Text;
                
                //saveButton.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
               frm.Show();
        }

        private void cmbLedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPreviousSubLedgerId.Focus();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  Ledger.LedgerId  from Ledger where Ledger.LedgerName='" + cmbLedgerName.Text + "' ";
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

        private void txtPreviousSubLedgerId_KeyDown(object sender, KeyEventArgs e)
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
                saveButton_Click(this, new EventArgs());
            }
        }
    }
}
