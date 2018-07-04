using ECommerce.Classes;
using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutcsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Produtcs
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var produtcs = db.Produtcs.Include(p => p.Category).Include(p => p.Tax).Where(c => c.CompanyId == user.CompanyId);
            return View(produtcs.ToList());
        }

        // GET: Produtcs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtc produtc = db.Produtcs.Find(id);
            if (produtc == null)
            {
                return HttpNotFound();
            }
            return View(produtc);
        }

        // GET: Produtcs/Create
        public ActionResult Create()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(user.CompanyId), "CategoryId", "Description");
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(user.CompanyId), "TaxId", "Description");
            var products = new Produtc
            {
                CompanyId = user.CompanyId
            };

            return View(products);
        }

        // POST: Produtcs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Produtc produtc)
        {
            if (ModelState.IsValid)
            {
                db.Produtcs.Add(produtc);
                db.SaveChanges();

                if (produtc.ImageFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Products";
                    var file = string.Format("{0}.jpg", produtc.ProductId);

                    var response = FilesHelper.UploadPhoto(produtc.ImageFile, folder, file);

                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        produtc.Image = pic;
                        db.Entry(produtc).State = EntityState.Modified;
                        db.SaveChanges();

                    }

                }

                return RedirectToAction("Index");
            }

            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
           

            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(user.CompanyId), "CategoryId", "Description", produtc.CategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(user.CompanyId), "TaxId", "Description", produtc.TaxId);

            

            return View(produtc);
        }

        // GET: Produtcs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtc produtc = db.Produtcs.Find(id);
            if (produtc == null)
            {
                return HttpNotFound();
            }

                  


            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(produtc.CompanyId), "CategoryId", "Description", produtc.CategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(produtc .CompanyId), "TaxId", "Description", produtc.TaxId);
            return View(produtc);
        }

        // POST: Produtcs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produtc produtc)
        {
            if (ModelState.IsValid)
            {
                if (produtc.ImageFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Products";
                    var file = string.Format("{0}.jpg", produtc.ProductId);

                    var response = FilesHelper.UploadPhoto(produtc.ImageFile, folder, file);

                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        produtc.Image = pic;
                        

                    }

                }
                db.Entry(produtc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(CombosHelper.GetCategories(produtc.CompanyId), "CategoryId", "Description", produtc.CategoryId);
            ViewBag.TaxId = new SelectList(CombosHelper.GetTaxes(produtc.CompanyId), "TaxId", "Description", produtc.TaxId);
            return View(produtc);
        }

        // GET: Produtcs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtc produtc = db.Produtcs.Find(id);
            if (produtc == null)
            {
                return HttpNotFound();
            }
            return View(produtc);
        }

        // POST: Produtcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtc produtc = db.Produtcs.Find(id);
            db.Produtcs.Remove(produtc);
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
