using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DbGateway;
using AccountsManagementSystem.LogInUI;

namespace AccountsManagementSystem.UI
{
    public partial class LedgerEntryForIndividualPosting : Form
    {
        const int kSplashUpdateInterval_ms = 50;
        const int kMinAmountOfSplashTime_ms = 800;
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlConnection rdrCon;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private SqlTransaction trans;
        public int iTransactionId = 0, lEntryId, cEntryId, k, genericOTypeId, creditLedgerEntryId, debitContraEntryId, BDEntryId, BCEntryId;
        public string contraLedgerName, conTraLedgerId, cmb11LedgerName, firstLedgerId, ledgerId2, userId, secondLedgerId, fullName, lGenericType, aGRelId1, aGRelId2, voucherNoD;
        public decimal debitAmount = 0, creditAmount = 0, takeRemove = 0, debitBalance = 0, lDBalance = 0, lCBalance = 0, creditBalance = 0;
        public string OAgrelId, accountOTypeD, accountOType,startDateInd,endDateInd;
        public int fiscalLE1Year, lID1, lID2;
        public DateTime startDateInd1, endDateInd1;
        private delegate void ChangeFocusDelegate(Control ctl);
        public LedgerEntryForIndividualPosting()
        {
            InitializeComponent();
        }
        static Splash splash = null;

        /// <summary>
        /// Starts the splash screen on a separate thread
        /// </summary>
        static public void StartSplash()
        {
            // Instance a splash form given the image names
            splash = new Splash(kSplashUpdateInterval_ms);

            // Run the form
            Application.Run(splash);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (splash != null)
                return;

            base.OnPaint(e);
        }

        /// <summary>
        /// Paint the form background only if the splash screen is gone
        /// </summary>
        /// <param name="e">Paint event arguments</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (splash != null)
                return;

            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Shuts down and cleans up the splash screen
        /// </summary>
        private void CloseSplash()
        {
            if (splash == null)
                return;

            // Shut down the splash screen
            splash.Invoke(new EventHandler(splash.KillMe));
            splash.Dispose();
            splash = null;
        }
        public void Ledger1CmbFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(LedgerName) from Ledger,BalanceFiscal  where Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='"+fiscalLE1Year+"'  order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbInd1LedgerName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            cmbInd1LedgerName.SelectedIndex = -1;
            //txtInd1Entrydate.Value = this.txtInd1Entrydate.MaxDate;
            if (DateTime.UtcNow.ToLocalTime() > endDateInd1)
            {
                txtInd1Entrydate.Value = txtInd1Entrydate.MaxDate;

            }
            else
            {
                txtInd1Entrydate.Value = DateTime.Now;
            }
            txtInd1RequisitionNo.Clear();
            cmbVoucherNoD.Items.Remove(cmbVoucherNoD.Text);
            cmbVoucherNoD.Items.Remove(cmbVoucherNoC.Text);
            cmbVoucherNoD.Refresh();
            cmbVoucherNoC.Items.Remove(cmbVoucherNoC.Text);
            
            cmbVoucherNoC.Refresh();
           
            //cmbVoucherNoD.SelectedIndex=-1;
            txtInd1Particulars.Clear();
            txtIndDebitBalance.TextChanged -= txtDebitBalance_TextChanged;
            txtIndDebitBalance.Clear();
            txtIndDebitBalance.TextChanged += txtDebitBalance_TextChanged;
            cmbInd2LedgerName.SelectedIndex = -1;
            txtInd2FundRequisition.Clear();
            //cmbVoucherNoC.Enter -= cmbVoucherNoC_Enter;
            //cmbVoucherNoC.SelectedIndexChanged -= cmbVoucherNoC_SelectedIndexChanged;
            //cmbVoucherNoC.Leave -= cmbVoucherNoC_Leave;
            //cmbVoucherNoC.SelectedIndex=-1;
            //cmbVoucherNoC.Enter += cmbVoucherNoC_Enter;
            //cmbVoucherNoC.SelectedIndexChanged += cmbVoucherNoC_SelectedIndexChanged;
            //cmbVoucherNoC.Leave += cmbVoucherNoC_Leave;
            txtInd2Particulars.Clear();
            txtIndCrdeitBalance.Clear();
            group1.Enabled = true;
            if (textBox1.Visible)
            {
                label7.Visible = false;
                textBox1.Visible = false;
                textBox1.Clear();
                label7.Location = new Point(45, 448);
                textBox1.Location = new Point(202, 441);
                label3.Location = new Point(74, 226);
                txtInd1Particulars.Location = new Point(202, 226);
                label4.Location = new Point(45, 403);
                txtIndDebitBalance.Location = new Point(202, 400);
            }

