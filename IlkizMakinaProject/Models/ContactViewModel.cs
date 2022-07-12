using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace IlkizMakinaProject.Models
{
    public class ContactViewModel : MenuViewModel
    {
        [Required(ErrorMessage = "(*)")]
        [MaxLength(200, ErrorMessage = "(*)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "(*)")]
        [MaxLength(200, ErrorMessage = "(*)")]
        [EmailAddress(ErrorMessage = "(*)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "(*)")]
        [MaxLength(200, ErrorMessage = "(*)")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "(*)")]
        [MaxLength(5000, ErrorMessage = "(*)")]
        public string Message { get; set; }

        public bool? Result { get; set; }
        public string ResultMessage { get; set; }


        public void SendMessage()
        {
            try
            {
                MailMessage mail = new MailMessage(new MailAddress("iletisim@birsnmakina.com", "Site Mesajı"), new MailAddress("iletisim@birsnmakina.com", "Site Mesajı"));
                mail.IsBodyHtml = true;
                mail.Subject = "1sn Makina Site Mesajı";
                mail.Body = string.Format("Ad Soyad: {0}<br/>E-posta: {1}<br/>Konu: {2}<br/>Mesaj: {3}", Name, Email, Subject, Message);

                SmtpClient smtp = new SmtpClient("mail.birsnmakina.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("iletisim@birsnmakina.com", "@birsnmakina");
                smtp.Send(mail);

                Name = string.Empty;
                Email = string.Empty;
                Subject = string.Empty;
                Message = string.Empty;
                Result = true;
                ResultMessage = "Mesaj başarıyla gönderilmiştir.";
            }
            catch (Exception ex)
            {
                Result = false;
                ResultMessage = "Mesaj gönderme başarısız. Lütfen tekrar deneyiniz.</br>" + ex.Message + "</br>" + ex.InnerException;
            }
        }
    }
}