using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Lab20.Models;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        #region ViewPages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View("UserRegistration");
        }
        #endregion

        public ActionResult AddUser(User newUser, string FirstName)
        {
            CoffeeShopDBEntities UserOrm = new CoffeeShopDBEntities();

            UserOrm.Users.Add(newUser);

            UserOrm.SaveChanges();

            ViewBag.Fname = FirstName;

            return View("Summary");
        }

        public ActionResult CoffeeMenu()
        {
            CoffeeShopDBEntities CoffeeOrm = new CoffeeShopDBEntities();

            ViewBag.CoffeeItems = CoffeeOrm.Items.ToList();

            return View("CoffeeMenu");
        }

        public ActionResult GetOptionByDescription(string Description)
        {

            CoffeeShopDBEntities CoffeeOrm = new CoffeeShopDBEntities();

            ViewBag.CoffeeItems = CoffeeOrm.Items.Where(x => x.Description == Description).ToList();

            return View("CoffeeMenu");
        }

        public ActionResult UserLogin()
        {
            return View("Login");
        }

        public ActionResult LoginPage()
        {

            return View("UserPage");
        }
    }
}