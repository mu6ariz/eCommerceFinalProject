using Elazone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionsLesson.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace SessionsLesson.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private readonly GeneralDbContext _context;

        public CartController(GeneralDbContext context)
        {
            _context = context;
        }


        [Route("Orders")]
        public IActionResult Orders()
        {

            try
            {
                var cart = SessionHelper.GetObjectFromJson<List<Products>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Price * item.Quantity);
                ViewBag.count = cart.Count();
                return View();
            }
            catch (System.Exception)
            {

                return Content("Sebet Bosdur");
            }

            
        }


        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {

            if (SessionHelper.GetObjectFromJson<List<Products>>(HttpContext.Session, "cart") == null)
            {
                List<Products> cart = new List<Products>();

                cart.Add(_context.Products.Where(x => x.ID == id).FirstOrDefault());

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Products> cart = SessionHelper.GetObjectFromJson<List<Products>>(HttpContext.Session, "cart");

                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(_context.Products.Where(x => x.ID == id).FirstOrDefault());
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Orders");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Products> cart = SessionHelper.GetObjectFromJson<List<Products>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Orders");
        }

        private int isExist(int id)
        {
            List<Products> cart = SessionHelper.GetObjectFromJson<List<Products>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ID.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}