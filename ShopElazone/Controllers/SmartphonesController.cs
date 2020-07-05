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

    public class SmartphonesController : Controller
    {

        private readonly GeneralDbContext _context;


        public SmartphonesController(GeneralDbContext context)
        {          
            _context = context;          
     
        }

        [HttpGet]
        public IActionResult Paged(int id=1)
        {
            var takesize = 10;

            var skipsize = (id * takesize) - 10;

            var data = _context.Products.Where(x => x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

            return PartialView("_Paged", data);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Products.Where(x => x.Category.Name == "Smartphones").ToList();

            return View(data);
        }


        [HttpGet]
        public IActionResult SingleFilter(List<string> ram, List<string> brand, List<string> color, List<string> memoryValue, int priceMin, int priceMax, int id = 1)
        {
            List<Products> data = new List<Products>();

            var takesize = 10;

            var skipsize = (id * takesize) - 10;

            if (brand.Count() != 0)
            {
               
                foreach (var item in brand)
                {
                    var Brands =_context.Products.Where(x => x.Brand == item && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                    foreach (var product in Brands)
                    {
                        data.Add(product);
                    }
                    
                }

            }

            if (color.Count() != 0)
            {

                foreach (var item in color)
                {
                    var Colors = _context.Products.Where(x => x.Color == item && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                    foreach (var product in Colors)
                    {
                        data.Add(product);
                    }

                }                

            }

            if (ram.Count() != 0)
            {

                foreach (var item in ram)
                {
                    var Rams = _context.Products.Where(x => x.Ram == int.Parse(item) && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();
                    foreach (var product in Rams)
                    {
                        data.Add(product);
                    }

                }

            }

            if (memoryValue.Count() != 0)
            {

                foreach (var item in memoryValue)
                {
                    var Memorys = _context.Products.Where(x => x.MemoryInternal == item && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                    foreach (var product in Memorys)
                    {
                        data.Add(product);
                    }

                }

            }

            if (priceMin != 0 && priceMax != 0)
            {

                foreach (var item in memoryValue)
                {
                    var Memorys = _context.Products.Where(x => x.Price > priceMin && x.Price < priceMax && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                    foreach (var product in Memorys)
                    {
                        data.Add(product);
                    }

                }

            }

            return PartialView("_SmartphonesPartial", data);

        }


        [HttpGet]
        public IActionResult CustomPrice(int customePriceMin, int customePriceMax )
        {
            var data = _context.Products.Where(x => x.Price > customePriceMin && x.Price < customePriceMax).ToList();

            return PartialView("CustomPricePaged", data);
        }

        [HttpGet]
        public IActionResult MultipleFilter(List<string> ram, List<string> brand, List<string> color, List<string> memoryValue, int priceMin, int priceMax, int id = 1)
        {
            List<Products> data = new List<Products>();

            var takesize = 10;

            var skipsize = (id * takesize) - 10;

            if (brand.Count != 0 && ram.Count != 0 && color.Count != 0)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var ramItem in ram)
                    {
                        foreach (var colorItem in color)
                        {
                            var RamBrandColor = _context.Products.Where(x => x.Ram == int.Parse(ramItem) && x.Brand == itemBrand && x.Color == colorItem && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                            foreach (var products in RamBrandColor)
                            {
                                data.Add(products);
                            }
                        }

                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }

            if (brand.Count != 0 && ram.Count != 0 && color.Count != 0 && priceMin != null && priceMax !=null)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var ramItem in ram)
                    {
                        foreach (var colorItem in color)
                        {
                            var RamBrandColor = _context.Products.Where(x => x.Ram == int.Parse(ramItem) && x.Brand == itemBrand && x.Color == colorItem && x.Category.Name == "Smartphones" && x.Price > priceMin && x.Price < priceMax).Skip(skipsize).Take(takesize).ToList();

                            foreach (var products in RamBrandColor)
                            {
                                data.Add(products);
                            }
                        }

                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }

            if (brand.Count != 0 && ram.Count != 0 && memoryValue.Count != 0)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var ramItem in ram)
                    {
                        foreach (var memory in memoryValue)
                        {
                            var RamBrandMemory = _context.Products.Where(x => x.Ram == int.Parse(ramItem) && x.Brand == itemBrand && x.MemoryInternal == memory && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                            foreach (var products in RamBrandMemory)
                            {
                                data.Add(products);
                            }
                        }

                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }

            if (brand.Count != 0 && ram.Count != 0 && memoryValue.Count != 0 && priceMin != null && priceMax != null)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var ramItem in ram)
                    {
                        foreach (var memory in memoryValue)
                        {
                            var RamBrandMemory = _context.Products.Where(x => x.Ram == int.Parse(ramItem) && x.Brand == itemBrand && x.MemoryInternal == memory && x.Category.Name == "Smartphones" && x.Price > priceMin && x.Price < priceMax).Skip(skipsize).Take(takesize).ToList();

                            foreach (var products in RamBrandMemory)
                            {
                                data.Add(products);
                            }
                        }

                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }

            if (color.Count != 0 && brand.Count != 0 )
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var colorItem in color)
                    {
                        var ColorBrand = _context.Products.Where(x => x.Color == colorItem && x.Brand == itemBrand && x.Category.Name == "Smartphones" ).Skip(skipsize).Take(takesize).ToList();

                        foreach (var products in ColorBrand)
                        {
                            data.Add(products);
                        }
                    }
                                       
                }               

                return PartialView("_SmartphonesPartial", data);
            }

            if (color.Count != 0 && brand.Count != 0 && priceMin != null && priceMax != null)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var colorItem in color)
                    {
                        var ColorBrand = _context.Products.Where(x => x.Color == colorItem && x.Brand == itemBrand && x.Category.Name == "Smartphones" ).Skip(skipsize).Take(takesize).ToList();

                        foreach (var products in ColorBrand)
                        {
                            data.Add(products);
                        }
                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }

            if (brand.Count != 0 && ram.Count != 0)
            {
                foreach (var itemBrand in brand)
                {
                    foreach (var ramItem in ram)
                    {
                        var RamBrand = _context.Products.Where(x => x.Ram == int.Parse(ramItem) && x.Brand == itemBrand && x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                        foreach (var products in RamBrand)
                        {
                            data.Add(products);
                        }
                    }

                }

                return PartialView("_SmartphonesPartial", data);
            }





            return View("Index");

        }


        [HttpGet]
        public IActionResult PhoneDetails(int id)
        {
            var data = _context.Products.Where(x => x.ID == id).ToList();

            return View("PhoneDetails", data);
        }

        [HttpGet]
        public IActionResult FilterPrice(int id,int page=1)
        {
            var takesize = 10;

            var skipsize = (page * takesize) - 10;

            if (id == 2)
            {
                var data = _context.Products.Where(x=> x.Category.Name == "Smartphones").OrderByDescending(x => x.Price).Skip(skipsize).Take(takesize).ToList();


                return PartialView("_SmartphonesPartial", data);
            }
            if(id == 1)
            {
                var data = _context.Products.Where(x => x.Category.Name == "Smartphones").OrderBy(x => x.Price).Skip(skipsize).Take(takesize).ToList();


                return PartialView("_SmartphonesPartial", data);

            }
            else
            {
                var data = _context.Products.Where(x => x.Category.Name == "Smartphones").Skip(skipsize).Take(takesize).ToList();

                return PartialView("_SmartphonesPartial", data);
            }

            
        }
    }
}