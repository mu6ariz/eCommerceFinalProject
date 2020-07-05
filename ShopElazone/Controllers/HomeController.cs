using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Elazone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopElazone.Models;

namespace ShopElazone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GeneralDbContext _context;
        int x = 0;

        public HomeController(ILogger<HomeController> logger, GeneralDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Cook()
        {
            int y = Convert.ToInt32(HttpContext.Session.GetInt32("valueofx"));

            if (y == null)
            {
                x = 0;
            }
            else
            {
                x = y;
                x++;

            }

            HttpContext.Session.SetInt32("valuofx", x);

            return Content(x.ToString());

        }

        public IActionResult Index(Products products)
        {

            var data = _context.Products.ToList().Skip(4).Take(9);

            return View(data);
        }

        public IActionResult About(Products products)
        {
            var data = _context.Products.ToList().Skip(4).Take(9);
            return View(data);
        }

        [HttpGet]
        public IActionResult Contact()
        {           
            return View();
        }

        [HttpGet]
        public IActionResult Search(string searchstring,string category)
        {
            if(category == "Smartphones")
            {
                var data = _context.Products.Where(x => x.Brand.Contains(searchstring) && x.Category.Name == category).ToList();

                return RedirectToAction("Index", "Smartphones", data);
            }
            if(category == "Notebooks")
            {
                var data = _context.Products.Where(x => x.Brand.Contains(searchstring) && x.Category.Name == category).ToList();

                return RedirectToAction("Index", "NotebooksAndComputers", data);
            }
            else
            {
                return View("Search");
            }
            
        }





        ////////////////////////////////////MENU AJAX///////////////////////////////////////
        public  IActionResult SingleSmartphone()
        {
            var data = _context.Products.ToList();
            return PartialView("_SingleSmartphone",data);
        }

        public IActionResult SingleLaptops()
        {
            var data = _context.Products.ToList();
            return PartialView("_SingleLaptops", data);
        }

        public IActionResult SingleTablets()
        {
            var data = _context.Products.ToList();
            return PartialView("_SingleTablets", data);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
