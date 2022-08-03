using System.ComponentModel.DataAnnotations;

namespace LibraryToDocs.WebAPI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
