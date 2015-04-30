using System.Data.Entity;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AoqibaoStore.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name = "Category")]
        public int cateId { get; set; }
       
        [Display(Name="Product Name")]
        [Required(ErrorMessage= "Please enter a product name")]
        public string name { get; set; }
        
        
      //  [Display(Name = "Product Image")]
        //[Required(ErrorMessage = "Please upload a product image")]
        //public string imgUrl { get; set; }

        [Display(Name = "Product Image")]
       // [Required(ErrorMessage = "Please upload a product image")]
        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }


        [Display(Name = "Short Description")]
        [DataType(DataType.MultilineText)]
        public string shortDesc { get; set; }
        [Display(Name = "Long Description")]
        [DataType(DataType.MultilineText)]
        public string longDesc { get; set; }


        [Display(Name = "Quantity")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage="Please enter a positive price")]
        public int qty { get; set; }
        
        [Display(Name = "Unit Price")]
        public decimal unitPrice { get; set; }
        
        [Display(Name = "Create Date")]
        public DateTime createDate { get; set; }
        [Display(Name = "Modify Date")]
        public DateTime modifyDate { get; set; }


        [Display(Name = "Status")]
        public int status { get; set; }


        
    }




    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }

}