using AoqibaoStore.Models;
using System.Collections.Generic;


namespace AoqibaoStore.Abstract
{
  public interface IOrderRepository
    {
      IEnumerable<Order> Orders { get; }

      void SaveOrder(Order order);

      Order DeleteOrder(int orderId);
    }
}
