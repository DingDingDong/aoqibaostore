using System.Linq;
using System.Web.Mvc;
using AoqibaoStore.Abstract;
using AoqibaoStore.Models;
using System.Collections.Generic;
using System.Web;
using System;

namespace AoqibaoStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        private ICategoryRepository cateRepository;

        public AdminController(IProductRepository repo,ICategoryRepository cateRepo)
        {
            repository = repo;
            cateRepository = cateRepo;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Create()
        {
            List<Category> categories = cateRepository.Categories.ToList();

            ViewData["Categories"] = categories;

            return View("Create", new Product());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);

                }
                product.createDate = product.modifyDate = DateTime.Now;
            
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values
                return View(product);
            }
        }



        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.Id == productId);

            List<Category> categories = cateRepository.Categories.ToList();
            ViewData["Categories"] = categories;
            return View(product);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product,HttpPostedFileBase image = null ) {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData,0,image.ContentLength);

                }

                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.name);
                return RedirectToAction("Index");
            }
            else { 
                //there is something wrong with the data values
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",deletedProduct.name);
            }
            return RedirectToAction("Index");
        }
    }
}