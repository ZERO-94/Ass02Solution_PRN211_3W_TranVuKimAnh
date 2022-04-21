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
    public partial class frmProductForAdmin : Form
    {
        private string operationType;
        private Product product;
        private ProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        public frmProductForAdmin(string operationType, Product updateProduct)
        {
            this.operationType = operationType;
            product = updateProduct;
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();

            InitializeComponent();
            btnCancel.CausesValidation = false;
        }

        public Product GetProductObject()
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                int categoryId = int.Parse(cbCategory.SelectedValue.ToString());

                if (operationType.Equals("create"))
                {
                    Product newProduct = new Product()
                    {
                        ProductId = int.Parse(tbId.Text.Trim()),
                        CategoryId = categoryRepository.GetCategoryById(categoryId).CategoryId,
                        ProductName = tbName.Text.Trim(),
                        Weight = tbWeight.Text.Trim(),
                        UnitPrice = decimal.Parse(tbUnitPrice.Text.Trim()),
                        UnitsInStock = int.Parse(tbUnitInStock.Text.Trim())
                    };

                    return newProduct;
                }
                else if (operationType.Equals("update"))
                {
                    product.CategoryId = categoryRepository.GetCategoryById(categoryId).CategoryId;
                    product.ProductName = tbName.Text.Trim();
                    product.Weight = tbWeight.Text.Trim();
                    product.UnitPrice = decimal.Parse(tbUnitPrice.Text.Trim());
                    product.UnitsInStock = int.Parse(tbUnitInStock.Text.Trim());

                    return product;
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
                else if (productRepository.GetProductById(int.Parse(tbId.Text.Trim())) != null)
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

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbName, "Name can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbName, null);
            }
        }

        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbCategory.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(cbCategory, "Category can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cbCategory, null);
            }
        }

        private void tbWeight_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbWeight.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbWeight, "Weight can't be blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbWeight, null);
            }
        }

        private void tbUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (string.IsNullOrWhiteSpace(tbUnitPrice.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUnitPrice, "Unit Price can't be blank!");
            } else if (!decimal.TryParse(tbUnitPrice.Text.Trim(), out result))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUnitPrice, "Unit Price must be decimal!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUnitPrice, null);
            }
        }

        private void tbUnitInStock_Validating(object sender, CancelEventArgs e)
        {

            int result;

            if (operationType.Equals("create"))
            {
                if (string.IsNullOrWhiteSpace(tbUnitInStock.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbUnitInStock, "Unit in Stock can't be blank!");
                } else if (!int.TryParse(tbUnitInStock.Text.Trim(), out result))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbUnitInStock, "Unit in Stock must be integer!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tbUnitInStock, null);
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

        private void frmProductForAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductForAdmin_Load(object sender, EventArgs e)
        {
            //load category
            List<Category> categories = categoryRepository.GetAllCategories();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
            cbCategory.DataSource = categories;


            if (operationType.Equals("create"))
            {
                //show all
                lbOperation.Text = "Create new product";
            }
            else if (operationType.Equals("update"))
            {
                //hide id and password
                lbOperation.Text = "Update product with ID: " + product.ProductId;
                tbId.Hide();
                lbId.Hide();

                //load data
                tbId.Text = product.ProductId.ToString();
                cbCategory.SelectedItem = categoryRepository.GetCategoryById((int)product.CategoryId);
                tbName.Text = product.ProductName;
                tbWeight.Text = product.Weight;
                tbUnitPrice.Text = product.UnitPrice.ToString();
                tbUnitInStock.Text = product.UnitsInStock.ToString();
            }
        }
    }
}
