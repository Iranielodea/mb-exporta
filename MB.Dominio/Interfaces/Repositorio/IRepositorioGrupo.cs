using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioGrupo : IRepositoryBase<Grupo>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
