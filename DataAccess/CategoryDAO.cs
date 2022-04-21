using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        private static readonly object instanceLock = new object();
        private AssignmentPRN211DBContext context = new AssignmentPRN211DBContext();

        //Use singleton design pattern
        private CategoryDAO()
        {
        }

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }

                    return instance;
                }

            }
        }

        public List<Category> GetAllCategories() => context.Categories.ToList();

        public Category GetCategoryById(int id) => context.Categories.SingleOrDefault(c => c.CategoryId == id);
    }
}
