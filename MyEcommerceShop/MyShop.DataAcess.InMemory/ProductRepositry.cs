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


    }
}