            if (textBox2.Visible)
            {
                textBox2.Clear();
                label16.Visible = false;
                textBox2.Visible = false;
                label16.Location = new Point(58, 400);
                textBox2.Location = new Point(200, 433);
                label12.Location = new Point(81, 217);
                txtInd2Particulars.Location = new Point(200, 217);
                label13.Location = new Point(56, 393);
                txtIndCrdeitBalance.Location = new Point(200, 388);
            }
            takeRemove = 0;
            debitBalance = 0;
            lDBalance = 0;
            lCBalance = 0;
            creditBalance = 0;
            submitButton.Enabled = false;
        }
        public void VoucherNoForDebitEntry()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(VoucherNo) from VoucherNumber Where  VoucherNumber.Statuss!='Written' order by VoucherNo desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbVoucherNoD.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //public void VoucherNoForCreditEntry()
        //{
        //    try
        //    {

        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ct = "select RTRIM(VoucherNo) from VoucherNumber where  VoucherNo!='"+cmbVoucherNoD.Text+"'order by VoucherNo desc";
        //        cmd = new SqlCommand(ct);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cmbVoucherNoC.Items.Add(rdr[0]);
        //        }
        //        con.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void LedgerEntryForIndividualPosting_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            // Create a new thread from which to start the splash screen form
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            // Pretend that our application is doing a bunch of loading and
            // initialization
            Thread.Sleep(kMinAmountOfSplashTime_ms / 8);
            cmbVoucherNoD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVoucherNoC.AutoCompleteSource = AutoCompleteSource.ListItems;
            VoucherNoForDebitEntry();
            VoucherNoForCreditEntry();
            txtInd1TransactionType.Text = "Debit";
            txtInd2TransactionType.Text = "Credit";
            userId = frmLogin.uId.ToString();
            fiscalLE1Year = FiscalYear.phiscalYear;

