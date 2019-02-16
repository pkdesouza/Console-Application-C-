using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apresentacao;
using System;
using static Dominio.Pagamento;
using static Dominio.Utilidades.Util;

namespace Dominio.Tests
{
    [TestClass()]
    public class PagamentoTests: BaseOperacao
    {
        [TestMethod()]
        public void RealizarDebitoTest()
        {
            try
            {
                con.RecuperarSaldo();
                var valor = Convert.ToDecimal(new Random().NextDouble());
                var r = pag.RealizarDebito(valor, ValorAleatorioEnum<OpcoesPagamento>());
                if (!r.Sucesso)
                    Assert.Fail(r.Mensagem);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}