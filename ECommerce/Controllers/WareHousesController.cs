using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class WareHousesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: WareHouses
        public ActionResult Index()
        {
            var wareHouses = db.WareHouses.Include(w => w.Cities).Include(w => w.Company);
            return View(wareHouses.ToList());
        }

        // GET: WareHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouses.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            return View(wareHouse);
        }

        // GET: WareHouses/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: WareHouses/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WareHouseId,CompanyId,Name,Phone,Address,DepartamentId,CityId")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.WareHouses.Add(wareHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", wareHouse.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", wareHouse.CompanyId);
            return View(wareHouse);
        }

        // GET: WareHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouses.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", wareHouse.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", wareHouse.CompanyId);
            return View(wareHouse);
        }

        // POST: WareHouses/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WareHouseId,CompanyId,Name,Phone,Address,DepartamentId,CityId")] WareHouse wareHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wareHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", wareHouse.CityId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", wareHouse.CompanyId);
            return View(wareHouse);
        }

        // GET: WareHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WareHouse wareHouse = db.WareHouses.Find(id);
            if (wareHouse == null)
            {
                return HttpNotFound();
            }
            return View(wareHouse);
        }

        // POST: WareHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WareHouse wareHouse = db.WareHouses.Find(id);
            db.WareHouses.Remove(wareHouse);
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
    }
}
