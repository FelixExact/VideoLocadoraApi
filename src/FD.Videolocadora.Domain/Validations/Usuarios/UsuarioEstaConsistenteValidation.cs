using DomainValidation.Validation;
using FD.Videolocadora.Domain.Specifications.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Videolocadora.Domain.Entities;

namespace FD.Videolocadora.Domain.Validations.Usuarios
{
    class UsuarioEstaConsistenteValidation : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidation()
        {
            var CPFUsuario = new UsuarioDeveTerCpfValidoSpecification();
            base.Add("CPFCliente", new Rule<Usuario>(CPFUsuario, "Cliente informou um CPF invalido."));

        }
    }
}
