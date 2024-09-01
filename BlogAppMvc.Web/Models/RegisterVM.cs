using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlogAppMvc.Web.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler tutarsız")]
        [DataType(dataType: DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
