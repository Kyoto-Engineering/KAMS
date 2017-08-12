using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DbGateway;
using AccountsManagementSystem.LogInUI;

namespace AccountsManagementSystem.UI
{
    public partial class YearOpeningAproval : Form
    {
        private SqlTransaction trans;
        private SqlConnection con;
        private SqlConnection rdrCon;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlDataAdapter ada;
        private DataTable dt;
        ConnectionString cs=new ConnectionString();
        public string userId, fullName, accountOType, inputByUId;
        public int iTransactionId, k, lEntryId, cEntryId, debitContraEntryId, creditLedgerEntryId, fiscalLE3Year,inputByUID1;
        public decimal debitBalance, creditBalance, lDBalance, lCBalance;
        public DateTime transactionDate;
        private List<int> creditEntry=new List<int>();
        private List<int> debitContraEntry=new List<int>();
        private List<int> creditContraEntry=new List<int>();
        private List<int> debitEntry=new List<int>();

        public YearOpeningAproval()
        {
            InitializeComponent();
        }

        private void GetDebitTotal()
        {
           
            decimal gtotal = 0;
            foreach (ListViewItem lstItem in listView1.Items)
            {
                gtotal += decimal.Parse(lstItem.SubItems[2].Text);
            }
            txtTotalDebitBalance.Text = Convert.ToString(gtotal);
           
        }
        private void GetCreditTotal()
        {
            decimal gtotal2 = 0;
            foreach (ListViewItem lstItem in listView2.Items)
            {
                gtotal2 += decimal.Parse(lstItem.SubItems[2].Text);
            }
            txtTotalCreditBalance.Text = Convert.ToString(gtotal2);
           
               
                   
        }
        private void SetDebitLedgerDetails()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT RTRIM(Ledger.LedgerName),RTRIM(Ledger.LedgerId),RTRIM(MPBYearOpening.CarriedBalance),RTRIM(BalanceFiscal.LId),RTRIM(Ledger.AGRelId)  FROM Ledger INNER JOIN  BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN  MPBYearOpening ON BalanceFiscal.LId = MPBYearOpening.LId INNER JOIN  YearOpeningEvent ON MPBYearOpening.EventId = YearOpeningEvent.EventId where (Ledger.AGRelId=1 or Ledger.AGRelId=6) and YearOpeningEvent.FiscalId='" + fiscalLE3Year + "'";
            ada = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ada.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());
                
