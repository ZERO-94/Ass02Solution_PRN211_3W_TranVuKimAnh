using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class OrderDetailDetailDAO
    {
        private static readonly object instanceLock = new object();
        private AssignmentPRN211DBContext context = new AssignmentPRN211DBContext();

        //Use singleton design pattern
        public OrderDetailDetailDAO()
        {

        }
    }
}
