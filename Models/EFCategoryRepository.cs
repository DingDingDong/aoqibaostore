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

        public void SaveCategory(Category category)
        {
            if (category.Id == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = context.Categories.Find(category.Id);
                if (dbEntry != null)
                {
                    dbEntry.name = category.name;
                    dbEntry.status = category.status;
                    dbEntry.createDate = category.createDate;
                    dbEntry.ImageData = category.ImageData;
                    dbEntry.ImageMimeType = category.ImageMimeType;
                }
            }
            context.SaveChanges();
        }


        public Category DeleteCategory(int categoryID)
        {
            Category dbEntry = context.Categories.Find(categoryID);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}