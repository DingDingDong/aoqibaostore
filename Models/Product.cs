using System.Data.Entity;
using System.Collections.Generic;
using System;


namespace AoqibaoStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int cateId { get; set; }
       // public IList<Category> categories { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public string shortDesc { get; set; }
        public string longDesc { get; set; }
        public int qty { get; set; }
        public decimal unitPrice { get; set; }
        public DateTime createDate { get; set; }
        public DateTime modifyDate { get; set; }
        public int status { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

}