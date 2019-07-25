using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
namespace NaveedElectronicWeb.Controllers
{
    public class SupplyDetailController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }
         
        public ActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
        public ActionResult Edit(int id)
        {
            SupplyDetail supplyDetail = Db.SupplyDetails.Find(id);
            return View(supplyDetail);
        }
         
        [HttpPost]
        public ActionResult Edit(SupplyDetail supplyDetail)
        {
            try
            {
                SupplyDetail _supplyDetail = Db.SupplyDetails.Find(supplyDetail.Id);


                if (supplyDetail.PurchasePrice > _supplyDetail.PurchasePrice)
                {
                    _supplyDetail.PurchasePrice = supplyDetail.PurchasePrice;
                }
                int quantity = supplyDetail.Quantity - _supplyDetail.Quantity;

                _supplyDetail.Quantity += quantity;

                Product product = Db.Products.Find(supplyDetail.ProductId);
                product.Quantity += quantity;
                product.PurchasePrice = _supplyDetail.PurchasePrice;
                if (product.Quantity < 0)
                    product.Quantity = 0;

                Db.SaveChanges();

                return RedirectToAction("Details","Supply", new { id = supplyDetail.SupplyId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating supply details.";
                return View("Error");
            }
        }

      
        public ActionResult Delete(int id)
        {
            SupplyDetail supplyDetail = Db.SupplyDetails.Find(id);
            int SupplyId =supplyDetail.Supply.Id;
            var ProductInDb = Db.Products.Find(supplyDetail.ProductId);
            ProductInDb.Quantity -= supplyDetail.Quantity;

            if (ProductInDb.Quantity < 0)
                ProductInDb.Quantity = 0;
            Db.SupplyDetails.Remove(supplyDetail);
            Db.SaveChanges();

            return RedirectToAction("Details", "Supply", new { id = SupplyId});
        }

        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
