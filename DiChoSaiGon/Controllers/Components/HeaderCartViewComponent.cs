using System;
using System.Collections.Generic;
using DiChoSaiGon.Extension;
using DiChoSaiGon.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiChoSaiGon.Extension;
using DiChoSaiGon.ModelViews;

namespace DiChoSaiGon.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}