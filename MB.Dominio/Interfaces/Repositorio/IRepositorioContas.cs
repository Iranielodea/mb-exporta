using MB.Dominio.Entidades;
using System.Linq;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioContas : IRepositoryBase<Contas>
    {
        void AtualizarTabelaExportada(int id = 0);
        IQueryable<Contas> Filtrar(string dataInicial, string dataFinal);
    }
}
