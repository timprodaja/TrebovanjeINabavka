using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrebovanjeINabavke.Models;
using System.Net;

namespace TrebovanjeINabavke.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult SlanjeMejla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SlanjeMejla(EmailViewModel mejlVM)
        {
            if (ModelState.IsValid)
            {
                //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var emailPoruka = new MailMessage();
                emailPoruka.To.Add( mejlVM.NaMejl /*new MailAddress("name@gmail.com")*/); //replace with valid value
                emailPoruka.Subject = "Your email subject";
                emailPoruka.Body = mejlVM.Sadrzaj;
                var korisnik=User.Identity.Name;
                //emailPoruka.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                   
                     smtp.Send(emailPoruka);
                    return RedirectToAction("Index","Home");
                }
            }
            return View(mejlVM);
        }
    }
}