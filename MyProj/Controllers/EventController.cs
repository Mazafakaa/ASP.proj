using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProj.Models;

namespace MyProj.Controllers
{
    public class EventController : Controller
    {
       public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Event @event)
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Edit(Event @event)
        {
            return View();
        }

    }
}