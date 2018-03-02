using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExplainThisCrypto.Data;
using ExplainThisCrypto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ExplainThisCrypto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DescriptionsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Descriptions
        public async Task<IActionResult> Index(string searchString)
        {
            var descriptions = from d in _context.Descriptions.Include(x => x.Coins)
                               select d;

            if(!String.IsNullOrEmpty(searchString))
            {
                descriptions = descriptions.Where(x => x.Coins.Name.Contains(searchString));
            }

            return View(await descriptions.ToListAsync());
        }

        // GET: Descriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Coins)
                .SingleOrDefaultAsync(m => m.DescriptionId == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // GET: Descriptions/Create
        public IActionResult Create()
        {
            ViewData["CoinId"] = new SelectList(_context.Coins, "CoinId", "Name");
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescriptionId,Content,Author,Source,CoinId")] Description description)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(User);
                description.User = user;
                _context.Add(description);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoinId"] = new SelectList(_context.Coins, "CoinId", "Name", description.CoinId);
            return View(description);
        }

        // GET: Descriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions.SingleOrDefaultAsync(m => m.DescriptionId == id);
            if (description == null)
            {
                return NotFound();
            }
            ViewData["CoinId"] = new SelectList(_context.Coins, "CoinId", "Name", description.CoinId);
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescriptionId,Content,Author,Source,CoinId")] Description description)
        {
            if (id != description.DescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(description);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionExists(description.DescriptionId))
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
            ViewData["CoinId"] = new SelectList(_context.Coins, "CoinId", "Name", description.CoinId);
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = await _context.Descriptions
                .Include(d => d.Coins)
                .SingleOrDefaultAsync(m => m.DescriptionId == id);
            if (description == null)
            {
                return NotFound();
            }

            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var description = await _context.Descriptions.SingleOrDefaultAsync(m => m.DescriptionId == id);
            _context.Descriptions.Remove(description);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescriptionExists(int id)
        {
            return _context.Descriptions.Any(e => e.DescriptionId == id);
        }


    }
}
