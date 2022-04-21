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
    public partial class frmProductToOrder : Form
    {

        private IProductRepository productRepository = new ProductRepository();
        List<Product> productList;
        string operationType;
        OrderDetail orderDetail;

        public frmProductToOrder(string operationType, OrderDetail orderDetail)
        {
            this.operationType = operationType;
            this.orderDetail = orderDetail;
            InitializeComponent();
        }

        public OrderDetail GetOrderDetailObject()
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                if (operationType.Equals("create"))
                {
                    OrderDetail newOrderDetail = new OrderDetail()
                    {
                        ProductId = int.Parse(cbProduct.SelectedValue.ToString()),
                        UnitPrice = productList.Find(p => p.ProductId == int.Parse(cbProduct.SelectedValue.ToString())).UnitPrice,
                        Quantity = int.Parse(tbQuantity.Text),
                        Discount = double.Parse(tbDiscount.Text)
                    };

                    return newOrderDetail;

                }
                else if (operationType.Equals("update"))
                {
                    orderDetail.ProductId = int.Parse(cbProduct.SelectedValue.ToString());
                    orderDetail.UnitPrice = productList.Find(p => p.ProductId == int.Parse(cbProduct.SelectedValue.ToString())).UnitPrice;
                    orderDetail.Quantity = int.Parse(tbQuantity.Text);
                    orderDetail.Discount = double.Parse(tbDiscount.Text);

                    return orderDetail;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        private void frmProductToOrder_Load(object sender, EventArgs e)
        {
            productList = productRepository.GetAllProducts();

            //load combo box
            cbProduct.DataSource = productList;
            cbProduct.DisplayMember = "ProductName";
            cbProduct.ValueMember = "ProductId";

            if(operationType.Equals("update"))
            {
                cbProduct.SelectedValue = orderDetail.ProductId;
                tbDiscount.Text = orderDetail.Discount.ToString();
                tbQuantity.Text = orderDetail.Quantity.ToString();
            }
        }

        private void tbQuantity_Validating(object sender, CancelEventArgs e)
        {

            int result;

            if(string.IsNullOrWhiteSpace(tbQuantity.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbQuantity, "Quantity can't be blank");
            } else if (!int.TryParse(tbQuantity.Text.Trim(), out result))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbQuantity, "Quantity must be integer");
            }
            else if (productList.Find(p => p.ProductId == int.Parse(cbProduct.SelectedValue.ToString())).UnitsInStock == int.Parse(tbQuantity.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbQuantity, $"Only {productList.Find(p => p.ProductId == int.Parse(cbProduct.SelectedValue.ToString())).UnitsInStock} left!");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(tbQuantity, null);
            }
        }

        private void tbDiscount_Validating(object sender, CancelEventArgs e)
        {
            decimal result;

            if (string.IsNullOrWhiteSpace(tbDiscount.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDiscount, "Quantity can't be blank");
            }
            else if (!decimal.TryParse(tbDiscount.Text.Trim(), out result))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDiscount, "Quantity must be integer");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbDiscount, null);
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
    }
}
