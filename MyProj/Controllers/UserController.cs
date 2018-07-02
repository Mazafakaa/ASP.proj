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
        public ActionResult Auth(string login, string password)
        {
            //Ищем пользователя с запрошенным логином в бд
            List<User> luser = db.Users.ToList<User>();
            User user = luser.Find(u => u.Login == login);
            //Если пользователь найден, проверяем пароль
            if (user != null)
            {
                //Если пароль совпал - авторизуем
                if (Hash.GetMD5(Hash.GetMD5(password + user.Salt)) == user.Password)
                {
                    Session["id"] = user.Id;
                    Session["login"] = user.Login;
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
            ViewBag.RegPage = 1;
            return View();
        }
        //Вторая страница регистрации
        [HttpPost]
        public ActionResult Reg(string login, string password, string name, string surname)
        {
            if(login != null && login.Length > 6)
            {
                if(password != null && password.Length > 6)
                {
                    Session["login"] = login;
                    Session["password"] = password;
                    Session["name"] = name;
                    Session["surname"] = surname;
                    ViewBag.RegPage = 2;
                    return View();
                }
                else
                {
                    ViewBag.PassErr = "Минимальная длинна пароля 6 символом";
                }
            }
            else
            {
                ViewBag.LoginErr = "Минимальная длинна логина 6 символом";
            }
            ViewBag.RegPage = 1;
            return View();
        }
        //Третья страница регистрации
        [HttpPost]
        public ActionResult Reg(DateTime birthday, int group, int gender)
        {
            //Если значения не пустые и хитрый юзер не нахимичил с разметкой - то регаем, иначе возращаем текущую страницу с ошибкой
            if(birthday != null && (gender == 1||gender == 0))
            {
                User user = new User()
                {
                    Login = Session["login"].ToString(),
                    Salt = USalt.GenSalt(20),
                    Name = Session["name"].ToString(),
                    Surname = Session["surname"].ToString(),
                    Gender = (Gender)gender,
                    DateOfBirthday = birthday,
                    DateReg = DateTime.Now,
                    Group = group,
                    Access = Role.User
                };
                user.Password = Hash.GetMD5(Hash.GetMD5(Session["password"].ToString() + user.Salt));
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.RegPage = 3;
                return View();
            }
            ViewBag.ErrInp = "Введены некоректные данные";
            ViewBag.RegPage = 2;
            return View();
        }
        
        
    }
}