                listitem1.SubItems.Add(dr[3].ToString());
                listitem1.SubItems.Add(dr[4].ToString());
                //listitem1.SubItems.Add(dr[5].ToString());
                listView1.Items.Add(listitem1);
            } 
        }
        private void SetCreditLedgerDetails()
        {
            listView2.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string query = "SELECT RTRIM(Ledger.LedgerName),RTRIM(Ledger.LedgerId),RTRIM(MPBYearOpening.CarriedBalance),RTRIM(BalanceFiscal.LId),RTRIM(Ledger.AGRelId)  FROM Ledger INNER JOIN  BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN  MPBYearOpening ON BalanceFiscal.LId = MPBYearOpening.LId INNER JOIN  YearOpeningEvent ON MPBYearOpening.EventId = YearOpeningEvent.EventId where (Ledger.AGRelId=2 or Ledger.AGRelId=3) and YearOpeningEvent.FiscalId='" + fiscalLE3Year + "'";
            ada = new SqlDataAdapter(query, con);
            dt = new DataTable();
            ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem2 = new ListViewItem(dr[0].ToString());
                listitem2.SubItems.Add(dr[1].ToString());
                listitem2.SubItems.Add(dr[2].ToString());
               // listitem2.SubItems.Add(dr["Year Opening Balance Carried From Previous Year"].ToString());
                listitem2.SubItems.Add(dr[3].ToString());
                listitem2.SubItems.Add(dr[4].ToString());
                //listitem2.SubItems.Add(dr[5].ToString());
                listView2.Items.Add(listitem2);
            }
        }
        private void YearOpeningAproval_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            fiscalLE3Year = FiscalYear.phiscalYear;
            transactionDate = FiscalYear.startDate;
            SetDebitLedgerDetails();
            GetDebitTotal();
            SetCreditLedgerDetails();
            GetCreditTotal();


        }
        private void GetInputByUId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select RTRIM(YearOpeningEvent.InputByUId) From YearOpeningEvent where YearOpeningEvent.FiscalId='" + fiscalLE3Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                inputByUId = (rdr.GetString(0));
                inputByUID1 = Convert.ToInt32(inputByUId);
            }
        }

        private void UpdateApprovedStatus()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveNewTransaction()
        {
            

        }                                
        private void SaveCreditContraLCLRelation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                string q1 = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(q1, con);
                cmd.Parameters.AddWithValue("d1", iTransactionId);
                cmd.Parameters.AddWithValue("d2", creditLedgerEntryId);
                cmd.Parameters.AddWithValue("d3", debitContraEntryId);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveLCLRelation()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                string query = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("d1", iTransactionId);
                cmd.Parameters.AddWithValue("d2", lEntryId);
                cmd.Parameters.AddWithValue("d3", cEntryId);
                con.Open();
                cmd.ExecuteReader();
                con.Close();
                SaveCreditContraLCLRelation();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonApproved_Click(object sender, EventArgs e)
        {
            try
            {
                decimal debitValue = Convert.ToDecimal(txtTotalDebitBalance.Text);
                decimal creditValue = Convert.ToDecimal(txtTotalCreditBalance.Text);
                if (debitValue != creditValue)
                {
                    MessageBox.Show("Trial Balance does not Match,It can not be Approved", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (debitValue == creditValue)
                {
                    GetInputByUId();
                    //SaveNewTransaction();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction();
                    string cb1 = "insert into TransactionRecord(TransactionDate,EntryDateTime,InputBy,ApprovedBy) VALUES (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(cb1);
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(transactionDate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d3", inputByUID1);
                    cmd.Parameters.AddWithValue("@d4", userId);
                    iTransactionId = (int)cmd.ExecuteScalar();
                    //con.Close();
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {

                        rdrCon = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[1].Text + "' and BalanceFiscal.LId='" + listView1.Items[i].SubItems[3].Text + "' ";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = rdrCon;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            debitBalance = (rdr.GetDecimal(0));

                        }
                        rdrCon.Close();

                        rdrCon = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" + listView1.Items[i].SubItems[4].Text + "'";
                        cmd = new SqlCommand(q1, rdrCon);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            accountOType = (rdr.GetString(0));

                        }

                        rdrCon.Close();
                        //if (genericOTypeId == 1)
                        if (accountOType == "Asset" || accountOType == "Expense" || accountOType == "Pre Opening Expense")
                        {
                            decimal x = decimal.Parse(listView1.Items[i].SubItems[2].Text);
                            lDBalance = debitBalance + x;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[1].Text + "' and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[3].Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                            //con.Close();

                        }
                        // if (genericOTypeId == 2)
                        if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                        {
                            decimal y = decimal.Parse(listView1.Items[i].SubItems[2].Text);
                            lDBalance = debitBalance - y;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[1].Text + "'and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[3].Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();

                        }




                        //con = new SqlConnection(cs.DBConn);
                        //con.Open();
                        string cb = "insert into LedgerEntry(Particulars,Debit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("d1", "Year Opening Balance Carried From Previous Year");
                        cmd.Parameters.AddWithValue("d2", decimal.Parse(listView1.Items[i].SubItems[2].Text));
                        cmd.Parameters.AddWithValue("d3", lDBalance);
                        cmd.Parameters.AddWithValue("d4", iTransactionId);
                        cmd.Parameters.AddWithValue("d5", listView1.Items[i].SubItems[3].Text);
                        lEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                        debitEntry.Add(lEntryId);
                        //con = new SqlConnection(cs.DBConn);
                        string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(query, con,trans);
                        cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[0].Text);
                        cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[1].Text);
                        //con.Open();
                        debitContraEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                        debitContraEntry.Add(debitContraEntryId);
                    }

                    for (int i = 0; i <= listView2.Items.Count - 1; i++)
                    {


                        rdrCon = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string ct = "Select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + listView2.Items[i].SubItems[1].Text + "' and BalanceFiscal.LId='" + listView2.Items[i].SubItems[3].Text + "' ";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = rdrCon;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            creditBalance = (rdr.GetDecimal(0));


                        }
                        rdrCon.Close();

                        rdrCon = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" + listView2.Items[i].SubItems[4].Text + "'";
                        cmd = new SqlCommand(q1, rdrCon);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            accountOType = (rdr.GetString(0));

                        }

                        rdrCon.Close();
                        //if (genericOTypeId == 1)
                        if (accountOType == "Asset" || accountOType == "Expense" || accountOType == "Pre Opening Expense")
                        {
                            decimal x = decimal.Parse(listView2.Items[i].SubItems[2].Text);
                            lCBalance = creditBalance - x;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId='" + listView2.Items[i].SubItems[1].Text + "' and BalanceFiscal.LId ='" + listView2.Items[i].SubItems[3].Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();

                        }
                        // if (genericOTypeId == 2)
                        if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                        {
                            decimal y = decimal.Parse(listView2.Items[i].SubItems[2].Text);
                            lCBalance = creditBalance + y;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId='" + listView2.Items[i].SubItems[1].Text + "'and BalanceFiscal.LId ='" + listView2.Items[i].SubItems[3].Text + "'";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();

                        }


                        //Con.Close
                        //con = new SqlConnection(cs.DBConn);

                        string cb = "insert into LedgerEntry(Particulars,Credit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("d1", "Year Opening Balance Carried From Previous Year");
                        cmd.Parameters.AddWithValue("d2", decimal.Parse(listView2.Items[i].SubItems[2].Text));
                        cmd.Parameters.AddWithValue("d3", lCBalance);
                        cmd.Parameters.AddWithValue("d4", iTransactionId);
                        cmd.Parameters.AddWithValue("d5", listView2.Items[i].SubItems[3].Text);
                        //con.Open();
                        creditLedgerEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                        creditEntry.Add(creditLedgerEntryId);
                        //con = new SqlConnection(cs.DBConn);
                        string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(query, con,trans);
                        cmd.Parameters.AddWithValue("d1", listView2.Items[i].SubItems[0].Text);
                        cmd.Parameters.AddWithValue("d2", listView2.Items[i].SubItems[1].Text);
                        //con.Open();
                        cEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                        creditContraEntry.Add(cEntryId);

                    }
                    //SaveLCLRelation();
                    foreach (int crid in creditEntry)
                    {
                        foreach (int dbcnid in debitContraEntry)
                        {

                            //con = new SqlConnection(cs.DBConn);
                            string query = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                            cmd = new SqlCommand(query, con, trans);
                            cmd.Parameters.AddWithValue("d1", iTransactionId);
                            cmd.Parameters.AddWithValue("d2", crid);
                            cmd.Parameters.AddWithValue("d3", dbcnid);
                            //con.Open();
                            cmd.ExecuteNonQuery();
                            //con.Close();
                        }

                    }
                    foreach (int debid in debitEntry)
                    {
                        foreach (int crcnid in creditContraEntry)
                        {


                            //con = new SqlConnection(cs.DBConn);
                            string query = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                            cmd = new SqlCommand(query, con, trans);
                            cmd.Parameters.AddWithValue("d1", iTransactionId);
                            cmd.Parameters.AddWithValue("d2", debid);
                            cmd.Parameters.AddWithValue("d3", crcnid);
                            //con.Open();
                            cmd.ExecuteNonQuery();
                            //con.Close();
                        }

                    }
                    //UpdateApprovedStatus();
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string qry = "Update YearOpeningEvent set ApprovedByUId=@d1,ApprovedDateTime=@d2  where  FiscalId='" + fiscalLE3Year + "'";
                    cmd = new SqlCommand(qry, con,trans);
                    cmd.Parameters.AddWithValue("@d1", userId);
                    cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    //con.Close();
                    trans.Commit();
                    con.Close();
                    MessageBox.Show("Successfully  Approved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    this.Hide();
                    PreYearOpeningTransaction frm = new PreYearOpeningTransaction();
                    frm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error but we are Rollbacking", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trans.Rollback();
                con.Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainUI frm =new MainUI();
            frm.Show();
        }
    }
}
