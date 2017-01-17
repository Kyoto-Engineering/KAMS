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
    public partial class JournalForSubLedgerEntry : Form
    {   
        ConnectionString cs=new ConnectionString();
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlConnection con;
        public JournalForSubLedgerEntry()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(SubLedgerEntry.SubLedgerEntryId),RTRIM(SubLedger.SubLedgerName),RTRIM(SubLedgerEntry.EntryDate),RTRIM(SubLedgerEntry.FundRequisitionNo),RTRIM(SubLedgerEntry.VoucherNo),RTRIM(SubLedgerEntry.Particulars),RTRIM(SubLedgerEntry.Debit),RTRIM(SubLedgerEntry.Credit) from  SubLedger,SubLedgerEntry  where SubLedger.SubLedgerId=SubLedgerEntry.SubLedgerId order by SubLedgerEntry.SubLedgerEntryId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3],rdr[4],rdr[5],rdr[6],rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void JournalForSubLedgerEntry_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SubLedgerEntry frm=new SubLedgerEntry();
            frm.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                UpdateSubLedgerEntry frm=new UpdateSubLedgerEntry();
                frm.Show();
                frm.txtSubLedgerEntryId.Text = dr.Cells[0].Value.ToString();
                frm.txtSubLedgerName.Text = dr.Cells[1].Value.ToString();
                frm.txtSEntrydate.Text = dr.Cells[2].Value.ToString();
               
                frm.txtFundRequisitionNo.Text = dr.Cells[3].Value.ToString();
                frm.txtSVoucherNo.Text = dr.Cells[4].Value.ToString();
                frm.txtSParticulars.Text = dr.Cells[5].Value.ToString();
                frm.txtSExpence.Text = dr.Cells[6].Value.ToString();
                frm.txtSReceive.Text = dr.Cells[7].Value.ToString();
  
                frm.labelk.Text = frm.labelkl.Text;
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void closeButton_Click(object sender, EventArgs e)
        {
                                this.Hide();
                           MainUI frm=new MainUI();
                                  frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
