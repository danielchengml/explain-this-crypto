using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExplainThisCrypto.Models;
using ExplainThisCrypto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExplainThisCrypto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var coins = _context.Coins
                               .Include(x => x.Category)
                               .ThenInclude(x => x.Category)
                               .Include(x => x.Descriptions)
                               .ToList();

            ViewData["CoinId"] = new SelectList(_context.Coins, "CoinId", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy(x => x.Name), "CategoryId", "Name");

            return View(coins);
        }


        public async Task<IActionResult> GetCoins()
        {
            var coinList = await _context.Coins
                                .Include(x => x.Descriptions)
                                .Include(x => x.Category)
                                .ThenInclude(x => x.Category)
                                .OrderBy(x => x.Name)
                                .ToListAsync();

            return View(coinList);
        }

        [HttpPost]
        public async Task<IActionResult> GetCoins(string name)
        {
            var coinList = await _context.Coins
                                .Include(x => x.Descriptions)
                                .Include(x => x.Category)
                                .ThenInclude(x => x.Category)
                                .Where(x => EF.Functions.Like(x.Name, "%"+name+"%"))
                                .OrderBy(x => x.Name)
                                .ToListAsync();

            return View(coinList);
        }


        [HttpPost]
        public async Task<IActionResult> GetCategoryCoins(int categoryId)
        {
            var coinList = await _context.Categories
                                .Include(x => x.Coin)
                                .ThenInclude(x => x.Coin)
                                .ThenInclude(x => x.Category)
                                .ThenInclude(x => x.Category)
                                .SingleOrDefaultAsync(x => x.CategoryId == categoryId);

            return View(coinList);
        }

        

        public async Task<IActionResult> Category(string name)
        {
            var category = await _context.Categories
                            .Include(x => x.Coin)
                            .ThenInclude(x => x.Coin)
                            .ThenInclude(x => x.Category)
                            .ThenInclude(x => x.Category)
                            .SingleOrDefaultAsync(x => x.Name == name);

            return View(category);
        }

        public async Task<IActionResult> GetCoinList()
        {
            var coinNameList = await _context.Coins
                                        .Select(c => new MiniCoin { Name = c.Name, Symbol = c.Symbol })
                                        .OrderBy(x => x.Name)
                                        .ToListAsync();

            return Json(coinNameList);
        }

        public IActionResult GetCategoryList()
        {
            var categoryNameList = _context.Categories
                                        .Select(c => new Category { Name = c.Name })
                                        .OrderBy(x => x.Name)
                                        .ToList();

            return Json(categoryNameList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "";

            return View();
        }

        public IActionResult GetFeaturedCoins()
        {
            var FeaturedCoinsList = _context.Coins
                .ToList()
                .OrderBy(r => Guid.NewGuid());
            return Json(FeaturedCoinsList);
        }

        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                Console.WriteLine("null value");
                return NotFound();
            }

            var coin = await _context.Coins
                .Include(m => m.Descriptions)
                .SingleOrDefaultAsync(m => m.Name == name);
            if (coin == null)
            {
                Console.WriteLine("null value again");
                return NotFound();
            }

            return View(coin);
        }

        public IActionResult GetPrice(string symbol)
        {
            Console.WriteLine("HelloTest");

            var coinPrice = Price.GetPrice(symbol);
            return Json(coinPrice);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
