using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NaveedElectronicWeb.NEModel;
using NaveedElectronicWeb.Extensions;
using NaveedElectronicWeb.ViewModels;
namespace NaveedElectronicWeb.Controllers.Api
{
    
    public class DashBoardController : ApiController
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        DateTime NearDate = DateTime.Today.AddDays(10);
        DateTime Today = DateTime.Today;

        


        [HttpGet]
        [Route("api/DashBoard/DueOrders/{count}")]
        public List<DashBoardItem> DueOrders(int count)
        {
            List<DashBoardItem> list = new List<DashBoardItem>();


            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od=>(od.SalePrice*od.Quantity)-od.Discount)).ToList();
           var  dueorders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueorders = dueorders.Where(o => o.DueDate > NearDate).ToList();

            list = dueorders.Skip(count).Take(10).ToList().ToDashBoardList();

            return list;
        }

        [HttpGet]
        [Route("api/DashBoard/DueOrdersCount")]
        public int DueOrdersCount()
        {
            int Count = 0;
            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount)).ToList();
            var dueorders = orders.Where(o => o.CalculateDues() > 0).ToList();
            dueorders = dueorders.Where(o => o.DueDate > NearDate).ToList();

            Count = dueorders.Count;
            return Count;
        }

        [HttpGet]
        [Route("api/DashBoard/PaybleOrders/{count}")]
        public List<DashBoardItem> PaybleOrders(int count)
        {
            List<DashBoardItem> list = new List<DashBoardItem>();


            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount)).ToList();
            var DueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            var PaybleDueOrders = DueOrders.Where(o => o.DueDate >= Today && o.DueDate <= NearDate).ToList();

           list= PaybleDueOrders.Skip(count).Take(10).ToList().ToDashBoardList();

            return list;
        }

        [HttpGet]
        [Route("api/DashBoard/PaybleOrdersCount")]
        public int PaybleOrdersCount()
        {
            int Count = 0;
            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount)).ToList();
            var DueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            var PaybleDueOrders = DueOrders.Where(o => o.DueDate >= Today && o.DueDate <= NearDate).ToList();
            Count = PaybleDueOrders.Count;
            return Count;
        }

        [HttpGet]
        [Route("api/DashBoard/PaybleOrdersBefore/{count}")]
        public List<DashBoardItem> PaybleOrdersBefore(int count)
        {
            List<DashBoardItem> list = new List<DashBoardItem>();


            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount)).ToList();
            var DueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
             DueOrders = DueOrders.Where(o => o.DueDate < Today).ToList();
            
            list = DueOrders.Skip(count).Take(10).ToList().ToDashBoardList();

            return list;
        }


        [HttpGet]
        [Route("api/DashBoard/PaybleOrdersBeforCount")]
        public int PaybleOrdersBeforCount()
        {
            int Count = 0;
            var orders = Db.CustomerOrders.ToList();
            orders = orders.OrderByDescending(o => o.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount)).ToList();
            var DueOrders = orders.Where(o => o.CalculateDues() > 0).ToList();
            DueOrders = DueOrders.Where(o => o.DueDate < Today).ToList();
            Count = DueOrders.Count;
            return Count;
        }


        [HttpGet]
        [Route("api/DashBoard/Products")]
        public ProductItem Products()
        {
            ProductItem item = new ProductItem();

            int categories = Db.Categories.Count();
            int models = Db.Categories.Sum(c => c.Products.Count);
            int quantity = Db.Categories.Sum(c => c.Products.Sum(p => p.Quantity));

            item.TotalCategories = categories;
            item.TotalModels = models;
            item.TotalQuantity = quantity;


            return item;
        }

    }
}
