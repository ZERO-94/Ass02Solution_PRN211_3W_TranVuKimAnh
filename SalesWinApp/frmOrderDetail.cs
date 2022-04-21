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
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                if (operationType.Equals("create"))
                {
                    Order newOrder = new Order()
                    {
                        OrderId = int.Parse(tbId.Text.Trim()),
                        MemberId = int.Parse(cbMember.SelectedValue.ToString()),
                        OrderDate = dtpOrderDate.Value,
                        ShippedDate = dtpShippedDate.Value,
                        RequiredDate = dtpRequiredDate.Value
                    };

                    return newOrder;
                    
                }
                else if (operationType.Equals("update"))
                {
                    order.OrderDate = dtpOrderDate.Value;
                    order.ShippedDate = dtpShippedDate.Value;
                    order.RequiredDate = dtpRequiredDate.Value;

                    return order;
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
                order = new Order();
            }
            else if (operationType.Equals("update"))
            {
                //hide id and password
                lbOperation.Text = "Update order with ID: " + order.OrderId;
                tbId.Hide();
                lbId.Hide();
                cbMember.Hide();
                lbMember.Hide();

                //load data
                tbId.Text = order.OrderId.ToString();
                cbMember.SelectedItem = memberRepository.GetMemberById((int)order.MemberId);
                dtpOrderDate.Value = order.OrderDate;
                dtpRequiredDate.Value = (DateTime)order.RequiredDate;
                dtpShippedDate.Value = (DateTime)order.ShippedDate;

                //load order detail
                orderDetailDataGrid.DataSource = order.OrderDetails.ToList();
                orderDetailDataGrid.Columns[6].Visible = false;
                orderDetailDataGrid.Columns[5].Visible = false;
                orderDetailDataGrid.Columns[4].Visible = false;
                orderDetailDataGrid.Columns[0].Visible = false;
            }
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductToOrder frmProductToOrder = new frmProductToOrder("create", null);

                if (frmProductToOrder.ShowDialog() == DialogResult.OK)
                {
                    //create member
                    OrderDetail orderDetailObject = frmProductToOrder.GetOrderDetailObject();

                    orderDetailObject.OrderId = order.OrderId;

                    order.OrderDetails.Add(orderDetailObject);
                }
            }
            finally
            {
                //load order detail
                orderDetailDataGrid.DataSource = order.OrderDetails.ToList();
                orderDetailDataGrid.Columns[4].Visible = false;
            }
        }

        private void removeProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int deleteId = (int)orderDetailDataGrid.Rows[orderDetailDataGrid.CurrentCell.RowIndex].Cells[1].Value;

                if (deleteId != null)
                {
                    order.OrderDetails.Remove(
                        order.OrderDetails.FirstOrDefault(x => x.ProductId == deleteId)
                        );
                }
                else
                {
                    MessageBox.Show("There is problem, try again!");
                }
            }
            finally
            {
                //load order detail
                orderDetailDataGrid.DataSource = order.OrderDetails.ToList();
            }
        }

        private void updateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int updateId = (int)orderDetailDataGrid.Rows[orderDetailDataGrid.CurrentCell.RowIndex].Cells[1].Value;

                if (updateId != null)
                {
                    OrderDetail updateOrder = order.OrderDetails.FirstOrDefault(x => x.ProductId == updateId);
                    if (updateOrder != null)
                    {
                        try
                        {
                            frmProductToOrder frmProductToOrder = new frmProductToOrder("update", updateOrder);

                            if (frmProductToOrder.ShowDialog() == DialogResult.OK)
                            {
                                //create member
                                OrderDetail orderDetailObject = frmProductToOrder.GetOrderDetailObject();

                                orderDetailObject.OrderId = order.OrderId;

                                order.OrderDetails.Add(orderDetailObject);
                            }
                        }
                        finally
                        {
                            //load order detail
                            orderDetailDataGrid.DataSource = order.OrderDetails.ToList();
                            orderDetailDataGrid.Columns[4].Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is problem, try again!");
                }
            }
            finally
            {
                //load order detail
                orderDetailDataGrid.DataSource = order.OrderDetails.ToList();
            }
        }
    }
}
