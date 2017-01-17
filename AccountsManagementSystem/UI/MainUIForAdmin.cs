using AccountsManagementSystem.LogInUI;
using AccountsManagementSystem.Reports;
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
    public partial class MainUIForAdmin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int fiscalMAYear,testFiscalYear;
        public DateTime startDateM, endDateM;
        public  static string mAUserType;
        public MainUIForAdmin()
        {
            InitializeComponent();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void MainUIForAdmin_Load(object sender, EventArgs e)
        {
            fiscalMAYear = FiscalYear.phiscalYear;
            startDateM = FiscalYear.startDate;
            endDateM = FiscalYear.endDate;
            mAUserType = frmLogin.userType;
        }

        private void ledgerEntryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm = new JournalForLedgerEntry();
               frm.Show();
           
        }

        private void journalButton_Click(object sender, EventArgs e)
        {
            GridAsJournal frm = new GridAsJournal();
                       frm.Show();
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

        private void createFiscalYearButton_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ledger frm2 = new Ledger();
            frm2.Show();
        }

        private void buttonCloseingFiscalYear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ClosingFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
           ChangePassword frm =new ChangePassword();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select FiscalId From YearOpeningEvent where  YearOpeningEvent.FiscalId='" + fiscalMAYear + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                testFiscalYear = (rdr.GetInt32(0));
                
            }
            if (testFiscalYear != fiscalMAYear)
            {
                this.Hide();
                YearOpeningTransaction frm = new YearOpeningTransaction();
                frm.Show();
            }
            else
            {
                MessageBox.Show("The Balance Carry Forwarding is Already has  Done  for this Year", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                     
                      
        }

        private void buttonVoucherNumber_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new VoucherNumberUI();
            dr.ShowDialog();
            this.Visible = true;
        }
        }
    
}
