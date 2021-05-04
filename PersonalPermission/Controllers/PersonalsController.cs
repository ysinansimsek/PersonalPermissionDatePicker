using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalPermission.Models;

namespace PersonalPermission.Controllers
{
    public class PersonalsController : Controller
    {
        private DboPersonalPermissionEntities db = new DboPersonalPermissionEntities();

        
        public async Task<ActionResult> Index()
        {
            var tblPersonals = db.TblPersonals.Include(t => t.TblPermission);
            return View(await tblPersonals.ToListAsync());
        }

        
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPersonal tblPersonal = await db.TblPersonals.FindAsync(id);
            if (tblPersonal == null)
            {
                return HttpNotFound();
            }
            return View(tblPersonal);
        }

        
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.TblPermissions, "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,SurName,City,PermissionId,StartDate,EndDate")] TblPersonal tblPersonal)
        {
            if (ModelState.IsValid)
            {
                db.TblPersonals.Add(tblPersonal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.TblPermissions, "Id", "Name", tblPersonal.PermissionId);
            return View(tblPersonal);
        }

        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPersonal tblPersonal = await db.TblPersonals.FindAsync(id);
            if (tblPersonal == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.TblPermissions, "Id", "Name", tblPersonal.PermissionId);
            return View(tblPersonal);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,SurName,City,PermissionId,StartDate,EndDate")] TblPersonal tblPersonal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPersonal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.TblPermissions, "Id", "Name", tblPersonal.PermissionId);
            return View(tblPersonal);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPersonal tblPersonal = await db.TblPersonals.FindAsync(id);
            if (tblPersonal == null)
            {
                return HttpNotFound();
            }
            return View(tblPersonal);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TblPersonal tblPersonal = await db.TblPersonals.FindAsync(id);
            db.TblPersonals.Remove(tblPersonal);
            await db.SaveChangesAsync();
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
