using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banco.Models;

namespace Banco.Controllers
{
    public class ComentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Coments
        public async Task<ActionResult> Index()
        {
            return View(await db.Coments.ToListAsync());
        }

        // GET: Coments/Details/5
        public async Task<ActionResult> Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coment coment = await db.Coments.FindAsync(id);
            if (coment == null)
            {
                return HttpNotFound();
            }
            return View(coment);
        }

        // GET: Coments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,usuario,id_image,comment")] Coment coment)
        {
            if (ModelState.IsValid)
            {
                db.Coments.Add(coment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(coment);
        }

        // GET: Coments/Edit/5
        public async Task<ActionResult> Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coment coment = await db.Coments.FindAsync(id);
            if (coment == null)
            {
                return HttpNotFound();
            }
            return View(coment);
        }

        // POST: Coments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,usuario,id_image,comment")] Coment coment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coment);
        }

        // GET: Coments/Delete/5
        public async Task<ActionResult> Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coment coment = await db.Coments.FindAsync(id);
            if (coment == null)
            {
                return HttpNotFound();
            }
            return View(coment);
        }

        // POST: Coments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(decimal id)
        {
            Coment coment = await db.Coments.FindAsync(id);
            db.Coments.Remove(coment);
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
