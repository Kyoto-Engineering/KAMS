using AccountsManagementSystem.DbGateway;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace AccountsManagementSystem.Reports
{   public partial class PNLReportUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private int id;
        public PNLReportUI()
        {
            InitializeComponent();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            GetButton.Enabled = false;

            ParameterField paramField1 = new ParameterField();


            //creating an object of ParameterFields class
            ParameterFields paramFields1 = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            //set the parameter field name
            paramField1.Name = "id";

            //set the parameter value
            paramDiscreteValue1.Value = PNLIdComboBox.Text;

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
            PNLTotalX cr = new PNLTotalX();
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
            GetButton.Enabled = true;
            PNLIdComboBox.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void PNLReportUI_Load(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT PId FROM PNLEvent ORDER BY PId";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PNLIdComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
