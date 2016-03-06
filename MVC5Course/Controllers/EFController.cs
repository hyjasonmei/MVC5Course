using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index(bool? IsActive, string ProductName)
        {
            var product = new Product
            {
                ProductName = "BMW",
                Price = 3,
                Stock = 1,
                Active = true

            };
            //db.Product.Add(product   );
           

            var pkey = product.ProductId;
            var data = db.Product
                //.Where(p => p.Active.HasValue ? p.Active.Value : false)
                .OrderByDescending(p => p.ProductId).Take(5).AsQueryable();
            if (IsActive.HasValue)
                data = data.Where(p => p.Active.HasValue ? p.Active.Value == IsActive.Value : false);
            if (!String.IsNullOrEmpty(ProductName))
                data = data.Where(p => p.ProductName.Contains(ProductName));


            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }

            SaveChanges();

            return View(data);
        }

        private void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityname = item.Entry.Entity.GetType().Name;
                    foreach (var err in item.ValidationErrors)
                    {
                        throw new Exception(err.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public ActionResult Detail(int id)
        {
            var data = db.Product.FirstOrDefault(p=>p.ProductId == id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var removeitem = db.Product.Find(id);
            db.OrderLine.RemoveRange(removeitem.OrderLine);
            db.Product.Remove(removeitem);
            SaveChanges();
            return  RedirectToAction("Index");
        }

    }
}