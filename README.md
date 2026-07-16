# SendMailTester

A .NET Framework ASP.NET MVC app for testing SMTP server connectivity and sending emails.

## Features

- Configurable SMTP host, port, username, password, from/to, subject, and body
- Optional STARTTLS / TLS via the **Enable STARTTLS / TLS** checkbox (`SmtpClient.EnableSsl`)
- Forces **TLS 1.2** for outbound SMTP (required by Microsoft 365 and many modern SMTP hosts)
- SMTP authentication via username/password (`UseDefaultCredentials = false`)

## Microsoft 365 SMTP notes

If you are testing against Microsoft 365 and see:

`5.7.3 STARTTLS is required to send mail`

use settings like:

| Setting | Value |
|---|---|
| SMTP Server | `smtp.office365.com` |
| Port | `587` |
| SMTP Authentication | Enabled (username + password) |
| Encryption | STARTTLS / TLS (enable the checkbox) |
| Username | your mailbox (e.g. `no_reply@example.com`) |

Microsoft 365 also requires TLS 1.2 or later, which this app sets when sending.

## Run locally

Requires .NET Framework 4.5+ and IIS Express (or Visual Studio).

```bash
# Build
MSBuild SendMail.sln /p:Configuration=Debug

# Run with IIS Express
iisexpress /path:"<repo>\SendMail" /port:1160 /clr:v4.0
```

Then open [http://localhost:1160/](http://localhost:1160/).

Or open `SendMail.sln` in Visual Studio and press F5.
