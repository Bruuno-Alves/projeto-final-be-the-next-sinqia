using ProjetoPooAdaBank.Clientes;
using System;

namespace ProjetoPooAdaBank.Contas
{
	public class ContaInvestimento : Conta
	{
		public string PerfilInvestidor { get; private set; }

        public ContaInvestimento(
            int numeroAgencia, 
            int numeroConta,
            string email,
            string senha,
            Cliente titular) : base(numeroAgencia,numeroConta, email, senha, titular)
		{
			 PerfilInvestidor = AvaliaPerfil();
        }

        public void Investir()
        {
            int opcao;
            double valor;
            
            string infoExtrato;
            do
            {
                Console.WriteLine("Que tipo de investimento deseja realizar?\n" +
                    "[1] - Renda Fixa\n[2] - Ações");
               
                int.TryParse(Console.ReadLine(), out opcao);
            }while(opcao != 1 || opcao != 2);
            if(opcao == 1)
            {
                infoExtrato = "Investimento - Renda Fixa ";
                valor = RendaFixa(); 
            }
            else
            {
                infoExtrato = "Investimento - Ações ";
                valor = Acoes();
            }
            if(valor == 0)
            {
                Console.WriteLine("Operação cancelada.");
            }
            else
            {
                Saldo -= valor;
                Extrato.Add(new Transacao(infoExtrato, valor, Saldo));
            }
        }
        private double Acoes()
        {
            int opcao,quant,loop;
            double valorAcao = 0, valorTotal;

            if(Saldo < 50)
            {
                Console.WriteLine("É necessário ao menos 50R$ em conta para realizar um investimento.");
                return 0;
            }
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("As ações disponíveis no momento são\n" +
                    "[1] - AdaCars - 15,55 R$\n" +
                    "[2] - AdaImóveis - 22,01R$\n" +
                    "[3] - AdaTech - 33,15R$\n" +
                    "[4] - AdaTravel - 13,13R$\n" +
                    "[5] - AdaBank - 48,32R$");
                    Console.WriteLine("Qual das ações listadas deseja comprar?");
                    int.TryParse(Console.ReadLine(), out opcao);
                } while (opcao <= 0 || opcao > 5);

                switch (opcao)
                {
                    case 1:
                        valorAcao = 15.55;
                        break;
                    case 2:
                        valorAcao = 22.01;
                        break;
                    case 3:
                        valorAcao = 33.15;
                        break;
                    case 4:
                        valorAcao = 13.13;
                        break;
                    case 5:
                        valorAcao = 48.32;
                        break;
                    default:
                        break;
                }
                do
                {
                    Console.WriteLine("Quantas ações deseja comprar?");
                    int.TryParse(Console.ReadLine(), out quant);
                    
                    valorTotal = quant * valorAcao;
                    Console.WriteLine($"O total que será pago nas ações será de: {valorTotal}R$");
                    if(valorTotal > Saldo)
                    {
                        Console.WriteLine($"O valor da(s) ação(ões)({valorTotal}R$) ultrassa seu saldo({Saldo}R$)," +
                            $" tente uma quantia menor de ações");

                    }
                } while(quant <=0 ||  valorTotal > Saldo);

                Console.WriteLine($"O valor pago nas ações será de {valorTotal}R$, seu novo saldo será de {Saldo - valorTotal}\n" +
                    $"[1] - Concluir, [2] - Reiniciar , [3] - Cancelar");
                int.TryParse(Console.ReadLine(), out loop);

                if (loop == 3)
                {
                    valorTotal = 0;
                    break;
                }

            } while (loop !=1);

