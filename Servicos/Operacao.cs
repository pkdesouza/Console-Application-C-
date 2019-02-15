using System;
using static System.Enum;
using static System.Console;
using static System.Convert;
using static Dominio.Pagamento;
using Dominio;
using Dominio.Utilidades;

namespace Apresentacao
{
    public class Operacao : BaseOperacao
    {
        public static void Saldo()
        {
            Clear();
            WriteLine($"Saldo Atual: {con.ConsultarSaldo()}");
            ReadLine();
            Clear();
        }

        public static void RealizarPagamento()
        {
            Clear();
            DadosEntrada(out decimal valor, out int pagamento, out OpcoesPagamento formaPagamento);
            operacao.Pagar += pag.RealizarDebito;
            operacao.Fechar(valor, formaPagamento);
            operacao.Pagar -= pag.RealizarDebito;
            ReadLine();
            Clear();
        }
        public static void RealizarDeposito()
        {
            Clear();
            DadosEntrada(out decimal valor);
            operacao.Depositar += con.DepositoConta;
            Retorno retorno = operacao.Lancar(valor);
            operacao.Depositar -= con.DepositoConta;
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
            con.RecuperarExtrato();
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
            con.RecuperarSaldo();
        }

    }
}
