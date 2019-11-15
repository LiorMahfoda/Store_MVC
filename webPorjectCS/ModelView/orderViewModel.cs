using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webPorjectCS.Models;

namespace webPorjectCS.ModelView
{
    public class OrderViewModel
    {

        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
    }
}