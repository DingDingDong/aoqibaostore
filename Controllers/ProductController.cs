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
        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;

        public int PageSize = 2;

        //private List<Product> productList;
        //
        // GET: /Product/

        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        // GET: Product
        public ViewResult Index(string cateName, int page =1)
        {

         //   ViewData["Products"] = productRepository.Products.ToList();

            Category selectedCategory = categoryRepository.Categories.Where(c => c.name == cateName&& c.status == 1).FirstOrDefault();
            
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productRepository.Products
                .Where(p => cateName == null || p.cateId == selectedCategory.Id && p.status == 1)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize), PagingInfo = new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = cateName == null ? productRepository.Products.Count() : productRepository.Products.Where(e => e.cateId == selectedCategory.Id).Count()
                },
                CurrentCategory = cateName
            };
            
            
            return View(model);
        }

        //[Route("{cateName}")]
        //public ViewResult showCategory(string cateName)
        //{
        //    //return the products in  category
        //    Category selectedCategory = categoryRepository.Categories.Where(c => c.name == cateName).First();
        //    ViewData["Products"] = productRepository.Products.Where(p => p.cateId == selectedCategory.Id).ToList();

        //    return View("Index");
        //}

        [Route("detail/{id:int}")]
        public ViewResult Details(int id)
        {
            Product selectedProduct = productRepository.Products.Where(p => p.Id == id && p.status ==1).FirstOrDefault();
            return View(selectedProduct);
        }

        [Route("GetImage/{id:int}")]
        public FileContentResult GetImage(int id)
        {
            Product prod = productRepository.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                return File(prod.ImageData,prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
