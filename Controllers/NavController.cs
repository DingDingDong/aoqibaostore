using System.Linq;
using System.Web.Mvc;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;
using System.Collections.Generic;

namespace AoqibaoStore.Controllers
{
    public class NavController : Controller
    {

        private ICategoryRepository repository;

        public NavController(ICategoryRepository repo)
        {
            repository = repo; ;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Categories
                                             .Select(x => x.name)
                                             .Distinct();
            return PartialView("FlexMenu",categories);
                                         
        }
        
    }
}