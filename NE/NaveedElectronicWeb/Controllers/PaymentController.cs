using Microsoft.AspNet.Identity;
using NaveedElectronicWeb.NEModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NaveedElectronicWeb.Controllers
{

    [Authorize]
    public class PaymentController : Controller
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

          
        public ActionResult Create(int supplyid)
        {
            SupplyPayment supplyPayment = Db.SupplyPayments.Where(pm => pm.SupplyId == supplyid).FirstOrDefault();
            return View(supplyPayment);
        }

         
        [HttpPost]
        public ActionResult Create(SupplyPayment supplyPayment)
        {
            try
            {
                supplyPayment.DatePaid = DateTime.Today;
                supplyPayment.UserId = User.Identity.GetUserId();
                
                Db.SupplyPayments.Add(supplyPayment);
                Db.SaveChanges();

                return RedirectToAction("Details","Supply",new {id=supplyPayment.SupplyId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding supply payment";
                return View("Error");
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
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
