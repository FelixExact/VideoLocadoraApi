using System;
using System.ComponentModel.DataAnnotations;

namespace FD.Videolocadora.Presentation.UI.Models
{
    public class FilmeModelView
    {


        [Key]
        public Guid FilmeId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Valor")]
        public double Valor { get; set; }
        [Display(Name = "Disponivel")]
        public int Disponivel { get; set; }

        //genero

        public Guid GeneroId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Genero { get; set; }

        public FilmeModelView()
        {
            FilmeId = Guid.NewGuid();
        }

    }
}