            return valorTotal;
        }
        private double RendaFixa()
        {
            double valor, previaInvestimento=0;
            int opcao,loop;
            do
            {
                Console.Clear();
                Console.WriteLine("Informe quanto deseja investir, " +
                    "após isso escolha entre as opções e veja uma prévia do valor (sem correção)");
                
                do
                {
                    double.TryParse(Console.ReadLine(), out valor);

                    if (valor <= 0 || valor > Saldo)
                    {
                        Console.WriteLine("Valor negativo ou superior ao seu saldo, tente novamente.");
                    }
                } while (valor <= 0 || valor > Saldo);
                
                do
                {
                    Console.WriteLine("As opções de investimento disponíveis são:\n" +
                "[1] - 1 ano = 9%\n[2] - 2 anos = 22% \n[3] - 3 anos = 35%\n[4] - 4 anos = 50%\n[5] - 5 anos = 70%");
                    int.TryParse(Console.ReadLine(), out opcao);
                } while (opcao <= 0 || opcao > 5);
                switch (opcao)
                {
                    case 1:
                        previaInvestimento = valor * 1.09;
                        break;
                    case 2:
                        previaInvestimento = valor * 1.22;
                        break;
                    case 3:
                        previaInvestimento = valor * 1.35;
                        break;
                    case 4:
                        previaInvestimento = valor * 1.5;
                        break;
                    case 5:
                        previaInvestimento = valor * 1.7;
                        break;
                    default:
                        Console.WriteLine("Como tu chegou aqui? O.o");
                        break;
                }

                Console.WriteLine($"A previsão sem reajustes é de que o investimento no valor de {valor}R$, após o tempo estipulado será de {previaInvestimento}." +
                    $"Ao confirmar o investimento seu novo saldo será {Saldo-valor}R$");
                Console.WriteLine("Deseja realizar o investimento? \n[1] - SIM \n[2] - Nova Simulação\n[3] - Cancelar");
                int.TryParse(Console.ReadLine(),out loop);
                if(loop == 3)
                {
                    valor = 0;
                    break;
                }
            } while(loop != 1);

            return valor;

        }
        // baseado nas respostas do cliente, retornará um perfil (que não é usado pra nada)
        private string AvaliaPerfil()
        {
            string perfil;
            int r1, r2, r3, r4, r5;
            bool validaResposta;
            Console.WriteLine("Nós do AdaBank Estamos muito feliz que você deseja abrir uma conta de investimento conosco");
            Console.WriteLine("Por favor responda nosso breve questionário para avaliarmos o seu perfil de investimento");
            do
            {
                Console.WriteLine("1ª - Sua profissão atual exige que você tenha conhecimento sobre o mercado financeiro?");
                Console.WriteLine("[1] = SIM \n[0] = NÃO");
                validaResposta = int.TryParse(Console.ReadLine(), out r1);
            } while (!validaResposta || r1 < 0 || r1 > 1);
            Console.Clear();
            do
            {
                Console.WriteLine("2ª - Qual seria a sua atitude se ocorresse uma queda " +
                                  "de 10% alguns dias após seu investimento?;");
                Console.WriteLine("[1] = Venderia\n[2] = Aguardaria \n[3] = Compraria mais");
                int.TryParse(Console.ReadLine(), out r2);
            } while ( r2 < 1 || r2 > 3);
            Console.Clear();
            do
            {
                Console.WriteLine("3ª - Por quanto tempo pretende deixar seus investimentos?");
                Console.WriteLine("[1] = Até 2 anos\n[2] = Entre 3 e 5 anos \n[3] = Acima de 5 anos");
                 int.TryParse(Console.ReadLine(), out r3);
            } while ( r3 < 1 || r3 > 3);
            Console.Clear();
            do
            {
                Console.WriteLine("4ª - Quanto da sua renda pretende investir?");
                Console.WriteLine("[1] = Até 10%\n[2] = Entre 11% e 20%\n[3] = Acima de 20%");
                validaResposta = int.TryParse(Console.ReadLine(), out r4);
            } while ( r4 < 1 || r4 > 3);
            Console.Clear();
            do
            {
                Console.WriteLine("5ª - Qual é o seu objetivo com investimentos?");
                Console.WriteLine("[1] = Proteger meu patrimônio a curto prazo\n" +
                    "[2] = Proteger meu patrimônio e lucrar a médio Prazo \n" +
                    "[3] = Lucrar a longo prazo");
                validaResposta = int.TryParse(Console.ReadLine(), out r5);
            } while ( r5 < 1 || r5 > 3);
            Console.Clear();
            int media = (r1 * 3 + r2 + r3 + r4 + r5)/5;
            if (media == 0)
            {
                media = 1;
            }
            switch (media)
            {
                default:
                case 1:
                    perfil = "CONSERVADOR: Proteger seu patrimônio e evita o risco";
                    break;
                case 2:
                    perfil = "MODERADO: Aceitar correr algum risco e diversificar o investimento";
                    break;
                case 3:
                    perfil = "AGRESSIVO: Aceita grandes riscos em busca de uma recompensa tão grande quanto";
                    break;
            }


            Console.WriteLine("Obrigado pelas respostas, com base nisso definimos seu perfil de investidor como: ");
            Console.WriteLine(perfil);
            return perfil;
        }

        public override double CalcularValorTarifaManutencao()
        {
            double tarifa = Saldo * 0.008;
            return tarifa;
        }
    }
}
