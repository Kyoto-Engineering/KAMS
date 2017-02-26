using System;
using System.Collections;
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
    public partial class MultipleBatchPosting : Form
    {
        const int kSplashUpdateInterval_ms = 50;
        const int kMinAmountOfSplashTime_ms = 800;
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int iTransactionId = 0, lEntryId, creditContraEntryId, k, genericOTypeId, creditLedgerEntryId,  ledgerEntryRecordId, debitContraLedgerEntryRecordId, creditContraLedgerEntryRecordId;
        public string contraLedgerName, conTraLedgerId, cmb11LedgerName, ledgerId1, ledgerId2, userId, secondLedgerId, fullName, lGenericType, debitAGRelId1, creditAGRelId2, creditAGRelId, cLID2, voucherNoD;
        public decimal takeSum1 = 0,takeSum2=0, takeSub1 = 0,takeSub2=0, takeRemove1 = 0,takeRemove2, debitBalance = 0, lDBalance = 0, lCBalance = 0, creditBalance = 0;
        public string OAgrelId, accountOTypeD, accountOType,dLId1, cLId2, aGRelId;
        public int fiscalLE2Year;
        public int  dLId,cLId, debitAGRelId2;
        public  int debitContraEntryId;
        public DateTime startDateManyDManyC, endDateManyDManyC;
        public int max1, max2;
        private delegate void ChangeFocusDelegate(Control ctl);

        
        
        public MultipleBatchPosting()
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void Ledger1CmbFill()
        {
            try
            {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                   // string ct = "select RTRIM(Ledger.LedgerName) from Ledger where Ledger.AGRelId!='4' and Ledger.AGRelId!='5' and Ledger.LedgerName!='" +listView1.Items[i].SubItems[1].Text + "' order by LedgerId desc";
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
        public void Ledger2CmbFill()
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
                    cmb2LedgerName.Items.Add(rdr[0]);
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
                string ct = "select RTRIM(VoucherNo) from VoucherNumber where   VoucherNumber.Statuss!='Written' order by VoucherNo desc";
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
        private void MultipleBatchPosting_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            // Pretend that our application is doing a bunch of loading and
            // initialization
            Thread.Sleep(kMinAmountOfSplashTime_ms / 8);

            VoucherNoForDebitEntry();
            VoucherNoForCreditEntry();
            txt1TransactionType.Text = "Debit";
            txt2TransactionType.Text = "Credit";
            userId = frmLogin.uId.ToString();
            fiscalLE2Year = FiscalYear.phiscalYear;

            startDateManyDManyC = FiscalYear.startDate;
            endDateManyDManyC = FiscalYear.endDate;

            txtTransactiondate.MinDate = startDateManyDManyC;
            txtTransactiondate.MaxDate = endDateManyDManyC;

            if (DateTime.UtcNow.ToLocalTime() > endDateManyDManyC)
            {
                txtTransactiondate.Value = txtTransactiondate.MaxDate;

            }
            else
            {
                txtTransactiondate.Value = DateTime.Now;
            }

            groupBox2.Enabled = false;
            Ledger1CmbFill();
            Ledger2CmbFill();
            CloseSplash();
            Application.UseWaitCursor = false;
            txtTransactiondate.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1LedgerName.Focus();
                
            }

            else if (string.IsNullOrWhiteSpace(txt1Particulars.Text))
            {
                MessageBox.Show("You must enter Particulars", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1Particulars.Focus();
               
            }

            else if (string.IsNullOrWhiteSpace(txt1DebitAmount.Text))
            {
                MessageBox.Show("Please enter  debit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1DebitAmount.Focus();
               
            }
            else if (Convert.ToDecimal(txt1DebitAmount.Text )== 0.00m)
            {
                MessageBox.Show("Items Can not be Added with zero values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1DebitAmount.Clear();
                txt1DebitAmount.Focus();
            
            }

            else 
               
            {
                try
                {
                    takeSum1 = takeSum1 + Convert.ToDecimal(txt1DebitAmount.Text);

                     if (listView1.Items.Count == 0)
                      {
                            ListViewItem lst = new ListViewItem();
                            lst.SubItems.Add(cmb1LedgerName.Text);
                            secondLedgerId = Convert.ToString(ledgerId1);
                            lst.SubItems.Add(secondLedgerId);
                            lst.SubItems.Add(txt1RequisitionNo.Text);
                            lst.SubItems.Add(cmbVoucherNoD.Text);
                            lst.SubItems.Add(txt1Particulars.Text);
                            lst.SubItems.Add(txt1DebitAmount.Text);
                            dLId1 = Convert.ToString(dLId);
                            lst.SubItems.Add(dLId1);
                            aGRelId = Convert.ToString(debitAGRelId1);

                            lst.SubItems.Add(aGRelId);
                            if (billOrInvoiceNoD.Visible)
                            {
                                lst.SubItems.Add(billOrInvoiceNoD.Text);
                            }

                            listView1.Items.Add(lst);

                            cmb2LedgerName.Items.Remove(cmb1LedgerName.Text);
                            cmb2LedgerName.Refresh();
                            cmbVoucherNoD.Items.Remove(cmbVoucherNoD.Text);
                            cmbVoucherNoD.Refresh();
                            cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                            cmbVoucherNoC.Refresh();
                                if (billOrInvoiceNoD.Visible)
                                {
                                    label7.Visible = false;
                                    billOrInvoiceNoD.Visible = false;
                                    billOrInvoiceNoD.Clear();
                                    label7.Location = new Point(37, 336);
                                    billOrInvoiceNoD.Location = new Point(195, 329);

                                    label3.Location = new Point(65, 176);
                                    txt1Particulars.Location = new Point(195, 175);
                                    label4.Location = new Point(45, 290);
                                    txt1DebitAmount.Location = new Point(195, 287);
                                }
                                cmb1LedgerName.SelectedIndexChanged -= cmb1LedgerName_SelectedIndexChanged;
                                cmb1LedgerName.SelectedIndex = -1;
                                cmb1LedgerName.SelectedIndexChanged += cmb1LedgerName_SelectedIndexChanged;
                                txt1RequisitionNo.Clear();                               
                                cmbVoucherNoD.SelectedIndex = -1;
                                txt1Particulars.Clear();
                                txt1DebitAmount.Clear();



                }

                else
                {
                    ListViewItem lst1 = new ListViewItem();
                    lst1.SubItems.Add(cmb1LedgerName.Text);
                    secondLedgerId = Convert.ToString(ledgerId1);
                    lst1.SubItems.Add(secondLedgerId);
                    lst1.SubItems.Add(txt1RequisitionNo.Text);
                    lst1.SubItems.Add(cmbVoucherNoD.Text);
                    lst1.SubItems.Add(txt1Particulars.Text);
                    lst1.SubItems.Add(txt1DebitAmount.Text);
                    dLId1 = Convert.ToString(dLId);
                    lst1.SubItems.Add(dLId1);
                    aGRelId = Convert.ToString(debitAGRelId1);
                    lst1.SubItems.Add(aGRelId);
                    if (billOrInvoiceNoD.Visible)
                    {
                        lst1.SubItems.Add(billOrInvoiceNoD.Text);
                    }
                    listView1.Items.Add(lst1);
                    cmb2LedgerName.Items.Remove(cmb1LedgerName.Text);
                    cmb2LedgerName.Refresh();
                    cmbVoucherNoD.Items.Remove(cmbVoucherNoD.Text);
                    cmbVoucherNoD.Refresh();
                    cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                    cmbVoucherNoC.Refresh();
                    if (billOrInvoiceNoD.Visible)
                    {
                        label7.Visible = false;
                        billOrInvoiceNoD.Visible = false;
                        billOrInvoiceNoD.Clear();
                        label7.Location = new Point(37, 336);
                        billOrInvoiceNoD.Location = new Point(195, 329);

                        label3.Location = new Point(65, 176);
                        txt1Particulars.Location = new Point(195, 175);
                        label4.Location = new Point(45, 290);
                        txt1DebitAmount.Location = new Point(195, 287);
                    }
                    cmb1LedgerName.SelectedIndexChanged -= cmb1LedgerName_SelectedIndexChanged;
                    cmb1LedgerName.SelectedIndex = -1;
                    cmb1LedgerName.SelectedIndexChanged += cmb1LedgerName_SelectedIndexChanged;
                    txt1RequisitionNo.Clear();                   
                    cmbVoucherNoD.SelectedIndex = -1;
                    txt1Particulars.Clear();
                    txt1DebitAmount.Clear();

                }
            }
           catch (Exception ex)
          {
           MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
               

     }
            
        }

        private void creditLedgerAddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("You must select a LedgerName.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb2LedgerName.Focus();
                
            }

            else if (string.IsNullOrWhiteSpace(txt2Particulars.Text))
            {
                MessageBox.Show("You must enter Particulars", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2Particulars.Focus();
               
            }

            else  if (string.IsNullOrWhiteSpace(txt2CreditAmount.Text))
            {
                MessageBox.Show("Please enter  credit amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2CreditAmount.Focus();
               
            }

           
            else if (Convert.ToDecimal(txt2CreditAmount.Text) == 0.00m)
            {
                MessageBox.Show("Items Can not be Added with zero values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2CreditAmount.Clear();
                txt2CreditAmount.Focus();
               
            }

            else try
            {
                takeSub2 = takeSum2;
                takeSum2 = takeSum2 + Convert.ToDecimal(txt2CreditAmount.Text);
                if (takeSum1 < takeSum2)
                {
                    MessageBox.Show("Your input amount exceed the limit", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    takeSum2 = takeSub2;
                    txt2CreditAmount.Clear();
                    txt2CreditAmount.Focus();
                 
                }
                else
                {
                    if (listView2.Items.Count == 0)
                    {
                        ListViewItem lst10 = new ListViewItem();
                        lst10.SubItems.Add(cmb2LedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst10.SubItems.Add(secondLedgerId);
                        lst10.SubItems.Add(txt2FundRequisition.Text);
                        lst10.SubItems.Add(cmbVoucherNoC.Text);
                        lst10.SubItems.Add(txt2Particulars.Text);
                        lst10.SubItems.Add(txt2CreditAmount.Text);
                        cLId2 = Convert.ToString(cLId);
                        lst10.SubItems.Add(cLId2);
                        aGRelId = Convert.ToString(creditAGRelId2);
                        lst10.SubItems.Add(aGRelId);
                        if (billOrInvoiceNoForC.Visible)
                        {
                            lst10.SubItems.Add(billOrInvoiceNoForC.Text);
                        }
                        listView2.Items.Add(lst10);
                        cmbVoucherNoC.Items.Remove(cmbVoucherNoC.Text);
                        cmbVoucherNoC.Refresh();                        
                        if (billOrInvoiceNoForC.Visible)
                        {
                            label16.Visible = false;
                            billOrInvoiceNoForC.Visible = false;
                            billOrInvoiceNoForC.Clear();
                            label16.Location = new Point(57, 369);
                            billOrInvoiceNoForC.Location = new Point(213, 362);

                            label12.Location = new Point(88, 189);
                            txt2Particulars.Location = new Point(213, 187);
                            label13.Location = new Point(70, 317);
                            txt2CreditAmount.Location = new Point(213, 313);
                        }
                        cmb2LedgerName.SelectedIndexChanged -= cmb2LedgerName_SelectedIndexChanged;
                        cmb2LedgerName.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged += cmb2LedgerName_SelectedIndexChanged;
                        txt2FundRequisition.Clear();                       
                        cmbVoucherNoC.SelectedIndex = -1;
                        txt2Particulars.Clear();
                        txt2CreditAmount.Clear();




                    }

                    else
                    {
                        ListViewItem lst12 = new ListViewItem();
                        lst12.SubItems.Add(cmb2LedgerName.Text);
                        secondLedgerId = Convert.ToString(ledgerId2);
                        lst12.SubItems.Add(secondLedgerId);
                        lst12.SubItems.Add(txt2FundRequisition.Text);
                        lst12.SubItems.Add(cmbVoucherNoC.Text);
                        lst12.SubItems.Add(txt2Particulars.Text);
                        lst12.SubItems.Add(txt2CreditAmount.Text);
                        cLId2 = Convert.ToString(cLId);
                        lst12.SubItems.Add(cLId2);
                        aGRelId = Convert.ToString(creditAGRelId2);
                        lst12.SubItems.Add(aGRelId);
                        if (billOrInvoiceNoForC.Visible)
                        {
                            lst12.SubItems.Add(billOrInvoiceNoForC.Text);
                        }
                        listView2.Items.Add(lst12);
                        cmbVoucherNoC.Items.Remove(cmbVoucherNoC.Text);
                        cmbVoucherNoC.Refresh();

                        if (billOrInvoiceNoForC.Visible)
                        {
                            label16.Visible = false;
                            billOrInvoiceNoForC.Visible = false;
                            billOrInvoiceNoForC.Clear();
                            label16.Location = new Point(57, 369);
                            billOrInvoiceNoForC.Location = new Point(213, 362);

                            label12.Location = new Point(88, 189);
                            txt2Particulars.Location = new Point(213, 187);
                            label13.Location = new Point(70, 317);
                            txt2CreditAmount.Location = new Point(213, 313);
                        }
                        cmb2LedgerName.SelectedIndexChanged -= cmb2LedgerName_SelectedIndexChanged;
                        cmb2LedgerName.SelectedIndex = -1;
                        cmb2LedgerName.SelectedIndexChanged += cmb2LedgerName_SelectedIndexChanged;
                        txt2FundRequisition.Clear();                        
                        cmbVoucherNoC.SelectedIndex = -1;
                        txt2Particulars.Clear();
                        txt2CreditAmount.Clear();


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
            takeRemove1 = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[6].Text);
            takeSum1 = takeSum1 - takeRemove1;
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

        private void creditLedgerRemoveButton_Click(object sender, EventArgs e)
        {
            takeRemove2 = Convert.ToDecimal(listView2.SelectedItems[0].SubItems[6].Text); 
            takeSum2 = takeSum2 - takeRemove2;
            cmb2LedgerName.Items.Add(listView2.SelectedItems[0].SubItems[1].Text);
            for (int i = listView2.Items.Count - 1; i >= 0; i--)
            {
                if (listView2.Items[i].Selected)
                {
                    listView2.Items[i].Remove();
                }
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
                if (debitAGRelId1 == "5")
                {
                    label7.Visible = true;
                    billOrInvoiceNoD.Visible = true;
                    label7.Location = new Point(37, 176);
                    billOrInvoiceNoD.Location = new Point(195, 175);
                    label3.Location = new Point(65, 227);
                    txt1Particulars.Location = new Point(195, 220);
                    label4.Location = new Point(45, 336);
                    txt1DebitAmount.Location = new Point(195, 329);

                }
                else
                {
                    label7.Visible = false;
                    billOrInvoiceNoD.Visible = false;
                    billOrInvoiceNoD.Clear();
                    label7.Location = new Point(37, 336);
                    billOrInvoiceNoD.Location = new Point(195, 329);

                    label3.Location = new Point(65, 176);
                    txt1Particulars.Location = new Point(195, 175);
                    label4.Location = new Point(45, 290);
                    txt1DebitAmount.Location = new Point(195, 287);
                }               
                txt1RequisitionNo.Focus();

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
                if (creditAGRelId2 == "4")
                {
                    label16.Visible = true;
                    billOrInvoiceNoForC.Visible = true;
                    label16.Location = new Point(57, 189);
                    billOrInvoiceNoForC.Location = new Point(213, 187);
                    label12.Location = new Point(88, 245);
                    txt2Particulars.Location = new Point(213, 238);
                    label13.Location = new Point(70, 369);
                    txt2CreditAmount.Location = new Point(213, 362);

                }
                else
                {
                    label16.Visible = false;
                    billOrInvoiceNoForC.Visible = false;
                    billOrInvoiceNoForC.Clear();
                    label16.Location = new Point(57, 369);
                    billOrInvoiceNoForC.Location = new Point(213, 362);

                    label12.Location = new Point(88, 189);
                    txt2Particulars.Location = new Point(213, 187);
                    label13.Location = new Point(70, 317);
                    txt2CreditAmount.Location = new Point(213, 313);

                }
                txt2FundRequisition.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txt1DebitAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) ||  (e.KeyChar == '0'))
            //         {
            //             e.Handled = true;
            //                return;
            //         }

            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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

        private void txt2CreditAmount_KeyPress(object sender, KeyPressEventArgs e)
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
            PreliStepsOfLedgerEntry frm=new PreliStepsOfLedgerEntry();
                                 frm.Show();
        }

        private void debitCompleteButton_Click(object sender, EventArgs e)
        {
            
        }

        private void txt2CreditAmount_TextChanged(object sender, EventArgs e)
        {
            //decimal val1 = 0;
            //decimal val2 = 0;
            //decimal.TryParse(txt1Amount.Text, out val1);
            //decimal.TryParse(txt2Amount.Text, out val2);
            //if (takeSum1 > takeSum2)
            //{
            //    MessageBox.Show("This Amount must be less than Debit Ledger '" + takeSum1 + "' amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txt2CreditAmount.Text = "";
            //    txt2CreditAmount.Focus();
            //    return;
            //}
        }

        private void txt2CreditAmount_Validating(object sender, CancelEventArgs e)
        {
            if (takeSum2 > takeSum1)
            {
                MessageBox.Show("This Amount must be less than Debit Ledger '" + takeSum1 + "' amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2CreditAmount.Clear();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt2CreditAmount);

            }
        }
       
        private void SaveNewTransaction()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string cb = "insert into TransactionRecord(TransactionDate,EntryDateTime,InputBy) VALUES (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(cb);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtTransactiondate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
            cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d3", userId);
            iTransactionId = (int) cmd.ExecuteScalar();
            con.Close();

        }

        private void SaveLCLRelation()
        {
            try
            {
                for (int k = 1; k <= max1; k++)
                {
                    int ledgerEntryId = lEntryId - max1 + k;
                    for (int m = 1; m <= max2; m++)
                    {
                        int cContraEntryId = creditContraEntryId - max2 + m;
                        con = new SqlConnection(cs.DBConn);
                        string query = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("d1", iTransactionId);
                        cmd.Parameters.AddWithValue("d2", ledgerEntryId);
                        cmd.Parameters.AddWithValue("d3", cContraEntryId);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }
                   
                }
                for (int p = 1; p <= max2; p++)
                {
                    int creditLedgerEntryId1 = creditLedgerEntryId - max2 + p;
                    for (int q = 1; q <= max1; q++)
                    {
                        int debitContraEntryId1 = debitContraEntryId - max1 + q;
                        con = new SqlConnection(cs.DBConn);
                        string query = "insert into LECLERelation(TransactionId,LedgerEntryId,CEntryId) values(@d1,@d2,@d3)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("d1", iTransactionId);
                        cmd.Parameters.AddWithValue("d2", creditLedgerEntryId1);
                        cmd.Parameters.AddWithValue("d3", debitContraEntryId1);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }

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
       
       
       
       
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count != Convert.ToInt32(txtCEntryNo.Text))
            {
                MessageBox.Show("Your Number of Credit Entry is not equal to your Propossal Entry...Please Check before Submit", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }


            else try
            {
                if (takeSum1 != takeSum2)
                {
                    MessageBox.Show("Your Transaction Parameters(Debit & Credit) are not Equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                else  if (takeSum1 == takeSum2)
                {
                    
                    SaveNewTransaction();
                    max1 = Convert.ToInt32(txtDEntryNo.Text);
                    max2 = Convert.ToInt32(txtCEntryNo.Text);
                   //Debit Entry Start Here
                   
                    if (txt1TransactionType.Text == "Debit")
                    {
                        int count1 = 0;
                        for (int i = 0; i<= listView1.Items.Count - 1;i++)
                        {
                           
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId='" + listView1.Items[i].SubItems[7].Text + "' ";
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
                                string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" + listView1.Items[i].SubItems[8].Text + "'";
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
                                    lDBalance = debitBalance + x;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();

                                }
                                // if (genericOTypeId == 2)
                                if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                                {
                                    decimal y = decimal.Parse(listView1.Items[i].SubItems[6].Text);
                                    lDBalance = debitBalance - y;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lDBalance + " where BalanceFiscal.LedgerId='" + listView1.Items[i].SubItems[2].Text + "'and BalanceFiscal.LId ='" + listView1.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();

                                }
                          
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string cb = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Debit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d4", decimal.Parse(listView1.Items[i].SubItems[6].Text));
                            cmd.Parameters.AddWithValue("d5", lDBalance);
                            cmd.Parameters.AddWithValue("d6", iTransactionId);
                            cmd.Parameters.AddWithValue("d7", listView1.Items[i].SubItems[7].Text);
                            lEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                           
                            if (listView1.Items[i].SubItems[8].Text == "5")
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string Y = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)";
                                cmd = new SqlCommand(Y);
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[9].Text);
                                cmd.Parameters.AddWithValue("@d2", lEntryId);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            con = new SqlConnection(cs.DBConn);
                            string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[2].Text);
                            con.Open();
                            debitContraEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                           
      
                        }
                    }

                    //Credit Entry Start here

                    if (txt2TransactionType.Text == "Credit")
                    {

                        for (int i = 0; i <= listView2.Items.Count - 1; i++)
                        {

                            
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string ct = "select Balance from BalanceFiscal where  BalanceFiscal.LedgerId='" +
                                            listView2.Items[i].SubItems[2].Text + "' and BalanceFiscal.LId='" +
                                            listView2.Items[i].SubItems[7].Text + "' ";
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
                                string q1 = "Select RTRIM(AGRel.AccountType) from AGRel where AGRel.AGRelId='" +
                                            listView2.Items[i].SubItems[8].Text + "'";
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
                                    decimal x = decimal.Parse(listView2.Items[i].SubItems[6].Text);
                                    lCBalance = creditBalance - x;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance +
                                                 " where BalanceFiscal.LedgerId='" + listView2.Items[i].SubItems[2].Text +
                                                 "' and BalanceFiscal.LId ='" + listView2.Items[i].SubItems[7].Text +
                                                 "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();

                                }
                                // if (genericOTypeId == 2)
                                if (accountOType == "Liability" || accountOType == "Equity" || accountOType == "Revenue")
                                {
                                    decimal y = decimal.Parse(listView2.Items[i].SubItems[6].Text);
                                    lCBalance = creditBalance + y;
                                    con = new SqlConnection(cs.DBConn);
                                    con.Open();
                                    string cb2 = "Update BalanceFiscal set Balance=" + lCBalance +
                                                 " where BalanceFiscal.LedgerId='" + listView2.Items[i].SubItems[2].Text +
                                                 "'and BalanceFiscal.LId ='" + listView2.Items[i].SubItems[7].Text + "'";
                                    cmd = new SqlCommand(cb2);
                                    cmd.Connection = con;
                                    cmd.ExecuteReader();
                                    con.Close();

                                }

                            
                            //Con.Close
                            con = new SqlConnection(cs.DBConn);

                            string cb = "insert into LedgerEntry(FundRequisitionNo,VoucherNo,Particulars,Credit,Balances,TransactionId,LId) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(cb);
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("d1", listView2.Items[i].SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d2", listView2.Items[i].SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d3", listView2.Items[i].SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d4", decimal.Parse(listView2.Items[i].SubItems[6].Text));
                            cmd.Parameters.AddWithValue("d5", lCBalance);
                            cmd.Parameters.AddWithValue("d6", iTransactionId);
                            cmd.Parameters.AddWithValue("d7", listView2.Items[i].SubItems[7].Text);
                            con.Open();
                            creditLedgerEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                          
                            if (listView2.Items[i].SubItems[8].Text == "4")
                            {
                                con = new SqlConnection(cs.DBConn);
                                con.Open();
                                string Z = "INSERT INTO BillInfo (BillNo,LedgerEntryId)VALUES(@d1,@d2)";
                                cmd = new SqlCommand(Z);
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@d1", listView2.Items[i].SubItems[9].Text);
                                cmd.Parameters.AddWithValue("@d2", creditLedgerEntryId);
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            con = new SqlConnection(cs.DBConn);
                            string query = "insert into ContraEntry(ContraLName,ContraLId) values(@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("d1", listView2.Items[i].SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d2", listView2.Items[i].SubItems[2].Text);
                            con.Open();
                            creditContraEntryId = (int) cmd.ExecuteScalar();
                            con.Close();
                           
                        }
                    }
                    SaveLCLRelation();      
                }
             UpdateDebitVoucherStatus();
             UpdateCreditVoucherStatus();

             MessageBox.Show("Transaction Completed Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                                       
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            cmb1LedgerName.SelectedIndex = -1;
            txtTransactiondate.Value = this.txtTransactiondate.MaxDate;
            txt1RequisitionNo.Text = "";
            cmbVoucherNoD.SelectedIndex=-1;
            txt1Particulars.Text = "";
            txt1DebitAmount.TextChanged -= txt1DebitAmount_TextChanged;
            txt1DebitAmount.Text = "";
            txt1DebitAmount.TextChanged += txt1DebitAmount_TextChanged;
            cmb2LedgerName.SelectedIndex = -1;
            txt2FundRequisition.Text = "";
            cmbVoucherNoC.SelectedIndex=-1;
            txt2Particulars.Text = "";
            txt2CreditAmount.Text = "";
            group1.Enabled = true;
            listView1.Items.Clear();
            billOrInvoiceNoD.Clear();
            billOrInvoiceNoForC.Clear();
            label7.Visible = false;
            billOrInvoiceNoForC.Visible = false;
            label16.Visible = false;
            billOrInvoiceNoD.Visible = false;
            takeSum1 =takeSum2= 0;
            takeSub1 =takeSub2= 0;
            takeRemove1 =takeRemove2= 0;
            debitBalance = 0;
            lDBalance = 0;
            lCBalance = 0;
            creditBalance = 0;
        }

        private void txt1DebitAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                txt1Particulars.Focus();
                e.Handled = true;
            }
        }

        private void txt1Particulars_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {
                txt1DebitAmount.Focus();
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
                txt2Particulars.Focus();
                e.Handled = true;
            }
        }

        private void txt2Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt2CreditAmount.Focus();
                e.Handled = true;
            }
        }

        private void txt2CreditAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(this, new EventArgs());
            }
        }

       

        private void debitCompleteButton_Click_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count == Convert.ToInt32(txtDEntryNo.Text))
            {
                group1.Enabled = false;
                groupBox2.Enabled = true;
                cmbVoucherNoC.Items.Remove(cmbVoucherNoD.Text);
                cmbVoucherNoC.Refresh();
            }
            else
            {
                MessageBox.Show("Your Number of Debit Entry is not equal to your Propossal Entry", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbVoucherNoD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  RTRIM(VoucherNo) from VoucherNumber WHERE VoucherNumber.VoucherNo = '" + cmbVoucherNoD.Text + "'";
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    voucherNoD = (rdr.GetString(0));


                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                cmbVoucherNoD.Text = cmbVoucherNoD.Text.Trim();
                cmbVoucherNoC.Items.Clear();
                cmbVoucherNoC.Text = "";
                cmbVoucherNoC.Enabled = true;
                cmbVoucherNoC.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(VoucherNo) from  VoucherNumber  Where  VoucherNumber.Statuss!='Written' and  VoucherNumber.VoucherNo!= '" + voucherNoD + "' order by VoucherNumber.VoucherNo desc";
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

        
        private void txt1Particulars_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoD.Focus();
                //return;
            }
        }

        private void txt2Particulars_TextChanged(object sender, EventArgs e)
        {
           
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

        private void txt2Particulars_Enter(object sender, EventArgs e)
        {
            if (billOrInvoiceNoForC.Visible && string.IsNullOrWhiteSpace(billOrInvoiceNoForC.Text))
                {
                    MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.BeginInvoke(new ChangeFocusDelegate(changeFocus),billOrInvoiceNoForC);
                    
                }
            
            else  if (string.IsNullOrWhiteSpace(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoC);
               
            }
        }

        private void txt1Particulars_Enter(object sender, EventArgs e)
        {
            if (billOrInvoiceNoD.Visible && string.IsNullOrWhiteSpace(billOrInvoiceNoD.Text))
                {
                    MessageBox.Show("Please Insert Bill Or Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.BeginInvoke(new ChangeFocusDelegate(changeFocus),billOrInvoiceNoD);
                    //return;
                }
            
            else if (string.IsNullOrWhiteSpace(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Type Voucher No before Particulars", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoD);
                //return;
            }
        }

        private void txt1DebitAmount_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt1Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),txt1Particulars);
                
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Make sure the splash screen is closed
            CloseSplash();
            base.OnClosing(e);
        }

        private void MultipleBatchPosting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            PreliStepsOfLedgerEntry frm = new PreliStepsOfLedgerEntry();
            frm.Show();
        }

        private void cmbVoucherNoD_Leave(object sender, EventArgs e)
        {
            if ( !string.IsNullOrWhiteSpace(cmbVoucherNoD.Text)&&!cmbVoucherNoD.Items.Contains(cmbVoucherNoD.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoD.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoD);
            }
        }

        private void cmbVoucherNoC_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbVoucherNoC.Text) && !cmbVoucherNoC.Items.Contains(cmbVoucherNoC.Text))
            {
                MessageBox.Show("Please Select A Valid Voucher No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVoucherNoC.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmbVoucherNoC);
            }
        }

        private void txt1RequisitionNo_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmb1LedgerName);

            }
        }

        private void cmbVoucherNoD_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb1LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmb1LedgerName);

            }
        }

        private void txt2FundRequisition_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmb2LedgerName);

            }
        }

        private void cmbVoucherNoC_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb2LedgerName.Text))
            {
                MessageBox.Show("Please select Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus),cmb2LedgerName);

            }
        }

        private void txt2CreditAmount_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt2Particulars.Text))
            {
                MessageBox.Show("Please enter Particulars", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), txt2Particulars);

            }
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
    }
}
