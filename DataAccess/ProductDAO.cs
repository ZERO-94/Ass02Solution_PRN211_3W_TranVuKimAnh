using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        private static readonly object instanceLock = new object();
        private AssignmentPRN211DBContext context = new AssignmentPRN211DBContext();

        //Use singleton design pattern
        private ProductDAO()
        {
        }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }

                    return instance;
                }

            }
        }

        public bool CreateProduct(Product newProduct)
        {
            try
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                Product deleteProduct = GetProductById(id);
                if (deleteProduct != null)
                {
                    context.Products.Remove(deleteProduct);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public bool UpdateProduct(int id, Product updatedProductInfo)
        {
            try
            {
                Product updateProduct = GetProductById(id);
                if (updateProduct != null)
                {
                    context.Products.Update(updatedProductInfo);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public Product GetProductById(int id) => context.Products.SingleOrDefault<Product>((m) => m.ProductId == id);

        public List<Product> GetAllProducts() => context.Products.ToList<Product>();

        public List<Product> SearchProduct(int? searchId, string? searchName, decimal? searchPrice, int? searchInStock)
        {
            return context.Products.Where(product => searchId != null || product.ProductId == searchId)
                .Where(product => searchName == null || product.ProductName.Contains(searchName))
                .Where(product => searchPrice == null || product.UnitPrice == searchPrice)
                .Where(product => searchInStock == null || product.UnitsInStock == searchInStock)
                .ToList();
        }
    }
}
