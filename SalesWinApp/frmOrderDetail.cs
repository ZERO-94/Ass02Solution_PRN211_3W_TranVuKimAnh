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
    public partial class frmOrderDetail : Form
    {
        private string operationType;
        private Order order;
        private OrderRepository orderRepository;
        private ICategoryRepository categoryRepository;
        private IMemberRepository memberRepository;
        public frmOrderDetail(string operationType, Order updateOrder)
        {
            this.operationType = operationType;
            order = updateOrder;
            orderRepository = new OrderRepository();
            categoryRepository = new CategoryRepository();
            memberRepository = new MemberRepository();

            InitializeComponent();
            btnCancel.CausesValidation = false;
        }

        public Order GetOrderObject()
        {
            Order newOrder = null;
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                newOrder = new Order()
                {
                    OrderDate = dtpOrderDate.Value,
                    ShippedDate = dtpShippedDate.Value,
                    RequiredDate = dtpRequiredDate.Value
                };

                //TODO: get all product later

                if (operationType.Equals("create"))
                {
                    newOrder.OrderId = int.Parse(tbId.Text.Trim());
                    newOrder.MemberId = int.Parse(cbMember.SelectedValue.ToString());
                }
                else if (operationType.Equals("update"))
                {
                    newOrder.OrderId = order.OrderId;
                    newOrder.OrderId = (int)order.MemberId;
                }

                return newOrder;
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
                }
                else if (!int.TryParse(tbId.Text.Trim(), out result))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbId, "Id must be number!");
                }
                else if (orderRepository.GetOrderById(int.Parse(tbId.Text.Trim())) != null)
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

        private void cbMember_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbMember.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbMember, "Name can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbMember, null);
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

        private void frmOrderDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            //load member
            List<Member> loadedMember = memberRepository.GetAllMembers();
            cbMember.DisplayMember = "MemberId";
            cbMember.ValueMember = "MemberId";
            cbMember.DataSource = loadedMember;

            if (operationType.Equals("create"))
            {
                //show all
                lbOperation.Text = "Create new order";
            }
            else if (operationType.Equals("update"))
            {
                //hide id and password
                lbOperation.Text = "Update order with ID: " + order.OrderId;
                tbId.Hide();
                lbId.Hide();

                //load data
                tbId.Text = order.OrderId.ToString();
                cbMember.SelectedValue = order.Member.MemberId.ToString();
                dtpOrderDate.Value = order.OrderDate;
                dtpRequiredDate.Value = (DateTime)order.RequiredDate;
                dtpShippedDate.Value = (DateTime)order.ShippedDate;
            }
        }
    }
}
