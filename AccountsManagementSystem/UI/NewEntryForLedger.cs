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
    public partial class NewEntryForLedger : Form
    {
        const int kSplashUpdateInterval_ms = 50;
        const int kMinAmountOfSplashTime_ms = 800;
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int  iTransactionId = 0, lEntryId, cEntryId, k, genericOTypeId,creditLedgerEntryId,debitContraEntryId;
        public string contraLedgerName, conTraLedgerId, cmb11LedgerName, ledgerId1, ledgerId2, userId, secondLedgerId, fullName, lGenericType, debitAGRelId1, creditAGRelId2,creditAGRelId,cLID2,voucherNoD;
        public decimal takeSum=0, takeSub=0,takeRemove=0,debitBalance=0,lDBalance=0,lCBalance=0,creditBalance=0;
        public string OAgrelId, accountOTypeD, accountOType;
        public int fiscalLE2Year;
        public int dLId, cLId,max2;
        public DateTime startDateOneDManyC, endDateOneDManyC;
        private delegate void ChangeFocusDelegate(Control ctl);
        public NewEntryForLedger()
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
        
        public void Ledger2FillCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(LedgerName) from Ledger where Ledger.LedgerName!='"+cmb1LedgerName.Text+"' order by LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmb2LedgerName.Items.Add(rdr[0]);
                }
                con.Close();

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
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger,BalanceFiscal where Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='" + fiscalLE2Year + "' order by Ledger.LedgerId desc";
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
        public void VoucherNoForDebitEntry()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(VoucherNo) from VoucherNumber  where VoucherNumber.Statuss!='Written' order by VoucherNo desc";
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
        public void VoucherNoForCreditEntry()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(VoucherNo) from  VoucherNumber  Where  VoucherNumber.Statuss!='Written'  order by VoucherNumber.VoucherNo desc";
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
        private void NewEntryForLedger_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            // Create a new thread from which to start the splash screen form
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            // Pretend that our application is doing a bunch of loading and
            // initialization
            Thread.Sleep(kMinAmountOfSplashTime_ms / 8);

            // Sit and spin while we wait for the minimum timer interval if
            // the interval has not already passed
            //while (splash.GetUpMilliseconds() < kMinAmountOfSplashTime_ms)
            //{
            //    Thread.Sleep(kSplashUpdateInterval_ms / 8);
            //}

            // Close the splash screen
            
            VoucherNoForDebitEntry();
            VoucherNoForCreditEntry();


            txt1TransactionType.Text = "Debit";
            txt2TransactionType.Text = "Credit";
            userId = frmLogin.uId.ToString();
            fiscalLE2Year = FiscalYear.phiscalYear;
            groupBox2.Enabled = false;
            Ledger1CmbFill();


            startDateOneDManyC = FiscalYear.startDate;
            endDateOneDManyC = FiscalYear.endDate;           
            txt1Entrydate.MinDate = startDateOneDManyC;
            txt1Entrydate.MaxDate = endDateOneDManyC;

            cmbVoucherNoD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVoucherNoC.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (DateTime.UtcNow.ToLocalTime() > endDateOneDManyC)
            {
                txt1Entrydate.Value = txt1Entrydate.MaxDate;

            }
            else
            {
                txt1Entrydate.Value = DateTime.Now;
            }
           
            CloseSplash();
            Application.UseWaitCursor = false;
            
        }

        public void GetLedgerId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT RTRIM(Ledger.LedgerId)  from  Ledger.LedgerName = '" + cmb1LedgerName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId1 = (rdr.GetString(0));
                   
                   
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm = new JournalForLedgerEntry();
            frm.Show();
        }

        private void Reset()
        { 
            
            if (DateTime.UtcNow.ToLocalTime() > endDateOneDManyC)
            {
                txt1Entrydate.Value = txt1Entrydate.MaxDate;

            }
            else
            {
                txt1Entrydate.Value = DateTime.Now;
            }
            cmb1LedgerName.SelectedIndex = -1;
            txt1RequisitionNo.Clear();
            cmbVoucherNoD.SelectedIndex=-1;
            txt1Particulars.Clear();
            textBox1.Clear();
            //txt1Amount.TextChanged -= txt1Amount_TextChanged;
            txt1Amount.Clear();
           // txt1Amount.TextChanged += txt1Amount_TextChanged;
            cmb2LedgerName.SelectedIndex = -1;
            txt2FundRequisition.Clear();
            cmbVoucherNoC.SelectedIndexChanged -= cmbVoucherNoC_SelectedIndexChanged;
            cmbVoucherNoC.SelectedIndex =-1;
            cmbVoucherNoC.SelectedIndexChanged += cmbVoucherNoC_SelectedIndexChanged;
            textBox2.Clear();
            txt2Particulars.Clear();
            txt2Amount.Clear();
            
            
            label7.Visible = false;
            textBox2.Visible = false;
            label16.Visible = false;
            textBox1.Visible = false;
            group1.Enabled = true;
            groupBox2.Enabled = false;
            addButton.Enabled = true;
            addButton.Visible = true;
            submitButton.Enabled = false;
            submitButton.Visible = false;
            button1.Enabled = false;
            button1.Visible = true;
            listView1.Items.Clear();
            takeSum = 0; 
            takeSub=0;
            takeRemove=0;
            debitBalance = 0;
            lDBalance = 0;
            lCBalance = 0;
            creditBalance=0;
        }
        private void txtReceive_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
            
            }
        }

        private void txtExpence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
             
            }
        }

        private void dynamicButton_Click(object sender, EventArgs e)
        {
            AddNewTextBox();
        }

        private int A = 1;

        public System.Windows.Forms.TextBox AddNewTextBox()
        {
            System.Windows.Forms.TextBox txt1 = new System.Windows.Forms.TextBox();
            this.Controls.Add(txt1);
            txt1.Top = A*28;
            txt1.Left = 150;
            txt1.Text = "ContraLedgerName" + this.A.ToString();
            A = A + 1;
            return txt1;

        }

        private void adToChartButton_Click(object sender, EventArgs e)
        {         
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Reset();
            //groupBox2.Enabled = false;


        }

        private void cmb1LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb1TransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmb1TransactionType.Text == "Debit")
            //{
            //    txt2TransactionType.Text = "Credit";
            //}
            //if (cmb1TransactionType.Text == "Credit")
            //{
            //    txt2TransactionType.Text = "Debit";
            //}
        }
        private void GetLId1()
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
        private void cmb1LedgerName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
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
                cmb1LedgerName.Text = cmb1LedgerName.Text.Trim();
                cmb2LedgerName.Items.Clear();
                cmb2LedgerName.ResetText();
                cmb2LedgerName.Enabled = true;
                //cmb2LedgerName.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger,BalanceFiscal  Where Ledger.LedgerName!= '" + cmb11LedgerName + "' and Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='"+fiscalLE2Year+"' order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmb2LedgerName.Items.Add(rdr[0]);
                }
                con.Close();
                if (debitAGRelId1 == "5")
                {
                    label16.Visible = true;
                    textBox1.Visible = true;
                    label16.Location = new Point(36, 203);
                    textBox1.Location = new Point(195, 203);
                    label3.Location = new Point(65, 249);
                    txt1Particulars.Location = new Point(195, 245);
                    label4.Location = new Point(45, 372);
                    txt1Amount.Location = new Point(195, 368);
                    txt1Entrydate.Focus();

                }
                else
                {
                    label16.Visible = false;
                    textBox1.Visible = false;
                    textBox1.Clear();
                    label16.Location = new Point(36,372);
                    textBox1.Location = new Point(195, 368);
                    label3.Location = new Point(65, 203);
                    txt1Particulars.Location = new Point(195, 203);
                    label4.Location = new Point(45, 329);
                    txt1Amount.Location = new Point(195, 329);
                    txt1Entrydate.Focus();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreditOptionClear()
        {
            cmb2LedgerName.SelectedIndex = -1;
            txt2FundRequisition.Clear();
            txt2Particulars.Clear();
            cmbVoucherNoC.SelectedIndex=-1;
            txt2Amount.Clear();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmb2LedgerName.Focus();
            }
           
            else if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type or Select Voucher No.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoC);
            }
            else if (textBox2.Visible && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox2);

            }
            else if (string.IsNullOrWhiteSpace(txt2Particulars.Text))
            {
                MessageBox.Show("Please type Particulars", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2Particulars.Focus();
            }

            else if (string.IsNullOrWhiteSpace(txt2Amount.Text))
            {
                MessageBox.Show("Please enter  credit amount.", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txt2Amount.Focus();
            }

            else if ((listView1.Items.Count + 1) > Convert.ToInt32(txtCEntryNo.Text))
                {
                    MessageBox.Show("You can not  add more item than Your Propossal item", "error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    CreditOptionClear();
                    listView1.Focus();
                }
           
            else
            {
               
                try
                {
                    decimal val1 = 0;
                    decimal.TryParse(txt1Amount.Text, out val1);

                    takeSub = takeSum;
                    takeSum = takeSum + Convert.ToDecimal(txt2Amount.Text);
                    if (val1 < takeSum)
                    {
                        MessageBox.Show("Your input amount exceed the limit", "Input Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        takeSum = takeSub;
                        txt2Amount.Clear();
                        txt2Amount.Focus();
                    }
                    else if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.SubItems.Add(cmb2LedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst.SubItems.Add(secondLedgerId);
                        lst.SubItems.Add(txt2FundRequisition.Text);
                        lst.SubItems.Add(cmbVoucherNoC.Text);
                        lst.SubItems.Add(txt2Particulars.Text);
                        lst.SubItems.Add(txt2Amount.Text);
                        cLID2 = Convert.ToString(cLId);
                        lst.SubItems.Add(cLID2);
                        creditAGRelId = Convert.ToString(creditAGRelId2);
                        lst.SubItems.Add(creditAGRelId);
                        if (textBox2.Visible)
                        {
                            lst.SubItems.Add(textBox2.Text);
                        }
                        listView1.Items.Add(lst);
                        if (textBox2.Visible)
                        {
                            label7.Visible = false;
                            textBox2.Visible = false;
                            textBox2.Clear();
                            label7.Location = new Point(61, 368);
                            textBox2.Location = new Point(213, 365);
                            label12.Location = new Point(88, 189);
                            txt2Particulars.Location = new Point(213, 189);
                            label13.Location = new Point(70, 320);
                            txt2Amount.Location = new Point(213, 319);
                        }
                        txt2Amount.Clear();
                        txt2FundRequisition.Clear();                                               
                        txt2Particulars.Clear();                       
                        cmbVoucherNoC.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged -= cmb2LedgerName_SelectedIndexChanged;
                        cmb2LedgerName.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged += cmb2LedgerName_SelectedIndexChanged;
                        button1.Visible = true;
                        button1.Enabled = true;

                    }
                    else
                    {
                        ListViewItem lst1 = new ListViewItem();
                        lst1.SubItems.Add(cmb2LedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst1.SubItems.Add(secondLedgerId);
                        lst1.SubItems.Add(txt2FundRequisition.Text);
                        lst1.SubItems.Add(cmbVoucherNoC.Text);
                        lst1.SubItems.Add(txt2Particulars.Text);
                        lst1.SubItems.Add(txt2Amount.Text);
                        cLID2 = Convert.ToString(cLId);
                        lst1.SubItems.Add(cLID2);
                        creditAGRelId = Convert.ToString(creditAGRelId2);
                        lst1.SubItems.Add(creditAGRelId);
                        if (textBox2.Visible)
                        {
                            lst1.SubItems.Add(textBox2.Text);
                        }
                        listView1.Items.Add(lst1);
                        if (textBox2.Visible)
                        {
                            label7.Visible = false;
                            textBox2.Visible = false;
                            textBox2.Clear();
                            label7.Location = new Point(61, 368);
                            textBox2.Location = new Point(213, 365);
                            label12.Location = new Point(88, 189);
                            txt2Particulars.Location = new Point(213, 189);
                            label13.Location = new Point(70, 320);
                            txt2Amount.Location = new Point(213, 319);
                        }

                        txt2Amount.Clear();
                        txt2FundRequisition.Clear();
                        txt2Particulars.Clear();
                        cmbVoucherNoC.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged -= cmb2LedgerName_SelectedIndexChanged;
                        cmb2LedgerName.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged += cmb2LedgerName_SelectedIndexChanged;

                        if (listView1.Items.Count == int.Parse(txtCEntryNo.Text))
                        {
                            addButton.Enabled = false;
                            addButton.Visible = false;
                            submitButton.Enabled = true;
                            submitButton.Visible = true;
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SaveDebitContraEntry()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("d1", cmb1LedgerName.Text);
                cmd.Parameters.AddWithValue("d2", ledgerId1);
                con.Open();
                debitContraEntryId = (int) cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                //for (int p = 1; p<= max2; p++)
                //{
                   
                //}
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
        private void SaveNewTransaction()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cb = "insert into TransactionRecord(TransactionDate,EntryDateTime,InputBy) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txt1Entrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
            cmd.Parameters.AddWithValue("@d2",DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d3", userId);
            iTransactionId = (int)cmd.ExecuteScalar();
            con.Close();

        }

        private void SaveDebitLedgerBalance()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + ledgerId1 + "' and BalanceFiscal.LId='" + dLId + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    debitBalance = (rdr.GetDecimal(0));      
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "select AccountType from AGRel where AGRel.AGRelId='" + debitAGRelId1 + "'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    accountOTypeD = (rdr.GetString(0));

                }
                con.Close();

                if (accountOTypeD == "Asset" || accountOTypeD == "Expense" || accountOTypeD == "Pre Opening Expense")
                {
                    decimal a = decimal.Parse(txt1Amount.Text);
                    lDBalance = debitBalance + a;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId ='" + ledgerId1 + "' and BalanceFiscal.LId='" + dLId + "' ";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();

                }
                if (accountOTypeD == "Liability" || accountOTypeD == "Equity" || accountOTypeD == "Revenue")
                {
                    decimal b = decimal.Parse(txt1Amount.Text);
                    lDBalance = debitBalance - b;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId ='" + ledgerId1 + "' and BalanceFiscal.LId='" + dLId + "' ";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDebitVoucherStatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + cmbVoucherNoD.Text + "' ";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCreditVoucherStatus()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + cmbVoucherNoC.Text + "' ";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != Convert.ToInt32(txtCEntryNo.Text))
            {
                MessageBox.Show("Number Of Credit Entry does not match....Please Check before Submit", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }

            else try
            {
                if (takeSum > Convert.ToDecimal(txt1Amount.Text) || takeSum < Convert.ToDecimal(txt1Amount.Text))
                {
                    MessageBox.Show("Your Transaction Parameters(Debit & Credit amount ) are not Equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }

                else  if (takeSum == Convert.ToDecimal(txt1Amount.Text))
                {
                        SaveNewTransaction();
                        max2 = Convert.ToInt32(txtCEntryNo.Text);
                        SaveDebitLedgerBalance();
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string qry = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Debit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(qry);
                        cmd.Connection = con;                       
                        cmd.Parameters.AddWithValue("@d1", txt1RequisitionNo.Text);
                        cmd.Parameters.AddWithValue("@d2", cmbVoucherNoD.Text);
                        cmd.Parameters.AddWithValue("@d3", txt1Particulars.Text);
                        cmd.Parameters.AddWithValue("@d4", decimal.Parse(txt1Amount.Text));
                        cmd.Parameters.AddWithValue("@d5", lDBalance);
                        cmd.Parameters.AddWithValue("@d6", iTransactionId);
                        cmd.Parameters.AddWithValue("@d7", dLId);
                        lEntryId = (int) cmd.ExecuteScalar();
                        con.Close();
                        if (textBox1.Visible)
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string X = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)";
                            cmd = new SqlCommand(X);
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@d1", textBox1.Text);
                            cmd.Parameters.AddWithValue("@d2", lEntryId);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        SaveDebitContraEntry();


                   //Credit Entry Start here
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {                       
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId='" + listView1.Items[i].SubItems[7].Text + "' ";
                                cmd = new SqlCommand(ct);
                                cmd.Connection = con;
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    creditBalance = (rdr.GetDecimal(0));                                    
                                }
                                con.Close();
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" +listView1.Items[i].SubItems[8].Text + "'";
                                cmd = new SqlCommand(q1, con);
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    accountOType = (rdr.GetString(0));                                    
                                }
                                con.Close();
                                //if (genericOTypeId == 1)
                                if (accountOType == "Asset" || accountOType == "Expense" || accountOType == "Pre Opening Expense")                                
                                {
                                    decimal x = decimal.Parse(listView1.Items[i].SubItems[6].Text);
                                    lCBalance = creditBalance - x;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();
                                }
                                // if (genericOTypeId == 2)
                                 if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")                              
                                {
                                    decimal y = decimal.Parse(listView1.Items[i].SubItems[6].Text);
                                    lCBalance = creditBalance + y;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "'and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();
                                }
                            con = new SqlConnection(cs.DBConn);
                            string cb = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Credit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d4", decimal.Parse(listView1.Items[i].SubItems[6].Text));
                            cmd.Parameters.AddWithValue("d5", lCBalance);
                            cmd.Parameters.AddWithValue("d6", iTransactionId);
                            cmd.Parameters.AddWithValue("d7", listView1.Items[i].SubItems[7].Text);
                            con.Open();
                            creditLedgerEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                            if (listView1.Items[i].SubItems[8].Text == "4")
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string Y = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)";
                                cmd = new SqlCommand(Y);
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[9].Text);
                                cmd.Parameters.AddWithValue("@d2", creditLedgerEntryId);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            con = new SqlConnection(cs.DBConn);
                            string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[2].Text);
                            con.Open();
                            cEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                            SaveLCLRelation();
                    }                    
                    UpdateDebitVoucherStatus();
                    UpdateCreditVoucherStatus();
                    MessageBox.Show("Transaction Completed Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Reset();
                    this.Hide();
                    PreliStepsOfLedgerEntry frmk = new PreliStepsOfLedgerEntry();
                    frmk.Show();
                    
                }
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           
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
            
            try
            {
                
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
                //if (creditAGRelId2 == "4")
                //{
                //    label7.Visible = true;
                //    textBox2.Visible = true;
                //    label7.Location = new Point(61, 189);
                //    textBox2.Location = new Point(213, 189);
                //    label12.Location = new Point(88, 237);
                //    txt2Particulars.Location = new Point(213,234);
                //    label13.Location = new Point(70, 368);
                //    txt2Amount.Location = new Point(213, 365);

                //}
                //else
                //{
                //    label7.Visible = false;
                //    textBox2.Visible = false;
                //    textBox2.Clear();
                //    label7.Location = new Point(61, 368);
                //    textBox2.Location = new Point(213, 365);
                //    label12.Location = new Point(88, 189);
                //    txt2Particulars.Location = new Point(213, 189);
                //    label13.Location = new Point(70, 320);
                //    txt2Amount.Location = new Point(213, 319);
                //}
                GetLId2();
                txt2FundRequisition.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt2Amount_TextChanged_1(object sender, EventArgs e)
        {
            decimal val1 = 0;
            decimal val2 = 0;
            decimal.TryParse(txt1Amount.Text, out val1);
            decimal.TryParse(txt2Amount.Text, out val2);
            if (val2 > val1)
            {
                MessageBox.Show("This Amount must be less than  Ledger '"+txt1TransactionType.Text+"' amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2Amount.Clear();
                txt2Amount.Focus();
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count < 1)
            {
                MessageBox.Show("Select Something to Remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                takeRemove = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[6].Text);
                takeSum = takeSum - takeRemove;

                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Remove();
                    }
                }
                if (listView1.Items.Count < 1)
                {
                    button1.Enabled = false;
                    button1.Visible = false;
                    submitButton.Enabled = false;
                    submitButton.Visible = false;
                    addButton.Enabled = true;
                    addButton.Visible = true;
                }
                if (listView1.Items.Count > 0 && listView1.Items.Count < int.Parse(txtCEntryNo.Text))
                {
                    submitButton.Enabled = false;
                    submitButton.Visible = false;
                    addButton.Enabled = true;
                    addButton.Visible = true;
                }
            }
            
        }

        private void txt1Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt2Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt1RequisitionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                
            }
        }

        private void txt1VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txt2FundRequisition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
             
            }
        }

        private void txt2VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                
            }
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
                            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt1Entrydate_ValueChanged(object sender, EventArgs e)
        {
            txt1RequisitionNo.Focus();
        }

        private void txt1RequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoD.Focus();
                e.Handled = true;
            }
        }

        private void txt1VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Visible )
                {
                    textBox1.Focus();
                }
                else
                {
                    txt1Particulars.Focus();
                }

                e.Handled = true;
            }
        }

        private void txt1Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt1Amount.Focus();
                e.Handled = true;
            }
        }

        private void txt1Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmb2LedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txt2FundRequisition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoC.Focus();
                e.Handled = true;
            }
        }

        private void txt2VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Visible)
                {
                    textBox2.Focus();
                    e.Handled = true;
                }
                else
                {
                    txt2Particulars.Focus();
                    e.Handled = true;   
                }
                
            }
        }

        private void txt2Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt2Amount.Focus();
                e.Handled = true;
            }
        }

        private void txt2Amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(this, new EventArgs());
            }
        }
       
        private void cmbVoucherNoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //cmd = con.CreateCommand();
                //cmd.CommandText = "SELECT  RTRIM(VoucherNo) from VoucherNumber WHERE VoucherNumber.VoucherNo = '" + cmbVoucherNoD.Text + "'";
                //rdr = cmd.ExecuteReader();

                //if (rdr.Read())
                //{

                //    voucherNoD = (rdr.GetString(0));
                    

                //}

                //if ((rdr != null))
                //{
                //    rdr.Close();
                //}
                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //cmb2LedgerName.Items.Remove(cmb1LedgerName.Text);
                //cmb2LedgerName.Refresh();

                //cmbVoucherNoD.Text = cmbVoucherNoD.Text.Trim();
                //cmbVoucherNoC.Items.Clear();
                //cmbVoucherNoC.Text = "";
                //cmbVoucherNoC.Enabled = true;
                //cmbVoucherNoC.Focus();

                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string ct = "select RTRIM(VoucherNo) from  VoucherNumber  Where  VoucherNumber.Statuss!='Written' and  VoucherNumber.VoucherNo!= '" + voucherNoD + "'  order by VoucherNumber.VoucherNo desc";
                //cmd = new SqlCommand(ct);
                //cmd.Connection = con;
                //rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    cmbVoucherNoC.Items.Add(rdr[0]);
                //}
                //con.Close();
                if (textBox1.Visible)
                {
                    textBox1.Focus();
                }
                else
                {
                    txt1Particulars.Focus();
                }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txt1Particulars_Enter(object sender, EventArgs e)
        {
           
        }

        private void txt1Amount_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb1LedgerName);
               
            }
            else if (textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                   MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox1);
                    
                
            }
            else if (string.IsNullOrWhiteSpace(txt1Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt1Particulars);
                
            }
            else
            {
                groupBox2.Enabled = true;  
            }
           
        }

        private void cmb2LedgerName_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt1Amount.Text))
            {
                    MessageBox.Show("Please Enter Debit balance", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt1Amount);
                }
            else
            {
                group1.Enabled = false;
                cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                cmbVoucherNoC.Refresh();
            }
           
        }

        private void txt2Particulars_Enter(object sender, EventArgs e)
        {
           
        }

        private void txt2Amount_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb2LedgerName);
                
            }
            else if (textBox2.Visible && string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox2);
                    
            }
            else if (string.IsNullOrWhiteSpace(txt2Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt2Particulars);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No first", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoD);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoC);
            }
        }

        private void cmbVoucherNoC_Enter(object sender, EventArgs e)
        {

            //if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            //{
            //    MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb2LedgerName);
            //}
        }

        private void cmbVoucherNoD_Enter(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb1LedgerName);
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

        private void cmbVoucherNoC_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbVoucherNoC.Text)&&!cmbVoucherNoC.Items.Contains(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoC.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoC);
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
                txt2Particulars.Focus();
            }
        }

        private void txt1RequisitionNo_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb1LedgerName);
            }
        }

        private void txt2FundRequisition_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb2LedgerName);
            }
        }

        private void addButton_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            //{
            //    MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmb2LedgerName);
            //}

            //else if (string.IsNullOrWhiteSpace(txt2Particulars.Text))
            //{
            //    MessageBox.Show("You must enter Particulars", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt2Particulars);
            //}

            //else if (string.IsNullOrWhiteSpace(txt2Amount.Text))
            //{
            //    MessageBox.Show("Please enter  credit amount.", "Input Error", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt2Amount);
            //}
        }

        private void NewEntryForLedger_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            PreliStepsOfLedgerEntry frm = new PreliStepsOfLedgerEntry();
            frm.Show();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Make sure the splash screen is closed
            CloseSplash();
            base.OnClosing(e);
        }
        private void NewEntryForLedger_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseSplash();
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }

        private void cmb1LedgerName_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(cmb1LedgerName, (string)cmb1LedgerName.SelectedItem);
        }

        private void cmb1LedgerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }
            Point p = new Point(cmb1LedgerName.Location.X + 120, cmb1LedgerName.Location.Y + cmb1LedgerName.Height + (30 + e.Index * 10));
            Font drawFont = new Font("Times New Roman", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
              //  toolTip1.Show(cmb1LedgerName.Items[e.Index].ToString(), this, p);
            }
           
                e.DrawBackground();
                e.Graphics.DrawString(cmb1LedgerName.Items[e.Index].ToString(), drawFont, Brushes.Black,
                    new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void cmb2LedgerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }
            Point p = new Point(cmb2LedgerName.Location.X + 200, cmb2LedgerName.Location.Y + cmb2LedgerName.Height + (30 + e.Index * 10));
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {

               // toolTip2.Show(cmb2LedgerName.Items[e.Index].ToString(), this, p);

            }

            e.DrawBackground();
            e.Graphics.DrawString(cmb2LedgerName.Items[e.Index].ToString(), e.Font, Brushes.Black, new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(toolTip1.GetToolTip(e.AssociatedControl),new Font("Arial", 16.0f));
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 16.0f);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2)); 
        }

        private void cmb1LedgerName_Leave(object sender, EventArgs e)
        {
            toolTip1.Dispose();
        }

        private void cmb2LedgerName_Leave(object sender, EventArgs e)
        {
            toolTip2.Dispose();
        }

        private void toolTip2_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 16.0f);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2)); 
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(toolTip2.GetToolTip(e.AssociatedControl), new Font("Arial", 16.0f));
        }
      }
    }

