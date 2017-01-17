using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountsManagementSystem.LogInUI
{
    public partial class UserManagementUI : Form
    {
        public string testUserType;
        public UserManagementUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testUserType == "SuperAdmin")
            {
                this.Visible = false;
                dynamic frm = new frmRegistration();
                frm.ShowDialog();
                this.Visible = true;
            }
            if (testUserType == "Admin")
            {
                this.Visible = false;
                dynamic frm = new RegistrationForUser();
                frm.ShowDialog();
                this.Visible = true;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (testUserType == "SuperAdmin")
            {
                this.Visible = false;
                dynamic frm = new UpdateUserForAdmin();
                frm.ShowDialog();
                this.Visible = true;
            }
            if (testUserType == "Admin")
            {
                this.Visible = false;
                dynamic frm = new UpdateUser();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            dynamic frm = new ResetPassword();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void UserManagementUI_Load(object sender, EventArgs e)
        {
            testUserType = frmLogin.userType;
        }
    }
}
