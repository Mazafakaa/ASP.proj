using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProj.Models;

namespace MyProj.Controllers
{
    public class UserController : Controller
    {
        static DataBaseContext db = new DataBaseContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(string email, string password)
        {
            //Ищем пользователя с запрошенным логином в бд
            var user = db.Users
                 .Where(u => u.Email == email)
                 .FirstOrDefault();
            //Если пользователь найден, проверяем пароль
            if (user != null)
            {
                //Если пароль совпал - авторизуем
                if (Hash.GetMD5(Hash.GetMD5(password + user.Salt)) == user.Password)
                {
                    Session["id"] = user.Id;
                    Session["name"] = user.Name;
                    Session["surname"] = user.Surname;
                    Session["dob"] = user.DateOfBirthday;
                    Session["access"] = user.Access;
                    Session["auth"] = true;
                    ViewBag.Auth = true;
                    return View();
                }
            }
            //Если пользователь не найден или пароль некоректен - не авторизуем и выведем соответствующее сообщение
            ViewBag.Auth = false;
            ViewBag.AuthError = "Логин или пароль введены неверно";
            return View();
        }
        public ActionResult Auth()
        {
            return View();
        }
        //Первая страница регистрации
        public ActionResult Reg()
        {
            return View();
        }
        //Вторая страница регистрации
        [HttpPost]
        public ActionResult Reg(string password, string name, string surname)
        {
            return View();
        }
        //Третья страница регистрации
        [HttpPost]
        public ActionResult Reg(DateTime birthday, int group, int gender)
        {
            return View();
        }
        [HttpGet]
        public RedirectResult Verify(string verify)
        {
            var user = db.Users
                .Where(u => u.VerifyCode == verify)
                .FirstOrDefault();
            if(user != null)
            {
                user.Verification = true;
                db.SaveChanges();
                return Redirect("/User/My");
            }
            else
            {
                return Redirect("https://ru.wikipedia.org/wiki/Мошенничество");
            }
        }
        public ActionResult My()
        {
            if(Session["Id"] != null)
            { 
                var user = db.Users
                    .Where(u => u.Id == int.Parse(Session["id"].ToString()))
                    .FirstOrDefault();
                return View(user);
            }
            return Redirect("/User/Auth");
        }
        
    }
}