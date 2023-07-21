using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserRegisterDtos
    {
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        [Display(Name="İsim:")]
        [MaxLength(30,ErrorMessage ="En Fazla 30 karakter girebilirsiniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [Display(Name = "Soy İsim:")]
        [MaxLength(30, ErrorMessage = "En Fazla 30 karakter girebilirsiniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [Display(Name = "Mail:")]
        [MaxLength(15, ErrorMessage = "En Fazla 15 karakter girebilirsiniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        [Display(Name = "Kullanıcı Adı:")]
        [MaxLength(15, ErrorMessage = "En Fazla 15 karakter girebilirsiniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [Display(Name = "Şifre:")]
        [MaxLength(15, ErrorMessage = "En Fazla 15 karakter girebilirsiniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
        [Display(Name = "Şifre Tekrar:")]
        [MaxLength(15, ErrorMessage = "En Fazla 15 karakter girebilirsiniz.")]
        public string ConfirmPassword { get; set; }
    }
}
