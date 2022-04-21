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
        private int? memberId;

        //Use singleton design pattern
        private OrderDAO()
        {
        }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }

                    return instance;
                }

            }
        }

        public bool CreateOrder(Order newOrder)
        {
            try
            {
                context.Orders.Add(newOrder);
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
                Order updateOrder = GetOrderById(id);
                if (updateOrder != null)
                {
                    context.Orders.Update(updatedOrderInfo);
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

        public Order GetOrderById(int id) => context.Orders.SingleOrDefault<Order>((m) => m.OrderId == id);

        public List<Order> GetOrderByMemberId(int memberId) => context.Orders.Where<Order>((m) => m.MemberId == memberId).ToList();

        public List<Order> GetOrderByDateRange(DateTime startDate, DateTime endDate) => context.Orders.Where<Order>((m) => m.OrderDate >= startDate && m.OrderDate <= endDate).ToList();

        public List<Order> GetAllOrders() => context.Orders.ToList<Order>();
    }
}
