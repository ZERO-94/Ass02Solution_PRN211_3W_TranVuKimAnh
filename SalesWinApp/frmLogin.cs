using BusinessObject;
using BusinessObject.Models;
using DataAccess.repository;
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
    public partial class frmLogin : Form
    {
        private IMemberRepository memberRepository;
        public frmLogin()
        {
            memberRepository = new MemberRepository();
            InitializeComponent();
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Email can't be blank!");
            } else
            {
                e.Cancel= false;
                errorProvider1.SetError(tbEmail,"");
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Password can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, "");
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                Member authenticatedUser = memberRepository.CheckLogin(tbEmail.Text, tbPassword.Text);
                if(authenticatedUser != null)
                {
                    //redirect to new screen
                    RedirectToForm(authenticatedUser);
                } else
                {
                    MessageBox.Show("Invalid account!");
                }
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void RedirectToForm(Member member)
        {
            tbEmail.ResetText();
            tbPassword.ResetText();
            this.Hide();

            frmMain frmMain = new frmMain(member);
            this.FormClosed += (s, e) => frmMain.Close();
            frmMain.FormClosed += (s, e) => this.Close();
            frmMain.Show();
        }
    }
}
