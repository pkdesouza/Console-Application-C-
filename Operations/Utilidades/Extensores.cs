using System;
using System.Collections.Generic;

namespace Dominio.Utilidades
{
    public static class Extensores
    {
        public static string ValorReal(this string s) => s.Replace(".", ",");

        public static string RemoverReal(this string s) => s.Replace("R$", "");

        public static List<string> Lista(this string[] s)
        {
            var ls = new List<string>();
			ls.AddRange(s);
            return ls;
        }
    }
}
