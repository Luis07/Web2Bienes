using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bienes_Banco.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }
        // GET: Registro
        public ActionResult Registro()
        {
            ViewBag.Title = "Registro";
            return View();
        }
    }
}