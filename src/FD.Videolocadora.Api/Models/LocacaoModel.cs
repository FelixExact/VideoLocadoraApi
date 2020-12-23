using FD.Videolocadora.Domain.Entities;
using System;

namespace FD.Videolocadora.Application.Models
{
    public class LocacaoModel
    {
        public LocacaoModel()
        {
            LocacaoId = Guid.NewGuid();
        }
        public Guid LocacaoId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Guid FilmeId { get; set; }
        public Guid UsuarioId { get; set; }

        public Locacao ToEntity()
        {
            return new Locacao()
            {
                LocacaoId = LocacaoId,
                DataDevolucao = DataDevolucao,
                FilmeId = FilmeId,
                UsuarioId = UsuarioId
            };
        }
    }
}
