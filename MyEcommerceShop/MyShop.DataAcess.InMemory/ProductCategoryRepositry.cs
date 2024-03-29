﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAcess.InMemory
{
   public class ProductCategoryRepositry
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepositry()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories==null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productcategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if(productcategoryToUpdate != null)
            {
                productcategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Item Not Found");
            }

        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == Id);

            if(productCategory!=null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }


        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if(productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }

            else
            {
                throw new Exception("Product Category Not Found");
            }

        }
    }
}
