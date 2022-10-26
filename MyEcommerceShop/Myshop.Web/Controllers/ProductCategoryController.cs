using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.DataAcess.InMemory;
using MyShop.Core.Models;

namespace Myshop.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryRepositry context;

        public ProductCategoryController()
        {
            context = new ProductCategoryRepositry();
        }

        // GET: ProductCategory
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }

            else
            {
                context.Insert(productCategory);
                context.Commit();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Edit(String Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            else
            {
                return View(productCategory);
            }

        }
        [HttpPost]

        public ActionResult Edit(ProductCategory productCategory, String Id)
        {
            ProductCategory EditProductCategory = context.Find(Id);
            if (EditProductCategory == null)
            {
                return HttpNotFound();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                EditProductCategory.Id = productCategory.Id;
                EditProductCategory.Category = productCategory.Category;
                context.Commit();

                return RedirectToAction("Index");


            }


        }

        public ActionResult Delete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(CategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");



            }
        }
    }

}