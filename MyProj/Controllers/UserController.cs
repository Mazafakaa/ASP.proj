using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Xml;
using MyProj.Models;

namespace MyProj.Controllers
{
    public class UserController : Controller
    {
        static DataBaseContext db = new DataBaseContext();
        
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
                    return Redirect("/User/My");
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
        //Дефолт страницы регистрации
        public ActionResult Reg()
        {
            ViewBag.RegPage = 1;
            return View("~/Views/User/Reg.cshtml");
        }
        //Обрабатывает первую страницу и если все ок - возвращает вторую
        [HttpPost]
        public ActionResult Reg2(string email, string password, string confirmpassword)
        {
            if(email != null && password != null && confirmpassword != null)
            {
                if(password.Length >= 6)
                {
                    if(password == confirmpassword)
                    {
                        Session["email"] = email;
                        Session["password"] = password;
                        ViewBag.RegPage = 2;
                        return View("~/Views/User/Reg.cshtml");
                    }
                    else
                    {
                        ViewBag.ErrorReg = "Введенные пароли не совпадают";
                    }
                }
                else
                {
                    ViewBag.ErrorReg = "Длинна пароля должна составлять минимум 6 символов";
                }
            }
            else
            {
                ViewBag.ErrorReg = "Заполнены не все обязательные поля";
            }
            ViewBag.RegPage = 1;
            return View("~/Views/User/Reg.cshtml");
        }
        //Обрабатывает вторую страницу и если все ок - возвращает третью
        [HttpPost]
        public ActionResult Reg3(string name, string surname, DateTime dob, Gender gender, int city)
        {
            if (name != null && surname != null && dob != null)
            {
                Session["name"] = name;
                Session["surname"] = surname;
                Session["dob"] = dob;
                Session["city"] = city;
                ViewBag.RegPage = 3;
                return View("~/Views/User/Reg.cshtml");
            }
            else
            {
                ViewBag.ErrorReg = "Заполнены не все обязательные поля";
            }
            ViewBag.RegPage = 2;
            return View("~/Views/User/Reg.cshtml");
        }
        [HttpPost]
        public ActionResult Reg4()
        {
           
            if (Session["email"] != null && Session["password"] != null && Session["name"] != null && Session["surname"] != null && Session["dob"] != null)
                {
                User user = new User()
                {
                    Email = Session["email"].ToString(),
                    Name = Session["name"].ToString(),
                    Surname = Session["surname"].ToString(),
                    DateReg = DateTime.Now,
                    DateOfBirthday = DateTime.Parse(Session["dob"].ToString()),
                    City = int.Parse(Session["city"].ToString()),
                    CountCreateEvent = 0,
                    Rating = 0,
                    Access = Role.User
                };
                user.Salt = USalt.GenSalt(20);
                user.Password = Hash.GetMD5(Hash.GetMD5(Session["password"].ToString() + user.Salt));
                user.Verification = false;
                user.VerifyCode = VerifyCode.GetVerifyCode(60);
                //TODO: Отправка писем
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.RegPage = 4;
                ViewBag.Name = user.Name;
                db.Dispose();
                return View("~/Views/User/Reg.cshtml");
            }
            
        //Пятая страница - страница ошибки регистрации
        ViewBag.RegPage = 5;
        return View("~/Views/User/Reg.cshtml");

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
            if(bool.Parse(Session["auth"].ToString()))
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