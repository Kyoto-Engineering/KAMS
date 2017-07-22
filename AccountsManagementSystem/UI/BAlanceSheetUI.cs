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
using AccountsManagementSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Groups = AccountsManagementSystem.Models.Groups;

namespace AccountsManagementSystem.UI
{
    public partial class BAlanceSheetUI : Form
    {
        private Dictionary<int, string> accountTypeDictionary=new Dictionary<int, string>();
        private List<SubAccountTypes> SubAccountTypesList =new List<SubAccountTypes>();
        private List<Groups> GroupList = new List<Groups>();
        private SqlDataReader rdr;
        private SqlCommand cmd;
        private SqlConnection con;
        ConnectionString cs=new ConnectionString();
        private DataGridViewRow dr;
        private int ExpenseSid, EGId,Lid,pnlId;
        private int asetSid,agId;
        private decimal balance, totalAsset = 0.0m, totalLiability = 0.0m, profitorLoss = 0.0m, totalEquity=0.0m,totalCredit=0.0m;
        private DateTime pnlDateTime;
        private string LossOrProfit;
        private int _eqGId;
        private int _eqSid;
        private int _bId;

        public BAlanceSheetUI()
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
                totalAsset = totalAsset + balance;
                textBox3.Text = totalAsset.ToString();
                dataGridView3.Rows.Add(Lid, textBox1.Text, balance, asetSid, agId);
                ClearRevenues();
                CalculateBS();
            }
           
        }

        private void CalculateBS()
        {
            if (totalAsset > totalCredit)
            {
                label7.Text = "Aset is Greater";
                
            }
            else if (totalAsset < totalCredit)
            {
                label7.Text = "Aset is Lesser";
            }
            else
            {
                label7.Text = "Balance Sheet is Balanced";
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
        private void ClearEquity()
        {
            dataGridView5.Rows.Remove(dr);
            comboBox6.SelectedIndexChanged -= comboBox6_SelectedIndexChanged;
            comboBox6.SelectedIndex = -1;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            comboBox5.SelectedIndexChanged -= comboBox5_SelectedIndexChanged;
            comboBox5.SelectedIndex = -1;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            textBox6.Clear();
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

        private void BAlanceSheetUI_Load(object sender, EventArgs e)
        {
            LoadPNL();
        }

        private void LoadLiabilityAccountTypes()
        {
            var expenseaccounts = from SubAccountTypes in SubAccountTypesList
                                  where SubAccountTypes.AccountType == "Liability"
                select SubAccountTypes.SName;
            foreach (var subaccounttypes in expenseaccounts)
            {
                comboBox4.Items.Add(subaccounttypes);
            }
        }
        private void LoadPNL()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "select * from PNLEvent where FiscalId=" + FiscalYear.phiscalYear;
          
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                MessageBox.Show(@"Make A Profit & Loss Statement for This Fiscal Year First", @"PNL Not Found");
                con.Close();
                this.Close();
            }
            else
            {
                con.Close();
                string query2 =
                    "declare  @d1 as int; set @d1=(select MAX(PId) from PNLEvent where FiscalId="+ FiscalYear.phiscalYear+");select * from PNLEvent where PId= @d1;";
                cmd.CommandText = query2;
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pnlId = rdr.GetInt32(0);
                    pnlDateTime = rdr.GetDateTime(1);
                    LossOrProfit = rdr.GetString(3);
                    profitorLoss = rdr.GetDecimal(4);
                }
                con.Close();
                if (pnlDateTime.Date != DateTime.UtcNow.ToLocalTime().Date)
                {
                    DialogResult dsResult = MessageBox.Show(
                        @"PNL is " + (DateTime.UtcNow.ToLocalTime() - pnlDateTime).Days + " Days older" + "\r\n" +
                        @"Are You Sure To continue?", @"Please Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dsResult == DialogResult.Yes)
                    {
                        LoadSubAccountTypes();
                        LoadGroups();
                        LoadAssetAccountTypes();
                        LoadLiabilityAccountTypes();
                        LoadEquityAccountTypes();
                        LoadGridOne();
                        LoadGridTwo();
                        LoadGridThree();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    LoadSubAccountTypes();
                    LoadGroups();
                    LoadAssetAccountTypes();
                    LoadLiabilityAccountTypes();
                    LoadEquityAccountTypes();
                    LoadGridOne();
                    LoadGridTwo();
                    LoadGridThree();
                }
            }

        }
        private void LoadAssetAccountTypes()
        {
            var revenueaccounts = from SubAccountTypes in SubAccountTypesList
                                  where SubAccountTypes.AccountType == "Asset"
                select SubAccountTypes.SName;
            foreach (var subaccounttypes in revenueaccounts)
            {
                comboBox1.Items.Add(subaccounttypes);
            }
        }
        private void LoadEquityAccountTypes()
        {
            var revenueaccounts = from SubAccountTypes in SubAccountTypesList
                                  where SubAccountTypes.AccountType == "Equity"
                select SubAccountTypes.SName;
            foreach (var subaccounttypes in revenueaccounts)
            {
                comboBox6.Items.Add(subaccounttypes);
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
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE (AGRel.AccountType = 'Asset' or AGRel.AccountType = 'Pre Opening Expense' ) and BalanceFiscal.FiscalId='" + FiscalYear.phiscalYear + "'";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
            if (LossOrProfit.Trim()=="Loss")
            {
                dataGridView1.Rows.Add(0, "Loss In Current Year", profitorLoss);
            }
        }
        private void LoadGridTwo()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Liability' and BalanceFiscal.FiscalId='" + FiscalYear.phiscalYear + "'";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
        }
        private void LoadGridThree()
        {
            con = new SqlConnection(cs.DBConn);
            cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT BalanceFiscal.LId, Ledger.LedgerName, BalanceFiscal.Balance FROM Ledger INNER JOIN BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN AGRel ON Ledger.AGRelId = AGRel.AGRelId WHERE AGRel.AccountType = 'Equity' and BalanceFiscal.FiscalId='" + FiscalYear.phiscalYear + "'";
            con.Open();
            cmd.CommandText = query;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView5.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
            if (LossOrProfit.Trim() == "Profit")
            {
                dataGridView5.Rows.Add(0, "Profit In Current Year", profitorLoss);
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
            asetSid = revenueSid.FirstOrDefault().SId;
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
            agId = rGid.FirstOrDefault().GId;
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
                totalLiability = totalLiability + balance;
                textBox4.Text = totalLiability.ToString();
                dataGridView4.Rows.Add(Lid, textBox2.Text, balance, ExpenseSid, EGId);
                ClearExpenses();
                totalCredit = totalCredit + totalLiability;
                CalculateBS();
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
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
           // LoadAssetAccountTypes();
            //LoadLiabilityAccountTypes();
            //LoadEquityAccountTypes();
            


        }

        private void Report()
        {
            ParameterField parameterField1 = new ParameterField();

            ParameterFields parameterFields1 = new ParameterFields();
            
            ParameterDiscreteValue parameterDiscreteValue1 = new ParameterDiscreteValue();

            parameterField1.Name = "id";

            parameterDiscreteValue1.Value = _bId;

            parameterField1.CurrentValues.Add(parameterDiscreteValue1);

            parameterFields1.Add(parameterField1);

            ReportViewer f1 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);

            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "AccountDb";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";

            BSTotalX cr = new BSTotalX();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f1.crystalReportViewer1.ParameterFieldInfo = parameterFields1;
            f1.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f1.ShowDialog();
            this.Visible = true;



        }

        private void Report1()
        {
            ParameterField parameterField1 = new ParameterField();

            ParameterFields parameterFields1 = new ParameterFields();

            ParameterDiscreteValue parameterDiscreteValue1 = new ParameterDiscreteValue();

            parameterField1.Name = "id";

            parameterDiscreteValue1.Value = _bId;

            parameterField1.CurrentValues.Add(parameterDiscreteValue1);

            parameterFields1.Add(parameterField1);

            ReportViewer f1 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);

            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "AccountDb";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";

            Equity cr = new Equity();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f1.crystalReportViewer1.ParameterFieldInfo = parameterFields1;
            f1.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f1.ShowDialog();
            this.Visible = true;



        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount-1 > 0)
            {
                MessageBox.Show("Asset Items Left You can not complete Balance Sheet Now","Stop",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                dataGridView1.Focus();
            }
            else if (dataGridView2.RowCount-1 > 0)
            {
                MessageBox.Show("Liability Items Left You can not complete Balance Sheet Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dataGridView2.Focus();
            }
            else if (dataGridView5.RowCount - 1 > 0)
            {
                MessageBox.Show("Equity Items Left You can not complete Balance Sheet Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dataGridView5.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You Forgot To Add Something On The List.You can not complete Balance Sheet Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox1.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("You Forgot To Add Something On The List.You can not complete Balance Sheet Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox2.Focus();
            }
            else if (!string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("You Forgot To Add Something On The List.You can not complete Balance Sheet Now", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox6.Focus();
            }
            else if (dataGridView3.RowCount - 1 == 0 && dataGridView4.RowCount - 1 == 0 && dataGridView6.RowCount - 1 == 0)
            {
                MessageBox.Show(@"Nothing to Entry ", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            else
            {
                con = new SqlConnection(cs.DBConn);
                string query1 = "INSERT INTO BSEvent (EntryDate, UserId, FiscalId,PId) VALUES (@d1,@d2,@d5,"+pnlId+") SELECT CONVERT(int, SCOPE_IDENTITY());";
                cmd.Connection = con;
                cmd.CommandText = query1;
                cmd.Parameters.AddWithValue("@d1",DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d2",frmLogin.uId );
                cmd.Parameters.AddWithValue("@d5", FiscalYear.phiscalYear);
                con.Open();
                _bId = (int) cmd.ExecuteScalar();
                con.Close();
                string query = "INSERT INTO BSRel (LId, GId,Balance,BId,LedgerName) VALUES  (@d1,@d2,@d3," + _bId + ",@d4)";
                cmd.CommandText = query;
               
                con.Open();
                for (int i = 0; i < dataGridView3.RowCount-1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@d1", dataGridView3.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", dataGridView3.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@d3", dataGridView3.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@d4", dataGridView3.Rows[i].Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i < dataGridView4.RowCount-1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@d1", dataGridView4.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", dataGridView4.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@d3", dataGridView4.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@d4", dataGridView4.Rows[i].Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i < dataGridView6.RowCount - 1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@d1", dataGridView6.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@d2", dataGridView6.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@d3", dataGridView6.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@d4", dataGridView6.Rows[i].Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Successfully Done");

                Report();
                Report1();
                ClearAfterDone();
                this.Close();


            }
        }



        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var eGid = from grups in GroupList
                where grups.GroupName == comboBox5.Text
                select grups;
            _eqGId = eGid.FirstOrDefault().GId;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            var expenseSid = from SubAccountTypes in SubAccountTypesList
                where SubAccountTypes.SName == comboBox6.Text
                select SubAccountTypes;
             _eqSid = expenseSid.FirstOrDefault().SId;
            var groups = from Groups in GroupList
                where Groups.Stype == comboBox6.Text
                select Groups.GroupName;
            foreach (string grGroup in groups)
            {
                comboBox5.Items.Add(grGroup);
            }
        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView5.SelectedRows[0] == dataGridView5.Rows[dataGridView5.RowCount - 1])
            {
                MessageBox.Show("Select a Valid Ledger");
            }
            else
            {
                dr = dataGridView5.SelectedRows[0];
                Lid = Convert.ToInt32(dr.Cells[0].Value);
                textBox6.Text = dr.Cells[1].Value.ToString();
                balance = Convert.ToDecimal(dr.Cells[2].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox6.Text))
            {
                MessageBox.Show("Please Select Account Type");
            }

            else if (string.IsNullOrWhiteSpace(comboBox5.Text))
            {
                MessageBox.Show("Please Select Group");
            }
            else if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Please Select Ledger");
            }
            else
            {
                totalEquity = totalEquity + balance;
                totalCredit = totalCredit + totalEquity;
                textBox5.Text = totalEquity.ToString();
                dataGridView6.Rows.Add(Lid, textBox6.Text, balance, _eqSid, _eqGId);
                ClearEquity();
                CalculateBS();
            }
        }
    }
}
