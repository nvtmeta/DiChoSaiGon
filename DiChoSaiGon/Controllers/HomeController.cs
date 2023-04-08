using DiChoSaiGon.Models;
using DiChoSaiGon.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DiChoSaiGon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbMarketsContext _context;


        public HomeController(ILogger<HomeController> logger, dbMarketsContext context)
        { 
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM();

            var lsProducts = _context.Products.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .ToList();


            var TinTuc = _context.TinDangs
                .AsNoTracking()
                .Where(x => x.Published == true && x.IsNewfeed == true)
                .Take(3)
                .ToList();


            model.TinTucs = TinTuc;

            model.Products = lsProducts;


            ViewBag.AllProducts = lsProducts;
            return View(model);


        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
