//307459305 Alex Sirotin
//302782230 Lior Mahfoda

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using webPorjectCS.Dal;
using webPorjectCS.Models;
using webPorjectCS.ModelView;
namespace webPorjectCS.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home

        // The homepage. Use of ModelView to show the list of products according to Data access layer
        public ActionResult computerHome()
        {
            ProductDal dal = new ProductDal();
            List<Product> objProducts = dal.Products.ToList<Product>();
            ProductViewModel pvm = new ProductViewModel();
            pvm.product = new Product();
            pvm.products = objProducts;
            return View(pvm);

        }

        // Upload the product database
        public ActionResult Search()
        {
            ProductViewModel pvm = new ProductViewModel();
            pvm.products = new List<Product>();
            return View("ShowSearch", pvm);

        }
       
        // Show search of products according to parameters of name and price range 
        public ActionResult ShowSearch(Product searchProduct)
        {
            ProductDal dal = new ProductDal();
            string searchName = Request.Form["ProductName"].ToString();
            int LowPrice = Int32.Parse(Request.Form["LowPrice"].ToString());
            int HighPrice = Int32.Parse(Request.Form["HighPrice"].ToString());

            List<Product> objProd =
                    (from x in dal.Products
                     where x.ProductName == searchName && x.Price >= LowPrice
                     && x.Price <= HighPrice
                     select x).ToList<Product>();

            ProductViewModel pvm = new ProductViewModel();
            pvm.products = objProd;
            return View("ShowSearch", pvm);

        }

        public ActionResult Buy()
        {
            ProductDal dal = new ProductDal();
            List<Product> objProducts = dal.Products.ToList<Product>();
            ProductViewModel pvm = new ProductViewModel();
            pvm.product = new Product();
            pvm.products = objProducts;
            return View(pvm);

        }

        public ActionResult BuyProd()
        {
            OrderDal dal = new OrderDal();//open data accses

            dal.SaveChanges();
            TempData["good"] = "The product updated ";
            return View();
        }

    }
}