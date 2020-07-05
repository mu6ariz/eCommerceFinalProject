using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elazone.Models;
using Microsoft.AspNetCore.Authorization;

namespace ShopElazone.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly GeneralDbContext _context;

        public ProductsController(GeneralDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var generalDbContext = _context.Products.Include(p => p.Category);
            return View(await generalDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Brand,Model,ImageUrl,Photo1,Photo2,Photo3,Description,OperatingSystem,CoreCount,Vga,Price,Color,TypeOfInternalMemory,MemoryInternal,Discount,Stock,ScreenSize,Ram,CameraMp,BatteryMah,IsActive,Quantity,ID,CreateDate,CreateUserID")] Products products)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", products.CategoryId);
            _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
    
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", products.CategoryId);
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Brand,Model,ImageUrl,Photo1,Photo2,Photo3,Description,OperatingSystem,CoreCount,Vga,Price,Color,TypeOfInternalMemory,MemoryInternal,Discount,Stock,ScreenSize,Ram,CameraMp,BatteryMah,IsActive,Quantity,ID,CreateDate,CreateUserID")] Products products)
        {
            if (id != products.ID)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "Name", products.CategoryId);

            try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
           
           
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
