using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioEstado : IRepositoryBase<Estado>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
