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
        private DataGridViewRow dr;
        private int ExpenseSid, EGId,Lid;
        private int RevenueSid,RGId;
        private decimal balance,totalRevenue=0.0m,totalExpense=0.0m,profitorLoss=0.0m;
        public PRofitAndLoss()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please Select Account Type");
            }

            else if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Please Select Group");
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please Select Ledger");
            }
            else
            {
                totalRevenue = totalRevenue + balance;
                textBox3.Text = totalRevenue.ToString();
                dataGridView3.Rows.Add(Lid, textBox1.Text, balance, RevenueSid, RGId);
                ClearRevenues();
                CalculatePNL();
            }
           
        }

        private void CalculatePNL()
        {
            if (totalRevenue > totalExpense)
            {
                label7.Text = "Profit";
                textBox5.Text = (totalRevenue - totalExpense).ToString();
            }
            else if (totalRevenue < totalExpense)
            {
                label7.Text = "Loss";
                textBox5.Text = (totalExpense - totalRevenue).ToString();
            }
            else
            {
                label7.Text = "No Profit or  Loss";
                textBox5.Text = "0";
            }
        }

        private void ClearExpenses()
        {
            dataGridView2.Rows.Remove(dr);
            comboBox3.SelectedIndexChanged -= comboBox3_SelectedIndexChanged;
            comboBox3.SelectedIndex = -1;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged -= comboBox4_SelectedIndexChanged;
            comboBox4.SelectedIndex = -1;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            textBox2.Clear();
        }
        private void ClearRevenues()
        {
            dataGridView1.Rows.Remove(dr);
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged -= comboBox2_SelectedIndexChanged;
            comboBox2.SelectedIndex = -1;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            textBox1.Clear();
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
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Revenue' and BalanceFiscal.FiscalId='" + FiscalYear.phiscalYear + "'";
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
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Expense' and BalanceFiscal.FiscalId='"+FiscalYear.phiscalYear+"'";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows[0]==dataGridView1.Rows[dataGridView1.RowCount-1])
            {
                MessageBox.Show("Select a Valid Ledger");
            }
            else
            {
                dr = dataGridView1.SelectedRows[0];
                Lid = Convert.ToInt32(dr.Cells[0].Value);
                textBox1.Text = dr.Cells[1].Value.ToString();
                balance = Convert.ToDecimal(dr.Cells[2].Value);
            }
            

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.SelectedRows[0] == dataGridView2.Rows[dataGridView2.RowCount - 1])
            {
                MessageBox.Show("Select a Valid Ledger");
            }
            else
            {
                dr = dataGridView2.SelectedRows[0];
                Lid = Convert.ToInt32(dr.Cells[0].Value);
                textBox2.Text = dr.Cells[1].Value.ToString();
                balance = Convert.ToDecimal(dr.Cells[2].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox4.Text))
            {
                MessageBox.Show("Please Select Account Type");
            }

            else if (string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                MessageBox.Show("Please Select Group");
            }
            else if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please Select Ledger");
            }
            else
            {
                totalExpense = totalExpense + balance;
                textBox4.Text = totalExpense.ToString();
                dataGridView4.Rows.Add(Lid, textBox2.Text, balance, ExpenseSid, EGId);
                ClearExpenses();
                CalculatePNL();
            }
        }

        private void ClearAfterDone()
        {
                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox4.Items.Clear();
                comboBox3.Items.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount-1 > 0)
            {
                MessageBox.Show("Revenue Items Left You can not complete PNL Now","Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                dataGridView1.Focus();
            }
            else if (dataGridView2.RowCount-1 > 0)
            {
                MessageBox.Show("Expense Items Left You can not complete PNL Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dataGridView2.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You Forgot To Add Something On The List.You can not complete PNL Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You Forgot To Add Something On The List.You can not complete PNL Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox2.Focus();
            }
            else
            {
                con = new SqlConnection(cs.DBConn);
                string query1 = "INSERT INTO PNLEvent (EntryDate, UserId, PL, Balance, FiscalId) VALUES (@d1,@d2,@d3,@d4,@d5) SELECT CONVERT(int, SCOPE_IDENTITY());";
                cmd.Connection = con;
                cmd.CommandText = query1;
                cmd.Parameters.AddWithValue("@d1",DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d2",frmLogin.uId );
                cmd.Parameters.AddWithValue("@d3", label7.Text.Trim());
                cmd.Parameters.AddWithValue("@d4", textBox5.Text);
                cmd.Parameters.AddWithValue("@d5", FiscalYear.phiscalYear);
                con.Open();
                int Pid = (int) cmd.ExecuteScalar();
                con.Close();
                string query = "INSERT INTO GLRel (LId, GId,Balance,PId) VALUES  (@d1,@d2,@d3,"+Pid+")";
                cmd.CommandText = query;
               
                con.Open();
                for (int i = 0; i < dataGridView3.RowCount-1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@d1", dataGridView3.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", dataGridView3.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@d3", dataGridView3.Rows[i].Cells[2].Value);
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i < dataGridView4.RowCount-1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@d1", dataGridView4.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", dataGridView4.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@d3", dataGridView4.Rows[i].Cells[2].Value);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Successfully Done");

                ClearAfterDone();


            }
        }
    }
}
