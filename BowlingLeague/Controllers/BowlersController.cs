using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BowlingLeague.Models;

namespace BowlingLeague.Controllers
{
    public class BowlersController : Controller
    {
        private readonly BowlingDbContext _context;

        // Setting a repositoey adds a layer between the Dbcontext and Controller,
        // it does the same thing without the repository but you can test dumy codes on the repository
        //private IBowlersRepository _repo { get; set; }

        public BowlersController(BowlingDbContext context)
        {
            _context = context;
        }

        // GET: Bowlers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bowlers
            .ToListAsync());
        }

        [HttpGet]
        // GET: Bowlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlers = await _context.Bowlers
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowlers == null)
            {
                return NotFound();
            }

            return View(bowlers);
        }

        // GET: Bowlers/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowlers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BowlerID,BowlerFirstName,BowlerLastName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowlers bowlers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowlers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowlers);
        }

        // GET: Bowlers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlers = await _context.Bowlers.FindAsync(id);
            if (bowlers == null)
            {
                return NotFound();
            }
            return View(bowlers);
        }

        // POST: Bowlers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BowlerID,BowlerFirstName,BowlerLastName,BowlerMiddleInit,BowlerAddress,BowlerCity,BowlerState,BowlerZip,BowlerPhoneNumber,TeamID")] Bowlers bowlers)
        {
            if (id != bowlers.BowlerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowlers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlersExists(bowlers.BowlerID))
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
            return View(bowlers);
        }

        // GET: Bowlers/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlers = await _context.Bowlers
                .FirstOrDefaultAsync(m => m.BowlerID == id);
            if (bowlers == null)
            {
                return NotFound();
            }

            return View(bowlers);
        }

        // POST: Bowlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowlers = await _context.Bowlers.FindAsync(id);
            _context.Bowlers.Remove(bowlers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlersExists(int id)
        {
            return _context.Bowlers.Any(e => e.BowlerID == id);
        }
    }
}
