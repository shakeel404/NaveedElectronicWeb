using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using PagedList;
namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class GuarantorController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public ActionResult Index(int? page,string search,int? customerid)
        {
            int _page = page ?? 1;
            int _customerid = customerid ?? 0;
            string _search = search ?? string.Empty;

            ViewBag.Search = _search;
            List<Guarantor> list = null;

            if (!string.IsNullOrEmpty(_search))
            {
                list = Db.Guarantors.OrderByDescending(g => g.Id).Where(s => s.GuarantorName.Contains(_search)).ToList();
            }
            else if (_customerid>0)
            {
                list = Db.Guarantors.OrderByDescending(g => g.Id).Where(c=>c.CustomerId == _customerid).ToList();
            }
            else
            {
                list = Db.Guarantors.OrderByDescending(g => g.Id).ToList();
            }
             

            return View(list.ToPagedList(_page,8));
        }

        
        public ActionResult Details(int id)
        {
            Guarantor guarantor = Db.Guarantors.Find(id);
            return View(guarantor);
        }

       
        public ActionResult Create(int customerid)
        {
            Customer customer = Db.Customers.Find(customerid);
            Guarantor guarantor = new Guarantor();
            guarantor.Customer = customer;
            guarantor.CustomerId = customer.Id;
            return View(guarantor);
        }

         
        [HttpPost]
        public ActionResult Create(Guarantor guarantor)
        {
            try
            {
                Db.Guarantors.Add(guarantor);
                Db.SaveChanges();
                  
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while adding guarantor.";
                return View("Error");
            }
        }

        
        public ActionResult Edit(int id)
        {
            Guarantor guarantor = Db.Guarantors.Find(id);
            return View(guarantor);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, Guarantor guarantor)
        {
            try
            {
                Guarantor guarantorInDb = Db.Guarantors.Find(guarantor.Id);
                guarantorInDb.GuarantorName = guarantor.GuarantorName;
                guarantorInDb.Contact = guarantor.Contact;
                guarantorInDb.NIC = guarantor.NIC;
                guarantorInDb.PrimaryAddress = guarantor.PrimaryAddress;
                Db.SaveChanges();

               
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating guarantor.";
                return View("Error");
            }
        }

       
        public ActionResult Delete(int id)
        {
            Guarantor guarantor = Db.Guarantors.Find(id);

            return View(guarantor);
        }

      
        [HttpPost]
        public ActionResult Delete(int id, Guarantor guarantor)
        {
            try
            {
                Guarantor _guarantor = Db.Guarantors.Find(guarantor.Id);
                Db.Guarantors.Remove(_guarantor);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting guarantor";
                return View("Error");
            }
        }
    }
}
