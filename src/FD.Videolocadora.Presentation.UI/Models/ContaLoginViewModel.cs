using System.ComponentModel.DataAnnotations;

namespace FD.Videolocadora.Presentation.UI.Models
{
    public class ContaLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Continuar Logado")]
        public bool ContinuarLogado { get; set; }
    }
}