using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace brq.com.TFSDashboard.Web.Controllers
{
    public class ExpurgoSLAController : Controller
    {
        private DashboardDatabase db = new DashboardDatabase();

        // GET: ExpurgoSLA
        public ActionResult Index()
        {
            return View(db.ExpurgoSLA.ToList());
        }

        // GET: ExpurgoSLA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpurgoSLA expurgoSLA = db.ExpurgoSLA.Find(id);
            if (expurgoSLA == null)
            {
                return HttpNotFound();
            }
            return View(expurgoSLA);
        }

        // GET: ExpurgoSLA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpurgoSLA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkItemID,Dsc_ExpurgoSLAAnalise,Dsc_ExpurgoSLADimensionamento,Dsc_ExpurgoSLAEntrega,Dsc_RefazerDesenvolvimento")] ExpurgoSLA expurgoSLA)
        {
            if (ModelState.IsValid)
            {
                db.ExpurgoSLA.Add(expurgoSLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expurgoSLA);
        }

        // GET: ExpurgoSLA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpurgoSLA expurgoSLA = db.ExpurgoSLA.Find(id);
            if (expurgoSLA == null)
            {
                return HttpNotFound();
            }
            return View(expurgoSLA);
        }

        // POST: ExpurgoSLA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkItemID,Dsc_ExpurgoSLAAnalise,Dsc_ExpurgoSLADimensionamento,Dsc_ExpurgoSLAEntrega,Dsc_RefazerDesenvolvimento")] ExpurgoSLA expurgoSLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expurgoSLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expurgoSLA);
        }

        // GET: ExpurgoSLA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpurgoSLA expurgoSLA = db.ExpurgoSLA.Find(id);
            if (expurgoSLA == null)
            {
                return HttpNotFound();
            }
            return View(expurgoSLA);
        }

        // POST: ExpurgoSLA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpurgoSLA expurgoSLA = db.ExpurgoSLA.Find(id);
            db.ExpurgoSLA.Remove(expurgoSLA);
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
