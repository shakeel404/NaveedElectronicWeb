using NaveedElectronicWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NaveedElectronicWeb.NEModel;
using Microsoft.AspNet.Identity;

namespace NaveedElectronicWeb.Controllers.Api
{
    [Authorize]
    public class OrderController : ApiController
    {

        NEDataBaseEntities Db = new NEDataBaseEntities();

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        public int Post(OrderViewModel vm)
        {
            return 0;
            //CustomerOrder order = new CustomerOrder();
            //order.UserId = User.Identity.GetUserId();
            //order.OrderDate = DateTime.Today;
            //order.DueDate = DateTime.Today;
            //order.CustomerId = vm.CustomerId;
            //if (vm.IsInstallment)
            //{
            //    var Products = vm.OrderDetails.Select(p => p.ProductId);
            //    double MonthlyInstallment = Db.Products.Where(p => Products.Contains(p.Id)).Max(price => price.MonthlyPayment);
            //    order.MonthlyInstallment = (int)MonthlyInstallment;
            //}
            

            //Db.CustomerOrders.Add(order);
            //Db.SaveChanges();

            //List<OrderDetail> OrderDetails= new List<OrderDetail>();

            //foreach(var detail in vm.OrderDetails)
            //{
            //    OrderDetail orderDetail = new OrderDetail()
            //    {
            //        OrderId = order.Id,
            //        ProductId = detail.ProductId,
            //        PurchasePrice = Db.Products.Find(detail.ProductId).PurchasePrice,
            //        SalePrice = detail.SalePrice,
            //        Quantity = detail.Quantity

            //    };

            //    Product productInDb = Db.Products.Find(orderDetail.ProductId);
            //    productInDb.Quantity -= orderDetail.Quantity;
            //    Db.SaveChanges();

            //    OrderDetails.Add(orderDetail);

               
            //}
           


            //Db.OrderDetails.AddRange(OrderDetails);
            //Db.SaveChanges();
            //return order.Id;

        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
