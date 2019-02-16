using Dominio.ServicosAbstratos;
using static System.Console;
using static Dominio.Conta;
namespace Dominio
{
    public class Pagamento : Transacao, IPagamento
    {
        public Retorno RealizarDebito(decimal valor, OpcoesPagamento opcaoPagamento)
        {
            var transacao = (OpcoesTransacoes)opcaoPagamento;
			if (valor <= 0)
                throw new System.Exception("Cod:Pag-RD, Valor Informado inválido");
            switch (opcaoPagamento)
            {
                case OpcoesPagamento.Boleto:
                    WriteLine(Boleto(valor));
                    break;
                case OpcoesPagamento.Cartao:
                    WriteLine(Cartao(valor));
                    break;
                case OpcoesPagamento.Cheque:
                    WriteLine(Cheque(valor));
                    break;
                case OpcoesPagamento.DebitoConta:
                    DebitarConta(valor);
                    WriteLine($"Valor debitado R${valor}");
                    break;
                case OpcoesPagamento.Paypal:
                    WriteLine(Paypal(valor));
                    break;
                default:
                    throw new System.Exception("Cod:Pag-RD, Forma de Pagamento Inválida");
            }
            RegistrarTransacao(transacao, valor);
            return new Retorno{ Sucesso = true, Mensagem = "Transação de débito realizada com éxito" };
        }

        private static string Cartao(decimal valor) => $"Valor pago no cartão de R${valor}";
        private static string Cheque(decimal valor) => $"Valor pago no cheque de R${valor}";
        private static string Paypal(decimal valor) => $"Valor pago no Paypal de R${valor}";
        private static string Boleto(decimal valor) => $"Valor pago no boleto de R${valor}";

        public enum OpcoesPagamento { Boleto, Cartao, Cheque, Paypal, DebitoConta };

    }
}
