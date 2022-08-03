using System.ComponentModel.DataAnnotations;

namespace LibraryToDocs.WebAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "O nome do Usuário é obrigatório")]
        public string Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
