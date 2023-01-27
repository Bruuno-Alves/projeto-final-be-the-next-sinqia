using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPooAdaBank.Clientes
{
    public class Endereco 
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco(string rua, int numero, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public static Endereco CadastrarEndereco()
        {
            String logradouro, bairro, cidade, estado, cep;
            int numero;
            bool converteu;

            Console.WriteLine("Informe o seu logradouro");
            logradouro = Console.ReadLine();

            Console.Clear();

            do
            {
                Console.WriteLine("Informe o número da sua redidência");
                converteu = int.TryParse(Console.ReadLine(), out numero);

                if (!converteu)
                {
                    Console.WriteLine("Digite um número válido");
                }

            } while (!converteu);

            Console.Clear();

            Console.WriteLine("Informe o seu bairro");
            bairro = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe a sua cidade");
            cidade = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe o seu estado");
            estado = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Informe o seu CEP");
            cep = Console.ReadLine();

            Console.Clear();

            Endereco endereco = new Endereco(logradouro, numero, bairro, cidade, estado);

            return endereco;
        }

        public override string ToString()
        {
            return $"Rua {Rua}, nº {Numero} - {Bairro} - {Cidade} - {Estado}";
        }


    }
}
