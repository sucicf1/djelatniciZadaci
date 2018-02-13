using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using djelatniciZadaci.Models;

namespace djelatniciZadaci.Controllers
{
    public class DjelatniciController : Controller
    {
        private djelatniciZadaciEntities db = new djelatniciZadaciEntities();

        // GET: Djelatnici
        public ActionResult Index()
        {
            return View(db.Djelatnici.ToList());
        }

        // GET: Djelatnici/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Djelatnici djelatnici = db.Djelatnici.Find(id);
            if (djelatnici == null)
            {
                return HttpNotFound();
            }
            return View(djelatnici);
        }

        // GET: Djelatnici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Djelatnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ime,prezime")] Djelatnici djelatnici)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Djelatnici.Add(djelatnici);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Ne mogu spremiti.");
            }

            return View(djelatnici);
        }

        // GET: Djelatnici/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Djelatnici djelatnici = db.Djelatnici.Find(id);
            if (djelatnici == null)
            {
                return HttpNotFound();
            }
            return View(djelatnici);
        }

        // POST: Djelatnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ime,prezime")] Djelatnici djelatnici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(djelatnici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(djelatnici);
        }

        // GET: Djelatnici/Delete/5
        public ActionResult Delete(long? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Ne mogu izbrisati.";
            }
            Djelatnici djelatnici = db.Djelatnici.Find(id);
            if (djelatnici == null)
            {
                return HttpNotFound();
            }
            return View(djelatnici);
        }

        // POST: Djelatnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                Djelatnici djelatnici = db.Djelatnici.Find(id);
                db.Djelatnici.Remove(djelatnici);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
    }
}
