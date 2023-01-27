using ConsoleApp;
using ProjetoPooAdaBank.Clientes;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPooAdaBank.Contas
{
    internal class MenuAberturaConta
    {
        public void Menu()
        {
            int input;
            MensagemInicial();

            do
            {
                Console.WriteLine("Selecione [1] para criar uma nova conta ou [2] para logar");
                int.TryParse(Console.ReadLine(), out input);
            } while (input != 1 && input != 2);

            Console.Clear();

            if (input == 1)
            {

                Conta.CriarConta(Cliente.CadastrarCliente());

                Menu();
            }
            else if (input == 2)
            {
                String email, senha;
                bool logou = false, converteu = false;
                int tentativas = 3;
                int operacao;

                do
                {
                    Console.WriteLine("Digite o seu email");
                    email = Console.ReadLine();

                    Console.Clear();

                    Console.WriteLine("Digite o a sua senha");
                    senha = Console.ReadLine();

                    Console.Clear();

                    (Conta conta, logou) = Conta.Logar(email, senha);

                    if (logou)
                    {
                        
                        Console.WriteLine($"Olá {conta.Titular.Nome}, que tipo de operação deseja fazer hoje?\n " +
                            $"[1] Saque\n [2] Visualizar Extrato\n [3] Deposito\n [4] Transferência\n" +
                            $" [5] Consulta de saldo ");
                        if (conta is ContaInvestimento)
                        {
                            
                            Console.WriteLine($" [6] Novo Investimento");
                        }
                        do
                        {
                            converteu = int.TryParse(Console.ReadLine(), out operacao);
                            if (!converteu) Console.WriteLine("Escolha uma opção válida!");

                            else
                            {
                                bool fazerOutraOperacao = false;
                                string resposta;
                                Conta.FazerOperacao(conta, operacao);

                                while (true)
                                {
                                    Console.WriteLine("Deseja fazer outra operação? (sim/nao)");
                                    resposta = Console.ReadLine();

                                    if (resposta.ToLower() != "sim")
                                    {
                                        Console.WriteLine("Até logo e tenha um ótimo dia!");
                                        break;
                                    }
                                    Console.Clear();

                                    Console.WriteLine($"Olá {conta.Titular.Nome}, que tipo de operação deseja fazer hoje?\n " +
                            $"[1] Saque\n [2] Visualizar Extrato\n [3] Deposito\n [4] Transferência\n" +
                            $" [5] Consulta de saldo ");
                                    if (conta is ContaInvestimento)
                                    {

                                        Console.WriteLine($" [6] Novo Investimento");
                                    }

                                    converteu = int.TryParse(Console.ReadLine(), out operacao);
                                    if (!converteu) Console.WriteLine("Opção inválida, até logo!");

                                    Conta.FazerOperacao(conta, operacao);
                                }

                            }
                        } while (!converteu);

                        break;
                    }
                    else
                    {
                        tentativas--;
                        if (tentativas == 0)
                        {
                            Console.Clear();

                            Console.WriteLine("Conta bloqueada por excesso de tentativas!");
                        }
                        Console.WriteLine($"Tentativas restantes {tentativas}");

                        Console.WriteLine();
                    }
                } while (tentativas > 0);
            }
        }
        public void MensagemInicial()
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Bem Vindo ao Ada Bank");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$");

        }
    }
}