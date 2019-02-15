using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apresentacao;
using System;

namespace Dominio.Tests
{
    [TestClass()]
    public class ContaTests : BaseOperacao
    {
        [TestMethod()]
        public void RecuperarExtratoTest()
        {
            try
            {
                con.RecuperarExtrato();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void RecuperarSaldoTest()
        {
            try
            {
                con.RecuperarSaldo();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void DepositoContaTest()
        {
            try
            {
                con.RecuperarSaldo();
                Retorno r = con.DepositoConta(Convert.ToDecimal(new Random().NextDouble()));
                if (!r.Sucesso)
                    Assert.Fail(r.Mensagem);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod()]
        public void ConsultarSaldoTest()
        {
            try
            {
                con.RecuperarSaldo();
                decimal saldo = con.ConsultarSaldo();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}