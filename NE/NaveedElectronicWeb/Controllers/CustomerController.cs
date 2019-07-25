using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using PagedList;
namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
 
       
        private List<City> PopulateCities()
        {
            List<City> list = new List<City>();

            var cities = Db.Cities;
            foreach(var city in cities)
            {
                list.Add(new City()
                {
                    Id = city.Id,
                    CityName = city.CityName
                });
            }

            return list;
        }

        
        public ActionResult Index(int? page,int? cityid,string search)
        {
            ViewBag.Cities = PopulateCities();
           
            int _cityid = cityid ?? 0;
            string _search = search ?? string.Empty;
            int _page = page ?? 1;
            ViewBag.Search = _search;
            ViewBag.Cityid = _cityid;
            List<Customer> list = null;

            if (_cityid > 0)
            {
                list = Db.Customers.Where(c => c.CityId == _cityid).OrderBy(cn => cn.CustomerName).ToList();
            }
            else if (!string.IsNullOrEmpty(_search))
            {
                _search = _search.ToLower();
                list = Db.Customers.Where(c => c.CustomerName.ToLower().Contains(_search) || c.FatherName.ToLower().Contains(_search)).OrderBy(cn => cn.CustomerName).ToList();
                
            }
            else
            {
                list = Db.Customers.OrderByDescending(c => c.Id).ToList();
            }
            
            return View(list.ToPagedList(_page,8));
        }

      
        public ActionResult Details(int id)
        {
            Customer customer = Db.Customers.Find(id);
            return View(customer);
        }
         
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                Db.Customers.Add(customer);
                Db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage("Error occured while adding customer.");
                return View("Error");
            }
        }
         
        public ActionResult Edit(int id)
        {
            Customer customer = Db.Customers.Find(id);
            return View(customer);
        }
         
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                Customer customerInDb = Db.Customers.Find(customer.Id);
                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.FatherName = customer.FatherName;
                customerInDb.NIC = customer.NIC;
                customerInDb.PrimaryAddress = customer.PrimaryAddress;
                customerInDb.CityId = customer.CityId;
                Db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating customer.";
                return View("Error");
            }
        }

         
        public ActionResult Delete(int id)
        {
            Customer customer = Db.Customers.Find(id);
            return View(customer);
        }
         
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                Customer customerInDb = Db.Customers.Find(customer.Id);

                Db.Customers.Remove(customerInDb);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting customer.";
                return View("Error");
            }
        }

        public ActionResult AddContact(int customerid)
        {
            CustomerContact customerContact = new CustomerContact();
            customerContact.CustomerId = customerid;
            return View(customerContact);
        }

        [HttpPost]
        public ActionResult AddContact(CustomerContact customerContact)
        {

            try
            {

                Db.CustomerContacts.Add(customerContact);
                Db.SaveChanges();

                return RedirectToAction("Details",new { id=customerContact.CustomerId});
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting customer.";
                return View("Error");
            }
           
        }

        public ActionResult DeleteContact(int contactid,int customerid)
        {
            CustomerContact customerContact = Db.CustomerContacts.Find(contactid);
            Db.CustomerContacts.Remove(customerContact);
            Db.SaveChanges();

            return RedirectToAction("Details", new { id = customerid });
        }
    }
}
