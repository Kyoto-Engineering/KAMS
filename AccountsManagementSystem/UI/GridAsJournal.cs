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
    public partial class GridAsJournal : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int  fiscalLE8Year;
        private delegate void DayOfMonthEventHandler(int day);
        private event DayOfMonthEventHandler DayOfMonthEvent;

        /// <summary>/// We handle here the classical user event fired when the user /// changes the value of the DateTimePicker./// This, in turns, fires our event passing the day of the month. /// </summary>/// <param name="sender">The reference to the object instance /// firing the event.</param>/// <param name="e">Arguments passed to the event handler.</param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DayOfMonthEvent(dateTimePicker1.Value.Day);
        }
        private void ShowDayOfMonth(int day)
        {
            // cmbSTransactionDate
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='" + fiscalLE8Year + "' and TransactionRecord.TransactionDate like '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%'   order by LedgerEntry.LedgerEntryId desc", con);
                // cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
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
           // MessageBox.Show(String.Format("This is the day of the month: {0}", day));
        }

        public GridAsJournal()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged +=new System.EventHandler(this.dateTimePicker1_ValueChanged);
            DayOfMonthEvent += new DayOfMonthEventHandler(ShowDayOfMonth);
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='"+fiscalLE8Year+"'  order by LedgerEntry.LedgerEntryId desc",con);
                //cmd = new SqlCommand("SELECT RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) from Ledger,LedgerEntry,TransactionRecord,BalanceFiscal where BalanceFiscal.LId=LedgerEntry.LId and LedgerEntry.TransactionId=TransactionRecord.TransactionId and Ledger.LedgerId=BalanceFiscal.LedgerId and LedgerEntry.LId='" + fiscalLE8Year + "' order by LedgerEntry.LedgerEntryId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6],rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillLedgerNameCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbSLedgerName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public void FillTransactionDateCombo()
        //{
        //    try
        //    {

        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ct = "select RTRIM(TransactionRecord.TransactionDate) from TransactionRecord order by TransactionRecord.TransactionDate desc";
        //        cmd = new SqlCommand(ct);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cmbSTransactionDate.Items.Add(rdr[0]);
        //        }
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void GridAsJournal_Load(object sender, EventArgs e)
        {
            fiscalLE8Year = FiscalYear.phiscalYear;
            GetData();
           // FillTransactionDateCombo();
            FillLedgerNameCombo();
           // cmbSTransactionDate.Focus();

        }

        private void txtSLedgerName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbSTransactionDate_SelectedIndexChanged(object sender, EventArgs e)
        {
           //// cmbSTransactionDate
           // try
           // {
           //     con = new SqlConnection(cs.DBConn);
           //     con.Open();
           //     cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='" + fiscalLE8Year + "' and TransactionRecord.TransactionDate like '" + cmbSTransactionDate.Text + "%'   order by LedgerEntry.LedgerEntryId desc", con);
           //     // cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
           //     rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           //     dataGridView1.Rows.Clear();
           //     while (rdr.Read() == true)
           //     {
           //         dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
           //     }
           //     con.Close();
           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
        }

        private void cmbSLedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='" + fiscalLE8Year + "' and Ledger.LedgerName like '" + cmbSLedgerName.Text + "%'   order by LedgerEntry.LedgerEntryId desc", con);
                // cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSEntryDate_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='" + fiscalLE8Year + "' and TransactionRecord.TransactionDate like '" + txtSEntryDate.Value.Date + "%'   order by LedgerEntry.LedgerEntryId desc", con);
            //    // cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
            //    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    dataGridView1.Rows.Clear();
            //    while (rdr.Read() == true)
            //    {
            //        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtSEntryDate_Validating(object sender, CancelEventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = new SqlCommand("SELECT RTRIM(LedgerEntry.LedgerEntryId),RTRIM(TransactionRecord.TransactionDate),RTRIM(Ledger.LedgerName),RTRIM(LedgerEntry.FundRequisitionNo),RTRIM(LedgerEntry.VoucherNo),RTRIM(LedgerEntry.Particulars),RTRIM(LedgerEntry.Debit),RTRIM(LedgerEntry.Credit) FROM   ((BalanceFiscal INNER JOIN LedgerEntry ON BalanceFiscal.LId=LedgerEntry.LId) INNER JOIN Ledger ON BalanceFiscal.LedgerId=Ledger.LedgerId) INNER JOIN TransactionRecord ON LedgerEntry.TransactionId=TransactionRecord.TransactionId where  BalanceFiscal.FiscalId='" + fiscalLE8Year + "' and TransactionRecord.TransactionDate like '" + txtSEntryDate.Value.Date + "%'   order by LedgerEntry.LedgerEntryId desc", con);
            //    // cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
            //    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //    dataGridView1.Rows.Clear();
            //    while (rdr.Read() == true)
            //    {
            //        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