            startDateInd1 = FiscalYear.startDate;
            endDateInd1 = FiscalYear.endDate;                     
            txtInd1Entrydate.MinDate = startDateInd1;
            txtInd1Entrydate.MaxDate = endDateInd1;
            if (DateTime.UtcNow.ToLocalTime() > endDateInd1)
            {
                txtInd1Entrydate.Value = txtInd1Entrydate.MaxDate;

            }
            else
            {
                txtInd1Entrydate.Value = DateTime.Now;
            }

            
            groupBox2.Enabled = false;
            Ledger1CmbFill();
            CloseSplash();
            Application.UseWaitCursor = false;
            cmbInd1LedgerName.Focus();
        }
        private void GetLId2()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + ledgerId2 + "' and  BalanceFiscal.FiscalId='" + fiscalLE1Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lID2 = (rdr.GetInt32(0));
            }
        }
        private void cmbInd2LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  RTRIM(Ledger.LedgerId),RTRIM(Ledger.AGRelId)  from Ledger where Ledger.LedgerName='" + cmbInd2LedgerName.Text + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId2 = (rdr.GetString(0));
                    aGRelId2 = (rdr.GetString(1));
                }
                con.Close();
                if (aGRelId2 == "4")
                {
                    label16.Visible = true;
                    textBox2.Visible = true;
                    label16.Location=new Point(58,217);
                    textBox2.Location=new Point(200,217);
                    label12.Location=new Point(81,264);
                    txtInd2Particulars.Location=new Point(200,259);
                    label13.Location=new Point(56,440);
                    txtIndCrdeitBalance.Location=new Point(200,433);
                }
                else
                {
                    textBox2.Clear();
                    label16.Visible = false;
                    textBox2.Visible = false;
                    label16.Location = new Point(58, 400);
                    textBox2.Location = new Point(200, 433);
                    label12.Location = new Point(81, 217);
                    txtInd2Particulars.Location = new Point(200, 217);
                    label13.Location = new Point(56, 393);
                    txtIndCrdeitBalance.Location = new Point(200,388);
                }
                GetLId2();
                txtInd2FundRequisition.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtDebitBalance_TextChanged(object sender, EventArgs e)
        {
            decimal val1 = 0;
            decimal val2 = 0;
            decimal.TryParse(txtIndDebitBalance.Text, out val1);
            decimal.TryParse(txtIndCrdeitBalance.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("This Credit Amount must be equal to Debit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIndCrdeitBalance.Clear();
                txtIndCrdeitBalance.Focus();
               
            }

            else
            {
                submitButton.Enabled = true;
            }
            
        }
        
        private void SaveNewTransaction()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                trans = con.BeginTransaction();
                //Save Transaction
                string cb = "insert into TransactionRecord(TransactionDate,EntryDateTime,InputBy) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtInd1Entrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d3", userId);
                iTransactionId = (int)cmd.ExecuteScalar();
                //Save Debit Entry
                if (txtInd1TransactionType.Text == "Debit")
                {
                    //SaveDebitLedgerBalance();
                    rdrCon = new SqlConnection(cs.DBConn);
                    rdrCon.Open();
                    string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + firstLedgerId + "' and BalanceFiscal.LId='" + lID1 + "'";
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
                    string query = "select AccountType from AGRel where AGRel.AGRelId='" + aGRelId1 + "'";
                    cmd = new SqlCommand(query, rdrCon);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        accountOTypeD = (rdr.GetString(0));

                    }
                    rdrCon.Close();

                    if (accountOTypeD == "Asset" || accountOTypeD == "Expense" || accountOTypeD == "Pre Opening Expense")
                    {
                        decimal a = decimal.Parse(txtIndDebitBalance.Text);
                        lDBalance = debitBalance + a;
                        //con = new SqlConnection(cs.DBConn);
                        //con.Open();
                        string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId ='" + firstLedgerId + "' and BalanceFiscal.LId='" + lID1 + "' ";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                        //con.Close();

                    }
                    if (accountOTypeD == "Liability" || accountOTypeD == "Equity" || accountOTypeD == "Revenue")
                    {
                        decimal b = decimal.Parse(txtIndDebitBalance.Text);
                        lDBalance = debitBalance - b;
                        //con = new SqlConnection(cs.DBConn);
                        //con.Open();
                        string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId ='" + firstLedgerId + "' and BalanceFiscal.LId='" + lID1 + "' ";
                        cmd = new SqlCommand(cb2);
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.ExecuteNonQuery();
                        //con.Close();

                    }
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string cb1 = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Debit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(cb1);
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@d1", txtInd1RequisitionNo.Text);
                    cmd.Parameters.AddWithValue("@d2", cmbVoucherNoD.Text);
                    cmd.Parameters.AddWithValue("@d3", txtInd1Particulars.Text);
                    cmd.Parameters.AddWithValue("@d4", decimal.Parse(txtIndDebitBalance.Text));
                    cmd.Parameters.AddWithValue("@d5", lDBalance);
                    cmd.Parameters.AddWithValue("@d6", iTransactionId);
                    cmd.Parameters.AddWithValue("@d7", lID1);
                    lEntryId = (int)cmd.ExecuteScalar();
                    //con.Close();
                    //SaveDebitContraEntry();
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string query3 = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query3, con,trans);
                    cmd.Parameters.AddWithValue("d1", cmbInd1LedgerName.Text);
                    cmd.Parameters.AddWithValue("d2", firstLedgerId);
                    debitContraEntryId = (int)cmd.ExecuteScalar();
                    //con.Close();

                    if (textBox1.Visible && !string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        //con = new SqlConnection(cs.DBConn);
                        //con.Open();
                        string X = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(X,con,trans);
                        //cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@d1", textBox1.Text);
                        cmd.Parameters.AddWithValue("@d2", lEntryId);
                        BDEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                    }
                }
                rdrCon = new SqlConnection(cs.DBConn);
                rdrCon.Open();
                string ct3 = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + ledgerId2 + "' and BalanceFiscal.LId='" + lID2 + "'";
                cmd = new SqlCommand(ct3);
                cmd.Connection = rdrCon;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    creditBalance = (rdr.GetDecimal(0));


                }
                rdrCon.Close();
                //////

                rdrCon = new SqlConnection(cs.DBConn);
                rdrCon.Open();
                string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" + aGRelId2 + "'";
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
                    decimal x = decimal.Parse(txtIndCrdeitBalance.Text);
                    lCBalance = creditBalance - x;
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId ='" + ledgerId2 + "' and BalanceFiscal.LId='" + lID2 + "' ";
                    cmd = new SqlCommand(cb2,con,trans);
                    //cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    //con.Close();

                }
                // if (genericOTypeId == 2)
                if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                {
                    decimal y = decimal.Parse(txtIndCrdeitBalance.Text);
                    lCBalance = creditBalance + y;
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId ='" +
                                 ledgerId2 + "' and BalanceFiscal.LId='" + lID2 + "' ";
                    cmd = new SqlCommand(cb2, con, trans);
                    //cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    //con.Close();


                }
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                string cb4 = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Credit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(cb4,con,trans);
                //cmd.Connection = con;
                cmd.Parameters.AddWithValue("d1", txtInd2FundRequisition.Text);
                cmd.Parameters.AddWithValue("d2", cmbVoucherNoC.Text);
                cmd.Parameters.AddWithValue("d3", txtInd2Particulars.Text);
                cmd.Parameters.AddWithValue("d4", decimal.Parse(txtIndDebitBalance.Text));
                cmd.Parameters.AddWithValue("d5", lCBalance);
                cmd.Parameters.AddWithValue("d6", iTransactionId);
                cmd.Parameters.AddWithValue("d7", lID2);
                creditLedgerEntryId = (int)cmd.ExecuteScalar();
                //con.Close();
                if (textBox2.Visible && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string R = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(R,con,trans);
                    //cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", textBox2.Text);
                    cmd.Parameters.AddWithValue("@d2", creditLedgerEntryId);
                    BCEntryId = (int)cmd.ExecuteScalar();
                    //con.Close();
                }

                //con = new SqlConnection(cs.DBConn);
                string z = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(z, con,trans);
                cmd.Parameters.AddWithValue("d1", cmbInd2LedgerName.Text);
                cmd.Parameters.AddWithValue("d2", ledgerId2);
                //con.Open();
                cEntryId = (int)cmd.ExecuteScalar();
                //con.Close();
                //con = new SqlConnection(cs.DBConn);
                string queryz = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(queryz, con,trans);
                cmd.Parameters.AddWithValue("d1", iTransactionId);
                cmd.Parameters.AddWithValue("d2", lEntryId);
                cmd.Parameters.AddWithValue("d3", cEntryId);
                //con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
                //SaveContraLCLRelation();
                //con = new SqlConnection(cs.DBConn);
                string q1z = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                cmd = new SqlCommand(q1z, con,trans);
                cmd.Parameters.AddWithValue("d1", iTransactionId);
                cmd.Parameters.AddWithValue("d2", creditLedgerEntryId);
                cmd.Parameters.AddWithValue("d3", debitContraEntryId);
                //con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
                //con = new SqlConnection(cs.DBConn);
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                string queryu1 = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + cmbVoucherNoC.Text + "' ";
                cmd = new SqlCommand(queryu1, con,trans);
                cmd.ExecuteNonQuery();
                //con.Close();
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                string queryu2 = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + cmbVoucherNoD.Text + "' ";
                cmd = new SqlCommand(queryu2, con,trans);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                con.Close();
                MessageBox.Show("Transaction Completed Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                groupBox2.Enabled = false;
                cmbInd1LedgerName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmd.Transaction.Rollback();
                con.Close();
            }

        }
       
   
        private void submitButton_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtIndCrdeitBalance.Text))
            {
                MessageBox.Show("Please Enter Debit balance", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIndDebitBalance.Focus();
                
            }

            else try
            {

                debitAmount = Convert.ToDecimal(txtIndDebitBalance.Text);
                creditAmount = Convert.ToDecimal(txtIndCrdeitBalance.Text);

                if (debitAmount == creditAmount)
                {
                    
                    SaveNewTransaction();
                    //SaveDebitEntry();
                    //UpdateLedgerCreditBalance();
                    //SaveCreditEntry();
                    //SaveContraEntry();
                    //SaveLCLRelation();
                    //UpdateCreditVoucherStatus();
                    //UpdateDebitVoucherStatus();

                }
                else
                {
                    MessageBox.Show("Your Transaction Parameters are invalid", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetLId1()
        {
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + firstLedgerId + "' and  BalanceFiscal.FiscalId='" + fiscalLE1Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lID1 = (rdr.GetInt32(0));
            }
        }
        private void cmbInd1LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(Ledger.LedgerId),RTRIM(Ledger.LedgerName),RTRIM(Ledger.AGRelId) from Ledger WHERE Ledger.LedgerName = '" + cmbInd1LedgerName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    firstLedgerId = (rdr.GetString(0));
                    cmb11LedgerName = (rdr.GetString(1));
                    aGRelId1 = (rdr.GetString(2));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (aGRelId1 == "5")
                {
                    label7.Visible = true;
                    textBox1.Visible = true;
                    label7.Location=new Point(45,226);
                    textBox1.Location= new Point(202,226);
                    label3.Location= new Point(74,278);
                    txtInd1Particulars.Location=new Point(202,271);
                    label4.Location=new Point(45,448);
                    txtIndDebitBalance.Location=new Point(202,441);

                }
                else
                {
                    label7.Visible = false;
                    textBox1.Visible = false;
                    textBox1.Clear();
                    label7.Location = new Point(45, 448);
                    textBox1.Location = new Point(202, 441);
                    label3.Location = new Point(74,226);
                    txtInd1Particulars.Location = new Point(202,226);
                    label4.Location = new Point(45, 403);
                    txtIndDebitBalance.Location = new Point(202, 400);
                }
                GetLId1();

                cmbInd1LedgerName.Text = cmbInd1LedgerName.Text.Trim();
                cmbInd2LedgerName.Items.Clear();
                cmbInd2LedgerName.ResetText();
                cmbInd2LedgerName.Enabled = true;
              //cmbInd2LedgerName.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger,BalanceFiscal  Where Ledger.LedgerName!= '" + cmb11LedgerName + "' and Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='"+fiscalLE1Year+"' order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbInd2LedgerName.Items.Add(rdr[0]);
                }
                con.Close();
                UseWaitCursor = false;
                txtInd1Entrydate.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIndDebitBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
              
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm=new JournalForLedgerEntry();
            frm.Show();
        }

        private void txtInd1RequisitionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txtInd1VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txtInd2FundRequisition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txtInd2VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtInd1Entrydate_ValueChanged(object sender, EventArgs e)
        {
            txtInd1RequisitionNo.Focus();
        }

        private void txtInd1RequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoD.Focus();
                e.Handled = true;
            }
        }

        private void txtInd1VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtInd1Particulars.Focus();
                e.Handled = true;
            }
        }

        private void txtInd1Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIndDebitBalance.Focus();
                e.Handled = true;
            }
        }

        private void txtIndDebitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbInd2LedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtInd2FundRequisition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoC.Focus();
                e.Handled = true;
            }
        }

        private void txtInd2VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                txtInd2Particulars.Focus();
                e.Handled = true;
            }
            
        }

        private void txtIndCrdeitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(this, new EventArgs());
            }
        }

        private void txtInd2Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtIndCrdeitBalance.Focus();
                e.Handled = true;
            }
        }

        private void VoucherNoForCreditEntry()
        {
            try
            {
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(VoucherNo) from  VoucherNumber  Where  VoucherNumber.Statuss!='Written' order by VoucherNumber.VoucherNo desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbVoucherNoC.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Visible == true)
            {
                textBox1.Focus();
            }
            else
            {
                txtInd1Particulars.Focus();
            }
           
        }

        private void txtInd1Particulars_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        textBox1.Focus();
                   
            //    }
      
            //else
            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoD.Focus();
      
            }
        }

        private void txtInd2Particulars_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Visible && string.IsNullOrWhiteSpace(textBox2.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        textBox2.Focus();
                   
            //    }
            
            //else 
            if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoC.Focus();
               
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIndCrdeitBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
  
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtIndDebitBalance_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace( cmbInd1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbInd1LedgerName);
               
            }
            //else if (textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        this.BeginInvoke(new ChangeFocusDelegate(changeFocus),textBox1);
                   
            //    }
            
            else if (string.IsNullOrWhiteSpace(txtInd1Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txtInd1Particulars);

            }
            else
            {
                groupBox2.Enabled = true;
            }
        }

        private void txtIndDebitBalance_Leave(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }

        private void txtIndCrdeitBalance_Enter(object sender, EventArgs e)
        {
            //if (textBox2.Visible && string.IsNullOrWhiteSpace(textBox2.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        this.BeginInvoke(new ChangeFocusDelegate(changeFocus),textBox2);
                  
            //    }
            

            //else 
                if (string.IsNullOrWhiteSpace(txtInd2Particulars.Text))
            {
                MessageBox.Show("Please Enter Debit Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txtInd2Particulars);
                
            }
           
            //submitButton.Enabled = true;
        }

        private void cmbInd2LedgerName_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIndDebitBalance.Text))
            {
                MessageBox.Show("Please Enter Debit balance", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txtIndDebitBalance);
            }
            else
            {
                group1.Enabled = false;
                cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                cmbVoucherNoC.Refresh();
            }
        }

        private void cmbVoucherNoC_Leave(object sender, EventArgs e)
        {

            if (!cmbVoucherNoC.Items.Contains(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoC.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoC);
            }
           
        }

        private void cmbVoucherNoD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbVoucherNoD.Text)&&!cmbVoucherNoD.Items.Contains(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoD.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoD);

            }
            
        }

        private void cmbVoucherNoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.Visible)
            {
                textBox2.Focus();
            }
            else
            {
                txtInd2Particulars.Focus();
            }
        }

        private void cmbVoucherNoD_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInd1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbInd1LedgerName);
                
            }
        }

        private void txtInd1RequisitionNo_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInd1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbInd1LedgerName);
            }
        }

        private void cmbVoucherNoC_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInd2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbInd2LedgerName);
            }
        }

        private void txtInd2FundRequisition_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInd2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbInd2LedgerName);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No first", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoD);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoC);
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Make sure the splash screen is closed
            CloseSplash();
            base.OnClosing(e);
        }
        private void LedgerEntryForIndividualPosting_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSplash();
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }

        private void LedgerEntryForIndividualPosting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm = new JournalForLedgerEntry();
            frm.Show();
        }
    }
}
