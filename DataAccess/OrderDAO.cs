using BusinessObject;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        private AssignmentPRN211DBContext context = new AssignmentPRN211DBContext();

        //Use singleton design pattern
        public OrderDAO()
        {

        }

        public bool CreateOrder(Order newOrder)
        {
                try
                {
                    context.Orders.Add(newOrder);
                    foreach(OrderDetail detail in newOrder.OrderDetails)
                    {
                        Product product = context.Products.SingleOrDefault(p => p.ProductId == detail.ProductId);
                        product.UnitsInStock -= detail.Quantity;
                        context.Products.Update(product);
                        context.SaveChanges();
                    }
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

        public bool DeleteOrder(int id)
        {
                try
                {
                    Order deleteOrder = GetOrderById(id);
                    if (deleteOrder != null)
                    {
                        context.Orders.Remove(deleteOrder);
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

        public bool UpdateOrder(int id, Order updatedOrderInfo)
        {
                try
                {
                    Order updateOrder = context.Orders.AsNoTracking().SingleOrDefault(o => o.OrderId == id);
                    if (updateOrder != null)
                    {
                        context.Orders.Update(updatedOrderInfo);
                        foreach (OrderDetail detail in updatedOrderInfo.OrderDetails)
                        {
                            Product product = context.Products.SingleOrDefault(p => p.ProductId == detail.ProductId);
                            int gap = updateOrder.OrderDetails.SingleOrDefault(d => d.ProductId == detail.ProductId).Quantity - detail.Quantity;

                            if (gap > 0)
                            {
                                product.UnitsInStock += gap;
                                context.Products.Update(product);
                            }
                            else if (gap < 0)
                            {
                                product.UnitsInStock -= gap;
                                context.Products.Update(product);
                            }
                            context.SaveChanges();

                        }
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

        public Order GetOrderById(int id)
        {
                return context.Orders.Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product).SingleOrDefault<Order>((m) => m.OrderId == id);
        }

        public List<Order> GetOrderByMemberId(int memberId)
        {
                return context.Orders.Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product).Where<Order>((m) => m.MemberId == memberId).ToList();
        }

        public List<Order> GetOrderByDateRange(DateTime startDate, DateTime endDate)
        {
                return context.Orders.Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product).Where<Order>((m) => m.OrderDate >= startDate && m.OrderDate <= endDate).ToList();
        }

        public List<Order> GetAllOrders()
        {
                return context.Orders.Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.Product).ToList<Order>();
        }

        public SaleReport GetSaleReport(DateTime startDate, DateTime endDate)
        {
            SaleReport saleReport = new SaleReport();

            List<Order> soldOrder = GetOrderByDateRange(startDate, endDate);

            List<dynamic> products = new List<dynamic>();

            foreach(Order order in soldOrder)
            {
                foreach(OrderDetail detail in order.OrderDetails)
                {
                    if(products.SingleOrDefault(p => p.ProductId == detail.ProductId) != null)
                    {
                        dynamic product = products.SingleOrDefault(p => p.ProductId == detail.ProductId);
                        product.soldAmount += detail.Quantity;
                        saleReport.Income += detail.Quantity * detail.UnitPrice;
                    } else
                    {
                        dynamic product = new { 
                            ProductId = detail.ProductId,
                            ProductName = detail.Product.ProductName,
                            UnitPrice = detail.UnitPrice,
                            soldAmount = detail.Quantity
                        };
                        products.Add(product);

                        saleReport.Income += detail.Quantity * detail.UnitPrice;
                    }
                }
            }

            return saleReport;
        }
    }
}
