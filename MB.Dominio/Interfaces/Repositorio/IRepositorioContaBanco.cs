using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioContaBanco : IRepositoryBase<ContaBanco>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
