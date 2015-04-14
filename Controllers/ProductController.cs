using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AoqibaoStore.Models;
using AoqibaoStore.Abstract;


namespace AoqibaoStore.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : Controller
    {
        private ICategoryRepository cateRepository;
        private IProductRepository productRepository;
        //
        // GET: /Product/

        public ProductController(ICategoryRepository cateRepository, IProductRepository productRepository)
        {
            this.cateRepository = cateRepository;
            this.productRepository = productRepository;
        }

        // GET: Product
        // [Route("product")]
        public ViewResult Index()
        {
       

            ViewData["Categories"] = cateRepository.Categories.ToList();

            ViewData["Products"] = productRepository.Products.ToList();

            return View();
        }

        [Route("{category}")]
        public string showCategory(string category)
        {
            //return the products in  category

            return category;
        }

        [Route("{category}/{id:int}")]
        public string details(string category, int id)
        {

            return "individual product";

        }

    }
}
