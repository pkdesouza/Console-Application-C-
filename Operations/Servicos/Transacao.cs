using Dominio.Utilidades;
using System;
using System.IO;
using System.Text;

namespace Dominio
{
    public abstract class Transacao
    {
        private static string Diretorio { get => @"C:\Transacao\"; }
        protected static string CaminhoExtrato { get => $"{Diretorio}extrato.txt"; }
        protected static string CaminhoSaldo { get => $"{Diretorio}saldo.txt"; }
        private static DateTime Momento { get => DateTime.UtcNow; }
        public enum OpcoesTransacoes { Boleto, Cartao, Cheque, Paypal, DebitoConta, CreditoConta };

        protected static void RegistrarTransacao(OpcoesTransacoes opcaoPagamento, decimal valor)
        {   
			AtualizarSaldo(new Conta().ConsultarSaldo());
			var sb = new StringBuilder();
			sb.AppendLine($"Momento da transacao: {Momento.ToString()}");
            sb.AppendLine($"Transacao: {opcaoPagamento}");
            sb.AppendLine($"Valor: {valor.ToString("C")}");
            CriarRegistro(Cripitografia.Codificar(sb.ToString()),CaminhoExtrato);
        }
        private static void AtualizarSaldo(decimal valor)
        {
            if (File.Exists(CaminhoSaldo))
                File.Delete(CaminhoSaldo);
            var sb = new StringBuilder();
			sb.Append($"Saldo:{valor.ToString("C")}");
            CriarRegistro(Cripitografia.Codificar(sb.ToString()), CaminhoSaldo);
        }

        private static void CriarRegistro(string sb,string caminho)
        {
            if (!File.Exists(caminho))
            {
                if (!Directory.Exists(Diretorio))
                    Directory.CreateDirectory(Diretorio);
                File.Create(caminho).Close();
            }
            using (StreamWriter leitor = new StreamWriter(caminho, true))
            {
                leitor.WriteLine(sb);
                leitor.Close();
            }
        }
    }
}
