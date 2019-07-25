using Microsoft.AspNet.Identity;
using NaveedElectronicWeb.NEModel;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NaveedElectronicWeb.Controllers.Api
{
    [Authorize]
    public class PaymentController : ApiController
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

      
       
        public void Post(SupplyPayment supplyPayment)
        {
            
                supplyPayment.DatePaid = DateTime.Today;
                supplyPayment.UserId = User.Identity.GetUserId();

                Db.SupplyPayments.Add(supplyPayment);
                Db.SaveChanges();
            
             
        }

       
        public void Put(int id, [FromBody]string value)
        {
        }

        
        public void Delete(int id)
        {
          SupplyPayment  supplyPayment =  Db.SupplyPayments.Find(id);

            Db.SupplyPayments.Remove(supplyPayment);
            Db.SaveChanges();
        }
    }
}
