using MB.Dominio.Entidades;
using System.Linq;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioPedidoItem : IRepositoryBase<PedidoItem>
    {
        void AtualizarTabelaExportada(int id = 0);
        IQueryable<PedidoItem> Filtrar(string dataInicial, string dataFinal);
    }
}
