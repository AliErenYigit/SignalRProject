using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            // Yeni MimeMessage oluştur
            MimeMessage mimeMessage = new MimeMessage();

            // Gönderen bilgisi
            MailboxAddress mailboxAdress = new MailboxAddress("SignalR Rezervasyon", "sad549333@gmail.com");
            mimeMessage.From.Add(mailboxAdress);

            // Alıcı bilgisi
            MailboxAddress mailBoxAdressTo = new MailboxAddress("User", createMailDto.ReciverMail);
            mimeMessage.To.Add(mailBoxAdressTo);

            // E-posta içeriği (Body)
            var bodyBuilder = new BodyBuilder();

            // HTML formatında body ayarı
            bodyBuilder.HtmlBody = createMailDto.Body; // Summernote ile gelen HTML içeriği direkt kullanılıyor
            bodyBuilder.TextBody = "Bu mail HTML formatını desteklemeyen istemciler için düz metin versiyonudur."; // Alternatif düz metin içeriği

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // E-posta konusu
            mimeMessage.Subject = createMailDto.Subject;

            // SMTP istemcisi ayarları
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("sad549333@gmail.com", "orcx bzch ycih fecn");

                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return RedirectToAction("Index", "Category");
        }
    }
}
