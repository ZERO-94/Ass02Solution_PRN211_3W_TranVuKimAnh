using BusinessObject;
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
    public partial class frmSaleReport : Form
    {

        private IOrderRepository orderRepository = new OrderRepository();
        private DateTime startDate;
        private DateTime endDate;

        public frmSaleReport(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            InitializeComponent();
        }

        private void frmSaleReport_Load(object sender, EventArgs e)
        {
            SaleReport saleReport = orderRepository.GetSaleReport(startDate, endDate);

            soldProductDataGrid.DataSource = saleReport.soldProductList;

            lbMoney.Text = saleReport.Income.ToString();
        }
    }
}
