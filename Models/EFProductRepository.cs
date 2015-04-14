using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoqibaoStore.Abstract;
using AoqibaoStore.Concrete;

namespace AoqibaoStore.Models
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}