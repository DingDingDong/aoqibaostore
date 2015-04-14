using System.Collections.Generic;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;
using AoqibaoStore.Concrete;

namespace AoqibaoStore.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Categories
        {

            get { return context.Categories; }
        }

    }
}