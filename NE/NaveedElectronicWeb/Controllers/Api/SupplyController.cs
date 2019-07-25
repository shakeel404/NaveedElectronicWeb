using Microsoft.AspNet.Identity;
using NaveedElectronicWeb.NEModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NaveedElectronicWeb.Controllers.Api
{
    [Authorize]
    public class SupplyController : ApiController
    {
         NEDataBaseEntities Db = new  NEDataBaseEntities(); 

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Supply/5
        public IEnumerable<SupplyDetail> Get(int id)
        {
            List<SupplyDetail> list = new List<SupplyDetail>();

            var data = Db.SupplyDetails.Where(sd => sd.SupplyId == id);
            foreach(var item in data)
            {
                list.Add(item);
            }

            return list;
        }

        
        public void Post(ViewModels.SupplyViewModel supplyViewModel)
        {
             
            //Supply supply = Db.Supplies.Add(new Supply() {  SupplierId=supplyViewModel.SupplierId, SupplyDate=DateTime.Today,UserId=User.Identity.GetUserId()});


            //Db.SaveChanges();

            //int SupplyId = supply.Id;
            //foreach(var supplyDetail in supplyViewModel.SupplyDetails)
            //{
            //    SupplyDetail _supplyDetail = new SupplyDetail()
            //    {
            //        ProductId = supplyDetail.ProductId,
            //        PurchasePrice = supplyDetail.PurchasePrice,
            //        Quantity = supplyDetail.Quantity,
            //        SupplyId = supply.Id

            //    };
                 
            //    SupplyDetail supplyDetailInDb = Db.SupplyDetails.Add(_supplyDetail);
            //    Db.SaveChanges();

            //    Product product = Db.Products.Where(p => p.Id == supplyDetailInDb.ProductId).FirstOrDefault();

            //    if (product.PurchasePrice <= supplyDetailInDb.PurchasePrice)
            //        product.PurchasePrice = supplyDetailInDb.PurchasePrice;

            //    product.Quantity += supplyDetailInDb.Quantity;
            //   Db.SaveChanges();
            //}

            //return SupplyId;
           
        }

 
        public void Put(int id, SupplyDetail supplyDetail)
        {
            var _supplyDetail = Db.SupplyDetails.Where(sp => sp.Id == id).FirstOrDefault();

            _supplyDetail.ProductId = supplyDetail.ProductId;
            _supplyDetail.PurchasePrice = supplyDetail.PurchasePrice;
            _supplyDetail.Quantity = supplyDetail.Quantity;
            _supplyDetail.SupplyId = supplyDetail.SupplyId;
            Db.SaveChanges();

        }

 
        public void Delete(int id)
        {
            //delete logic
        }
    }
}
