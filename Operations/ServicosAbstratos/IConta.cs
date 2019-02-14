using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ServicosAbstratos
{
    public interface IConta
    {
        Retorno DepositoConta(decimal valor);
        void RecuperarSaldo();
        void RecuperarExtrato();
        decimal ConsultarSaldo();
    }
}
