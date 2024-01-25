using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using System.ComponentModel.DataAnnotations;
using SendGrid.Helpers.Mail;
namespace SendGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SendEmail()
        {
            var apiKey = "apikey alıp yazıyoruz";
            var client = new SendGridClient(apiKey);
            var from = new EMailAddress("gonderii emaila adresi", "isim soy isim");
            var subject = "konuyu yazıyoruyz";
            var to = new EmailAddress("kimemnail atcaksak", "kime gidecek ");
            var plainTextContext = "mesajımız";
            var htmlContent = "<storng>html içeriğinde de yazı gönderebiliriz<strong>";
            var msg=MailHelper.CreateSingleEmail(from,to,subject,plainTextContext,htmlContent);
            var response=await client.SendAsync(msg);
            return Ok(new { Message = "mail başarılı gitti" });

        }

    }
}