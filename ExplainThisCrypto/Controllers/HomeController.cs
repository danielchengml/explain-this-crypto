using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExplainThisCrypto.Models;
using ExplainThisCrypto.Data;
using Microsoft.EntityFrameworkCore;

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
                               .Include(x => x.Descriptions).Take(10)
                               .ToList();
            return View(coins);
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
            var FeaturedCoinsList = _context.Coins.OrderBy(r => Guid.NewGuid()).Take(4).ToList();
            return Json(FeaturedCoinsList);
        }


        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var coin = await _context.Coins
                .Include(m => m.Descriptions)
                .SingleOrDefaultAsync(m => m.Name == name);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
