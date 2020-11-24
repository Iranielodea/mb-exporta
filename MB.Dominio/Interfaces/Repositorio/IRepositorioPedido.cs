using MB.Dominio.Entidades;
using System.Linq;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioPedido : IRepositoryBase<Pedido>
    {
        void AtualizarTabelaExportada(int id = 0);
        IQueryable<Pedido> Filtrar(string dataInicial, string dataFinal);
    }
}
