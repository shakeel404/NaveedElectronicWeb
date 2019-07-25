using NaveedElectronicWeb.NEModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System;

namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();

        public ActionResult Index(int? page)
        {
            int _page = page ?? 1;
           
            var data = Db.Suppliers.OrderByDescending(s => s.Id);
            return View(data.ToPagedList(_page,6));
        }

       
        public ActionResult Details(int id)
        { 
            Supplier supplier = Db.Suppliers.Include(s => s.SupplierContacts).Where(s => s.Id == id).FirstOrDefault();

            return View(supplier);
        }

         
        public ActionResult Create()
        {
            return View();
        }

         
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                 
                Supplier _supplier = Db.Suppliers.Add(supplier);
               Db.SaveChanges();
                return  RedirectToAction("Details",new { id = _supplier.Id });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding supplier.";
                return View("Error");
            }
        }

         
        public ActionResult Edit(int id)
        {
            NEDataBaseEntities db = new NEDataBaseEntities();

            Supplier supplier = db.Suppliers.Find(id);

            return View(supplier);
        }

         
        [HttpPost]
        public ActionResult Edit(int id, Supplier supplier)
        {
            try
            {
                
                Supplier _supplier = Db.Suppliers.Where(s => s.Id == id).FirstOrDefault();

                _supplier.SupplierName = supplier.SupplierName;
                _supplier.Company = supplier.Company;
                _supplier.PrimaryAddress = supplier.PrimaryAddress;
                Db.SaveChanges();


               return RedirectToAction("Details", new { id = _supplier.Id });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating supplier.";
                return View("Error");
            }
        }

        
        public ActionResult Delete(int id)
        {
            
            Supplier supplier = Db.Suppliers.Find(id);

            return View(supplier);
        }

         
        [HttpPost]
        public ActionResult Delete(int id, Supplier supplier)
        {
            try
            { 
                Supplier _supplier = Db.Suppliers.Find(id);
                Db.Suppliers.Remove(_supplier);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting supplier";
                return View("Error");
            }
        }

        public ActionResult AddContact(int supplierId)
        { 
            Supplier supplier = Db.Suppliers.Find(supplierId);
          
            SupplierContact supplierContact = new SupplierContact();
            supplierContact.Supplier = supplier;
            supplierContact.SupplierId = supplier.Id;
           
            return View(supplierContact);
        }

        [HttpPost]
        public ActionResult AddContact(SupplierContact supplierContact)
        {
            try
            {
                Db.SupplierContacts.Add(supplierContact);
                Db.SaveChanges(); 
                return RedirectToAction("Details",new { id=supplierContact.SupplierId});
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding contact number.";
                return View("Error");
            }
           
        }

        public ActionResult DeleteContact(int contactid,int supplierid)
        {
            SupplierContact supplierContact = Db.SupplierContacts.Find(contactid);
            Db.SupplierContacts.Remove(supplierContact);
            Db.SaveChanges();
           return RedirectToAction("Details",new { id=supplierid});
        }
        public ActionResult AddAccount(int supplierId)
        {
             
            Supplier supplier = Db.Suppliers.Find(supplierId);
            SupplierAccount supplierAccount = new SupplierAccount();
            supplierAccount.Supplier = supplier;
            supplierAccount.SupplierId = supplier.Id;


            return View(supplierAccount);
        }


        [HttpPost]
        public ActionResult AddAccount(SupplierAccount supplierAccount)
        {
            try
            {
                Db.SupplierAccounts.Add(supplierAccount);
                Db.SaveChanges();
                return RedirectToAction("Details", new { id = supplierAccount.SupplierId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding account number.";
                return View("Error");
            }
            
        }
        public ActionResult DeleteAccount(int accountid, int supplierid)
        {
            SupplierAccount supplierAccount = Db.SupplierAccounts.Find(accountid);
            Db.SupplierAccounts.Remove(supplierAccount);
            Db.SaveChanges();
            return RedirectToAction("Details", new { id = supplierid });
        }


        public ActionResult Print(DateTime start,DateTime end )
        {
            var data = Db.Suppliers.OrderByDescending(s => s.Id).Where(spl=>spl.Supplies.Where(sply=>sply.SupplyDate>=start.Date && sply.SupplyDate<=end.Date).Count()>0).ToList();

            ViewBag.StartDate = start;
            ViewBag.EndDate = end;

            return View(data);
        }
    }

}
