using System;

namespace FD.Videolocadora.Domain.Entities
{
    public class Filme
    {
        public Filme()
        {
            FilmeId = Guid.NewGuid();
        }
        public Guid FilmeId { get; set; }
        public String Nome { get; set; }
        public double Valor { get; set; }
        public int Disponivel { get; set; }
        public Guid GeneroId { get; set; }
        public virtual Genero Genero { get; set; }


        public void ValidaNome()
        {
            if (Nome == string.Empty)
            {
                throw new Exception("Nome do filme invalido.");
            }
        }

    }
}
