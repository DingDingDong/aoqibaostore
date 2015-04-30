using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace AoqibaoStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public DateTime createDate { get; set; }

        [Display(Name = "Category Image")]
        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

    }

    public class CategoryDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}