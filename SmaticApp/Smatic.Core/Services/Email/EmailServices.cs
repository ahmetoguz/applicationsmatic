using System.Net;
using System.Net.Mail;


namespace Smatic.Core.Services.Email
{
    public class EmailServices : IEmailService
    {
        public void SendInviteEmail(string from, string to, string subject, string body)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;


            sc.Credentials = new NetworkCredential("testogz21@gmail.com", "cnmo0*8Anb");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("eposta@gmail.com", "Test isim");

            mail.To.Add("ahmetoguz.net@mail.com");
            mail.To.Add("testogz21@gmail.com");



            mail.Subject = "E-Posta Konusu"; 
            mail.IsBodyHtml = true; 
            mail.Body = "E-Posta İçeriği";


            sc.Send(mail);
        }
    }
}
