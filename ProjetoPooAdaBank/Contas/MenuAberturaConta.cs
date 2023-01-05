using ConsoleApp;
using ProjetoPooAdaBank.Clientes;

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
                Conta conta = AbrirConta();
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
                                FazerOperacao(conta, operacao);

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

                                    FazerOperacao(conta, operacao);
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

        public Endereco CadastrarEndereco()
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
        public Cliente CadastrarCliente()
        {
            String nomeCompleto, CPF;

            Console.WriteLine("Informe o seu nome");
            nomeCompleto = Console.ReadLine();

            Console.Clear();
            do
            {
                Console.WriteLine("Informe o seu CPF");
                CPF = Console.ReadLine();
                if (CPFValidator.ValidaCPF(CPF))
                {
                    break;
                }
                Console.WriteLine("CPF inválido, por favor digite novamente.");
            } while (true);

            Console.Clear();

            Endereco endereco = CadastrarEndereco();

            Cliente cliente = new(nomeCompleto, CPF, endereco);

            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.Cpf}, rua: {cliente.Endereco.Rua} ");

            return cliente;
        }

        public Conta AbrirConta()
        {
            int tipoConta;

            Cliente clienteCadastrado = CadastrarCliente();

            Console.WriteLine("Que tipo de conta você deseja abrir?");
            Console.WriteLine("[1] - Poupança\n[2] - Salario\n[3] - Investimento");

            do
            {
                int.TryParse(Console.ReadLine(), out tipoConta);
            } while (tipoConta < 1 || tipoConta > 3);

            Console.Clear();

            // criar métodos para construir as contas: poupança, salário e investimento.
            if(tipoConta ==1)
            {
                String email, senha;
                double valorInicial;
                bool converteu = false;

                Random random = new Random();

                Console.WriteLine("Informe o seu Email");
                email = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Crie uma senha");
                senha = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Informe o saldo inicial");
                do
                {
                    converteu = double.TryParse(Console.ReadLine(), out valorInicial);

                    if (valorInicial <= 50)
                    {
                        Console.WriteLine("O saldo inicial deve ser estar de R$ 50,00");
                    }
                } while (valorInicial <= 50);

                ContaPoupanca contaPoupanca = new ContaPoupanca(
                    random.Next(0, 9999),
                    email,
                    senha,
                    clienteCadastrado,
                    valorInicial);

                Console.Clear();

                Console.WriteLine("Conta Salário aberta com sucesso!");
                Console.WriteLine($"Agência: {contaPoupanca.NumeroAgencia}, " +
                                    $"Conta: {contaPoupanca.NumeroConta}, " +
                                    $"Titular: {contaPoupanca.Titular.Nome}, " +
                                    $"Data de abertura: {contaPoupanca.DataAbertura}");

                return contaPoupanca;

            }
            
            if (tipoConta == 2)
            {
                String email, senha, cnpjEmpregador;
                double salario;
                bool converteu = false;

                Random random = new Random();

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
                    cnpjEmpregador,
                    salario);

                Console.Clear();

                Console.WriteLine("Conta Salário aberta com sucesso!");
                Console.WriteLine($"Agência: {contaSalario.NumeroAgencia}, " +
                                    $"Conta: {contaSalario.NumeroConta}, " +
                                    $"Titular: {contaSalario.Titular.Nome}, " +
                                    $"Data de abertura: {contaSalario.DataAbertura}");

                return contaSalario;
            }

            if(tipoConta == 3)
            {
                String email, senha;
                Random random = new Random();
                Console.Clear();
                Console.WriteLine("Informe o seu Email");
                email = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Crie uma senha");
                senha = Console.ReadLine();

                ContaInvestimento ContaInvestimento = new(random.Next(0,9999),email,senha,clienteCadastrado);

                return ContaInvestimento;
            }

            return null;
        }

        

        public void FazerOperacao(Conta conta, int operacao)
        {
            double valor;
            bool sucedido = false;
            String cpf;

            if (operacao == 1)
            {
                Console.WriteLine("Digite o valor a ser sacado");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                if (sucedido)
                {
                    conta.Sacar(valor);
                }
            }
            else if (operacao == 2)
            {
                conta.MostrarExtrato();
            }
            else if (operacao == 3)
            {
                Console.WriteLine("Digite o valor a ser depositado");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                if (sucedido)
                {
                    conta.Depositar(valor);

                }
            }
            else if (operacao == 4)
            {
                Console.WriteLine("Digite o valor a ser tranferido");
                sucedido = double.TryParse(Console.ReadLine(), out valor);

                Console.WriteLine("Digite o CPF do titular da conta para qual deseja transferir");
                cpf = Console.ReadLine();

                conta.Transferir(valor, cpf);
            }
            else if (operacao == 5)
            {
                Console.WriteLine($"O seu saldo atual é de R${conta.Saldo}");
            }
            else if(operacao == 6 && conta is ContaInvestimento)
            {
                var contaInvestimento = (ContaInvestimento)conta;
                contaInvestimento.Investir();
            }
            else
            {
                Console.WriteLine("Digite um valor válido ou pressione 'E' para sair");
            }
        }
    }
}