using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bienes_Banco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Title = "Contactanos";

            return View();
        }
        // POST: Home/Contacto
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contacto([Bind(Include = "id,name,lastname,admin,email,password,ubicacion,activo,bloqueado")] user user)
        {
            if (ModelState.IsValid)
            {
               
                    db.users.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                
                    ViewData["Error"] = "El correo ya existe";
            }

            return View(user);
        }
    }
}
