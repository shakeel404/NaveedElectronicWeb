using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NaveedElectronicWeb.NEModel;
using Microsoft.AspNet.Identity;

namespace NaveedElectronicWeb.Controllers.Api
{
    [Authorize]
    public class OrderPaymentController : ApiController
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

     
        public string Get(int id)
        {
            return "value";
        }

     
        public void Post(OrderPayment orderPayment)
        {
            if (orderPayment.AmountPaid > 0)
            {


                orderPayment.DatePaid = DateTime.Today;
                orderPayment.UserId = User.Identity.GetUserId();



                Db.OrderPayments.Add(orderPayment);
                Db.SaveChanges();

                CustomerOrder customerOrder = Db.CustomerOrders.Find(orderPayment.OrderId);

                int NetTotal = customerOrder.OrderDetails.Sum(od => (od.SalePrice * od.Quantity) - od.Discount);
                int NetPayament = customerOrder.OrderPayments.Sum(op => op.AmountPaid);
                int NetDues = NetTotal - NetPayament;
                if (NetDues > 0)
                {

                    int month = customerOrder.DueDate.Month;

                    month++;

                    customerOrder.DueDate = new DateTime(DateTime.Now.Year, month, 5);


                }
                Db.SaveChanges();
            }
        }

        
        public void Put(int id, [FromBody]string value)
        {
        }

         
        public void Delete(int id)
        {
            OrderPayment orderPayment = Db.OrderPayments.Find(id);

            
            Db.OrderPayments.Remove(orderPayment);
            Db.SaveChanges();
        }
    }
}
