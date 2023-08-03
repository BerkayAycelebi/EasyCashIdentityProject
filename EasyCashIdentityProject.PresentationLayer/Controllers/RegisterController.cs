using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                AppUser appUser = new AppUser()
                {
                    UserName=appUserRegisterDtos.Username,
                    Name=appUserRegisterDtos.Name,
                    Surname=appUserRegisterDtos.Surname,
                    Email=appUserRegisterDtos.Email,
                    City="aaaa",
                    District="bbb",
                    ImageUrl="dddd"

                };
                var result=await _userManager.CreateAsync(appUser,appUserRegisterDtos.Password);
                
                if(result.Succeeded)
                {
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
