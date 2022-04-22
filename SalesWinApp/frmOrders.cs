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
    public partial class frmOrders : UserControl
    {
        private Member member;
        private IOrderRepository orderRepository;
        private ICategoryRepository categoryRepository;
        private IMemberRepository memberRepository;
        private frmLogin loginForm;

        public frmOrders()
        {
            this.loginForm = loginForm;
            orderRepository = new OrderRepository();
            categoryRepository = new CategoryRepository();
            memberRepository = new MemberRepository();
            InitializeComponent();
        }

        public void setMember(Member member)
        {
            this.member=member;

            if(member!=null)
            {
                loadTableData(delegate (List<Order> list)
                {
                    return list;
                });
            }
        }

        private delegate List<Order> TableFilter(List<Order> orderList);

        private void loadTableData(TableFilter filter)
        {
            DataTable orderTable = new DataTable();
            orderTable.Columns.Add("ID");
            orderTable.Columns.Add("Member ID");
            orderTable.Columns.Add("Order date");
            orderTable.Columns.Add("Required date");
            orderTable.Columns.Add("Shipped date");
            orderTable.Columns.Add("Freight");

            //load data
            List<Order> orders = orderRepository.GetAllOrders();

            //filter in here
            List<Order> ordersAfterFilter = filter(orders);

            if(member != null && !(member is Admin))
            {
                ordersAfterFilter = ordersAfterFilter.Where(o => o.MemberId == member.MemberId).ToList();
            }

            foreach (Order order in ordersAfterFilter)
            {
                orderTable.Rows.Add(order.OrderId, order.MemberId, order.OrderDate, order.RequiredDate, order.ShippedDate, order.Freight);
            }

            orderDataGrid.DataSource = orderTable;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            //logout
            loginForm.Show();
            member = null;

            this.Hide();
        }

        private void createOrder_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrderDetail frmOrderDetail = new frmOrderDetail("create", null);

                if (frmOrderDetail.ShowDialog() == DialogResult.OK)
                {
                    //create order
                    Order orderObject = frmOrderDetail.GetOrderObject();

                    bool createRes = orderRepository.CreateOrder(orderObject);
                    if (createRes) MessageBox.Show("Create successfully");
                    else MessageBox.Show("Failed to create");
                }
            }
            finally
            {
                loadTableData(delegate (List<Order> list)
                {
                    return list;
                });
            }
        }

        private void updateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string updateId = (string)orderDataGrid.Rows[orderDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (updateId != null)
                {
                    Order updateOrder = orderRepository.GetOrderById(int.Parse(updateId));
                    frmOrderDetail frmOrderDetail = new frmOrderDetail("update", updateOrder);

                    if (frmOrderDetail.ShowDialog() == DialogResult.OK)
                    {
                        //create order
                        Order orderObject = frmOrderDetail.GetOrderObject();

                        bool updateRes = orderRepository.UpdateOrder(int.Parse(updateId), orderObject);
                        if (updateRes) MessageBox.Show("Update successfully");
                        else MessageBox.Show("Failed to update");
                    }
                }
            }
            finally
            {
                loadTableData(delegate (List<Order> list)
                {
                    return list;
                });
            }
        }

        public void load()
        {
            loadTableData(delegate (List<Order> list)
            {
                return list;
            });
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteId = (string)orderDataGrid.Rows[orderDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (deleteId != null)
                {
                    bool deleteRes = orderRepository.DeleteOrder(int.Parse(deleteId));
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
                loadTableData(delegate (List<Order> list)
                {
                    return list;
                });
            }
        }

        private void report_Click(object sender, EventArgs e)
        {
            DateTime startTime = dtpStartDate.Value;
            DateTime endTime = dtpEndDate.Value;

            frmSaleReport frmSaleReport = new frmSaleReport(startTime, endTime);

            if (frmSaleReport.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
