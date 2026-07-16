using System;
using System.Net;
using System.Net.Mail;
using System.Text;
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
                // Microsoft 365 requires TLS 1.2 or later for authenticated SMTP
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                MailMessage mail = new MailMessage(obj.From, obj.To);
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Port = obj.SmtpPort;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Host = obj.SmtpHost;
                client.Credentials = new NetworkCredential(obj.Username, obj.Password);
                // EnableSsl = true triggers STARTTLS on port 587 (required by Microsoft 365)
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
