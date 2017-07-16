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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AccountsManagementSystem.UI
{
    public partial class YearOpeningTransaction : Form
    {

        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int iTransactionId = 0, lEntryId, cEntryId, k, genericOTypeId, creditLedgerEntryId, debitContraEntryId;
        public string contraLedgerName, conTraLedgerId, cmb11LedgerName, ledgerId1, ledgerId2, userId, secondLedgerId, fullName, lGenericType, debitAGRelId1, creditAGRelId2, creditAGRelId, cLID2,testUserType;
        public decimal takeSum1 = 0, takeSum2 = 0, takeSub1 = 0, takeSub2 = 0, takeRemove1 = 0, takeRemove2, debitBalance = 0, lDBalance = 0, lCBalance = 0, creditBalance = 0,totalDebit=0,totalCredit=0;
        public string OAgrelId, accountOTypeD, accountOType, dLId1, cLId2, aGRelId;
        public int fiscalLE2Year;
        public int dLId, cLId, debitAGRelId2, currentEventId1, currentEventId2;
        public DateTime startDateManyDManyC, endDateManyDManyC;
        public YearOpeningTransaction()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (cmb1LedgerName.Text == "")
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1LedgerName.Focus();
                return;
            }                     
            if (txt1DebitAmount.Text == "")
            {
                MessageBox.Show("Please enter  debit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1DebitAmount.Focus();
                return;
            }
            decimal debitAmount = Convert.ToDecimal(txt1DebitAmount.Text);
            if (debitAmount == 0)
            {
                MessageBox.Show("Items Can not be Added with zero values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1DebitAmount.Clear();
                txt1DebitAmount.Focus();
                return;
            }

            try
            {

                takeSum1 = takeSum1 + Convert.ToDecimal(txt1DebitAmount.Text);
                txtTotalDebitBalance.Text = Convert.ToString(takeSum1);
                if (listView1.Items.Count == 0)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(cmb1LedgerName.Text);
                    secondLedgerId = Convert.ToString(ledgerId1);
                    lst.SubItems.Add(secondLedgerId);
                    
                    lst.SubItems.Add(txt1DebitAmount.Text);
                    dLId1 = Convert.ToString(dLId);
                    lst.SubItems.Add(dLId1);
                    aGRelId = Convert.ToString(debitAGRelId1);
                    lst.SubItems.Add(aGRelId);
                    listView1.Items.Add(lst);

                    cmb2LedgerName.Items.Remove(cmb1LedgerName.Text);
                    cmb2LedgerName.Refresh();
                    cmb1LedgerName.Items.Remove(cmb1LedgerName.Text);
                    cmb1LedgerName.Refresh();

                    cmb1LedgerName.SelectedIndex = -1;
                    
                    txt1DebitAmount.Text = "";


                    return;
                }

                ListViewItem lst1 = new ListViewItem();
                lst1.SubItems.Add(cmb1LedgerName.Text);
                secondLedgerId = Convert.ToString(ledgerId1);
                lst1.SubItems.Add(secondLedgerId);               
                lst1.SubItems.Add(txt1DebitAmount.Text);
                dLId1 = Convert.ToString(dLId);
                lst1.SubItems.Add(dLId1);
                aGRelId = Convert.ToString(debitAGRelId1);
                lst1.SubItems.Add(aGRelId);

                listView1.Items.Add(lst1);
                cmb2LedgerName.Items.Remove(cmb1LedgerName.Text);
                cmb2LedgerName.Refresh();
                cmb1LedgerName.Items.Remove(cmb1LedgerName.Text);
                cmb1LedgerName.Refresh();

                cmb1LedgerName.SelectedIndex = -1;             
                txt1DebitAmount.Text = "";

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Ledger1CmbFill()
        {
            try
            {
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger where Ledger.AGRelId!='2' and Ledger.AGRelId!='3' and Ledger.AGRelId!='4' and Ledger.AGRelId!='5' order by LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmb1LedgerName.Items.Add(rdr[0]);
                }
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Ledger2CmbFill()
        {
            try
            {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger where Ledger.AGRelId!='1' and Ledger.AGRelId!='4' and Ledger.AGRelId!='5' and Ledger.AGRelId!='6' order by LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmb2LedgerName.Items.Add(rdr[0]);
                }
                con.Close();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void YearOpeningTransaction_Load(object sender, EventArgs e)
        {
            txt1TransactionType.Text = "Debit";
            txt2TransactionType.Text = "Credit";
            userId = frmLogin.uId.ToString();
            testUserType = frmLogin.userType;
            fiscalLE2Year = FiscalYear.phiscalYear;
            startDateManyDManyC = FiscalYear.startDate;
            endDateManyDManyC = FiscalYear.endDate;
            Ledger1CmbFill();
            Ledger2CmbFill();
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            takeRemove1 = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[3].Text);
            totalDebit = Convert.ToDecimal(txtTotalDebitBalance.Text);
            takeSum1 = takeSum1 - takeRemove1;
            totalDebit = totalDebit - takeRemove1;
            txtTotalDebitBalance.Text = totalDebit.ToString();


            cmb1LedgerName.Items.Add(listView1.SelectedItems[0].SubItems[1].Text);
            cmb2LedgerName.Items.Add(listView1.SelectedItems[0].SubItems[1].Text);
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void debitCompleteButton_Click(object sender, EventArgs e)
        {
            
        }

        private void creditLedgerAddButton_Click(object sender, EventArgs e)
        {
            if (cmb2LedgerName.Text == "")
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb2LedgerName.Focus();
                return;
            }

            

            if (txt2CreditAmount.Text == "")
            {
                MessageBox.Show("Please enter  credit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2CreditAmount.Focus();
                return;
            }
            decimal creditAmount = Convert.ToDecimal(txt2CreditAmount.Text);
            if (creditAmount == 0)
            {
                MessageBox.Show("Items Can not be Added with zero values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2CreditAmount.Clear();
                txt2CreditAmount.Focus();
                return;
            }

            try
            {
                takeSub2 = takeSum2;
                takeSum2 = takeSum2 + Convert.ToDecimal(txt2CreditAmount.Text);
                
                if (takeSum1 < takeSum2)
                {
                    MessageBox.Show("Your input amount exceed the limit", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    takeSum2 = takeSub2;
                    txt2CreditAmount.Text = "";
                    txt2CreditAmount.Focus();
                    return;
                }
                else
                {
                    if (listView2.Items.Count == 0)
                    {
                        ListViewItem lst10 = new ListViewItem();
                        lst10.SubItems.Add(cmb2LedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst10.SubItems.Add(secondLedgerId);
                        //lst10.SubItems.Add(txt2FundRequisition.Text);
                        //lst10.SubItems.Add(txt2VoucherNo.Text);
                        //lst10.SubItems.Add(txt2Particulars.Text);
                        lst10.SubItems.Add(txt2CreditAmount.Text);
                        cLId2 = Convert.ToString(cLId);
                        lst10.SubItems.Add(cLId2);
                        aGRelId = Convert.ToString(creditAGRelId2);
                        lst10.SubItems.Add(aGRelId);

                        listView2.Items.Add(lst10);
                        //cmb1LedgerName.Items.Remove(cmb2LedgerName.Text);
                        //cmb2LedgerName.Refresh();
                        cmb2LedgerName.Items.Remove(cmb2LedgerName.Text);
                        cmb2LedgerName.Refresh();

                        cmb2LedgerName.SelectedIndex = -1;
                        //txt2FundRequisition.Text = "";
                        //txt2VoucherNo.Text = "";
                        //txt2Particulars.Text = "";
                        txt2CreditAmount.Text = "";


                        txtTotalCreditBalance.Text = takeSum2.ToString();
                        return;
                    }

                    ListViewItem lst12 = new ListViewItem();
                    lst12.SubItems.Add(cmb2LedgerName.Text);
                    secondLedgerId = Convert.ToString(ledgerId2);
                    lst12.SubItems.Add(secondLedgerId);
                    //lst12.SubItems.Add(txt2FundRequisition.Text);
                    //lst12.SubItems.Add(txt2VoucherNo.Text);
                    //lst12.SubItems.Add(txt2Particulars.Text);
                    lst12.SubItems.Add(txt2CreditAmount.Text);
                    cLId2 = Convert.ToString(cLId);
                    lst12.SubItems.Add(cLId2);
                    aGRelId = Convert.ToString(creditAGRelId2);
                    lst12.SubItems.Add(aGRelId);

                    listView2.Items.Add(lst12);
                    cmb2LedgerName.Items.Remove(cmb2LedgerName.Text);
                    cmb2LedgerName.Refresh();

                    cmb2LedgerName.SelectedIndex = -1;
                    //txt2FundRequisition.Text = "";
                    //txt2VoucherNo.Text = "";
                    //txt2Particulars.Text = "";
                    txt2CreditAmount.Text = "";

                    txtTotalCreditBalance.Text = takeSum2.ToString();
                    return;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void creditLedgerRemoveButton_Click(object sender, EventArgs e)
        {
            takeRemove2 = Convert.ToDecimal(listView2.SelectedItems[0].SubItems[3].Text);
            totalCredit = Convert.ToDecimal(txtTotalCreditBalance.Text);
            takeSum2 = takeSum2 - takeRemove2;
            totalCredit = totalCredit - takeRemove2;
            txtTotalCreditBalance.Text = totalCredit.ToString();

            cmb2LedgerName.Items.Add(listView2.SelectedItems[0].SubItems[1].Text);
            for (int i = listView2.Items.Count - 1; i >= 0; i--)
            {
                if (listView2.Items[i].Selected)
                {
                    listView2.Items[i].Remove();
                }
            }
        }

        private void refresh2Button_Click(object sender, EventArgs e)
        {

        }

        private void GetTrialBalance()
        {
            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "fId";

            //set the parameter value
            paramDiscreteValue1.Value = fiscalLE2Year;

            //add the parameter value in the ParameterField object
            paramField1.CurrentValues.Add(paramDiscreteValue1);

            //add the parameter in the ParameterFields object
            paramFields1.Add(paramField1);

            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "AccountDb";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            TrialBalanceCN cr = new TrialBalanceCN();
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            f2.crystalReportViewer1.ReportSource = cr;
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void SaveEvent()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "insert into YearOpeningEvent(FiscalId,InputByUId,InputDateTime) values(@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@d1", fiscalLE2Year);
                cmd.Parameters.AddWithValue("@d2", userId);
                cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                currentEventId1 = (int) cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (takeSum1 != takeSum2)
                {
                    MessageBox.Show("Your Transaction Parameters(Debit & Credit) are not Equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (takeSum1 == takeSum2)
                {
                    SaveEvent();
                   
                        for (int i = 0; i <= listView1.Items.Count - 1; i++)
                        {
                           
                               

                            con=new SqlConnection(cs.DBConn);
                            con.Open();
                            string qty = "insert into MPBYearOpening(LId,CarriedBalance,EventId) values(@d1,@d2,@d3)";
                            cmd=new SqlCommand(qty,con);
                            cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[4].Text);
                            cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[3].Text);
                            cmd.Parameters.AddWithValue("@d3", currentEventId1);
                           
                            rdr = cmd.ExecuteReader();
                            con.Close();

                        }  
                    

                        for (int i = 0; i <= listView2.Items.Count - 1; i++)
                        {
          
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string qty = "insert into MPBYearOpening(LId,CarriedBalance,EventId) values(@d1,@d2,@d3)";
                                    cmd = new SqlCommand(qty, con);
                                    cmd.Parameters.AddWithValue("@d1", listView2.Items[i].SubItems[4].Text);
                                    cmd.Parameters.AddWithValue("@d2", listView2.Items[i].SubItems[3].Text);
                                    cmd.Parameters.AddWithValue("@d3", currentEventId1);
                                    rdr = cmd.ExecuteReader();
                                    con.Close();

                       }

                 }
                GetTrialBalance();

                MessageBox.Show("Balance Carry Forwarded Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
                listView2.Items.Clear();
                this.Hide();
                PreYearOpeningTransaction frm=new PreYearOpeningTransaction();
                  frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (testUserType == "SuperAdmin")
            {
                this.Hide();
                PreYearOpeningTransaction frm = new PreYearOpeningTransaction();
                frm.Show();
            }
            if (testUserType == "Admin")
            {
                this.Hide();
               MainUIForAdmin frm=new MainUIForAdmin();
                frm.Show();
            }
           
        }
        private void GetLId1()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + ledgerId1 + "' and  BalanceFiscal.FiscalId='" + fiscalLE2Year + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    dLId = (rdr.GetInt32(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmb1LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
           // txt1RequisitionNo.Focus();
            try
            {

                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(Ledger.LedgerId),RTRIM(Ledger.LedgerName),RTRIM(Ledger.AGRelId) from Ledger WHERE Ledger.LedgerName = '" + cmb1LedgerName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId1 = (rdr.GetString(0));
                    cmb11LedgerName = (rdr.GetString(1));
                    debitAGRelId1 = (rdr.GetString(2));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                GetLId1();
                //cmb1LedgerName.Text = cmb1LedgerName.Text.Trim();
                //cmb2LedgerName.Items.Clear();
                //cmb2LedgerName.Text = "";
                //cmb2LedgerName.Enabled = true;
                //cmb2LedgerName.Focus();

                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string ct = "select RTRIM(Ledger.LedgerName) from Ledger  Where Ledger.LedgerName!= '" + cmb11LedgerName + "' order by Ledger.LedgerId desc";
                //cmd = new SqlCommand(ct);
                //cmd.Connection = con;
                //rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    cmb2LedgerName.Items.Add(rdr[0]);
                //}
                //con.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetLId2()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + ledgerId2 + "' and  BalanceFiscal.FiscalId='" + fiscalLE2Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                cLId = (rdr.GetInt32(0));
            }
        }
        private void cmb2LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt2FundRequisition.Focus();
            try
            {
                group1.Enabled = false;
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  RTRIM(Ledger.LedgerId),RTRIM(Ledger.AGRelId)  from Ledger where Ledger.LedgerName='" + cmb2LedgerName.Text + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId2 = (rdr.GetString(0));
                    creditAGRelId2 = (rdr.GetString(1));
                }
                con.Close();
                GetLId2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void debitCompleteButton_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonDebitComplete_Click(object sender, EventArgs e)
        {
            group1.Enabled = false;
            groupBox2.Enabled = true;
        }
    }
}
