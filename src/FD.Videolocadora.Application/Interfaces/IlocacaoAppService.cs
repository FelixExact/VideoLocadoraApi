using System;
using System.Collections.Generic;
using FD.Videolocadora.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FD.Videolocadora.Application.Models;

namespace FD.Videolocadora.Application.Interfaces
{
    public interface IlocacaoAppService
    {
        void Adicionar(LocacaoModel locacao);
        LocacaoModel ObterPorId(Guid id);
        IEnumerable<LocacaoModel> ObterTodos();
        LocacaoModel Atualizar(LocacaoModel locacao);
        void Remover(Guid id);
    }
}
