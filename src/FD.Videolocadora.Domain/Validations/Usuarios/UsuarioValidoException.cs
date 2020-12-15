using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Videolocadora.Domain.Validations.Usuarios
{
    class UsuarioValidoException : Exception
    {
        public UsuarioValidoException()
        {

        }

        public UsuarioValidoException(string mensagem) : base(mensagem)
        {

        }
        public UsuarioValidoException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }
    }
}