using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NaveedElectronicWeb.NEModel;
namespace NaveedElectronicWeb.Controllers.Api
{
    public class GuarantorController : ApiController
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public void Get()
        {

        }

        public IEnumerable<Guarantor> Get(int customerid)
        {
            var list = Db.Guarantors.Where(g => g.CustomerId == customerid).ToList();

            List<Guarantor> guaranters = new List<Guarantor>();
            foreach(var g in list)
            {
                Guarantor guarantor = new Guarantor();
                guarantor.Id = g.Id;
                guarantor.GuarantorName = g.GuarantorName;
                guaranters.Add(guarantor);
            }

            guaranters = guaranters.OrderByDescending(g => g.Id).ToList();
            return guaranters;
        }
    }
}
