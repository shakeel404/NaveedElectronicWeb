using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaveedElectronicWeb.ViewModels
{
    public class OrderDetailViewModel
    {
        

        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}