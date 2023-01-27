
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoPooAdaBank.Clientes;
using ProjetoPooAdaBank.Log;

namespace ProjetoPooAdaBank.Contas
{
    [JsonConverter(typeof(Json))]
    public class ContaSalario : Conta
    {
        public Holerite Holerite { get; private set; }

        public ContaSalario(
            int numeroConta,
            string email,
            string senha,
            Cliente titular,
            Holerite holerite) : base(numeroConta, email, senha, titular)
        {
            TipoConta = "ContaSalario";
            Holerite = holerite;
        }

        public void DepositarSalario(double valor, string cnpjEmpregador)
        {
            if (cnpjEmpregador == Holerite.CnpjEmpregador)
            {
                Saldo += valor;
                Extrato.Add(new Transacao("Depósito", valor, Saldo));
            }
        }

        public override double CalcularValorTarifaManutencao(double valor)
        {
            double tarifa = Saldo * 0.003;

            return tarifa;
        }

        public static ContaSalario CriarConta(Cliente clienteCadastrado)
        {
            String email, senha;
            Holerite holerite = Holerite.CadastrarHolerite();

            Random random = new Random();

            Console.WriteLine("Informe o seu Email");
            email = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Crie uma senha");
            senha = Console.ReadLine();

            ContaSalario contaSalario = new ContaSalario(
                random.Next(0, 9999),
                email,
                senha,
                clienteCadastrado,
                holerite);


            Console.Clear();

            Console.WriteLine("Conta Salário aberta com sucesso!");
            Console.WriteLine($"Agência: {contaSalario.NumeroAgencia}, " +
                                $"Conta: {contaSalario.NumeroConta}, " +
                                $"Titular: {contaSalario.Titular.Nome}, " +
                                $"Data de abertura: {contaSalario.DataAbertura}");

            return contaSalario;
        }
    }
}
