using Dominio;
using Dominio.ServicosAbstratos;

namespace Apresentacao
{
    public abstract class BaseOperacao
    {
        public static readonly IPagamento pag = new Pagamento();
        public static readonly IConta con = new Conta();
        public static readonly Framework operacao = new Framework();
    }
}
