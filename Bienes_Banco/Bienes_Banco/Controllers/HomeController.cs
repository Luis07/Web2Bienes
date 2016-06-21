using Bienes_Banco.Models;
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
        private Model1 db = new Model1();
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
        public async Task<ActionResult> Contacto([Bind(Include = "name,lastname,email,asunto,contenido")] user user)
        {
            if (EnviarCorreo(user)) {
                return View(user);
            }         
            //if (ModelState.IsValid)
            //{
            //        db.users.Add(user);
            //        await db.SaveChangesAsync();
            //        return RedirectToAction("Index");
            //       }
            return View(user);
        }
        public bool EnviarCorreo(user user)
        {
            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add("luisbrenes250594@gmail.com");

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = user.asunto.ToString();
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add("greivindca7@gmail.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = user.contenido;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(user.email);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential("greivindca7@gmail.com", "gredan0708$");

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            
            cliente.Port = 587;
            cliente.EnableSsl = true;
            

            cliente.Host = "smtp.gmail.com"; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ex.ToString();
                return false;
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }
    }
}
