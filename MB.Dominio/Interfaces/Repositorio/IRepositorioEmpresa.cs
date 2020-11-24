using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioEmpresa : IRepositoryBase<Empresa>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
