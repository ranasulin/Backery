using BakeBFlake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BakeBFlake.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Start your order right here";

            var model = new System.Collections.Generic.List<Pastery>();
            model.Add(new Pastery() { Id = 1, Name = "Whole Wheat Bread", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS1lnOLjYuqp5hcUoZv2zp3-Hy1qkrMBHxJAGMZS7FUh6KP9UdFaA" });
            model.Add(new Pastery() { Id = 2, Name = "Rye Bread", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSgpMMudTEPY9GQUFFXNi1aAkM2spjZ9lT-zqsLynF1rMULXnkG" });
            model.Add(new Pastery() { Id = 3, Name = "Vanilla Cupcakes", Price = 9.99, ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5oatXxYiBZLT7m5DnDnJ-fXeeO75yIec6Fdepcjlf2QWKc1F1nA" });
            model.Add(new Pastery() { Id = 4, Name = "Choclate Cake", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSnkc1WbBgCDbnWka_wOzg9lanUb3eRDR2G3pS_iGIYdBp8bPiH" });
            model.Add(new Pastery() { Id = 5, Name = "Onion Bagel", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRhbizKQJIr3dqooIqfeq6mmbNrvvLeNp-PmfJd6de6jPsQvExqjA" });
            /*model.Add(new Pastery() { Id = 6, Name = "Strewberry Cupcakes", Price = 9.99 });
            model.Add(new Pastery() { Id = 7, Name = "Apple Pie", Price = 9.99 });*/

            return View(model);
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

        // order/types/{type}
        public ActionResult Types(string type)
        {
            var model = new System.Collections.Generic.List<Pastery>();

            if (type == "Breads")
            {
                model.Add(new Pastery() { Id = 1, Name = "Whole Wheat Bread", Price = 9.99, ImageLink = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS1lnOLjYuqp5hcUoZv2zp3-Hy1qkrMBHxJAGMZS7FUh6KP9UdFaA" });
                model.Add(new Pastery() { Id = 2, Name = "Rye Bread", Price = 9.99, ImageLink = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSgpMMudTEPY9GQUFFXNi1aAkM2spjZ9lT-zqsLynF1rMULXnkG" });
            }
            else if (type == "Cupcakes")
            {
                model.Add(new Pastery() { Id = 3, Name = "Vanilla Cupcakes", Price = 9.99, ImageLink = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5oatXxYiBZLT7m5DnDnJ-fXeeO75yIec6Fdepcjlf2QWKc1F1nA" });
            }

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
