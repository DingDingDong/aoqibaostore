using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AoqibaoStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Decimal SalePrice { get; set; }

        public int Status { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product product { get; set; }

    }


    public class OrderDetailDBContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}