using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class OrderDetailController : Controller
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
            OrderDetail orderDetail = Db.OrderDetails.Find(id);
            
            return View(orderDetail);
        }
         
        [HttpPost]
        public ActionResult Edit(int id, OrderDetail orderDetail)
        {
            try
            {
                OrderDetail orderDetailInDb = Db.OrderDetails.Find(orderDetail.Id);
                orderDetailInDb.Discount = orderDetail.Discount;
                
                int quantity = orderDetail.Quantity - orderDetailInDb.Quantity;

                orderDetailInDb.Quantity += quantity;
                

                Product productInDb = Db.Products.Find(orderDetail.ProductId);

              
                    productInDb.Quantity -= quantity;

                if (productInDb.Quantity < 0)
                    productInDb.Quantity = 0;

                Db.SaveChanges();
                return RedirectToAction("Details","Order",new { id=orderDetail.OrderId});
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating order details";
                return View("Error");
            }
        }
         
        public ActionResult Delete(int id)
        {
            var orderdetail = Db.OrderDetails.Find(id);

            int orderid = (int)orderdetail.OrderId;

            var productInDb = Db.Products.Find(orderdetail.ProductId);

            productInDb.Quantity += orderdetail.Quantity;
            Db.OrderDetails.Remove(orderdetail);

            if (productInDb.Quantity < 0)
                productInDb.Quantity = 0;

            Db.SaveChanges();
            return RedirectToAction("Details", "Order", new { id = orderid });
        }
         
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
