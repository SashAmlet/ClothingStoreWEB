using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothingStoreWEB.Context;
using ClothingStoreWEB.Models;

namespace ClothingStoreWEB.Controllers
{
    public class DeliveryAddressesController : Controller
    {
        private readonly MainContext _context;

        public DeliveryAddressesController(MainContext context)
        {
            _context = context;
        }

        // GET: DeliveryAddresses
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.DeliveryAddresses.Include(d => d.User);
            return View(await mainContext.ToListAsync());
        }

        // GET: DeliveryAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeliveryAddresses == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: DeliveryAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceiverFName,ReceiverLName,Region,City,Street,HouseNumber,Postcode,PhoneNumber,Email,UserId")] DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", deliveryAddress.UserId);
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeliveryAddresses == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", deliveryAddress.UserId);
            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceiverFName,ReceiverLName,Region,City,Street,HouseNumber,Postcode,PhoneNumber,Email,UserId")] DeliveryAddress deliveryAddress)
        {
            if (id != deliveryAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryAddressExists(deliveryAddress.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", deliveryAddress.UserId);
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeliveryAddresses == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAddress == null)
            {
                return NotFound();
            }

            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeliveryAddresses == null)
            {
                return Problem("Entity set 'MainContext.DeliveryAddresses'  is null.");
            }
            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress != null)
            {
                _context.DeliveryAddresses.Remove(deliveryAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryAddressExists(int id)
        {
          return (_context.DeliveryAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
