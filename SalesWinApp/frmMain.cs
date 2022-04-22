using BusinessObject;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        private Member user;
        private frmLogin frmLogin;
        public frmMain(Member member, frmLogin frmLogin)
        {
            this.frmLogin = frmLogin;
            user = member;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (user is Admin)
            {
                memberManagement.Visible = true;
                productManagement.Visible = true;
                myProfile.Visible = false;
                frmMembers1.Show();
                frmMembers1.load();
                frmOrders1.Hide();
                frmProducts1.Hide();
                frmProfile1.Hide();
            }
            else
            {
                memberManagement.Visible = false;
                productManagement.Visible = false;
                myProfile.Visible = true;
                frmMembers1.Hide();
                frmOrders1.Hide();
                frmProducts1.Hide();
                frmProfile1.Show();
                frmProfile1.setMember(user);
                frmProfile1.load();
            }
        }

        private void memberManagement_Click(object sender, EventArgs e)
        {
            frmMembers1.Show();
            frmMembers1.load();
            frmMembers1.load();
            frmOrders1.Hide();
            frmProducts1.Hide();
        }

        private void productManagement_Click(object sender, EventArgs e)
        {
            frmMembers1.Hide();
            frmOrders1.Hide();
            frmProducts1.Show();
            frmProducts1.load();
        }

        private void orderManagement_Click(object sender, EventArgs e)
        {
            if (user is Admin)
            {
                frmMembers1.Hide();
                frmOrders1.Show();
                frmOrders1.load();
                frmProducts1.Hide();

            }
            else
            {
                frmProfile1.Hide();
                frmOrders1.Show();
                frmOrders1.load();
            }

            frmOrders1.setMember(user);
        }

        private void myProfile_Click(object sender, EventArgs e)
        {
            frmProfile1.setMember(user);
            frmProfile1.Show();
            frmProfile1.load();
            frmOrders1.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin.Show();
            user = null;
        }
    }
}
