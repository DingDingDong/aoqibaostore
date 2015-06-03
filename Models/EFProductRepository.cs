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

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.name = product.name;
                    dbEntry.categoryId = product.categoryId;
                    dbEntry.shortDesc = product.shortDesc;
                    dbEntry.longDesc = product.longDesc;
                    dbEntry.unitPrice = product.unitPrice;
                    dbEntry.qty = product.qty;
                    dbEntry.createDate = product.createDate;
                    dbEntry.modifyDate = DateTime.Now;
                    dbEntry.status = product.status;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }


        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}