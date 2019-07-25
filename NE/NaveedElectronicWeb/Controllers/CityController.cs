using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NaveedElectronicWeb.NEModel;

namespace NaveedElectronicWeb.Controllers
{
    public class CityController : Controller
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();
        // GET: City
        public ActionResult Index()
        {
            var cities = Db.Cities.OrderByDescending(c=>c.Id).ToList();
            return View(cities);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: City/Edit/5
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

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {

           if(id==1)
            {
                return RedirectToAction("Index");
            }

            var city = Db.Cities.Find(id);
            var customers = Db.Customers.Where(c => c.CityId == id).ToList();

            foreach(var customer in customers)
            {
                customer.CityId = 1;
            }
            Db.Cities.Remove(city);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: City/Delete/5
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
