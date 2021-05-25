using System;
using System.Collections.Generic;
using System.Text;

namespace MRALeiloes.Models
{
    public class Produto
    { 
        public string Descricao { get; private set; }
        public double PrecoInicial { get; private set; }
        public double PrecoFinal { get; set; }

        public Produto() { }

        public Produto(string descricao, double precoInicial, double precoFinal)
        {
            Descricao = descricao;
            PrecoInicial = precoInicial;
            PrecoFinal = precoFinal;
        }
    }
}
