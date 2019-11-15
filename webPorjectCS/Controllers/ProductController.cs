using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPorjectCS.Dal;
using webPorjectCS.Models;
using System.Web.Security;
using webPorjectCS.ModelView;
using System.Threading;
using System.Data.Entity.Validation;

namespace webPorjectCS.Controllers
{

    public class ProductController : Controller
    {
        // Route Action to Manager-menu
        public ActionResult Menu()
        {
            return View("ManagerMenu");

        }

        // Use of JSON in order to retrieve list of products
        public ActionResult GetProductsByJson()
        {
            ProductDal dal = new ProductDal();
            Thread.Sleep(7000);
            List<Product> objProducts = dal.Products.ToList<Product>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }


        //Redirects to the add product
        [HttpPost]
        public ActionResult Prod()
        {

            return View("AddProduct");

        }

        //Add a new product to db with data access layer
        public ActionResult AddProduct(Product prod)
        {
            ProductDal dal = new ProductDal();//open data accses

            //query to see if prod exists in db or not - verification of Serial Number
            List<Product> ProdSNExists = (from U in dal.Products
                                          where (U.SN == prod.SN)
                                          select U).ToList<Product>();

            if (ProdSNExists.Count == 1)
            {
                TempData["Error"] = " the serial you entered is already In";
                return View("Managermenu", new Product());
            }
            else
            {
                dal.Products.Add(prod);
                dal.SaveChanges();
                TempData["good"] = "The product updated ";
                return View("Managermenu", new Product());
            }

        }

        [HttpPost]
        // Validation of username&password in sqlserver
        public ActionResult ManagerMenu(Manager man)
        {
            if (ModelState.IsValid)
            { //checkhing validation an user in data base
                ManagerDal dal = new ManagerDal();//open data access
               
                List<Manager> ManagerValid = (from U in dal.Managers
                                              where (U.UserName == man.UserName) && (U.Password == man.Password)
                                              select U).ToList<Manager>();
                //if manager authenticated
                if (ManagerValid.Count == 1)
                {
                    FormsAuthentication.SetAuthCookie("cookie", true);
                    return Menu();
                }
                else
                    return Redirect("~/Home/computerHome");
            }

            else
                return Redirect("~/Product/ManagerMenu");
        }

        // Retrieve all orders from sql using data access layer 
        public ActionResult Orders()
        {

            OrderDal dal = new OrderDal(); // call to sql
            List<Order> objOrders = dal.Orders.ToList<Order>(); // casting to list of orders
            OrderViewModel ovm = new OrderViewModel();

            ovm.Orders = objOrders; // move all the list to model-view
            return View(ovm);
        }


        // Shows the list of prodocts in the store
        public ActionResult ShowStoc()
        {
            ProductDal dal = new ProductDal(); // call to sql
            List<Product> objProducts = dal.Products.ToList<Product>(); // convert to list type from dal
            ProductViewModel pvm = new ProductViewModel(); // access to watch content of the sql table
            pvm.product = new Product(); // new object
            pvm.products = objProducts; // move all the list to model-view
            return View(pvm);

        }

        // Direction to another view
        public ActionResult redirectDel()
        {

            return View("DeleteProduct");
        }

        // Delete a product from db
        public ActionResult DeleteProduct(Product delProd)
        {

            ProductDal dal = new ProductDal();//open data accses

            // find parcicular product in dv
            List<Product> ProdToDel = (from U in dal.Products
                                       where (U.SN == delProd.SN)
                                       select U).ToList<Product>();
            if (ProdToDel.Count() == 1)
            {
                dal.Products.Remove(ProdToDel[0]); // remove it
                dal.SaveChanges(); // save the db itself- not just in memory
                TempData["good"] = "The product deleted ";
                return View("ManagerMenu"); // new page
            }
            else
                return View(new Product());

        }

        // Function updates our database amount according to product's Serial-Number 
        public ActionResult UpdateAmount(Product p)
        {
            ProductDal dal = new ProductDal();//open database

            List<Product> ProdToUpdate =
                    (from prod in dal.Products
                     where (prod.SN == p.SN)
                     select prod).ToList<Product>();

            if (ProdToUpdate.Count == 1)
            {
                ProdToUpdate[0].Amount=p.Amount;
               // dal.Products.Remove(ProdToUpdate[0]);
                //dal.SaveChanges();
               // k.Amount = p.Amount;
                try
                {
                    dal.Products.Add(ProdToUpdate[0]);
                    dal.SaveChanges();
                }
                catch { }
                TempData["good"] = "The amount updated ";
                return View("UpdateAmount"); //new Product()
            }
            else
            {
                // TempData["bad"] = "No Such Product ";
                return View();
            }
           
            
            /*   Product ProdToUpdate =
                    (from prod in dal.Products
                     where (prod.SN == p.SN)
                     select prod).ToList<Product>()[0];

            ProdToUpdate.Amount = p.Amount;
           
            dal.SaveChanges();
           
         
            return View("UpdateAmount");
           */
          
        }
    }
}