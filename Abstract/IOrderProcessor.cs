using AoqibaoStore.Models;

namespace AoqibaoStore.Abstract
{
   public interface IOrderProcessor
    {
       void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
