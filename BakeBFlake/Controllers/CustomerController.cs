using BakeBFlake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeBFlake.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            ViewBag.Message = "Customers List";

            return View(getUsers());
        }

        private List<User> getUsers()
        {
            var user1 = new User();
            user1.Id = 123;
            user1.Name = "Ido";
            user1.LastName = "Ganzer";
            user1.Address = "Bla bla 30";
            user1.PhoneNumber = "5543253";
            user1.Password = "abcde";
            user1.Prefered = true;

            var user2 = new User();
            user2.Id = 456;
            user2.Name = "Ido2";
            user2.LastName = "Ganzer2";
            user2.Address = "Bla bla 32";
            user2.PhoneNumber = "56785467";
            user2.Password = "fghjf";
            user2.Prefered = false;

            var users = new List<User>();
            users.Add(user1);
            users.Add(user2);

            return users;
        }

        [HttpPost]
        public ActionResult Edit(User customer)
        {
            ViewBag.Message = "Customers List";
            return View("Index", getUsers());
        }

        public ActionResult Edit(int id)
        {
            var user1 = new User();
            user1.Id = 123;
            user1.Name = "Ido";
            user1.LastName = "Ganzer";
            user1.Address = "Bla bla 30";
            user1.PhoneNumber = "5543253";
            user1.Password = "abcde";
            user1.Prefered = true;

            return View(user1);
        }

        public ActionResult Delete(int id)
        {
            return View("Index", getUsers());
        }

    }
}
