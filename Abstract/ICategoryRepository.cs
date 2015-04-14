using System.Collections.Generic;
using AoqibaoStore.Models;

namespace AoqibaoStore.Abstract
{
  public interface ICategoryRepository
    {

      IEnumerable<Category> Categories { get; }
    }
}
