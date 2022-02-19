using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarbucksStore.Data;
using StarbucksStore.Models;

namespace StarbucksStore.Controllers
{
    public class StarbucksOrdersController : Controller
    {
        private readonly ibdbContext _context;

        public StarbucksOrdersController(ibdbContext context)
        {
            _context = context;
        }

        // GET: StarbucksOrders
        public async Task<IActionResult> Index()
        {
            var ibdbContext = _context.StarbucksOrders.Include(s => s.Customer);
            return View(await ibdbContext.ToListAsync());
        }

        // GET: StarbucksOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starbucksOrder = await _context.StarbucksOrders
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starbucksOrder == null)
            {
                return NotFound();
            }

            return View(starbucksOrder);
        }

        // GET: StarbucksOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: StarbucksOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date,CustomerId")] StarbucksOrder starbucksOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(starbucksOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", starbucksOrder.CustomerId);
            return View(starbucksOrder);
        }

        // GET: StarbucksOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starbucksOrder = await _context.StarbucksOrders.FindAsync(id);
            if (starbucksOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", starbucksOrder.CustomerId);
            return View(starbucksOrder);
        }

        // POST: StarbucksOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date,CustomerId")] StarbucksOrder starbucksOrder)
        {
            if (id != starbucksOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(starbucksOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarbucksOrderExists(starbucksOrder.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", starbucksOrder.CustomerId);
            return View(starbucksOrder);
        }

        // GET: StarbucksOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starbucksOrder = await _context.StarbucksOrders
                .Include(s => s.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starbucksOrder == null)
            {
                return NotFound();
            }

            return View(starbucksOrder);
        }

        // POST: StarbucksOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starbucksOrder = await _context.StarbucksOrders.FindAsync(id);
            _context.StarbucksOrders.Remove(starbucksOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarbucksOrderExists(int id)
        {
            return _context.StarbucksOrders.Any(e => e.Id == id);
        }
    }
}
