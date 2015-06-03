using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AoqibaoStore.Models
{
    public class Order
    {

        public Order()
        {
           OrderDetails = new List<OrderDetail>();
        }
       

        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderDate { get; set; }

        public int ShippingDetailsID { get; set; }

        public int Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ShippingDetails shippingDetails { get; set; }

    }


    public class OrderDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }

}