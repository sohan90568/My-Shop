﻿using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModel
{
   public class ProductManagerViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
