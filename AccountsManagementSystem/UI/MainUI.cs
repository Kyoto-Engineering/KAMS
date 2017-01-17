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
using AccountsManagementSystem.LogInUI;
using AccountsManagementSystem.Reports;

namespace AccountsManagementSystem.UI
{
    public partial class MainUI : Form
    {                     
        public static int fiscalMYear;
        public static DateTime startDateM, endDateM;
        public static string mSAUserType;

        public MainUI()
        {
            InitializeComponent();
        }

        private void ledgerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ledger frm = new Ledger();
            frm.Show();
        }

        private void ledgerEntryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm = new JournalForLedgerEntry();
            frm.Show();
        }

        private void SubLedgerButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This  User Interface is Now Unavailable", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
            //this.Hide();
            //SubLedger frm = new SubLedger();
            //frm.Show();
        }

        private void subledgerEntryButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This  User Interface is Now Unavailable", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            //this.Hide();
            //JournalForSubLedgerEntry frm = new JournalForSubLedgerEntry();
            //frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        

        private void btnTempLedger_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This  User Interface is Now Unavailable", "error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            return;
            //this.Hide();
            //TemporaryLedgerNewEntry frm = new TemporaryLedgerNewEntry();
            //frm.Show();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic frm = new UserManagementUI();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ReportsUI();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This  User Interface is Now Unavailable", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
            //this.Visible = false;
            //dynamic dr = new ThreeParamUpdateForm();
            //dr.ShowDialog();
            //this.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DailyBalance frm=new DailyBalance();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void journalButton_Click(object sender, EventArgs e)
        {
            GridAsJournal frm=new GridAsJournal();
                         frm.Show();
        }
        //private void GetFiscalId()
        //{
        //    con = new SqlConnection(cs.DBConn);
        //    con.Open();
        //    string cty4 = "SELECT FiscalYears.FiscalId FROM FiscalYears where  FiscalYears.FiscalYear='" + cmbFiscalYear.Text + "'";
        //    cmd = new SqlCommand(cty4);
        //    cmd.Connection = con;
        //    rdr = cmd.ExecuteReader();
        //    if (rdr.Read())
        //    {
        //        loadFiscalId = (rdr.GetString(0));

        //    }
        //    con.Close();

        //}
        private void MainUI_Load(object sender, EventArgs e)
        {
            fiscalMYear = FiscalYear.phiscalYear;
            startDateM = FiscalYear.startDate;
            endDateM = FiscalYear.endDate;
            mSAUserType = FiscalYear.fUserType;

        }

        private void createFiscalYearButton_Click(object sender, EventArgs e)
        {

            NewEntryForFiscalYear frm=new NewEntryForFiscalYear();
                              frm.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            PreYearOpeningTransaction frm = new PreYearOpeningTransaction();
            frm.Show();
        }

        private void buttonCloseingFiscalYear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ClosingFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ReOpeninigFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new NewEntryForFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void buttonVoucherNumber_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new VoucherNumberUI();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new FiscalYearManagementUI();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            dynamic frm = new ChangePassword();
            frm.Show();
            
        }
    }
}
