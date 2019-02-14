using System;
using System.Collections.Generic;

namespace Dominio
{
    public static class Extensores
    {
        public static string ValorReal(this string s) => s.Replace(".", ",");

        public static List<string> Lista(this string[] s)
        {
            List<string> ls = new List<string>();
            ls.AddRange(s);
            return ls;
        }
    }
}
