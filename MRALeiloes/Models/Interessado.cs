
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MRALeiloes.Models
{
    public class Interessado
    {
        public string Nome { get; set; }
        public IList<double> MeusLances { get; } = new List<double>();

        public Interessado()
        {
        }
        public Interessado(string nome)
        {
            Nome = nome;
        }

        public double UltimoLance()
        {
            return MeusLances.DefaultIfEmpty(0)
                 .LastOrDefault();
        }
        public void DarLance(Lance lance)
        {
            if (lance.Valor <= 0 || string.IsNullOrEmpty(lance.Valor.ToString()))
            {
                throw new Exception("Seu lance não pode ser registrado.");
            }
            MeusLances.Add(lance.Valor);
        }

    }
}
