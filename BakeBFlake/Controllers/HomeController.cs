using BakeBFlake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeBFlake.Controllers
{
    public class HomeController : Controller
    {
        public User loginedUser
        {
            get
            {
                return Session["LoginUser"] as User;
            }
            set
            {
                Session["LoginUser"] = value;
            }
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Start your order right here";

            var model = getProducts();

            TempData["cart"] = new System.Collections.Generic.List<OrderDetails>();

            return View(model);
        }

        private System.Collections.Generic.List<Pastery> getProducts()
        {
            var model = new System.Collections.Generic.List<Pastery>();
            model.Add(new Pastery() { Id = 1, Name = "Whole Wheat Bread", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS1lnOLjYuqp5hcUoZv2zp3-Hy1qkrMBHxJAGMZS7FUh6KP9UdFaA" });
            model.Add(new Pastery() { Id = 2, Name = "Rye Bread", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSgpMMudTEPY9GQUFFXNi1aAkM2spjZ9lT-zqsLynF1rMULXnkG" });
            model.Add(new Pastery() { Id = 3, Name = "Vanilla Cupcakes", Price = 9.99, ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5oatXxYiBZLT7m5DnDnJ-fXeeO75yIec6Fdepcjlf2QWKc1F1nA" });
            model.Add(new Pastery() { Id = 4, Name = "Choclate Cake", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSnkc1WbBgCDbnWka_wOzg9lanUb3eRDR2G3pS_iGIYdBp8bPiH" });
            model.Add(new Pastery() { Id = 5, Name = "Onion Bagel", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRhbizKQJIr3dqooIqfeq6mmbNrvvLeNp-PmfJd6de6jPsQvExqjA" });
            /*model.Add(new Pastery() { Id = 6, Name = "Strewberry Cupcakes", Price = 9.99 });
            model.Add(new Pastery() { Id = 7, Name = "Apple Pie", Price = 9.99 });*/

            return model;
        }

        public PartialViewResult Search(string name, string type, string price, bool? glotanFree, bool? vegan)
        {
            var model = new System.Collections.Generic.List<Pastery>();
            if (name != null)
            {
                model.Add(new Pastery() { Id = 1, Name = "Whole Wheat Bread", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS1lnOLjYuqp5hcUoZv2zp3-Hy1qkrMBHxJAGMZS7FUh6KP9UdFaA" });
                model.Add(new Pastery() { Id = 2, Name = "Rye Bread", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSgpMMudTEPY9GQUFFXNi1aAkM2spjZ9lT-zqsLynF1rMULXnkG" });
            }
            else
            {
                model.Add(new Pastery() { Id = 1, Name = "Whole Wheat Bread", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS1lnOLjYuqp5hcUoZv2zp3-Hy1qkrMBHxJAGMZS7FUh6KP9UdFaA" });
                model.Add(new Pastery() { Id = 2, Name = "Rye Bread", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSgpMMudTEPY9GQUFFXNi1aAkM2spjZ9lT-zqsLynF1rMULXnkG" });
                model.Add(new Pastery() { Id = 3, Name = "Vanilla Cupcakes", Price = 9.99, ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5oatXxYiBZLT7m5DnDnJ-fXeeO75yIec6Fdepcjlf2QWKc1F1nA" });
                model.Add(new Pastery() { Id = 4, Name = "Choclate Cake", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSnkc1WbBgCDbnWka_wOzg9lanUb3eRDR2G3pS_iGIYdBp8bPiH" });
                model.Add(new Pastery() { Id = 5, Name = "Onion Bagel", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRhbizKQJIr3dqooIqfeq6mmbNrvvLeNp-PmfJd6de6jPsQvExqjA" });
            }

            return PartialView(model);
        }

        public Boolean AddToCart(Int32 pasteryId, string pasteryName, string price)
        {
           List<OrderDetails> cart = (List<OrderDetails>)TempData["cart"];
            OrderDetails cartItem = cart.Find(x => x.Id == pasteryId);
            if (cartItem != null)
            {
                ++cartItem.Amount;
            }
            else
            {
                cartItem = new OrderDetails() { PasteryId = pasteryId, PasteryName = pasteryName, Amount = 1, Price = Decimal.Parse(price) };
                cart.Add(cartItem);
            }
            TempData["cart"] = cart;
            return true;
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User customer)
        {
            this.loginedUser = customer;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            loginedUser = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            if(username == "admin")
            {
                var user1 = new User();
                user1.Id = 999;
                user1.Name = "admin";
                user1.LastName = "hamelech";
                user1.Address = "Bla bla 56";
                user1.PhoneNumber = "5547853";
                user1.Password = "123";
                user1.Prefered = true;

                this.loginedUser = user1;
            }
            else if (username == "abc")
            {
                var user1 = new User();
                user1.Id = 999;
                user1.Name = "abc";
                user1.LastName = "tipesh";
                user1.Address = "Bla bla 56";
                user1.PhoneNumber = "5547853";
                user1.Password = "321";
                user1.Prefered = false;

                this.loginedUser = user1;
            }
            else
            {
                ViewBag.Message = "Access denied, Bad Id or password";
                return View("Login");
            }

            return RedirectToAction("Index");
        }
    }
}
