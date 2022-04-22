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
    public partial class frmProducts : UserControl
    {
        private Admin admin;
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private frmLogin loginForm;

        public frmProducts()
        {
            this.admin = admin;
            this.loginForm = loginForm;
            productRepository = new ProductRepository();
            categoryRepository = new CategoryRepository();
            InitializeComponent();
        }

        private delegate List<Product> TableFilter(List<Product> productList);

        private void loadTableData(TableFilter filter)
        {
            DataTable productTable = new DataTable();
            productTable.Columns.Add("ID");
            productTable.Columns.Add("Category");
            productTable.Columns.Add("Product Name");
            productTable.Columns.Add("Weight");
            productTable.Columns.Add("Unit Price");
            productTable.Columns.Add("Unit in Stock");

            //load data
            List<Product> products = productRepository.GetAllProducts();

            //filter in here
            List<Product> productsAfterFilter = filter(products);

            foreach (Product product in productsAfterFilter)
            {
                int productCategory = (int)product.CategoryId;
                productTable.Rows.Add(product.ProductId, categoryRepository.GetCategoryById(productCategory).CategoryName, product.ProductName, product.Weight, product.UnitPrice, product.UnitsInStock);
            }

            productDataGrid.DataSource = productTable;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            //logout
            loginForm.Show();
            admin = null;

            this.Hide();
        }

        private void createProduct_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductForAdmin frmProductForAdmin = new frmProductForAdmin("create", null);

                if (frmProductForAdmin.ShowDialog() == DialogResult.OK)
                {
                    //create product
                    Product productObject = frmProductForAdmin.GetProductObject();

                    bool createRes = productRepository.CreateProduct(productObject);
                    if (createRes) MessageBox.Show("Create successfully");
                    else MessageBox.Show("Failed to create");
                }
            }
            finally
            {
                loadTableData(delegate (List<Product> list)
                {
                    return list;
                });
            }
        }

        private void updateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string updateId = (string)productDataGrid.Rows[productDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (updateId != null)
                {
                    Product updateProduct = productRepository.GetProductById(int.Parse(updateId));
                    frmProductForAdmin frmProductForAdmin = new frmProductForAdmin("update", updateProduct);

                    if (frmProductForAdmin.ShowDialog() == DialogResult.OK)
                    {
                        //create product
                        Product productObject = frmProductForAdmin.GetProductObject();

                        bool updateRes = productRepository.UpdateProduct(int.Parse(updateId), productObject);
                        if (updateRes) MessageBox.Show("Update successfully");
                        else MessageBox.Show("Failed to update");
                    }
                }
            }
            finally
            {
                loadTableData(delegate (List<Product> list)
                {
                    return list;
                });
            }
        }

        private void tbId_Validating(object sender, CancelEventArgs e)
        {
            int result;
            if (tbId.Text.Trim().Length > 0 && !int.TryParse(tbId.Text.Trim(), out result))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbId, "Id must be number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbId, null);
            }
        }

        private void tbUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            decimal result;
            if (tbUnitPrice.Text.Trim().Length > 0 && !decimal.TryParse(tbUnitPrice.Text.Trim(), out result))
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
            if (tbUnitInStock.Text.Trim().Length > 0 && !int.TryParse(tbUnitInStock.Text.Trim(), out result))
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

        private void search_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //load table
                loadTableData(delegate (List<Product> list)
                {
                    int? searchId = tbId.Text.Trim().Length <= 0 ? null : int.Parse(tbId.Text.Trim());
                    string? searchName = tbProductName.Text.Trim().Length <= 0 ? null : tbProductName.Text.Trim();
                    int? searchUnitInStock = tbUnitInStock.Text.Trim().Length <= 0 ? null : int.Parse(tbUnitInStock.Text.Trim());
                    decimal? searchUnitPrice = tbUnitPrice.Text.Trim().Length <= 0 ? null : decimal.Parse(tbUnitPrice.Text.Trim());

                    return productRepository.SearchProduct(searchId, searchName, searchUnitPrice, searchUnitInStock);
                });
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            loadTableData(delegate (List<Product> list)
            {
                return list; //get all
            });
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteId = (string)productDataGrid.Rows[productDataGrid.CurrentCell.RowIndex].Cells[0].Value;

                if (deleteId != null)
                {
                    bool deleteRes = productRepository.DeleteProduct(int.Parse(deleteId));
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
                loadTableData(delegate (List<Product> list)
                {
                    return list;
                });
            }
        }
    }
}
