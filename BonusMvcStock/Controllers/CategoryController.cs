using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStock.Models.Entity; // Assuming you have a Models namespace
namespace BonusMvcStock.Controllers
{
    public class CategoryController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities(); // Assuming you have a DbContext named DbMvcStockEntities
        // GET: Category
        public ActionResult Index()
        {
            var categories = db.TblCategory.ToList(); // Assuming you have a DbSet<Category> in your DbContext

            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(TblCategory category)
        {
            if (ModelState.IsValid)
            {
                db.TblCategory.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public ActionResult Delete(int id)
        {
            var category = db.TblCategory.Find(id);
            if (category != null)
            {
                db.TblCategory.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var category = db.TblCategory.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

    }
}