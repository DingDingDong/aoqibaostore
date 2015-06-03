using AoqibaoStore.Models;
using System.Collections.Generic;


namespace AoqibaoStore.Abstract
{
   public interface IShippingDetailRepository
    {

        IEnumerable<ShippingDetails> ShippingDetails { get; }

        void SaveShippingDetail(ShippingDetails ShippingDetails);

        ShippingDetails DeleteShippingDetail(int shippingDetailId);

    }
}
