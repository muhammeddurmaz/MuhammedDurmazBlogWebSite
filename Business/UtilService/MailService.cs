using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace Business.UtilService
{
    public class MailService : IMailService
    {

        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string to, String fromName)
        {
            var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_configuration["EmailSettings:SmtpPort"]),
                Credentials = new NetworkCredential(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]),
                EnableSsl = bool.Parse(_configuration["EmailSettings:UseSsl"]),
            };


			var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["EmailSettings:FromAddress"]),
                Subject = "Teşekkürler!",
                IsBodyHtml = true, // Change to false if you're sending plain text
            };
            string htmlBody = $@"
                <!DOCTYPE html>
<html lang='tr'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Teşekkür Ederim</title>
  <style>
    body {{
      font-family: 'Arial', sans-serif;
      background-color: #f4f4f4;
      text-align: center;
    }}

    .container {{
      max-width: 600px;
      margin: 0 auto;
      padding: 20px;
      background-color: #ffffff;
      border-radius: 10px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }}

    h1 {{
      color: #333333;
    }}

    p {{
      color: #666666;
    }}

    .button {{
      display: inline-block;
      padding: 10px 20px;
      font-size: 16px;
      text-align: center;
      text-decoration: none;
      background-color: #4caf50;
      color: #ffffff;
      border-radius: 5px;
    }}
  </style>
</head>
<body>
  <div class='container'>
    <h1>Teşekkür Ederim!</h1>
    <p>Merhaba {HtmlEncoder.Default.Encode(fromName)}, </p>
    <p>Gösterdiğiniz ilgi ve destek için minnettarım. Teşekkür ederim.</p>
    <p>İyi günler dilerim!</p>
    <br>
    <p>Saygılarımla,</p>
    <p>Muhammed Durmaz</p>
    <br>
    <a href='muhammeddurmaz.com' class='button'>Web Sitemi Ziyaret Et</a>
  </div>
</body>
</html>

";

            
            mailMessage.Body = htmlBody;
            mailMessage.To.Add(to);

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
