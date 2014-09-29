using BakeBFlake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakeBFlake.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            var cart = TempData["cart"];
            TempData["cart"] = cart;
            return View(cart);
        }

        public void RemoveItem(Int32 id)
        {
            List<OrderDetails> cart = (List<OrderDetails>)TempData["cart"];
            cart.Remove(cart.Find(x => x.Id == id));
        }

    }
}
