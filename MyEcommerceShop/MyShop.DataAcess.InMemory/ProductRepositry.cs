using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAcess.InMemory
{
    public class ProductRepositry

    {
        ObjectCache cache = MemoryCache.Default;
        List<Products> products;

        public ProductRepositry()
        {
            products = cache["products"] as List<Products>;
            if(products==null)
            {
                products = new List<Products>();
            }

            
        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void insert(Products p)
        {
            products.Add(p);
        }

        public void Update(Products EditProduct)
        {
            Products producttoupdate = products.Find(p => p.Id == EditProduct.Id);
            if(producttoupdate!=null)
            {
                producttoupdate = EditProduct;
            }

            else
            {
                throw new Exception("Item Not Found");

            }
        }

        public Products Find(String Id)
        {
            Products product = products.Find(p => p.Id ==Id);
            if (product != null)
            {
                return product;
            }

            else
            {
                throw new Exception("Item Not Found");

            }
        }

        public IQueryable<Products> Collection()
        {
            return products.AsQueryable();
        }

        public void delete(String Id)
        {
            Products producttodelete = products.Find(p => p.Id ==Id);
            if (producttodelete != null)
            {
                products.Remove(producttodelete);
            }

            else
            {
                throw new Exception("Item Not Found");

            }
        }

    }
}
