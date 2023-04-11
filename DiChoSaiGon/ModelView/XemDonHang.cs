using DiChoSaiGon.Models;
using System;
using System.Collections.Generic;

namespace DiChoSaiGon.ModelViews
{
    public class XemDonHang
    {
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}