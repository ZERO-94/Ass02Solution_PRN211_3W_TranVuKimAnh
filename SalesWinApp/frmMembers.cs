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
    public partial class frmMembers : UserControl
    {

        private Admin admin;
        private MemberRepository memberRepository;
        private frmLogin loginForm;

        public frmMembers()
        {
            this.admin = admin;
            this.loginForm = loginForm;
            memberRepository = new MemberRepository();
            InitializeComponent();
        }

        private delegate List<Member> TableFilter(List<Member> memberList);

        private void loadTableData(TableFilter filter)
        {
            DataTable memberTable = new DataTable();
            memberTable.Columns.Add("ID");
            memberTable.Columns.Add("Email");
            memberTable.Columns.Add("Company Name");
            memberTable.Columns.Add("City");
            memberTable.Columns.Add("Country");
            
            //load data
            List<Member> members = memberRepository.GetAllMembers();

            //filter in here
            List<Member> membersAfterFilter = filter(members);

            foreach (Member member in membersAfterFilter)
            {
                memberTable.Rows.Add(member.MemberId, member.Email, member.CompanyName, member.City, member.Country);
            }

            memberDataGrid.DataSource = memberTable;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            //logout
            loginForm.Show();
            admin = null;

            this.Hide();
        }

        private void createMember_Click(object sender, EventArgs e)
        {
            try
            {
                  frmMemberForAdmin frmMemberForAdmin = new frmMemberForAdmin("create", null);

                if (frmMemberForAdmin.ShowDialog() == DialogResult.OK)
                {
                    //create member
                    Member memberObject = frmMemberForAdmin.GetMemberObject();

                    bool createRes = memberRepository.CreateMember(memberObject);
                    if (createRes) MessageBox.Show("Create successfully");
                    else MessageBox.Show("Failed to create");
                }
            }
            finally
            {
                loadTableData(delegate (List<Member> list)
                {
                    return list;
                });
            }
        }

        private void updateMember_Click(object sender, EventArgs e)
        {
            try
            {
                string updateId = (string)memberDataGrid.Rows[memberDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (updateId != null)
                {
                    Member updateMember = memberRepository.GetMemberById(int.Parse(updateId));
                    frmMemberForAdmin frmMemberForAdmin = new frmMemberForAdmin("update", updateMember);

                    if (frmMemberForAdmin.ShowDialog() == DialogResult.OK)
                    {
                        //create member
                        Member memberObject = frmMemberForAdmin.GetMemberObject();

                        bool updateRes = memberRepository.UpdateMember(int.Parse(updateId), memberObject);
                        if (updateRes) MessageBox.Show("Update successfully");
                        else MessageBox.Show("Failed to update");
                    }
                }
            }
            finally
            {
                loadTableData(delegate (List<Member> list)
                {
                    return list;
                });
            }
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            loadTableData(delegate (List<Member> list)
            {
                return list; //get all
            });
        }

        private void deleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteId = (string)memberDataGrid.Rows[memberDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (deleteId != null)
                {
                    bool deleteRes = memberRepository.DeleteMember(int.Parse(deleteId));
                    if (deleteRes)
                    {
                        MessageBox.Show("Delete successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete");
                    }
                }
                else
                {
                    MessageBox.Show("There is problem, try again!");
                }
            }
            finally
            {
                loadTableData(delegate (List<Member> list)
                {
                    return list;
                });
            }
        }
    }
}
