using System;
using System.IO;

namespace Dominio
{
    public class Conta : Transacao
    {
        public static decimal Saldo { get; private set; }

        private static void Debitar(decimal valor) => Saldo -= valor;
        private static void Depositar(decimal valor) => Saldo += valor;

        internal static void DepositarConta(decimal valor)
        {
            if (valor <= 0)
                throw new Exception($"Cod:Con-DC, Valor R${valor} informado inválido, operação não finalizada");
            Depositar(valor);
        }
        internal static void DebitarConta(decimal valor)
        {
            if (valor > Saldo)
                throw new Exception($"Cod:Con-DC, Valor R${valor} superior ao saldo de R${Saldo}, operação não finalizada");
            Debitar(valor);
        }
        public static Retorno DepositoConta(decimal valor)
        {
            DepositarConta(valor);
            RegistrarTransacao(OpcoesTransacoes.CreditoConta, valor);
            return new Retorno() { Sucesso = true, Mensagem = "Transação de Deposito realizada com éxito" };
        }
        public static decimal ConsultarSaldo() => Saldo;

        public static void RecuperarSaldo()
        {
            if (!File.Exists(CaminhoSaldo))
                return;
            string[] arquivo = File.ReadAllLines(CaminhoSaldo);
            for (int i = 0; i < arquivo.Length - 1; i++)
            {
                if (arquivo[i].IndexOf(":") != -1)
                {
                    string[] saldo = arquivo[i].Split(':');
                    Depositar(Convert.ToDecimal(saldo[1].Trim()));
                }
            }
        }
        public static void RecuperarExtrato()
        {
            if (!File.Exists(CaminhoExtrato))
                return;
            string[] arquivo = File.ReadAllLines(CaminhoExtrato);
            for (int i = 0; i < arquivo.Length - 1; i++)
            {
                Console.WriteLine(arquivo[i]);
            }
        }

    }
}
