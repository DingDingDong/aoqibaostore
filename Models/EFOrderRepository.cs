using System.Collections.Generic;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;
using AoqibaoStore.Concrete;

namespace AoqibaoStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(Order order)
        {
            if (order.Id == 0)
            {

               context.Orders.Add(order);
            }
            else
            {
                Order dbEntry = context.Orders.Find(order.Id);

                if (dbEntry != null)
                {
                    dbEntry.OrderNumber = order.OrderNumber;
                    dbEntry.OrderDate = order.OrderDate;
                    dbEntry.OrderDetails = order.OrderDetails;
                    dbEntry.shippingDetails = order.shippingDetails;
                    dbEntry.Status = order.Status;
                }
            }
            context.SaveChanges();
        }

        public Order DeleteOrder(int orderID)
        {
            Order dbEntry = context.Orders.Find(orderID);
            if (dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}