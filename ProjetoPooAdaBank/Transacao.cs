using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank
{
    public class Transacao
    {
        string Tipo { get; set; }
        public double Valor { get; set; }
        public Transacao(string tipo, double valor)
        {
            Tipo = tipo;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Transação: {Tipo} - Valor: {Valor}";
        }
    }


}
