using AoqibaoStore.Abstract;
using AoqibaoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AoqibaoStore.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        private ICategoryRepository cateRepository;
        // GET: AdminCategory

        public AdminCategoryController(ICategoryRepository cateRepo)
        {
            cateRepository = cateRepo;
        }

        public ViewResult Index()
        {
            return View(cateRepository.Categories);
        }

        public ViewResult Create()
        {
         //   List<Category> categories = cateRepository.Categories.ToList();
            return View("Create", new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    category.ImageMimeType = image.ContentType;
                    category.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(category.ImageData, 0, image.ContentLength);

                }
                category.createDate = DateTime.Now;

                cateRepository.SaveCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values
                return View(category);
            }
        }


        public ViewResult Edit(int cateId)
        {
            Category category = cateRepository.Categories.FirstOrDefault(c => c.Id == cateId);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    category.ImageMimeType = image.ContentType;
                    category.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(category.ImageData, 0, image.ContentLength);
                }

                cateRepository.SaveCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the data values
                return View(category);
            }
        }

        [HttpPost]
        public ActionResult Delete(int cateId)
        {
            Category deletedCategory = cateRepository.DeleteCategory(cateId);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedCategory.name);
            }
            return RedirectToAction("Index");
        }

        [Route("AdminCategory/GetImage/{id:int}")]
        public FileContentResult GetImage(int id)
        {
            Category category = cateRepository.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                return File(category.ImageData, category.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}