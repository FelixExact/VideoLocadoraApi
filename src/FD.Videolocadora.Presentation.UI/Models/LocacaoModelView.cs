using System;
using System.ComponentModel.DataAnnotations;

namespace FD.Videolocadora.Presentation.UI.Models
{
    public class LocacaoModelView
    {
        public LocacaoModelView()
        {
            LocacaoId = Guid.NewGuid();
        }
        [Key]
        public Guid LocacaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data")]
        public DateTime DataDevolucao { get; set; }

        [Key]
        public Guid filmeId { get; set; }

        [Key]
        public Guid usuarioId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Filme")]
        public string Filme { get; set; }

        [Required(ErrorMessage = "Preencha o campo Usuario")]
        public string Usuario { get; set; }

        public string CPF { get; set; }
    }
}