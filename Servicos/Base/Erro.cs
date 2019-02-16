using System;
using System.IO;
using System.Text;

namespace Apresentacao
{
    internal static class Erro
    {
        private static DateTime Momento { get => DateTime.UtcNow; }
        private static string Diretorio { get => @"C:\Logs\"; }
        private static string Path { get => $"{Diretorio}*nome*.txt".Replace("*nome*", DateTime.Now.ToString("yyyy-MM-dd")); }
        internal static void Registrar(Exception e)
        {
            var sb = new StringBuilder();
			sb.AppendLine($"-------------------------{Momento.ToString()}-------------------------");
            sb.AppendLine("Mensagem:");
            sb.AppendLine(e.Message);
            sb.AppendLine("Target:");
            sb.AppendLine(e.TargetSite.Name);
            sb.AppendLine("Source:");
            sb.AppendLine(e.Source);
            sb.AppendLine("Trace");
            sb.AppendLine(e.StackTrace);
            CriarRegistro(sb.ToString());
        }

        private static void CriarRegistro(string sb)
        {
            if (!File.Exists(Path))
            {
                if (!Directory.Exists(Diretorio))
                    Directory.CreateDirectory(Diretorio);
                File.Create(Path).Close();
            }
            using (StreamWriter leitor = new StreamWriter(Path, true))
            {
                leitor.WriteLine(sb.ToString());
                leitor.Close();
            }
        }
    }
}