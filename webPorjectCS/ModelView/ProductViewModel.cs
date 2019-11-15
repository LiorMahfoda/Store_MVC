using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webPorjectCS.Models;

namespace webPorjectCS.ModelView
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public List<Product> products { get; set; }
    }
}