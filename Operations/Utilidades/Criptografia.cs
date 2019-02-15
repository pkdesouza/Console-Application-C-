using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static System.Text.Encoding;
using static System.Convert;
namespace Dominio.Utilidades
{

    public static class Cripitografia
    {
        private static string chave { get => "PKHOUSE"; }

        private static TripleDESCryptoServiceProvider tripleDesCryptoServiceProvider { get => new TripleDESCryptoServiceProvider(); }
        private static MD5CryptoServiceProvider mD5CryptoServiceProvider { get => new MD5CryptoServiceProvider(); }


        public static string Codificar(string entrada)
        {
            try
            {
                if (entrada.Trim() == "")
                    return "";
                tripleDesCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(UTF8.GetBytes(chave));
                tripleDesCryptoServiceProvider.Mode = CipherMode.ECB;
                ICryptoTransform desdencrypt = tripleDesCryptoServiceProvider.CreateEncryptor();
                byte[] buff = UTF8.GetBytes(entrada);

                return ToBase64String(buff, 0, buff.Length);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public static string Decodificar(string entrada)
        {
            try
            {
                if (String.IsNullOrEmpty(entrada?.Trim()))
                    return "";

                tripleDesCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(UTF8.GetBytes(chave));
                tripleDesCryptoServiceProvider.Mode = CipherMode.ECB;
                ICryptoTransform desdenCrypt = tripleDesCryptoServiceProvider.CreateDecryptor();
                byte[] buff = FromBase64String(entrada);

                return UTF8.GetString(buff, 0, buff.Length);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

