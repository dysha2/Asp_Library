using System.ComponentModel.DataAnnotations;

namespace ASPLibrary.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "Укажите имя пользователя!")]
        [MinLength(4, ErrorMessage = "Имя пользователя должно быть от 4 до 25 символов!")]
        [MaxLength(25)]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Укажите пароль!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; 
}
        [Compare("Password", ErrorMessage = "Пароли должны совпадать!")]
        [Display(Name = "Повторите пароль")]
        public string RepeatPassword { get; set; }
    }
}
