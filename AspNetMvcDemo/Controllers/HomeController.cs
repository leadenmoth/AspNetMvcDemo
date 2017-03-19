using AspNetMvcDemo.Extensions;
using AspNetMvcDemo.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private ProductDbContext db = new ProductDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category,Name,Price,Description,Modified")] Product product)
        {
            string url = null;
            string partial = null;
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                url = Url.Action("Index", "Home");
            }
            else
            {
                partial = PartialView("Create", product).RenderToString();
            }
            return Json(new { partial, url });
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category,Name,Price,Description,Modified")] Product product)
        {
            string url = null;
            string partial = null;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                url = Url.Action("Index", "Home");
            } else
            {
                partial = PartialView("Edit", product).RenderToString();
            }
            return Json(new { partial, url});
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Json()
        {
            ViewBag.Message = "Json external API demo from Front End tasks.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Placeholder 'About' page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Placeholder 'Contact' page";

            return View();
        }
    }
}
