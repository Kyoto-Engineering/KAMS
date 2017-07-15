using AccountsManagementSystem.LogInUI;
using AccountsManagementSystem.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountsManagementSystem.UI
{
    public partial class MainUIForUser : Form
    {
        public static string mUUserType;
        public DateTime startDateM,endDateM;
        public static int fiscalMUYear;
        public MainUIForUser()
        {
            InitializeComponent();
        }

        private void ledgerEntryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry dr = new JournalForLedgerEntry();
            dr.Show();
         
            
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void btnregistration_Click(object sender, EventArgs e)
        {
            this.Dispose();
            dynamic frm = new ChangePassword();
            frm.Show();
            
            //this.Hide();
            //ChangePassword frm = new ChangePassword();
            //     frm.Show();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ReportsUI();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void journalButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new GridAsJournal();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void MainUIForUser_Load(object sender, EventArgs e)
        {
            fiscalMUYear = FiscalYear.phiscalYear;
            startDateM = FiscalYear.startDate;
            endDateM = FiscalYear.endDate;
            mUUserType = frmLogin.userType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PRofitAndLoss fr =new PRofitAndLoss();
            this.Visible = false;
            fr.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAlanceSheetUI fr = new BAlanceSheetUI();
            this.Visible = false;
            fr.ShowDialog();
            this.Visible = true;
        }
    }
}
