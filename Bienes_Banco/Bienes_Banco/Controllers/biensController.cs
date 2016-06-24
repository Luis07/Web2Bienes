using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bienes_Banco.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Bienes_Banco.Controllers
{
    public class biensController : Controller
    {
        private Model1 db = new Model1();

        // GET: biens
        public async Task<ActionResult> Index()
        {
            return View(await db.bien.ToListAsync());
        }

        // GET: biens/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = await db.bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }
        /// <summary>
        /// metodo para validar el formato de la imagen a guardar
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>true si está bien y false si no</returns>
        public bool validateImage(bien bien)
        {
            try
            {
                Stream stream = new MemoryStream(bien.imagen);
                using (Image img = Image.FromStream(stream))
                {
                    if (img.RawFormat.Equals(ImageFormat.Bmp) ||
                        img.RawFormat.Equals(ImageFormat.Gif) ||
                        img.RawFormat.Equals(ImageFormat.Jpeg) ||
                        img.RawFormat.Equals(ImageFormat.Png))
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        // GET: biens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: biens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_bien,localizacion,precio,recamaras,baños,estacionamientos,m_construccion,imagen,likes")] bien bien)
        {
            if (ModelState.IsValid)
            {
                db.bien.Add(bien);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bien);
        }

        // GET: biens/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = await db.bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: biens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_bien,localizacion,precio,recamaras,baños,estacionamientos,m_construccion,imagen,likes")] bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        // GET: biens/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bien bien = await db.bien.FindAsync(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        // POST: biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bien bien = await db.bien.FindAsync(id);
            db.bien.Remove(bien);
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
