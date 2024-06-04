using System.ComponentModel.DataAnnotations;

namespace JC_BlueTec.API.ViewModes
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login não pode vazio.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Senha { get; set; }
    }
}
