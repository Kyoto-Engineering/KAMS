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
    public partial class LedgerEntryForOneCreditManyDebit : Form
    {
        const int kSplashUpdateInterval_ms = 50;
        const int kMinAmountOfSplashTime_ms = 800;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlTransaction trans;
        ConnectionString cs=new ConnectionString();
        private SqlConnection rdrCon;
        public int  iTransactionId = 0, lEntryId, cEntryId, k,  genericOTypeId, creditLedgerEntryId, debitContraEntryId;
        public string contraLedgerName, conTraLedgerId, cmb11LedgerName, firstLedgerId, ledgerId2, userId, secondLedgerId, fullName, lGenericType, creditAGRelId1, debitAGRelId2, aGRelId, voucherNoD;
        public decimal takeSum = 0, takeSub = 0, takeRemove = 0, creditBalance1 = 0, lCBalance1 = 0, lDBalance2 = 0, debitBalance2 = 0;
        public string OAgrelId, accountOTypeD, accountOType, dLId2;
        public int fiscalLE3Year,cLId,dLId;
        public static DateTime startDateOneCManyD, endDateOneCManyD;
        private delegate void ChangeFocusDelegate(Control ctl);
        public LedgerEntryForOneCreditManyDebit()
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
        private void Reset()
        {
            cmbCreditLedgerName.SelectedIndex = -1;
            txtC1DM1Entrydate.Value = this.txtC1DM1Entrydate.MaxDate;
            txtC1DM1RequisitionNo.Clear();
            cmbVoucherNoD.ResetText();
            cmbVoucherNoD.Items.Clear();
            VoucherNoForDebitEntry();
            txtC1DM1Particulars.Clear();
            txtC1DM1CreditBalance.TextChanged -= txtC1DM1CreditBalance_TextChanged;
            txtC1DM1CreditBalance.Clear();
            txtC1DM1CreditBalance.TextChanged += txtC1DM1CreditBalance_TextChanged;
            cmbDebitLedgerName.SelectedIndex = -1;
            txtc1DM2FundRequisition.Clear();
            cmbVoucherNoC.ResetText();
            cmbVoucherNoC.Items.Clear();
            VoucherNoForDebitEntry();
            txtC1DM2Particulars.Clear();
            txtC1DM2DebitBalance.Clear();
            label7.Visible = false;
            label5.Visible=false;
            textBox1.Clear();
            textBox1.Visible = false;
            textBox2.Clear();
            textBox2.Visible = false;
            group1.Enabled = true;
            listView1.Items.Clear();
            takeSum = 0;
            takeSub = 0;
            takeRemove = 0;
            creditBalance1 = 0;
            lCBalance1 = 0;
            lDBalance2 = 0;
            debitBalance2 = 0;
        }

        public void DebitLedgerCmbFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Ledger.LedgerName) from Ledger,BalanceFiscal where Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='" + fiscalLE3Year + "' order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbDebitLedgerName.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreditLedgerCmbFill()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select RTRIM(Ledger.LedgerName) from Ledger,BalanceFiscal  where Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='"+fiscalLE3Year+"' order by Ledger.LedgerId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbCreditLedgerName.Items.Add(rdr[0]);
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
        public void VoucherNoForCreditEntry()
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
        private void LedgerEntryForOneCreditManyDebit_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            // Create a new thread from which to start the splash screen form
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            // Pretend that our application is doing a bunch of loading and
            // initialization
            Thread.Sleep(kMinAmountOfSplashTime_ms / 8);
            group1.Enabled = false;
            VoucherNoForDebitEntry();
            VoucherNoForCreditEntry();
            txtC1DM1TransactionType.Text = "Credit";
            txtC1DM2TransactionType.Text = "Debit";
            cmbCreditLedgerName.Focus();
            userId = frmLogin.uId.ToString();
            fiscalLE3Year =FiscalYear.phiscalYear;
            groupBox1.Enabled = true;
            DebitLedgerCmbFill();
            CreditLedgerCmbFill();


            startDateOneCManyD = FiscalYear.startDate;
            endDateOneCManyD = FiscalYear.endDate;
           
            txtC1DM1Entrydate.MinDate = startDateOneCManyD;
            txtC1DM1Entrydate.MaxDate = endDateOneCManyD;

            cmbVoucherNoD.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbVoucherNoC.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (DateTime.UtcNow.ToLocalTime() > endDateOneCManyD)
            {
                txtC1DM1Entrydate.Value = txtC1DM1Entrydate.MaxDate;

            }
            else
            {
                txtC1DM1Entrydate.Value = DateTime.Now;
            }
            CloseSplash();
            Application.UseWaitCursor = false;
            txtC1DM1Entrydate.Focus();

        }
        private void GetLId11()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + firstLedgerId + "' and  BalanceFiscal.FiscalId='" + fiscalLE3Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                cLId = (rdr.GetInt32(0));
            }
        }
        private void cmbC1DM1LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                con = new SqlConnection(cs.DBConn);

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(Ledger.LedgerId),RTRIM(Ledger.LedgerName),RTRIM(Ledger.AGRelId) from Ledger WHERE Ledger.LedgerName = '" + cmbCreditLedgerName.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    firstLedgerId = (rdr.GetString(0));
                    cmb11LedgerName = (rdr.GetString(1));
                    creditAGRelId1 = (rdr.GetString(2));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (creditAGRelId1 == "4")
                {
                    label5.Visible = true;
                    textBox2.Visible = true;
                    label5.Location = new Point(44, 226);
                    textBox2.Location = new Point(202, 226);
                    label3.Location = new Point(74, 274);
                    txtC1DM1Particulars.Location = new Point(202, 267);
                    label4.Location = new Point(45, 442);
                    txtC1DM1CreditBalance.Location = new Point(202, 435);

                }
                else
                {
                    label5.Visible = false;
                    textBox2.Visible = false;
                    textBox2.Clear();
                    label5.Location = new Point(44, 442);
                    textBox2.Location = new Point(202, 435);


                    label3.Location = new Point(74, 226);
                    txtC1DM1Particulars.Location = new Point(202, 226);
                    label4.Location = new Point(45, 398);
                    txtC1DM1CreditBalance.Location = new Point(202, 395);

                }
                GetLId11();

                //cmbCreditLedgerName.Text = cmbCreditLedgerName.Text.Trim();
                //cmbDebitLedgerName.Items.Clear();
                //cmbDebitLedgerName.Clear();
                //cmbDebitLedgerName.Enabled = true;
                //cmbDebitLedgerName.Focus();

                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string ct = "select RTRIM(Ledger.LedgerName) from Ledger  Where Ledger.LedgerName!= '" + cmb11LedgerName + "' order by Ledger.LedgerId desc";
                //cmd = new SqlCommand(ct);
                //cmd.Connection = con;
                //rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    cmbDebitLedgerName.Items.Add(rdr[0]);
                //}
                //con.Close();
                toolTip2.Hide(this);
                txtC1DM1RequisitionNo.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetLId22()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select BalanceFiscal.LId from BalanceFiscal where BalanceFiscal.LedgerId='" + ledgerId2 + "' and  BalanceFiscal.FiscalId='" + fiscalLE3Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                dLId = (rdr.GetInt32(0));
            }
        }
        private void cmbC1DM2LedgerName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  RTRIM(Ledger.LedgerId),RTRIM(Ledger.AGRelId)  from Ledger where Ledger.LedgerName='" + cmbDebitLedgerName.Text +"' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ledgerId2 = (rdr.GetString(0));
                    debitAGRelId2 = (rdr.GetString(1));
                }
                con.Close();
                if (debitAGRelId2 == "5")
                {
                    label7.Visible = true;
                    textBox1.Visible = true;
                    label7.Location = new Point(46, 217);
                    textBox1.Location = new Point(200, 217);
                    label12.Location = new Point(81, 268);
                    txtC1DM2Particulars.Location = new Point(200, 261);
                    label13.Location = new Point(56, 444);
                    txtC1DM2DebitBalance.Location = new Point(200, 437);

                }
                else
                {
                    label7.Visible = false;
                    textBox1.Visible = false;
                    textBox1.Clear();
                    label7.Location = new Point(46, 444);
                    textBox1.Location = new Point(200, 437);

                    label12.Location = new Point(81, 217);
                    txtC1DM2Particulars.Location = new Point(200, 217);
                    label13.Location = new Point(56, 397);
                    txtC1DM2DebitBalance.Location = new Point(200, 394);

                }
                GetLId22();
                toolTip1.Hide(this);
                txtc1DM2FundRequisition.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DebitOptionClear()
        {
            cmbDebitLedgerName.SelectedIndex = -1;
            txtc1DM2FundRequisition.Clear();
            txtC1DM2Particulars.Clear();
            cmbVoucherNoD.SelectedIndex=-1;
            txtC1DM2DebitBalance.Clear();
        }

        

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDebitLedgerName.Text))
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDebitLedgerName.Focus();               
            }
            //else if (textBox1.Visible &&string.IsNullOrWhiteSpace(textBox1.Text))
            //{
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        textBox1.Focus();                    
            //}
            else if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Select Voucher No", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoD);
            }

            else if (string.IsNullOrWhiteSpace(txtC1DM2Particulars.Text))
            {
                MessageBox.Show("You must enter Particulars", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtC1DM2Particulars.Focus();              
            }

            else if (string.IsNullOrWhiteSpace(txtC1DM2DebitBalance.Text))
            {
                MessageBox.Show("Please enter  debit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtC1DM2DebitBalance.Focus();
            }
            else  if ((listView1.Items.Count + 1) > Convert.ToInt32(txtManyD.Text))
            {
                MessageBox.Show("You can not  add more item than Your Propossal item,if you want  to modify existing item,please remove the Specific item and add correct item.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DebitOptionClear();               
            }
            else
                try
                {                   
                    takeSum = takeSum + Convert.ToDecimal(txtC1DM2DebitBalance.Text);                   
                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.SubItems.Add(cmbDebitLedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst.SubItems.Add(secondLedgerId);
                        lst.SubItems.Add(txtc1DM2FundRequisition.Text);
                        lst.SubItems.Add(cmbVoucherNoD.Text);
                        lst.SubItems.Add(txtC1DM2Particulars.Text);
                        lst.SubItems.Add(txtC1DM2DebitBalance.Text);
                        dLId2 = Convert.ToString(dLId);
                        lst.SubItems.Add(dLId2);
                        aGRelId = Convert.ToString(debitAGRelId2);
                        lst.SubItems.Add(aGRelId);
                        if (textBox1.Visible && !string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            lst.SubItems.Add(textBox1.Text);
                        }
                        listView1.Items.Add(lst);

                        cmbCreditLedgerName.Items.Remove(cmbDebitLedgerName.Text);
                        cmbCreditLedgerName.Refresh();
                        //cmbDebitLedgerName.ResetText();
                        cmbDebitLedgerName.SelectedIndexChanged -= cmbC1DM2LedgerName_SelectedIndexChanged;
                        cmbDebitLedgerName.SelectedIndex = -1;
                        cmbDebitLedgerName.SelectedIndexChanged += cmbC1DM2LedgerName_SelectedIndexChanged;
                        txtc1DM2FundRequisition.Clear();
                        cmbVoucherNoD.SelectedIndexChanged -= cmbVoucherNoD_SelectedIndexChanged;
                        cmbVoucherNoD.SelectedIndex = -1;
                        cmbVoucherNoD.SelectedIndexChanged += cmbVoucherNoD_SelectedIndexChanged;
                        txtC1DM2Particulars.Clear();
                        txtC1DM2DebitBalance.Clear();
                        if (textBox1.Visible)
                        {
                            label7.Visible = false;
                            textBox1.Visible = false;
                            textBox1.Clear();
                            label7.Location = new Point(46, 444);
                            textBox1.Location = new Point(200, 437);

                            label12.Location = new Point(81, 217);
                            txtC1DM2Particulars.Location = new Point(200, 217);
                            label13.Location = new Point(56, 397);
                            txtC1DM2DebitBalance.Location = new Point(200, 394);
                        }
                        button1.Enabled = true;
                        button1.Visible = true;
                        cmbDebitLedgerName.Focus();
                    }

                    else
                    {
                        ListViewItem lst1 = new ListViewItem();
                        lst1.SubItems.Add(cmbDebitLedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst1.SubItems.Add(secondLedgerId);
                        lst1.SubItems.Add(txtc1DM2FundRequisition.Text);
                        lst1.SubItems.Add(cmbVoucherNoD.Text);
                        lst1.SubItems.Add(txtC1DM2Particulars.Text);
                        lst1.SubItems.Add(txtC1DM2DebitBalance.Text);
                        dLId2 = Convert.ToString(dLId);
                        lst1.SubItems.Add(dLId2);
                        aGRelId = Convert.ToString(debitAGRelId2);
                        lst1.SubItems.Add(aGRelId);
                        if (textBox1.Visible && !string.IsNullOrWhiteSpace(textBox1.Text))
                        {
                            lst1.SubItems.Add(textBox1.Text);
                        }
                        listView1.Items.Add(lst1);

                        cmbCreditLedgerName.Items.Remove(cmbDebitLedgerName.Text);
                        cmbCreditLedgerName.Refresh();
                        if (textBox1.Visible)
                        {
                            label7.Visible = false;
                            textBox1.Visible = false;
                            textBox1.Clear();
                            label7.Location = new Point(46, 444);
                            textBox1.Location = new Point(200, 437);

                            label12.Location = new Point(81, 217);
                            txtC1DM2Particulars.Location = new Point(200, 217);
                            label13.Location = new Point(56, 397);
                            txtC1DM2DebitBalance.Location = new Point(200, 394);
                        }
                        cmbDebitLedgerName.SelectedIndexChanged -= cmbC1DM2LedgerName_SelectedIndexChanged;
                        cmbDebitLedgerName.SelectedIndex = -1;
                        cmbDebitLedgerName.SelectedIndexChanged += cmbC1DM2LedgerName_SelectedIndexChanged;
                        txtc1DM2FundRequisition.Clear();
                        cmbVoucherNoD.SelectedIndexChanged -= cmbVoucherNoD_SelectedIndexChanged;
                        cmbVoucherNoD.SelectedIndex = -1;
                        cmbVoucherNoD.SelectedIndexChanged += cmbVoucherNoD_SelectedIndexChanged;
                        txtC1DM2Particulars.Clear();
                        txtC1DM2DebitBalance.Clear();
                        if ((listView1.Items.Count) < Convert.ToInt32(txtManyD.Text))
                        {
                            cmbDebitLedgerName.Focus();

                        }
                        else
                        {
                            addButton.Enabled = false;
                            addButton.Visible = false;
                            completeButton.Visible = true;
                            completeButton.Enabled = true;
                            completeButton.Focus();

                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count < 1)
            {
                MessageBox.Show("There is nothing to remove. Add first to remve", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (listView1.SelectedItems.Count==0)
            {
            
                MessageBox.Show("Please select an Item first!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                addButton.Enabled = true;
                addButton.Visible = true;
                completeButton.Enabled = false;
                completeButton.Visible = false;
                if (listView1.Items.Count < 1)
                {
                    button1.Enabled = false;
                    button1.Visible = false;
                }
                cmbDebitLedgerName.Focus();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Reset();
            groupBox2.Enabled = false;
        }

        private void txtC1DM1CreditBalance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtC1DM1CreditBalance_TextChanged(object sender, EventArgs e)
        {
            
            decimal val2 = 0;
            decimal.TryParse(txtC1DM1CreditBalance.Text, out val2);
            if (val2 > takeSum)
            {
                MessageBox.Show("This Amount must be equal to Debit Ledger Total Debit Balance.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtC1DM1CreditBalance.Clear();
                txtC1DM1CreditBalance.Focus();
                return;
            }
        }
        

        private void SaveNewTransaction()
        {
            

        }
        
        private void SaveCreditLedgerBalance()
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SaveCreditContraEntry()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        
        
        private void SaveDebitContraLCLRelation()
        {
            try
            {
               
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
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCreditLedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCreditLedgerName.Focus();
               
            }
            else if (string.IsNullOrWhiteSpace(txtC1DM1Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtC1DM1Particulars.Focus();
              
            }


            else if ((listView1.Items.Count) != Convert.ToInt32(txtManyD.Text))
            {
               MessageBox.Show("Number Of Debit Entry does not match....Please Check before Submit","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }

            else if (takeSum > Convert.ToDecimal(txtC1DM1CreditBalance.Text) || takeSum < Convert.ToDecimal(txtC1DM1CreditBalance.Text))
                {
                    MessageBox.Show("Your Transaction Parameters are invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtC1DM1CreditBalance.Clear();
                    txtC1DM1CreditBalance.Focus();

                }
            else try
            {

                if (takeSum == Convert.ToDecimal(txtC1DM1CreditBalance.Text))
                {
                   
                    //SaveNewTransaction();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    trans = con.BeginTransaction();
                    string cb1 = "insert into TransactionRecord(TransactionDate,EntryDateTime,InputBy) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(cb1);
                    cmd.Connection = con;
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtC1DM1Entrydate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d3", userId);
                    iTransactionId = (int)cmd.ExecuteScalar();
                    //con.Close();

                    if (txtC1DM1TransactionType.Text == "Credit")
                    {
                        //SaveCreditLedgerBalance();
                        rdrCon = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + firstLedgerId + "' and BalanceFiscal.LId='" + cLId + "'";
                        cmd = new SqlCommand(ct);
                        cmd.Connection = rdrCon;
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            creditBalance1 = (rdr.GetDecimal(0));
                        }
                        rdrCon.Close();

                        con = new SqlConnection(cs.DBConn);
                        rdrCon.Open();
                        string query = "select AccountType from AGRel where AGRel.AGRelId='" + creditAGRelId1 + "'";
                        cmd = new SqlCommand(query, rdrCon);
                        rdr = cmd.ExecuteReader();
                        if (rdr.Read())
                        {
                            accountOTypeD = (rdr.GetString(0));

                        }
                        rdrCon.Close();

                        if (accountOTypeD == "Asset" || accountOTypeD == "Expense" || accountOTypeD == "Pre Opening Expense")
                        {
                            decimal a = decimal.Parse(txtC1DM1CreditBalance.Text);
                            lCBalance1 = creditBalance1 - a;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lCBalance1 + " where BalanceFiscal.LedgerId ='" + firstLedgerId + "' and BalanceFiscal.LId='" + cLId + "' ";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                            //con.Close();

                        }
                        if (accountOTypeD == "Liability" || accountOTypeD == "Equity" || accountOTypeD == "Revenue")
                        {
                            decimal b = decimal.Parse(txtC1DM1CreditBalance.Text);
                            lCBalance1 = creditBalance1 + b;
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string cb2 = "Update BalanceFiscal set Balance=" + lCBalance1 + " where BalanceFiscal.LedgerId ='" + firstLedgerId + "' and BalanceFiscal.LId='" + cLId + "' ";
                            cmd = new SqlCommand(cb2);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();
                            //con.Close();

                        }
                        //con = new SqlConnection(cs.DBConn);
                        //con.Open();
                        string cb = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Credit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(cb);
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("@d1", txtC1DM1RequisitionNo.Text);
                        cmd.Parameters.AddWithValue("@d2", cmbVoucherNoC.Text);
                        cmd.Parameters.AddWithValue("@d3", txtC1DM1Particulars.Text);
                        cmd.Parameters.AddWithValue("@d4", decimal.Parse(txtC1DM1CreditBalance.Text));
                        cmd.Parameters.AddWithValue("@d5", lCBalance1);
                        cmd.Parameters.AddWithValue("@d6", iTransactionId);
                        cmd.Parameters.AddWithValue("@d7", cLId);
                        lEntryId = (int) cmd.ExecuteScalar();
                        //con.Close();
                        if (textBox2.Visible && !string.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string R = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(R);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.Parameters.AddWithValue("@d1", textBox2.Text);
                            cmd.Parameters.AddWithValue("@d2", lEntryId);
                            cmd.ExecuteNonQuery();
                            //con.Close();
                        }
                        //SaveCreditContraEntry();              
                        //con = new SqlConnection(cs.DBConn);
                        string queryz = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(queryz, con,trans);
                        cmd.Parameters.AddWithValue("d1", cmbCreditLedgerName.Text);
                        cmd.Parameters.AddWithValue("d2", firstLedgerId);
                        //con.Open();
                        debitContraEntryId = (int)cmd.ExecuteScalar();
                        //con.Close();
                    }


                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {
                        if (txtC1DM2TransactionType.Text == "Debit")
                        {
                            try
                            {
                                rdrCon = new SqlConnection(cs.DBConn);
                                rdrCon.Open();
                                string ct = "select Balance from BalanceFiscal where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and  BalanceFiscal.LId='" + listView1.Items[i].SubItems[7].Text + "' ";
                                cmd = new SqlCommand(ct);
                                cmd.Connection = con;
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    debitBalance2 = (rdr.GetDecimal(0));
                                   

                                }
                                rdrCon.Close();

                                rdrCon = new SqlConnection(cs.DBConn);
                                rdrCon.Open();
                                string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" + listView1.Items[i].SubItems[8].Text + "'";
                                cmd = new SqlCommand(q1, con);
                                rdr = cmd.ExecuteReader();
                                if (rdr.Read())
                                {
                                    accountOType = (rdr.GetString(0));

                                }

                                rdrCon.Close();
                                //if (genericOTypeId == 1)
                                if (accountOType == "Asset" || accountOType == "Expense" || accountOType == "Pre Opening Expense")
                                {
                                    decimal x = decimal.Parse(listView1.Items[i].SubItems[6].Text);
                                    lDBalance2 = debitBalance2 + x;
                                    //con = new SqlConnection(cs.DBConn);
                                    //con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance2 + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.Transaction = trans;
                                    cmd.ExecuteNonQuery();
                                    //con.Close();

                                }
                                // if (genericOTypeId == 2)
                                if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                                {
                                    decimal y = decimal.Parse(listView1.Items[i].SubItems[6].Text);
                                    lDBalance2 = debitBalance2 - y;
                                    //con = new SqlConnection(cs.DBConn);
                                    //con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance2 + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.Transaction = trans;
                                    cmd.ExecuteNonQuery();
                                    //con.Close();

                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            //Con.Close
                            //con = new SqlConnection(cs.DBConn);
                            string cb = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Debit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            //cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Transaction = trans;
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d4", decimal.Parse(listView1.Items[i].SubItems[6].Text));
                            cmd.Parameters.AddWithValue("d5", lDBalance2);
                            cmd.Parameters.AddWithValue("d6", iTransactionId);
                            cmd.Parameters.AddWithValue("d7", listView1.Items[i].SubItems[7].Text);
                            //con.Open();
                            creditLedgerEntryId = (int) cmd.ExecuteScalar();
                            //con.Close();

                            if (listView1.Items[i].SubItems[8].Text == "5" && !string.IsNullOrWhiteSpace(listView1.Items[i].SubItems[9].Text))
                            {
                                //con = new SqlConnection(cs.DBConn);
                                //con.Open();
                                string Y = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)";
                                cmd = new SqlCommand(Y);
                                cmd.Connection = con;
                                cmd.Transaction = trans;
                                cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[9].Text);
                                cmd.Parameters.AddWithValue("@d2", creditLedgerEntryId);
                                cmd.ExecuteNonQuery();
                                //con.Close();
                            }

                            //con = new SqlConnection(cs.DBConn);
                            string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query, con,trans);
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[2].Text);
                            //con.Open();
                            cEntryId = (int) cmd.ExecuteScalar();
                            //con.Close();
                            //SaveLCLRelation();
                            //con = new SqlConnection(cs.DBConn);
                            string queryl = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                            cmd = new SqlCommand(queryl, con,trans);
                            cmd.Parameters.AddWithValue("d1", iTransactionId);
                            cmd.Parameters.AddWithValue("d2", lEntryId);
                            cmd.Parameters.AddWithValue("d3", cEntryId);
                            //con.Open();
                            cmd.ExecuteNonQuery();
                            //con.Close();
                            //SaveDebitContraLCLRelation();
                            //con = new SqlConnection(cs.DBConn);
                            string q1lc = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                            cmd = new SqlCommand(q1lc, con,trans);
                            cmd.Parameters.AddWithValue("d1", iTransactionId);
                            cmd.Parameters.AddWithValue("d2", creditLedgerEntryId);
                            cmd.Parameters.AddWithValue("d3", debitContraEntryId);
                            //con.Open();
                            cmd.ExecuteNonQuery();
                            //con.Close();
                            //UpdateDebitVoucherStatus();
                            //con = new SqlConnection(cs.DBConn);
                            //con.Open();
                            string queryuv = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + listView1.Items[i].SubItems[4].Text + "' ";
                            cmd = new SqlCommand(queryuv, con, trans);
                            cmd.ExecuteNonQuery();
                            //con.Close();
                        }

                    }
                   
                    //UpdateCreditVoucherStatus();
                    //con = new SqlConnection(cs.DBConn);
                    //con.Open();
                    string queryuvc = "Update VoucherNumber Set  Statuss='Written' where  VoucherNo='" + cmbVoucherNoC.Text + "' ";
                    cmd = new SqlCommand(queryuvc, con,trans);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    con.Close();
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
                
                MessageBox.Show(ex.Message, " Error But We are Roll Backing", MessageBoxButtons.OK, MessageBoxIcon.Error);
               trans.Rollback();
                con.Close();
            }

        }

        private void txtC1DM2DebitBalance_TextChanged(object sender, EventArgs e)
        {
            //decimal val1 = 0;
            //decimal val2 = 0;
            //decimal.TryParse(txtC1DM1CreditBalance.Text, out val1);
            //decimal.TryParse(txtC1DM2DebitBalance.Text, out val2);
            //if (val2 > val1)
            //{
            //    MessageBox.Show("This Amount must be less than or equal to Ledger '" + txtC1DM1TransactionType.Text + "' amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtC1DM2DebitBalance.Clear();
            //    txtC1DM2DebitBalance.Focus();
            //    return;
            //}
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            JournalForLedgerEntry frm = new JournalForLedgerEntry();
               frm.Show();
        }

        private void txtC1DM1RequisitionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                
            }
        }

        private void txtC1DM1VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txtc1DM2FundRequisition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
               
            }
        }

        private void txtC1DM2VoucherNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                
            }
        }

        private void completeButton_Click(object sender, EventArgs e)
        {

            if ((listView1.Items.Count) != Convert.ToInt32(txtManyD.Text))
            {
                MessageBox.Show("Debit Entry is not equal to Propossal. Complete Debit Entry ", "Could Not Proceed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                group1.Enabled = true;
                group1.Visible = true;
                groupBox2.Enabled = false;
                cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                cmbVoucherNoC.Refresh();
            }
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtC1DM1RequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoC.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM1VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC1DM1Particulars.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM1Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC1DM1CreditBalance.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM1CreditBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDebitLedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtc1DM2FundRequisition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVoucherNoD.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM2VoucherNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC1DM2Particulars.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM2Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtC1DM2DebitBalance.Focus();
                e.Handled = true;
            }
        }

        private void txtC1DM2DebitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(this, new EventArgs());
            }
        }

        private void txtC1DM2DebitBalance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbVoucherNoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Visible == true)
            {
                textBox1.Focus();
            }
            else
            {
                txtC1DM2Particulars.Focus();
            }
        }

        private void txtC1DM1Particulars_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoC.Focus();
                
            }
        }

        private void cmbVoucherNoD_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbVoucherNoD.Text)&&!cmbVoucherNoD.Items.Contains(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void txtc1DM2FundRequisition_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDebitLedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbDebitLedgerName); 
                
            }
        }

        private void cmbVoucherNoD_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbDebitLedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbDebitLedgerName);
             
            }
        }

        private void txtC1DM2Particulars_Enter(object sender, EventArgs e)
        {
            //if (textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        this.BeginInvoke(new ChangeFocusDelegate(changeFocus), textBox1);
                  
            //    }
            
            //else   
            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbVoucherNoD);

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

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No first", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoD);
               
            }
        }

        private void txtC1DM2DebitBalance_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtC1DM2Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txtC1DM2Particulars);
               
            }
        }

        private void txtC1DM1CreditBalance_Enter(object sender, EventArgs e)
        {
          if (string.IsNullOrWhiteSpace(txtC1DM1Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txtC1DM1Particulars);
            }
        }

        private void LedgerEntryForOneCreditManyDebit_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            PreliStepsOfLedgerEntry frm = new PreliStepsOfLedgerEntry();
            frm.Show();
        }

        private void txtC1DM1Particulars_Enter(object sender, EventArgs e)
        {
            //if (textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text))
            //    {
            //        MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //        this.BeginInvoke(new ChangeFocusDelegate(changeFocus),textBox1);
            //    }
            
            //else 
                if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoC);
            }
        }

        private void cmbVoucherNoC_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCreditLedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbCreditLedgerName);
                
            }
        }

        private void cmbVoucherNoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.Visible == true)
            {
                textBox2.Focus();
            }
            else
            {
                txtC1DM1Particulars.Focus();
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Make sure the splash screen is closed
            CloseSplash();
            base.OnClosing(e);
        }

        private void txtC1DM2Particulars_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtc1DM2FundRequisition_TextChanged(object sender, EventArgs e)
        {

        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }

        private void cmbDebitLedgerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }
            Point p = new Point(cmbDebitLedgerName.Location.X + 120, cmbDebitLedgerName.Location.Y + cmbDebitLedgerName.Height + (30 + e.Index * 10));
            Font drawFont = new Font("Times New Roman", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                toolTip1.Show(cmbDebitLedgerName.Items[e.Index].ToString(), this, p);
            }

            e.DrawBackground();
            e.Graphics.DrawString(cmbDebitLedgerName.Items[e.Index].ToString(), drawFont, Brushes.Black,
                new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void cmbCreditLedgerName_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }
            Point p = new Point(cmbCreditLedgerName.Location.X + 120, cmbCreditLedgerName.Location.Y + cmbCreditLedgerName.Height + (30 + e.Index * 10));
            Font drawFont = new Font("Times New Roman", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                toolTip1.Show(cmbCreditLedgerName.Items[e.Index].ToString(), this, p);
            }

            e.DrawBackground();
            e.Graphics.DrawString(cmbCreditLedgerName.Items[e.Index].ToString(), drawFont, Brushes.Black,
                new Point(e.Bounds.X, e.Bounds.Y));
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font f = new Font("Arial", 16.0f);
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, new PointF(2, 2)); 
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(toolTip1.GetToolTip(e.AssociatedControl), new Font("Arial", 16.0f));
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
            e.ToolTipSize = TextRenderer.MeasureText(toolTip1.GetToolTip(e.AssociatedControl), new Font("Arial", 16.0f));
        }
        }
    }

