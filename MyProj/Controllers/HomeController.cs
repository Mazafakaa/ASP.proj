using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProj.Models;
using System.Web.Mvc;

namespace MyProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Auth(string login, string password)
        {
            User vova = new User(login, password);
            
        }
       public ActionResult Auth()
       {
            return View();
       }
    }
}