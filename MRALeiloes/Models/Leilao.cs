using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MRALeiloes.Models
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public Produto Produto { get; set; }
        public IList<Lance> Lances { get; private set; } = new List<Lance>();
        public EstadoLeilao EstadoLeilao { get; private set; }

        public Leilao( string descricao, Produto produto)
        {
            Descricao = descricao;
            Produto = produto;
            EstadoLeilao = EstadoLeilao.Aberto;
        }

        public void IniciaPregao()
        {
            EstadoLeilao = EstadoLeilao.EmAnadamento;
        }
        public double Pregao()
        {
            EstadoLeilao = EstadoLeilao.Fechado;
            var maiorLance = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(x => x.Valor)
                .LastOrDefault();

            return maiorLance.Valor;
        }
        public void RecebeLance(Lance lance)
        {
            if(EstadoLeilao == EstadoLeilao.EmAnadamento)
            {
                Lances.Add(lance);
            }
        }
    }
}
