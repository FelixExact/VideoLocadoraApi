using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Videolocadora.Domain.Entities;
using FD.Videolocadora.Domain.Validations.Documentos;

namespace FD.Videolocadora.Domain.Specifications.Usuarios
{
    class UsuarioDeveTerCpfValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return CPFValidation.Validar(usuario.CPF);
        }
    }
}
