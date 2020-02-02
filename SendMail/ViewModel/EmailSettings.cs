using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendMail.ViewModel
{
    public class EmailSettings
    {
        public string  SmtpHost { get; set; }
        public int  SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool SSL { get; set; }
    }
}