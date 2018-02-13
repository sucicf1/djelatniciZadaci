using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using djelatniciZadaci.Models;

namespace djelatniciZadaci.Controllers
{
    public class RadniZadaciController : Controller
    {
        private djelatniciZadaciEntities db = new djelatniciZadaciEntities();

        // GET: RadniZadaci
        public ActionResult Index()
        {
            var radniZadaci = db.RadniZadaci.Include(r => r.Djelatnici);
            return View(radniZadaci.ToList());
        }

        // GET: RadniZadaci/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadniZadaci radniZadaci = db.RadniZadaci.Find(id);
            if (radniZadaci == null)
            {
                return HttpNotFound();
            }
            return View(radniZadaci);
        }

        // GET: RadniZadaci/Create
        public ActionResult Create()
        {
            ViewBag.djelatnikId = new SelectList(db.Djelatnici, "Id", "ime");
            return View();
        }

        // POST: RadniZadaci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "naslov,opis,djelatnikId")] RadniZadaci radniZadaci)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RadniZadaci.Add(radniZadaci);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.djelatnikId = new SelectList(db.Djelatnici, "Id", "ime", radniZadaci.djelatnikId);
            }
            catch
            {
                ModelState.AddModelError("", "Ne mogu spremiti.");
            }
            return View(radniZadaci);
        }

        // GET: RadniZadaci/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadniZadaci radniZadaci = db.RadniZadaci.Find(id);
            if (radniZadaci == null)
            {
                return HttpNotFound();
            }
            ViewBag.djelatnikId = new SelectList(db.Djelatnici, "Id", "ime", radniZadaci.djelatnikId);
            return View(radniZadaci);
        }

        // POST: RadniZadaci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,naslov,opis,djelatnikId")] RadniZadaci radniZadaci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radniZadaci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.djelatnikId = new SelectList(db.Djelatnici, "Id", "ime", radniZadaci.djelatnikId);
            return View(radniZadaci);
        }

        // GET: RadniZadaci/Delete/5
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
            RadniZadaci radniZadaci = db.RadniZadaci.Find(id);
            if (radniZadaci == null)
            {
                return HttpNotFound();
            }
            return View(radniZadaci);
        }

        // POST: RadniZadaci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            try
            {
                RadniZadaci radniZadaci = db.RadniZadaci.Find(id);
                db.RadniZadaci.Remove(radniZadaci);
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
