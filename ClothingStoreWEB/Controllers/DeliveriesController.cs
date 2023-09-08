using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStoreWEB.Context;
using ClothingStoreWEB.Models.AuxiliaryModels;
using Microsoft.AspNetCore.Authorization;

namespace ClothingStoreWEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class DeliveriesController : Controller
    {
        private readonly MainContext _context;

        public DeliveriesController(MainContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index()
        {
              return _context.DeliveryMethods != null ? 
                          View(await _context.DeliveryMethods.ToListAsync()) :
                          Problem("Entity set 'IdentityContext.DeliveryMethods'  is null.");
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeliveryMethods == null)
            {
                return NotFound();
            }

            var delivery = await _context.DeliveryMethods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeliveryMethods == null)
            {
                return NotFound();
            }

            var delivery = await _context.DeliveryMethods.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.Id))
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
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeliveryMethods == null)
            {
                return NotFound();
            }

            var delivery = await _context.DeliveryMethods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeliveryMethods == null)
            {
                return Problem("Entity set 'IdentityContext.DeliveryMethods'  is null.");
            }
            var delivery = await _context.DeliveryMethods.FindAsync(id);
            if (delivery != null)
            {
                _context.DeliveryMethods.Remove(delivery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(int id)
        {
          return (_context.DeliveryMethods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
