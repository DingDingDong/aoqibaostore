using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace AoqibaoStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int status { get; set; }
        public DateTime createDate { get; set; }
    }

    public class CategoryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}