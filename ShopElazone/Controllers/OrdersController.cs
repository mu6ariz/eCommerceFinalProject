using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elazone.Entity;
using Elazone.Models;
using Microsoft.AspNetCore.Mvc;
using ShopElazone.Models;

namespace ShopElazone.Controllers
{
    public class OrdersController : Controller
    {
        private readonly GeneralDbContext _context;

        public OrdersController(GeneralDbContext context)
        {
            _context = context;
        }


        

        [HttpGet]
        public IActionResult Checkout(int id)
        {

            var data = _context.Products.Where(x => x.ID == id).ToList();

            return View("Checkout", data);
        }
    }
}