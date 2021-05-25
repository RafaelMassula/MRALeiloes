using System;
using System.Collections.Generic;
using System.Text;

namespace MRALeiloes.Models
{
    public class Lance
    {
        public DateTime DataLance { get; set; } = DateTime.Now;
        public Interessado Participante { get; set; }
        public double Valor { get; set; }

        public Lance()
        {

        }
  
        public Lance(Interessado interessado, double valor)
        {
            Participante = interessado;
            Valor = valor;
        }
    }
}
