using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaveedElectronicWeb.ViewModels
{
    public class SupplyViewModel
    {
        public SupplyViewModel()
        { 
        }

       
        public int SupplierId { get; set; } 
        public List<SupplyDetailViewModel> Details { get; set; }
    }
}