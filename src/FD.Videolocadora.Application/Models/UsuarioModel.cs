using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Application.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            Usuarioid = Guid.NewGuid();
        }
        public Guid Usuarioid { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Ativo { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
