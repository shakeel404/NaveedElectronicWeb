using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using PagedList;

namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        NEDataBaseEntities Db = new NEDataBaseEntities();

        public ActionResult Index(int? page, int? categoryid)
        {

            int _page = page ?? 1;

          

            int _categoryid = categoryid ?? 0;

            IQueryable<Product> data = null; 
            if (_categoryid == 0)
            {
              
                data = Db.Products.OrderByDescending(p => p.Id);
                
            }
            else
            {
                ViewBag.CategoryId = _categoryid;
                data = Db.Products.Where(p=>p.CategoryId==_categoryid).OrderByDescending(p => p.Id);
            }

            

            return View(data.ToPagedList(_page,6));
        }

         
        public ActionResult Details(int id)
        {

            

            Product product = Db.Products.Find(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
             

            List<Category> list = Db.Categories.OrderByDescending(c => c.Id).ToList();

            ViewBag.CategoriesList = list;
             
            return View();
        }

         
        [HttpPost]
        public ActionResult Create(Product product)
        {

            try
            {
                
                Db.Products.Add(product);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {

                return View("Error");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
           
            var product = Db.Products.Find(id) ;
            
            return View(product);
        }
 
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                

                var _product = Db.Products.Where(p => p.Id == id).FirstOrDefault();



                _product.Id = product.Id;
                _product.CategoryId = product.CategoryId;
                _product.Model = product.Model;
                _product.GuaranteeWarranty = product.GuaranteeWarranty;
                _product.PurchasePrice = product.PurchasePrice;
                _product.SalePrice = product.SalePrice;
                _product.InstallmentRatio = product.InstallmentRatio;
                _product.FirstPaymentRatio = product.FirstPaymentRatio;
                _product.NoOfMonths = product.NoOfMonths;
                _product.Quantity = product.Quantity;
                
                Db.SaveChanges();


                return RedirectToAction("Index", new { page = 1, categoryid = _product.CategoryId });
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occrred while updatig the product";
                return View("Error");
            }
        }

         
        public ActionResult Delete(int id)
        {
            
            Product product = Db.Products.Find(id);

            return View(product);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                
                Product _product = Db.Products.Find(id);
                Db.Products.Remove(_product);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting product";

                return View("Error");
            }
        }
    }
}
