using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioUnidade : IRepositoryBase<Unidade>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
