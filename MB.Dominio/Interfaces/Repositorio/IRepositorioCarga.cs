using MB.Dominio.Entidades;
using System.Linq;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioCarga : IRepositoryBase<Carga>
    {
        void AtualizarTabelaExportada(int id = 0);
        IQueryable<Carga> Filtrar(string dataInicial, string dataFinal);
    }
}
