using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Contas
{
    public class Holerite
    {
        public string CnpjEmpregador { get; private set; }
        public double SalarioLiquido { get; private set; }
        // Sugestão:
        // adicionar uma propertie data do holerite,
        // validar a diferença em relação ao Date.Now ( menor que 90 dias).


        public Holerite(string cnpjEmpregador, double salarioLiquido)
        {
            CnpjEmpregador = cnpjEmpregador;
            SalarioLiquido = salarioLiquido;
        }
    }
}
