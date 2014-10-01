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
            var cart = Session["cart"];
            return View(cart);
        }

        public bool RemoveItem(Int32 id)
        {
            List<OrderDetails> cart = (List<OrderDetails>)Session["cart"];
            var item = cart.Find(x => x.Id == id);
            if (item != null)
            {
                cart.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult Checkout()
        {
            //save order to db and return order model
            var order = new Order() {Id= 19127872, TotalPrice = 50};

            //empty cart
            Session["cart"] = new List<OrderDetails>();

            return View(order);
        }

    }
}
