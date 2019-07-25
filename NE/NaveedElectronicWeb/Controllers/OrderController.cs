using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;
using NaveedElectronicWeb.ViewModels;
using System;
using Microsoft.AspNet.Identity;

namespace NaveedElectronicWeb.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details(int id)
        {
            CustomerOrder order = Db.CustomerOrders.Find(id);
            return View(order);
        }


        public ActionResult Create(int customerid, bool installment = false)
        {

            Customer customer = Db.Customers.Find(customerid);
            ViewBag.IsInstallment = installment;
            return View(customer);
        }

         
        [HttpPost]
        public ActionResult Create(OrderViewModel vm)
        {
            try
            {
                var UserId = User.Identity.GetUserId();
                CustomerOrder customerOrder = new CustomerOrder();
                customerOrder.CustomerId = vm.CustomerId;
                customerOrder.DueDate = vm.DueDate;
                if (vm.GuarantorId != 0)
                    customerOrder.GuarantorId = vm.GuarantorId;

                customerOrder.MonthlyInstallment = vm.Installment;
                customerOrder.OrderDate = DateTime.Today;
                customerOrder.UserId = UserId;

                Db.CustomerOrders.Add(customerOrder);
                Db.SaveChanges();

                int OrderId = customerOrder.Id;

                foreach(var detail in vm.Details)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    int productid = detail.ProductId;
                    orderDetail.OrderId = OrderId;
                    orderDetail.ProductId = productid;
                    orderDetail.SalePrice = detail.Price;
                    orderDetail.Quantity = detail.Quantity;
                    orderDetail.Discount = detail.Discount;

                    Product productInDb = Db.Products.Find(productid);
                    int purchaseprice = productInDb.PurchasePrice;

                    orderDetail.PurchasePrice = purchaseprice;
                    
                    productInDb.Quantity -= orderDetail.Quantity;
                   
                    Db.OrderDetails.Add(orderDetail);
                }
                Db.SaveChanges();

                if (vm.Payment > 0)
                {
                    OrderPayment orderPayment = new OrderPayment();
                    orderPayment.UserId = UserId;
                    orderPayment.OrderId = OrderId;
                    orderPayment.DatePaid = DateTime.Today;
                    orderPayment.AmountPaid = vm.Payment;
                    Db.OrderPayments.Add(orderPayment);
                    Db.SaveChanges();
                }
                 

                return RedirectToAction("Details",new { id=OrderId});
            }
            catch
            {
                return View();
            }
        }

         
        public ActionResult Edit(int id)
        {
            CustomerOrder customerOrder = Db.CustomerOrders.Find(id);

            List<Guarantor> guarantors = Db.Guarantors.Where(g => g.CustomerId == customerOrder.CustomerId).ToList();
            if(guarantors==null)
            {
                guarantors = new List<Guarantor>();
            }
            ViewBag.Guarantors = guarantors;

            return View(customerOrder);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, CustomerOrder customerOrder)
        {
            try
            {
                CustomerOrder customerOrderInDb = Db.CustomerOrders.Find(customerOrder.Id);
                customerOrderInDb.DueDate = customerOrder.DueDate;
                customerOrderInDb.GuarantorId = customerOrder.GuarantorId;
                customerOrderInDb.MonthlyInstallment = customerOrder.MonthlyInstallment;

                Db.SaveChanges();
                return RedirectToAction("Details",new {id=customerOrder.Id});
            }
            catch
            {
                ViewBag.ErrorMessage = "Error occured while updating order";
                return View("Error");
            }
        }

       
        public ActionResult Delete(int id)
        {
            CustomerOrder customerOrder = Db.CustomerOrders.Find(id);

            return View(customerOrder);
        }

        
        [HttpPost]
        public ActionResult Delete(int id, CustomerOrder customerOrder)
        {
            try
            {
                CustomerOrder customerOrderInDb = Db.CustomerOrders.Find(id);

                foreach(var detail in customerOrderInDb.OrderDetails)
                {
                    var productInDb = Db.Products.Find(detail.ProductId);

                    productInDb.Quantity += detail.Quantity;

                    if (productInDb.Quantity < 0)
                        productInDb.Quantity = 0;
                }
              
                Db.CustomerOrders.Remove(customerOrderInDb);
                Db.SaveChanges();

                return RedirectToAction("Index","Customer");
            }
            catch
            {

                ViewBag.ErrorMessage = "Error occured while deleting order";

                return View("Error");
            }
        }
    }
}
