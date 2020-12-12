using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Servico
{
    public interface IServicoPedidoItem : IServiceBase<PedidoItem>
    {
        void Exportar(string dataInicial, string dataFinal);
    }
}
