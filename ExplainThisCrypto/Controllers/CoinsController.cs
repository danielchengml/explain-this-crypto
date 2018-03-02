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
    public class CoinsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoinsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Coins
        public async Task<IActionResult> Index(string searchString)
        {

            var coins = from c in _context.Coins select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                coins = coins.Where(x => x.Name.Contains(searchString));
            }

            return View(await coins.ToListAsync());
        }

        public List<string> Search(string name)
        {
            return _context.Coins.Where(p => p.Name.StartsWith(name, 
                StringComparison.OrdinalIgnoreCase)).Select(p => p.Name).ToList();
        }

        public IActionResult GetCategoryList()
        {
            var categoryList = _context.Categories
                                        .Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name })
                                        .ToList();

            return Json(categoryList);
        }

        // GET: Coins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coin coin = await _context.Coins
                                    .Include(m => m.Category)
                                    .ThenInclude(m => m.Category)
                                    .SingleOrDefaultAsync(m => m.CoinId == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // GET: Coins/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Coins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoinId,Name,Symbol,Logo_url,Tagline,Description,Website,TwitterWidgetId")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                coin.User = user;
                _context.Add(coin);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = coin.CoinId });
            }
            return View();
        }

        public async Task<IActionResult> AddCategory(int id)
        {
            var coin = await _context.Coins.Include(x => x.Category).SingleOrDefaultAsync(x => x.CoinId == id);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");

            return View(coin);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(int coinId, int categoryId)
        {

            var coin = await _context.Coins.Include(x => x.Category).SingleOrDefaultAsync(x => x.CoinId == coinId);
            var thisCategory = await _context.Categories.SingleOrDefaultAsync(x => x.CategoryId == categoryId);

            coin.Category.Add(new Tag
            {
                Coin = coin,
                Category = thisCategory
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = coin.CoinId });
        }

        public async Task<IActionResult> RemoveCategory(int? id, int? categoryId)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (categoryId == null)
            {
                return NotFound();
            }


            var coin = await _context.Coins
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.CoinId == id);

            var category = await _context.Categories
                .SingleOrDefaultAsync(m => m.CategoryId == categoryId);



            coin.Category.Remove(coin.Category.Where(x => x.CategoryId == category.CategoryId).FirstOrDefault());

            await _context.SaveChangesAsync();

            if (coin == null)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new { id = coin.CoinId }); ;
        }

        // GET: Coins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins.SingleOrDefaultAsync(m => m.CoinId == id);
            if (coin == null)
            {
                return NotFound();
            }
            return View(coin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoinId,Name,Symbol,Logo_url,Tagline,Description,Website,TwitterWidgetId")] Coin coin)
        {
            if (id != coin.CoinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoinExists(coin.CoinId))
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
            return View(coin);
        }

        [HttpPost]
        public IActionResult QuickAddCategory(string name)
        {
            var category = new Category
            {
                Name = name
            };
            _context.Categories.Add(category);
            _context.SaveChangesAsync();

            return Json(category);
        }

        // GET: Coins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins
                .SingleOrDefaultAsync(m => m.CoinId == id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coin = await _context.Coins.SingleOrDefaultAsync(m => m.CoinId == id);
            _context.Coins.Remove(coin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoinExists(int id)
        {
            return _context.Coins.Any(e => e.CoinId == id);
        }
    }
}
