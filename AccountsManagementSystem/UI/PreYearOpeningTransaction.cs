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

namespace AccountsManagementSystem.UI
{
    public partial class PreYearOpeningTransaction : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int fiscalLE6Year,testFiscalYear, approvedByUId;
        public PreYearOpeningTransaction()
        {
            InitializeComponent();
        }

        private void btnNewYearOpeningTransaction_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select FiscalId From YearOpeningEvent where  YearOpeningEvent.FiscalId='" + fiscalLE6Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                testFiscalYear = (rdr.GetInt32(0));
                
            }
            if (testFiscalYear != fiscalLE6Year)
            {
                this.Hide();
                YearOpeningTransaction frm = new YearOpeningTransaction();
                frm.Show();
            }
            else
            {
                MessageBox.Show("The Balance Carry Forwarding is Already has  Done  for this Year", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                     
                      
        }

        private void btnApproveTrialBalance_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select ApprovedByUId From YearOpeningEvent  where  YearOpeningEvent.FiscalId='" + fiscalLE6Year + "'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {


                if (!rdr.IsDBNull(0))
                {


                    MessageBox.Show("The Balance Carry Forwarding is Already has  Approved  for this Year", "Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.Hide();
                    YearOpeningAproval frm = new YearOpeningAproval();
                    frm.Show();

                }

            }
            else
            {
                MessageBox.Show("Insert Year Opening Transaction  for this Year First", "Report",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
 


                           
        }

        private void button1_Click(object sender, EventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                frm.Show();
        }

        private void PreYearOpeningTransaction_Load(object sender, EventArgs e)
        {
            fiscalLE6Year = FiscalYear.phiscalYear;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            dynamic dr = new ReOpeninigFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }
    }
}
