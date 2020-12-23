using FD.Videolocadora.Domain.Entities;
using System;

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

        public Usuario ToEntity()
        {
            return new Usuario()
            {
                Usuarioid = Usuarioid,
                Nome = Nome,
                CPF = CPF,
                Endereco = Endereco,
                DataNascimento = DataNascimento,
                Ativo = 1
            };

        }
    }
}
