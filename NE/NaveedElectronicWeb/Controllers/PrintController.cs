using System;
using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using NaveedElectronicWeb.Extensions;
namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class PrintController : Controller
    {

        NEDataBaseEntities Db = new NEDataBaseEntities();
        DateTime NearDate = DateTime.Today.AddDays(10);
        DateTime Today = DateTime.Today;
        public ActionResult DueOrders()
        {

            var orders = Db.CustomerOrders.ToList();

            var dueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueOrders = dueOrders.OrderBy(o => o.Customer.CustomerName).ToList();

            var groupedOrders = dueOrders.GroupBy(g => g.Customer.City.CityName).ToList();
 
            
            return View(groupedOrders);
        }

        public ActionResult PaybleDueOrders()
        {
            var orders = Db.CustomerOrders.ToList();

            var dueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueOrders = dueOrders.Where(o => o.DueDate >= Today && o.DueDate <= NearDate).ToList();
            dueOrders = dueOrders.OrderBy(o => o.Customer.CustomerName).ToList();

            var groupedOrders = dueOrders.GroupBy(g => g.Customer.City.CityName).ToList();


            return View(groupedOrders);
        }

        public ActionResult PaybleBeforeToday()
        {
            var orders = Db.CustomerOrders.ToList();

            var dueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueOrders = dueOrders.Where(o => o.DueDate < Today).ToList();
            dueOrders = dueOrders.OrderBy(o => o.Customer.CustomerName).ToList();

            var groupedOrders = dueOrders.GroupBy(g => g.Customer.City.CityName).ToList();


            return View(groupedOrders);
        }

       

        public ActionResult Purchase(DateTime start, DateTime end)
        {
            var supplies = Db.Supplies.ToList();

            supplies = supplies.Where(sp => sp.SupplyDate >= start && sp.SupplyDate <= end).ToList();
            ViewBag.Start = start;
            ViewBag.End = end;

            return View(supplies);
        }

        public ActionResult Sale(DateTime start, DateTime end,int? cityid)
        {
            int _cityid = cityid ?? 0;
            var orders = Db.CustomerOrders.ToList();
            string City = "All Locations";
            if (_cityid > 0)
            {
                orders = orders.Where(o => o.Customer.CityId == _cityid).ToList();
                var city = Db.Cities.Find(_cityid);
                City = city.CityName;
            }
            orders = orders.Where(o => o.OrderDate >= start && o.OrderDate <= end).ToList();
            ViewBag.City = City;
            ViewBag.Start = start;
            ViewBag.End = end;
            return View(orders);
        }

        public ActionResult Installment(DateTime start, DateTime end)
        {
            var orders = Db.CustomerOrders.ToList();

            var dueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueOrders = dueOrders.Where(o => o.OrderDate >= start && o.OrderDate <= end).ToList();
            dueOrders = dueOrders.OrderBy(o => o.Customer.CustomerName).ToList();

            ViewBag.Start = start;
            ViewBag.End = end;

            var groupedOrders = dueOrders.GroupBy(g => g.Customer.City.CityName).ToList();

            return View(groupedOrders);
        }

        public ActionResult InstallmentByCity(int cityid)
        {

            var orders = Db.CustomerOrders.Where(c => c.Customer.CityId == cityid).ToList();
            var dueOrders = orders.Where(o => o.CalculateDues() > 0).ToList(); 
            dueOrders = dueOrders.OrderBy(o => o.Customer.CustomerName).ToList();
            var cityname = Db.Cities.Find(cityid).CityName;
            ViewBag.CityName = cityname;
            return View(dueOrders);
        }
    }
}