using DomainValidation.Validation;
using FD.Videolocadora.Domain.Validations.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            Usuarioid = Guid.NewGuid();

        }
        public Guid Usuarioid { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;// se for = 0, esta valido, sem erro!
        }
    }
}
