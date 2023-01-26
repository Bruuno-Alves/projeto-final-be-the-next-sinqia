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
        public DateTime DataHolerite { get; private set; }
        // Sugestão:
        // adicionar uma propertie data do holerite,
        // validar a diferença em relação ao Date.Now ( menor que 90 dias).


        public Holerite(string cnpjEmpregador, double salarioLiquido, DateTime dataHolerite)
        {
            CnpjEmpregador = cnpjEmpregador;
            SalarioLiquido = salarioLiquido;
            DataHolerite = dataHolerite;
        }

        public static Holerite CadastrarHolerite()
        {
            String cnpjEmpregador;
            double salario;
            bool converteu = false;
            bool validar = false;
            DateTime dataHolerite;

            Console.WriteLine("Informe o CNPJ do seu empregador");
            cnpjEmpregador = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe o seu salário líquido");
            do
            {
                converteu = double.TryParse(Console.ReadLine(), out salario);

                if (salario <= 0)
                {
                    Console.WriteLine("Digite um salário válido!");
                }
            } while (salario <= 0);

            Console.Clear();

            Console.WriteLine("Informe a data do seu último holerite");

            do
            {
                DateTime.TryParse(Console.ReadLine(), out dataHolerite);
                validar = Holerite.ValidarDataHolerite(dataHolerite);
                if (validar == false)
                {
                    Console.WriteLine("A data do holerite é superior a 90 dias. Digite um mais recente!");
                }

            } while (validar == false);

            Holerite holerite = new Holerite(cnpjEmpregador, salario, dataHolerite);

            Console.Clear();
            return holerite;
        }


        public static bool ValidarDataHolerite(DateTime dataHolerite) {

            DateTime dataAtual = DateTime.Today;
            TimeSpan diferenca = dataAtual.Subtract(dataHolerite);
            if (diferenca.TotalDays <= 90) {
                return true;
            }
            return false;
        }
    }
}
