using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApis.Services;
using WebApis.Models;

namespace WebApis.Controllers
{
    public class ShoppingCartController : Controller
    {
        public CartService cartsrc = new CartService();

        public ActionResult Index()
        {

            var cartinstance = cartsrc.GetCart(this.HttpContext);

            ShoppingCartVM cart = new ShoppingCartVM {cartitems = cartinstance.GetCartItems()};

            return View(cart);            
        }

        [HttpPost]
        public JsonResult AddToCart(int productId)
        {
            var cart = cartsrc.GetCart(this.HttpContext);

            cart.AddToCart(productId);

            var a = Json(new { id = productId }, JsonRequestBehavior.AllowGet);
            return a;
        }

        public ActionResult RemoveFromCart(int productId)
        {
            var cart = cartsrc.GetCart(HttpContext);

            cart.RemoveFromCart(productId);

            var a = Json(new { id = productId }, JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }
    }
}
