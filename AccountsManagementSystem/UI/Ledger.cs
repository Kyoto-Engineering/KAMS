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

namespace AccountsManagementSystem.UI
{
    public partial class Ledger : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string fullName, userId,accountType,genericType,lUserType;
        public int AGRelId, fiscalLYear, ledgerId, genericTypeId, AGRelId1, genericTypeId1, lID1, maxFiscalId;
        public decimal balance1;
       

        public Ledger()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal, AGRel where  Ledger.AGRelId=AGRel.AGRelId and Ledger.LedgerId=BalanceFiscal.LedgerId and BalanceFiscal.FiscalId='"+fiscalLYear+"' order by Ledger.LedgerId desc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridViewk.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridViewk.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3],rdr[4],rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Ledger_Load(object sender, EventArgs e)
        {
            updateButton.Visible = false;
            lUserType = frmLogin.userType;
            userId = frmLogin.uId.ToString();
            fiscalLYear = FiscalYear.phiscalYear;            
            GetData();
            
        }

        private void PopulateData()
        {
            try
            {
                DataGridViewRow dr = dataGridViewk.CurrentRow;
                txtLedgerId.Text = dr.Cells[0].Value.ToString();
                txtLedgerName.Text = dr.Cells[2].Value.ToString();
                cmbLedgerAccountType.Text = dr.Cells[3].Value.ToString();
                txtPreviousLedgerId.Text = dr.Cells[5].Value.ToString();
                label5.Text = label6.Text;
                updateButton.Enabled = true;
                saveButton.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            label8.Text = "Update Ledger Account";
            label4.Visible = true;
            txtLedgerId.Visible = true;
            updateButton.Visible = true;
            PopulateData();

            if (lUserType == "SuperAdmin")
            {
                label10.Visible = true;
                cmbLedgerAccountType.Visible = true;
            }
            if (lUserType == "Admin")
            {
                label10.Visible = false;
                cmbLedgerAccountType.Visible = false;
            }
            GetAGRelId();
            GetAccountTypeId();

        }

       

        private void Reset()
        {
            txtLedgerId.Text = "";
            txtPreviousLedgerId.Text = "";
            txtLedgerName.Text = "";
            cmbLedgerAccountType.SelectedIndex = -1;
            saveButton.Enabled = true;
            label10.Visible = true;
            cmbLedgerAccountType.Visible = true;
            label8.Text = "Create New Ledger Account";
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void UpdateSelectedLedgerBalance()
        {
            try
            {                             
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "Select BalanceFiscal.Balance from BalanceFiscal  where BalanceFiscal.LedgerId='" + txtLedgerId.Text + "' and BalanceFiscal.LId='" + lID1 + "' ";
                    cmd = new SqlCommand(qry, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        balance1 = (rdr.GetDecimal(0));
                    }

                    decimal balance2 = (balance1*(-1));               
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update BalanceFiscal set Balance=" + balance2 + " where BalanceFiscal.LedgerId ='" + txtLedgerId.Text + "' and BalanceFiscal.LId='" + lID1 + "' ";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input String was not in a Correct Format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAccountType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Ledger set AGRelId=@d1 where Ledger.LedgerId='" +txtLedgerId.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", AGRelId1);              
                rdr = cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
        private void updateButton_Click_1(object sender, EventArgs e)
        {
           
            if (txtLedgerName.Text == "")
            {
                MessageBox.Show("Please enter Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLedgerName.Focus();
                return;
            }
            if (cmbLedgerAccountType.Text == "")
            {
                MessageBox.Show("Please select Ledger Account Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLedgerAccountType.Focus();
                return;
            }
           

            try
            {


                if (genericTypeId == genericTypeId1)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "Update Ledger set PreviousLedgerId=@d1,LedgerName=@d2,UpdatedBy=@d3,DateUpdated=@d4 where Ledger.LedgerId='" + txtLedgerId.Text + "'";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtPreviousLedgerId.Text);
                    cmd.Parameters.AddWithValue("@d2", txtLedgerName.Text);
                    cmd.Parameters.AddWithValue("@d3", userId);
                    cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    rdr = cmd.ExecuteReader();
                    con.Close();

                    MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                    Reset();
                }
                if (genericTypeId != genericTypeId1)
                {

                   
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb2 = "Update Ledger set PreviousLedgerId=@d1,LedgerName=@d2,UpdatedBy=@d3,DateUpdated=@d4,AGRelId=@d5 where Ledger.LedgerId='" + txtLedgerId.Text + "'";
                    cmd = new SqlCommand(cb2);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", txtPreviousLedgerId.Text);
                    cmd.Parameters.AddWithValue("@d2", txtLedgerName.Text);
                    cmd.Parameters.AddWithValue("@d3", userId);
                    cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d5", AGRelId1);
                    rdr = cmd.ExecuteReader();
                    con.Close();
                    UpdateSelectedLedgerBalance();
                    MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetData();
                    Reset();

                    
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetMaxFiscalYear()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select MAX(FiscalId) from FiscalYears";
                cmd=new SqlCommand(qry,con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    maxFiscalId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
           
            if (txtLedgerName.Text == "")
            {
                MessageBox.Show("Please enter Ledger Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLedgerName.Focus();
                return;
            }
            if (cmbLedgerAccountType.Text == "")
            {
                MessageBox.Show("Please select Ledger Account Type ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLedgerAccountType.Focus();
                return;
            }
           

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select LedgerName from Ledger where LedgerName='" + txtLedgerName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Ledger  Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLedgerName.Text = "";
                    txtLedgerName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Ledger(DateCreated,PreviousLedgerId,LedgerName,CreatedBy,AGRelId) VALUES (@d1,@d2,@d3,@d4,@d5)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(System.DateTime.Today, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d2", txtPreviousLedgerId.Text);
                cmd.Parameters.AddWithValue("@d3", txtLedgerName.Text);
                cmd.Parameters.AddWithValue("@d4", userId);
                cmd.Parameters.AddWithValue("@d5", AGRelId1);
                ledgerId = (int)cmd.ExecuteScalar();
                con.Close();
                GetMaxFiscalYear();

                if (fiscalLYear == maxFiscalId)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "insert into BalanceFiscal(LedgerId,FiscalId,Balance) VALUES (@d1,@d2,@d3)";
                    cmd = new SqlCommand(qry);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", ledgerId);
                    cmd.Parameters.AddWithValue("@d2", fiscalLYear);
                    cmd.Parameters.AddWithValue("@d3", "0.0000");
                    cmd.ExecuteReader();
                    con.Close();
                }
                if (maxFiscalId > fiscalLYear)
                {
                    for (int fiscalId = fiscalLYear; fiscalId <= maxFiscalId; fiscalId++)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string qry1 = "insert into BalanceFiscal(LedgerId,FiscalId,Balance) VALUES (@d1,@d2,@d3)";
                        cmd = new SqlCommand(qry1);
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@d1", ledgerId);
                        cmd.Parameters.AddWithValue("@d2", fiscalId);
                        cmd.Parameters.AddWithValue("@d3", "0.0000");
                        cmd.ExecuteReader();
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                GetData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridViewk.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridViewk.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (lUserType == "SuperAdmin")
            {
                this.Hide();
                MainUI frm = new MainUI();
                frm.Show();
            }
            if (lUserType == "Admin")
            {
                this.Hide();
                MainUIForAdmin frm1 = new MainUIForAdmin();
                frm1.Show();
            }
            
        }

        private void txtSLedgerId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(LedgerId),RTRIM(PreviousLedgerId),RTRIM(LedgerName) from Ledger where  LedgerId like '" + txtLedgerId.Text + "%' order by LedgerId",con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridViewk.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridViewk.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSLedgerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.PreviousLedgerId),RTRIM(Ledger.LedgerName) from Ledger where  Ledger.LedgerName like '" + txtLedgerId.Text + "%' order by Ledger.LedgerId",con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridViewk.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridViewk.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSLedgerName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerName like '" + txtSLedgerName.Text + "%' and  BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridViewk.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridViewk.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3],rdr[4],rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSLedgerId_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(Ledger.LedgerId),RTRIM(Ledger.DateCreated),RTRIM(Ledger.LedgerName),RTRIM(AGRel.AccountType),RTRIM(BalanceFiscal.Balance),RTRIM(Ledger.PreviousLedgerId) from Ledger,BalanceFiscal,AGRel where Ledger.AGRelId=AGRel.AGRelId and  Ledger.LedgerId=BalanceFiscal.LedgerId and Ledger.LedgerId like '" + txtSLedgerId.Text + "%' and BalanceFiscal.FiscalId='" + fiscalLYear + "' order by Ledger.LedgerName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridViewk.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridViewk.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3],rdr[4],rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetAccountTypeId1()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  AGRel.GenericTypeId  from AGRel where AGRel.AGRelId='" + AGRelId1 + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    genericTypeId1 = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetAccountTypeId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select  AGRel.GenericTypeId  from AGRel where AGRel.AGRelId='" + AGRelId + "' ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    genericTypeId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetAGRelId1()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select AGRel.AGRelId from AGRel  where AGRel.AccountType='" + cmbLedgerAccountType.Text + "' ";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    AGRelId1 = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetAGRelId()
        {
            try
            {
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select AGRel.AGRelId from AGRel  where AGRel.AccountType='"+cmbLedgerAccountType.Text+"' ";
                cmd=new SqlCommand(qry,con);
                rdr=cmd.ExecuteReader();
                if (rdr.Read())
                {
                    AGRelId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbLedgerAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetAGRelId1();
            GetAccountTypeId1();

            txtPreviousLedgerId.Focus();
             
             


        }

        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }

        private void txtPreviousLedgerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLedgerName.Focus();
                e.Handled = true;
            }
        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (label4.Visible == true)
                {
                    updateButton_Click_1(this, new EventArgs());
                    
                }
                else
                {
                    saveButton_Click_1(this, new EventArgs());
                }
            }
        }

        private void txtLedgerId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLedgerAccountType.Focus();
                e.Handled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtLedgerId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Select BalanceFiscal.LId from BalanceFiscal  where BalanceFiscal.LedgerId='" + txtLedgerId.Text + "' and  BalanceFiscal.FiscalId='"+fiscalLYear+"' ";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lID1 = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewk_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label8.Text = "Update Ledger Account";
            label4.Visible = true;
            txtLedgerId.Visible = true;
            updateButton.Visible = true;
            PopulateData();

            if (lUserType == "SuperAdmin")
            {
                label10.Visible = true;
                cmbLedgerAccountType.Visible = true;
            }
            if (lUserType == "Admin")
            {
                label10.Visible = false;
                cmbLedgerAccountType.Visible = false;
            }
            GetAGRelId();
            GetAccountTypeId();
        }
    }
}
