using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        public readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Index(AppUserRegisterDtos appUserRegisterDtos)
        {
          
            if(ModelState.IsValid)
            {
                Random random=new Random();
                int code;
                code = random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDtos.Username,
                    Name = appUserRegisterDtos.Name,
                    Surname = appUserRegisterDtos.Surname,
                    Email = appUserRegisterDtos.Email,
                    City = "aaaa",
                    District = "bbb",
                    ImageUrl = "dddd",
                    ConfirmCode = code

                };
                var result=await _userManager.CreateAsync(appUser,appUserRegisterDtos.Password);
                
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage=new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin","differentiate.function@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz:" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("differentiate.function@gmail.com", "ydumzwyljhkzacpx");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                
            }
            return View();
        }
    }
}
