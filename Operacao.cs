using System;
using static System.Enum;
using static System.Console;
using static System.Convert;
using static Dominio.Pagamento;
using static Dominio.Conta;
using Dominio;

namespace Apresentacao
{
    public class Operacao
    {
        public static void Saldo()
        {
            Clear();
            WriteLine($"Saldo Atual: {ConsultarSaldo()}");
            ReadLine();
            Clear();
        }

        public static void RealizarPagamento()
        {
            Clear();
            var operacao = new Framework();
            decimal valor = 0;
            int pagamento = 0;
            OpcoesPagamento formaPagamento;
            DadosEntrada(out valor, out pagamento, out formaPagamento);
            operacao.Pagar += RealizarDebito;
            operacao.Fechar(valor, formaPagamento);
            ReadLine();
            Clear();
        }
        public static void RealizarDeposito()
        {
            Clear();
            var operacao = new Framework();
            decimal valor = 0;
            DadosEntrada(out valor);
            operacao.Depositar += DepositoConta;
            Retorno retorno = operacao.Lancar(valor);
            WriteLine("Status: " + (retorno.Sucesso ? "Sucesso" : "Erro") + "\nRetorno: " + retorno.Mensagem);
            ReadLine();
            Clear();
        }

        public static void DadosEntrada(out decimal valor, out int pagamento, out OpcoesPagamento formaPagamento)
        {
            Clear();
            var i = 0;
            string[] formasPagamentos = GetNames(typeof(OpcoesPagamento));
            Action<string> action = new Action<string>(v => WriteLine($"{++i} - {v}"));
            Predicate<int> predicate = new Predicate<int>(x => x >= 0 && x <= i);
            Write("Valor do pagamento: R$");
            valor = ToDecimal(ReadLine().ValorReal());
            WriteLine("Opção de Pagamento: ");
            (formasPagamentos.Lista()).ForEach(action);
            Write("Digite a opção(número): ");
            pagamento = ToInt32(ReadLine());
            if (!predicate(pagamento))
                DadosEntrada(out valor, out pagamento, out formaPagamento);
            formaPagamento = (OpcoesPagamento)Parse(typeof(OpcoesPagamento), (string)formasPagamentos.GetValue(--pagamento));
        }
        public static void ExibirExtrato()
        {
            Clear();
            RecuperarExtrato();
            ReadLine();
            Clear();
        }
        public static void DadosEntrada(out decimal valor)
        {
            Write("Valor do deposito: R$");
            valor = ToDecimal(ReadLine().ValorReal());
        }
        public static void RecuperarDados()
        {
            try
            {
                RecuperarSaldo();
            }
            catch {

            }
        }
        
    }
}
