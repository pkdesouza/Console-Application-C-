using System;
using Dominio;
using static System.Console;
using static System.Convert;
using static Apresentacao.Operacao;

namespace Apresentacao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    RecuperarDados();
                    var opcao = int.MaxValue;
                    while (opcao != 0)
                    {
                        WriteLine("Operações: ");
                        WriteLine("1 - Realizar Pagamento");
                        WriteLine("2 - Realizar Deposito");
                        WriteLine("3 - Consultar Saldo");
                        WriteLine("4 - Exibir Extrato");
                        WriteLine("0 - Sair");
                        Write("Escolha a operação: ");
                        opcao = ToInt32(ReadLine());
                        switch (opcao)
                        {
                            case 1: RealizarPagamento(); break;
                            case 2: RealizarDeposito(); break;
                            case 3: Saldo(); break;
                            case 4: ExibirExtrato(); break;
                            default: Clear(); break;
                        }
                    }
                }
                catch (FormatException e)
                {
                    Clear();
                    Erro.Registrar(e);
                    WriteLine($"Falha de conversão!\nPossível causa do erro : {e.Message}\nPressione a tecla enter para prosseguir...");
                    throw;
                }
                catch (OverflowException e)
                {
                    Clear();
                    Erro.Registrar(e);
                    WriteLine($"Falha na operação com números!\nPossível causa do erro : {e.Message}\nPressione a tecla enter para prosseguir...");
                    throw;
                }
                catch (Exception e) when(e.Message.ToLower().Contains("cod:"))
                {
                    Clear();
                    Erro.Registrar(e);
                    WriteLine($"Erro do sistema!\nPossível causa do erro : {e.Message}\nPressione a tecla enter para prosseguir...");
                    throw;
                }
                catch (Exception e)
                {
                    Clear();
                    Erro.Registrar(e);
                    WriteLine($"Erro durante a operação!\nPossível causa do erro : {e.Message}\nPressione a tecla enter para prosseguir...");
                    throw;
                }
            }
            catch (Exception)
            {
                ReadLine();
                Clear();
                Main(new string[] { });
            }
        }
    }
}
