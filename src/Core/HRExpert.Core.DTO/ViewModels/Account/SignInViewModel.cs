using System.ComponentModel.DataAnnotations;
namespace HRExpert.Core.DTO.ViewModels.Account
{
    public class SignInViewModel
    {
        public SignInViewModel()
        { }
        [Display(Name ="Login/Email")]
        public string Login { get; set; }
        [Display(Name ="Пароль")]
        public string Password { get; set; }
    }
}
