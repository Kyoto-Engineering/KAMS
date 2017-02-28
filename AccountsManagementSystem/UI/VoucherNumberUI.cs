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
    public partial class VoucherNumberUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private string userId;
        private int batchId,voucherNo;

        public VoucherNumberUI()
        {
            InitializeComponent();
        }

        private void SaveUserRecord()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "insert into VoucherBatch(EntryById,EntryDateTime,BookNum) Values(@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@d1", userId);
            cmd.Parameters.AddWithValue("@d2", DateTime.UtcNow.ToLocalTime());
            cmd.Parameters.AddWithValue("@d3", txtBookNumber.Text);
            batchId = (int)cmd.ExecuteScalar();
            con.Close();           
            
        }

        private void Reset()
        {
            voucherNoStartPoint.Clear();
            voucherNoEndPoint.Clear();
            txtBookNumber.Clear();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (voucherNoStartPoint.Text == "")
            {
                MessageBox.Show("Please enter VoucherNo Start Point", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                voucherNoStartPoint.Focus();
                return;
            }
            if (voucherNoEndPoint.Text == "")
            {
                MessageBox.Show("Please enter VoucherNo end Point", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                voucherNoEndPoint.Focus();
                return;
            }
            try
            {           
                con=new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "Select VoucherNumber.VoucherNo,VoucherNumber.VoucherNo from VoucherNumber  where  VoucherNumber.VoucherNo='" + voucherNoStartPoint.Text + "' OR  VoucherNumber.VoucherNo='" + voucherNoEndPoint.Text + "' ";
                cmd=new SqlCommand(query1,con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   // voucherNo = (rdr.GetInt32(0));
                    MessageBox.Show("This Voucher Number Range is already exist.Please select correct voucher Number range.", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    voucherNoStartPoint.Clear();
                    voucherNoEndPoint.Clear();
                    voucherNoStartPoint.Focus();
                }
                con.Close();
                SaveUserRecord();
                for (UInt64 k = Convert.ToUInt64(voucherNoStartPoint.Text); k <= Convert.ToUInt64(voucherNoEndPoint.Text); k++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "insert into VoucherNumber(VoucherBatchId,VoucherNo,Statuss) Values(@d1,@d2,@d3)";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d1", batchId);
                    cmd.Parameters.AddWithValue("@d2", k.ToString("D6"));
                    cmd.Parameters.AddWithValue("@d3", "Ready");
                    cmd.ExecuteNonQuery();
                    con.Close();

                }               
                MessageBox.Show("These Voucher Number Successfully  Created.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input String was not in a Correct Format", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void VoucherNumberUI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
        }
    }
}
