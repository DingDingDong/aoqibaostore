using System.Collections.Generic;
using AoqibaoStore.Models;

namespace AoqibaoStore.Abstract
{
   public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
   }
}
