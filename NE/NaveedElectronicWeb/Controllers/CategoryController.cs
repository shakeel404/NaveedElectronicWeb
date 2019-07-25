using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using PagedList;
namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public ActionResult Index(int? page)
        {
            int _page = page ?? 1;

             

             
            var data = Db.Categories.OrderByDescending(c=>c.Id);
            return View(data.ToPagedList(_page,6));
        }

        
        public ActionResult Details(int id)
        {
            
            var category = Db.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category == null)
                return HttpNotFound("The category you requested is not found.");

            return View(category);
        }
 
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Category category)
        {
            Category _category = new Category()
            {
                CategoryName = category.CategoryName
            };

            try
            {


                Db.Categories.Add(category);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while creating New Category.";
                return View("Error");
            }
        }

        
        public ActionResult Edit(int id)
        {
            
            var category = Db.Categories.Find(id);
            return View(category);
        }

         
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            
            Category _category = Db.Categories.Find(id);

            if (_category == null)
                return HttpNotFound("Category not found.");

            try
            {
                _category.CategoryName = category.CategoryName;
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating category.";
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            
            Category _category = Db.Categories.Where(c=>c.Id==id).FirstOrDefault();
            return View(_category);
        }

       
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            
            Category _category = Db.Categories.Find(id);

            if (_category == null)
                return HttpNotFound("Category not found.");

            try
            {
                Db.Categories.Remove(_category);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while deleting category";
                return View();
            }
        }


        public ActionResult Print()
        {
            var data = Db.Categories.OrderByDescending(c => c.Id);
            return View(data);
        }
    }
}
