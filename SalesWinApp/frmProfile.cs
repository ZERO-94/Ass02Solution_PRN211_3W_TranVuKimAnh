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
    public partial class frmProfile : UserControl
    {
        private Member member;
        private MemberRepository memberRepository;

        public frmProfile()
        {
            memberRepository = new MemberRepository();

            InitializeComponent();
        }

        public void setMember(Member updateMember)
        {
            member = updateMember;

            if (member != null)
            {
                //load data
                tbEmail.Text = member.Email;
                tbCompanyName.Text = member.CompanyName;
                tbCity.Text = member.City;
                tbCountry.Text = member.Country;
                tbPassword.Text = member.Password;
            }
        }

        private void tbCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCompanyName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCompanyName, "Name can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCompanyName, null);
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Email can't be blank!");
            }
            else if (!tbEmail.Text.Trim().Equals(member.Email) && memberRepository.GetMemberByEmail(tbEmail.Text.Trim()) != null)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Email already exists!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, null);
            }
        }

        private void tbCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCity.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCity, "City can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCity, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Password can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void tbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCountry.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCountry, "Country can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCountry, null);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //update profile
                member.CompanyName = tbCompanyName.Text.Trim();
                member.Email = tbEmail.Text.Trim();
                member.City = tbCity.Text.Trim();
                member.Country = tbCountry.Text.Trim();
                member.Password = tbPassword.Text.Trim();

                bool res = memberRepository.UpdateMember(member.MemberId, member);
                if (res) MessageBox.Show("Update successfully");
                else
                {
                    member = memberRepository.GetMemberById(member.MemberId);
                    MessageBox.Show("Update failed!");
                }



                //load data
                tbEmail.Text = member.Email;
                tbCompanyName.Text = member.CompanyName;
                tbCity.Text = member.City;
                tbCountry.Text = member.Country;
                tbPassword.Text = member.Password;
            }
        }

        private void frmProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        public void load()
        {
            if (member != null)
            {
                //load data
                tbEmail.Text = member.Email;
                tbCompanyName.Text = member.CompanyName;
                tbCity.Text = member.City;
                tbCountry.Text = member.Country;
                tbPassword.Text = member.Password;
            }
        }
    }
}
