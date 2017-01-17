using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountsManagementSystem.LogInUI;
using AccountsManagementSystem.UI;

namespace AccountsManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainUI());
           Application.Run(new frmLogin());
           // Application.Run(new Ledger());
            //Application.Run(new NewEntryForFiscalYear());
        }
    }
}
