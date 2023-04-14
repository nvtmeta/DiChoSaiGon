using DiChoSaiGon.Models;
using DiChoSaiGon.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using DiChoSaiGon.Extension;


namespace DiChoSaiGon.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbMarketsContext _context;
        public ProductController(dbMarketsContext context)
        {
            _context = context;
        }

        [Route("shop.html", Name = ("ShopProduct"))]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 20;
                var lsTinDangs = _context.Products
                    .AsNoTracking()
                    .OrderBy(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsTinDangs, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;

                var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");


                ViewBag.cart = cart;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [Route("/{Alias}-{id}.html", Name = ("ListProduct"))]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                var lsProduct = _context.Products.AsNoTracking().Where(x => 
                x.ProductId != id && x.Active == true).Take(3).ToList();



                var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");


                ViewBag.cart = cart;

                ViewBag.SanPham = lsProduct;

                return View(product);

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
