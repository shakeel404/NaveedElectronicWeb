using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using PagedList;
using NaveedElectronicWeb.ViewModels;
using Microsoft.AspNet.Identity;
using System;

namespace NaveedElectronicWeb.Controllers
{

    [Authorize]
    public class SupplyController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        
        public ActionResult Index(int? page,int? supplierId)
        {
            int _page = page ?? 1;
            var supplies = Db.Supplies.Where(sp=>sp.SupplierId==supplierId).OrderByDescending(s => s.Id).ToList();

            return View(supplies.ToPagedList(_page,6));
        }

        
        public ActionResult Details(int id)
        {
            Supply supply = Db.Supplies.Find(id);
            return View(supply);
        }
         
 
        public ActionResult Create(int? supplierid)
        {
            int _id = supplierid ?? 0;

            if(_id==0)
            {
                ViewBag.ErrorMessage = "Error Occured while adding supply";
                return View("Error");
            }

            Supplier supplier = Db.Suppliers.Find(_id); 
            
            return View(supplier);
        }

       
        [HttpPost] 
        public ActionResult Create(SupplyViewModel vm)
        {
            try
            {
                var UserId = User.Identity.GetUserId();

                Supply supply = new Supply();
                supply.UserId = UserId;
                supply.SupplierId = vm.SupplierId;
                supply.SupplyDate = DateTime.Today;

                Db.Supplies.Add(supply);
                Db.SaveChanges();

                int SupplyId = supply.Id;

                foreach(var item in vm.Details)
                {
                    SupplyDetail detail = new SupplyDetail();
                    detail.ProductId = item.ProductId;
                    detail.PurchasePrice = item.Price;
                    detail.Quantity = item.Quantity;
                    detail.SupplyId = SupplyId;

                    var ProductInDb = Db.Products.Find(detail.ProductId);

                    ProductInDb.Quantity += detail.Quantity;

                    Db.SupplyDetails.Add(detail);
                }

                Db.SaveChanges();
                return RedirectToAction("Details", new { id = SupplyId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding supply";
                return View("Error");
            }
        }
         


        public ActionResult Edit(int id)
        {
             
            return View();
        }

         
        [HttpPost]
        public ActionResult Edit(int id, SupplyDetail supplyDetail)
        {
            return View();
        }

        

        public ActionResult Delete(int id)
        {
            Supply supply = Db.Supplies.Find(id);
            return View(supply);
        }

        

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Supply supply = Db.Supplies.Find(id);
                Db.Supplies.Remove(supply);
                Db.SaveChanges();

                return RedirectToAction("Index","Supplier",null);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Print(int supplyid)
        {
            Supply supply = Db.Supplies.Find(supplyid);
            return View(supply);
        }
    }
}
