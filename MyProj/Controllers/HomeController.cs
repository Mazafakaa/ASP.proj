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
        public ActionResult Index(string login, string password, string name, string surname, int age, string group, string interes)
        {
            if (login != null|| login.Length > 5|| password != null||password.Length > 6||name!=null||surname!=null||age!=0||group!=null||interes!= null)
            {
            
            User user = new User
            {
                Name = name,
                Login = login,
                Surname = surname,
                Age = age,
                DateReg = DateTime.Now,
                Access = Role.User,
                Salt = USalt.GenSalt(20),
                Group = group,
                Interes = interes
                
            };
            user.Password =Hash.GetMD5(Hash.GetMD5(password + user.Salt));
            DataBaseContext db = new DataBaseContext();
            db.Users.Add(user);
            db.SaveChanges();
            return View();
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Auth(string login, string password)
        {
            return View();
            
        }
       public ActionResult Auth()
       {
            return View();
       }
    }
}