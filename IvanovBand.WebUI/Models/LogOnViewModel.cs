using System.ComponentModel.DataAnnotations;

namespace IvanovBand.WebUI.Models
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        public string UserName {get; set;}

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}