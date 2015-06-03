using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;
namespace AoqibaoStore.Models
{
    public class ShippingDetails
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        [Display(Name = "Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Line 2")]
        public string Line2 { get; set; }
        [Display(Name = "Line 3")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Postcode { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Status { get; set; }


       // public virtual Order order { get; set; }
    }


    public class ShippingDetailDBContext : DbContext
    {
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
    }
}