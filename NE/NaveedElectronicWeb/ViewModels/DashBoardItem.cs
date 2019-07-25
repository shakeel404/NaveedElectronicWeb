using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaveedElectronicWeb.ViewModels
{
    public class DashBoardItem
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CityName { get; set; }
        public int DueAmount { get; set; }
    }
}