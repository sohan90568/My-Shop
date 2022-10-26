using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAcess.InMemory;


namespace Myshop.Web.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepositry context;

        public ProductManagerController()
        {
            context = new ProductRepositry();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Products> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            Products products = new Products();
            return View(products);
        }

        [HttpPost]

        public ActionResult Create(Products products)
        {
            if(!ModelState.IsValid)
            {
                return View(products);
            }

            else
            {
                context.insert(products);
                context.commit();
                return RedirectToAction("Index");

            }
        }

        public ActionResult Edit(String Id)
        {
            Products products = context.Find(Id);
            if(products==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(products);
            }


        }

        [HttpPost]
        public ActionResult Edit(Products products, String Id)
        {
            Products producttoedit = context.Find(Id);

            if (producttoedit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(products);
                }

                producttoedit.Category = products.Category;
                products.Description = products.Description;
                producttoedit.Name = products.Name;
                producttoedit.Price = products.Price;
                producttoedit.Image = products.Image;

                context.commit();

                return RedirectToAction("Index");

            }


        }

        public ActionResult Delete(String Id)
        {
            Products productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(String Id)
        {
            Products productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.delete(Id);
                context.commit();
                return RedirectToAction("Index");
            }
        }

    }
}