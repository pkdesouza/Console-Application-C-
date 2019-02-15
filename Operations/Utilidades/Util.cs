using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Utilidades
{
    public static class Util
    {
        public static T ValorAleatorioEnum<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }
        public static decimal ValorAleatorioDecimal() => Convert.ToDecimal(new Random().NextDouble());        
    }
}
