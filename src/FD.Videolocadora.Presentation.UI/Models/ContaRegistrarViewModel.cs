using System.ComponentModel.DataAnnotations;

namespace FD.Videolocadora.Presentation.UI.Models
{
    public class ContaRegistrarViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}