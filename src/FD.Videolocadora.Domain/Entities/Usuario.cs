using FD.Videolocadora.Domain.Validations.Documentos;
using System;

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

        public void Valido()
        {
           if (!(CPFValidation.Validar(CPF)))
            {
                throw new Exception("CPF Invalido");
            }
        }
    }
}
