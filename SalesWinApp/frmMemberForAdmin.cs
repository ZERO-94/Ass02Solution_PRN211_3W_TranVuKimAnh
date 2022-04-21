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
    public partial class frmMemberForAdmin : Form
    {
        private string operationType;
        private Member member;
        private MemberRepository memberRepository;
        public frmMemberForAdmin(string operationType, Member updateMember)
        {
            this.operationType = operationType;
            member = updateMember;
            memberRepository = new MemberRepository();

            InitializeComponent();
            btnCancel.CausesValidation = false;
        }

        public Member GetMemberObject()
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                

                if (operationType.Equals("create"))
                {
                    Member newMember = new Member()
                    {
                        CompanyName = tbCompanyName.Text.Trim(),
                        Email = tbEmail.Text.Trim(),
                        City = tbCity.Text.Trim(),
                        Country = tbCountry.Text.Trim(),
                        MemberId = int.Parse(tbId.Text.Trim()),
                        Password = tbPassword.Text.Trim()
                    };
                    return newMember;
                }
                else if (operationType.Equals("update"))
                {
                    member.CompanyName = tbCompanyName.Text.Trim();
                    member.Email = tbEmail.Text.Trim();
                    member.City = tbCity.Text.Trim();
                    member.Country = tbCountry.Text.Trim();

                    return member;
                } else
                {
                    return null;
                }
            }

            return null;
        }

        private void tbId_Validating(object sender, CancelEventArgs e)
        {
            if (operationType.Equals("create"))
            {
                int result;
                if (string.IsNullOrWhiteSpace(tbId.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbId, "Id can't be blank!");
                } else if (!int.TryParse(tbId.Text.Trim(), out result))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbId, "Id must be number!");
                }
                else if (memberRepository.GetMemberById(int.Parse(tbId.Text.Trim())) != null)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbId, "Id can't be duplicated!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tbId, null);
                }
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

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (operationType.Equals("create"))
            {
                if (string.IsNullOrWhiteSpace(tbPassword.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbPassword, "Email can't be blank!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tbPassword, null);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void frmMemberForAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberForAdmin_Load(object sender, EventArgs e)
        {

            if (operationType.Equals("create"))
            {
                //show all
                lbOperation.Text = "Create new member";
            }
            else if (operationType.Equals("update"))
            {
                //hide id and password
                lbOperation.Text = "Update member with ID: " + member.MemberId;
                tbId.Hide();
                lbId.Hide();
                tbPassword.Hide();
                lbPassword.Hide();

                //load data
                tbId.Text = member.MemberId.ToString();
                tbEmail.Text = member.Email;
                tbCompanyName.Text = member.CompanyName;
                tbCity.Text = member.City;
                tbCountry.Text = member.Country;
                tbPassword.Text = member.Password;
            }
        }
    }
}
