using AccountsManagementSystem.DbGateway;
using AccountsManagementSystem.UI;
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
{
    public partial class BalanceSheetReportUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        private int id;
        public int BId, FiscalId;
        public static string pyear;
        public BalanceSheetReportUI()
        {
            InitializeComponent();
        }

        private void Report()
        {
            ParameterField parameterField1 = new ParameterField();

            ParameterFields parameterFields1 = new ParameterFields();

            ParameterDiscreteValue parameterDiscreteValue1 = new ParameterDiscreteValue();

            parameterField1.Name = "id";

            parameterDiscreteValue1.Value = BId;

            parameterField1.CurrentValues.Add(parameterDiscreteValue1);

            parameterFields1.Add(parameterField1);

            ReportViewer f1 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);

            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "AccountDb_new";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";

            BSTotalX cr = new BSTotalX();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f1.crystalReportViewer1.ParameterFieldInfo = parameterFields1;
            f1.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f1.ShowDialog();
            this.Visible = true;
        }

        private void Report1()
        {
            ParameterField parameterField1 = new ParameterField();

            ParameterFields parameterFields1 = new ParameterFields();

            ParameterDiscreteValue parameterDiscreteValue1 = new ParameterDiscreteValue();

            parameterField1.Name = "id";

            parameterDiscreteValue1.Value = BId;

            parameterField1.CurrentValues.Add(parameterDiscreteValue1);

            parameterFields1.Add(parameterField1);

            ReportViewer f1 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);

            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "AccountDb_new";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";

            Equity cr = new Equity();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f1.crystalReportViewer1.ParameterFieldInfo = parameterFields1;
            f1.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f1.ShowDialog();
            this.Visible = true;
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            GetButton.Enabled = false;

            //ParameterField paramField1 = new ParameterField();


            ////creating an object of ParameterFields class
            //ParameterFields paramFields1 = new ParameterFields();

            ////creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

            ////set the parameter field name
            //paramField1.Name = "id";

            ////set the parameter value
            //paramDiscreteValue1.Value = BId;

            ////add the parameter value in the ParameterField object
            //paramField1.CurrentValues.Add(paramDiscreteValue1);

            ////add the parameter in the ParameterFields object
            //paramFields1.Add(paramField1);
            //ReportViewer f2 = new ReportViewer();
            //TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            //TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            //ConnectionInfo reportConInfo = new ConnectionInfo();
            //Tables tables = default(Tables);
            ////	Table table = default(Table);
            //var with1 = reportConInfo;
            //with1.ServerName = "tcp:KyotoServer,49172";
            //with1.DatabaseName = "AccountDb_new";
            //with1.UserID = "sa";
            //with1.Password = "SystemAdministrator";
            //BSTotalX cr = new BSTotalX();
            //tables = cr.Database.Tables;
            //foreach (Table table in tables)
            //{
            //    reportLogonInfo = table.LogOnInfo;
            //    reportLogonInfo.ConnectionInfo = reportConInfo;
            //    table.ApplyLogOnInfo(reportLogonInfo);
            //}

            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields1;
            //f2.crystalReportViewer1.ReportSource = cr;
            //this.Visible = false;

            //f2.ShowDialog();
            //this.Visible = true;
            GetButton.Enabled = true;
            BSIdComboBox.SelectedIndexChanged -= BSIdComboBox_SelectedIndexChanged;
            BSIdComboBox.SelectedIndex = -1;
            BSIdComboBox.SelectedIndexChanged += BSIdComboBox_SelectedIndexChanged;
            Report();
            Report1();
        }

        private void BalanceSheetReportUI_Load(object sender, EventArgs e)
        {
            pyear = FiscalYear.phiscalYear.ToString();
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select (Convert(varchar(10),BSEvent.FiscalId)+'-'+ Convert(varchar(10),BSEvent.BId)) from BSEvent where BSEvent.FiscalId='" + pyear + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BSIdComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BSIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] splitterArray = BSIdComboBox.Text.Split('-');
            
            BId = Convert.ToInt32(splitterArray[1]);
            FiscalId = Convert.ToInt32(splitterArray[0]);
            string qry =
                "SELECT BSEvent.BId, FiscalYears.FiscalId FROM BSEvent INNER JOIN FiscalYears ON BSEvent.FiscalId = FiscalYears.FiscalId where BSEvent.FiscalId='" + FiscalId + "'";
            con = new SqlConnection(cs.DBConn);
            cmd.CommandText = qry;
            cmd.Connection = con;
            con.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BId = (rdr.GetInt32(0));
                FiscalId = (rdr.GetInt32(1));
               
            }
            con.Close();
        }
    }
}
