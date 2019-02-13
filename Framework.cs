using Dominio;
using System;
using static Dominio.Pagamento;

namespace Apresentacao
{
    public delegate Retorno PagarEvent(decimal valor, OpcoesPagamento opcoesPagamento);
    public delegate Retorno DepositarEvent(decimal valor);
    public class Framework
    {
        public event PagarEvent Pagar;
        public event DepositarEvent Depositar;
        public void Fechar(decimal valor, OpcoesPagamento opcoesPagamento) => Pagar(valor, opcoesPagamento);// delegação...
        public Retorno Lancar(decimal valor) => Depositar(valor);// delegação...
    }
}
