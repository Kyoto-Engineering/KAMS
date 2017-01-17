using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.DAO;
using AccountsManagementSystem.Manager;

namespace AccountsManagementSystem.UI
{
    public partial class VoucherNoLoader : Form
    {
        public VoucherNoLoader()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (chequeStartNoTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Cheque Start Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chequeStartNoTextBox.Focus();
                return;
            }
            if (chequeEndNoTextBox.Text == "")
            {
                MessageBox.Show("You Must Enter Cheque Ending Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chequeEndNoTextBox.Focus();
                return;
            }
            UInt64 L = Convert.ToUInt64(chequeEndNoTextBox.Text);
            UInt64 F = Convert.ToUInt64(chequeStartNoTextBox.Text);
            if ((L - (F - 1)) == 25 || (L - (F - 1)) == 50 || (L - (F - 1)) >= 100)
            {
                int i = 0;

                for (UInt64 k = Convert.ToUInt64(chequeStartNoTextBox.Text); k <= Convert.ToUInt64(chequeEndNoTextBox.Text); k++)
                {


                    VoucherManager aEmpManager = new VoucherManager();

                    Voucher aCheque = new Voucher
                    {

                        //BankName = txtLBankNameCombo.Text,
                        //AccountNo = cmbCAccountNo.Text,
                        //CheequeNumber = k




                    };

                    i = aEmpManager.SaveCheque(aCheque);
                }
                MessageBox.Show("Voucher Number Successfully Loaded");
               // Reset();
                loadButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Checque Book is Not Conventional in Range,Please Select a Conventional Range such as 25,50 or 100");
            }
            
        }
    }
}
