using static Dominio.Pagamento;
namespace Dominio.ServicosAbstratos
{
    public interface IPagamento
    {
        Retorno RealizarDebito(decimal valor, OpcoesPagamento opcaoPagamento);
    }
}
