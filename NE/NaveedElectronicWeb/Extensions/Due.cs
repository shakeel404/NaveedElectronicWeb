using NaveedElectronicWeb.NEModel;
using NaveedElectronicWeb.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace NaveedElectronicWeb.Extensions
{
    public static class Due
    {
        public static double CalculateDues(this CustomerOrder customerOrder)
        {
            try
            {
                double dues = 0d;
                int totalamount = customerOrder.OrderDetails.Sum(od => (od.Quantity * od.SalePrice) - od.Discount);
                int totalpaid = customerOrder.OrderPayments.Sum(od => od.AmountPaid);


                int remianing = totalamount - totalpaid;
                if (remianing == 0)
                    return 0d;
                dues = remianing;
                //dues = remianing / totalamount;
                //dues = dues * 100;
                return dues;
            }
            catch
            {
                return 0d;
            }

        }

        public static List<DashBoardItem> ToDashBoardList(this List<CustomerOrder> customerOrders )
        {

            List<DashBoardItem> list = new List<DashBoardItem>();
            try
            {
                foreach (var order in customerOrders)
                {
                    int amount = order.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount);

                    var item = new DashBoardItem();
                    item.CustomerName = order.Customer.CustomerName;
                    item.CityName = order.Customer.City.CityName;
                    item.OrderId = order.Id;
                    item.DueAmount = amount;

                    list.Add(item);
                }
                return list;
            }
            catch
            {
                return list;
            }

        }

    }
}