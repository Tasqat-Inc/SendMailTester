using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SendMail.ViewModel;

namespace SendMail.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(EmailSettings obj)
        {
            string result = "";
            try
            {
                MailMessage mail = new MailMessage(obj.From, obj.To);
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Port = obj.SmtpPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Host = obj.SmtpHost;
                client.Credentials = new System.Net.NetworkCredential(obj.Username, obj.Password);
                client.EnableSsl = obj.SSL;

                mail.Subject = obj.Subject;
                mail.Body = obj.Body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;



                client.Send(mail);
                result = "1";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    result = ex.Message + " - " + ex.InnerException.Message;
                }
                else
                {
                    result = ex.Message;
                }
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
