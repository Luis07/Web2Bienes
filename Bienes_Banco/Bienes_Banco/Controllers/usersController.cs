﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bienes_Banco.Models;

namespace Bienes_Banco.Controllers
{
    public class usersController : Controller
    {
        private Model1 db = new Model1();

        // GET: users
        public async Task<ActionResult> Index()
        {
            return View(await db.users.ToListAsync());
        }

        // GET: users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Registro()
        {
            return View();
        }

        // POST: users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registro([Bind(Include = "id,name,lastname,admin,email,password,ubicacion,activo,bloqueado")] user user)
        {
            if (ModelState.IsValid)
            {
                if (!FindEmail(user))
                {
                    db.users.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                    ViewData["Error"] = "El correo ya existe";
            }

            return View(user);
        }

        // GET: users/Login
        public ActionResult Login()
        {
            return View();
        }
        //// POST: users/Login
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login([Bind(Include = "email,password")] user user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (!FindEmail(user))
        //        {
        //            db.users.Add(user);
        //            await db.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //            ViewData["Error"] = "El correo ya existe";
        //    }

        //    return View(user);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "email,password")] user user)
        {
                if (FindUser(user))
                {
                    return RedirectToAction("Index");
                }
                else
                    ViewData["Error"] = "Usuario o contraseña incorrectos";
            return View(user);
        }

        // GET: users/emails/diferente
        /// <summary>
        /// Metodo para evitar que se registre un correo ya existente
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true si no está y false si ya está</returns>
        public bool FindEmail(user user)
        {
            int us =  db.users.Where(u => u.email ==user.email).Count();
            if (us ==0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// metodo para validar el login
        /// </summary>
        /// <param name="user">lleva los parametros de usuario y contraseña</param>
        /// <returns>true si se encuentra el usuario y false si no está</returns>
        public bool FindUser(user user)
        {
            var us = db.users.Where(u => u.email == user.email).Where(u => u.password == user.password).Count();
            if (us == 0)
            {
                return false;
            }
            return true;
        }
        // GET: users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,lastname,admin,email,password,ubicacion,activo,bloqueado")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            user user = await db.users.FindAsync(id);
            db.users.Remove(user);
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
