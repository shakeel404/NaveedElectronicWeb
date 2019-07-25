using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaveedElectronicWeb.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            
        }
      

        public int CustomerId { get; set; }
        public int Payment { get; set; }
        public int Installment { get; set; }
        public int GuarantorId { get; set; }
        public DateTime DueDate { get; set; }
        public List<OrderDetailViewModel> Details { get; set; }

    }
}