using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared.Interop;

namespace AccountsManagementSystem.UI
{
    public partial class FiscalYearManagementUI : Form
    {
        public FiscalYearManagementUI()
        {
            InitializeComponent();
        }

        private void createFiscalYearButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new NewEntryForFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
        }

        private void buttonCloseingFiscalYear_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic dr = new ClosingFiscalYear();
            dr.ShowDialog();
            this.Visible = true;
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
