using System.ComponentModel.DataAnnotations;
namespace HRExpert.Core.DTO.ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {

        }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name="Пароль")]
        public string Password { get; set; }
        [Display(Name="Email")]
        public string Email { get; set; }
    }
}
