using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SaleReport
    {

        public List<dynamic> soldProductList { get; set; }

        public decimal Income;
    }
}
