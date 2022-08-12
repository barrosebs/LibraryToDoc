using System.ComponentModel.DataAnnotations;

namespace LibraryToDocs.WebAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        [Display(Name = "senha")]
        public string Password { get; set; }
    }
}
