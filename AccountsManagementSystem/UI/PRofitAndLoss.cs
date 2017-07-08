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
using AccountsManagementSystem.Models;

namespace AccountsManagementSystem.UI
{
    public partial class PRofitAndLoss : Form
    {
        private Dictionary<int, string> accountTypeDictionary=new Dictionary<int, string>();
        private List<SubAccountTypes> SubAccountTypesList =new List<SubAccountTypes>();
        private List<Groups> GroupList = new List<Groups>();
        private SqlDataReader rdr;
        private SqlCommand cmd;
        private SqlConnection con;
        ConnectionString cs=new ConnectionString();
        private int ExpenseSid, EGId;
        private int RevenueSid,RGId;
        public PRofitAndLoss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PRofitAndLoss_Load(object sender, EventArgs e)
        {
            LoadSubAccountTypes();
            LoadGroups();
            LoadRevenueAccountTypes();
            LoadExpenseAccountTypes();
            LoadGridOne();
            LoadGridTwo();
        }

        private void LoadExpenseAccountTypes()
        {
            var expenseaccounts = from SubAccountTypes in SubAccountTypesList
                where SubAccountTypes.AccountType == "Expense"
                select SubAccountTypes.SName;
            foreach (var subaccounttypes in expenseaccounts)
            {
                comboBox4.Items.Add(subaccounttypes);
            }
        }

        private void LoadRevenueAccountTypes()
        {
            var revenueaccounts = from SubAccountTypes in SubAccountTypesList
                where SubAccountTypes.AccountType == "Revenue"
                select SubAccountTypes.SName;
            foreach (var subaccounttypes in revenueaccounts)
            {
                comboBox1.Items.Add(subaccounttypes);
            }
        }

        private void LoadGroups()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT Groups.GId, Groups.GroupName, SubAccountTypes.SubAccountType FROM Groups INNER JOIN SubAccountTypes ON Groups.SATId = SubAccountTypes.SATId";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Groups grup = new Groups();
                grup.GId = Convert.ToInt32(rdr[0]);
                grup.GroupName = rdr[1].ToString();
                grup.Stype = rdr[2].ToString();
                GroupList.Add(grup);
            }
        }
        private void LoadGridOne()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Revenue' and BalanceFiscal.FiscalId=17";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
        }
        private void LoadGridTwo()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Expense' and BalanceFiscal.FiscalId=17";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
        }
        private void LoadSubAccountTypes()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT SATId,SubAccountType,AGRel.AccountType FROM SubAccountTypes inner join AGRel on SubAccountTypes.AGRelId=AGRel.AGRelId";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SubAccountTypes SubAccountType = new SubAccountTypes();
                SubAccountType.SId = Convert.ToInt32(rdr[0]);
                SubAccountType.SName = rdr[1].ToString();
                SubAccountType.AccountType = rdr[2].ToString();
                SubAccountTypesList.Add(SubAccountType);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            var revenueSid = from SubAccountTypes in SubAccountTypesList
                where SubAccountTypes.SName == comboBox1.Text
                select SubAccountTypes;
            RevenueSid = revenueSid.FirstOrDefault().SId;
            var groups = from Groups in GroupList
                where Groups.Stype == comboBox1.Text
                select Groups.GroupName;
            foreach (string grGroup in groups)
            {
                comboBox2.Items.Add(grGroup);
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            var expenseSid = from SubAccountTypes in SubAccountTypesList
                where SubAccountTypes.SName == comboBox4.Text
                select SubAccountTypes;
            ExpenseSid = expenseSid.FirstOrDefault().SId;
            var groups = from Groups in GroupList
                where Groups.Stype == comboBox4.Text
                select Groups.GroupName;
            foreach (string grGroup in groups)
            {
                comboBox3.Items.Add(grGroup);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rGid = from grups in GroupList
                where grups.GroupName == comboBox2.Text
                select grups;
            RGId = rGid.FirstOrDefault().GId;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var eGid = from grups in GroupList
                where grups.GroupName == comboBox3.Text
                select grups;
            EGId = eGid.FirstOrDefault().GId;
        }
    }
}
