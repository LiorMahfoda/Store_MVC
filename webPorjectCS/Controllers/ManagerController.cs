using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPorjectCS.Dal;
using webPorjectCS.Models;
using System.Web.Security;
using webPorjectCS.ModelView;


namespace webPorjectCS.Controllers
{
    
    public class ManagerController : Controller
    {
        
        // GET: Maneger
       
        // Direct to View cshtml
        public ActionResult ManagerLogin()
        { 
            return View();

        }

    }
}