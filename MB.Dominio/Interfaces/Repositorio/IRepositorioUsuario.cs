using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioUsuario : IRepositoryBase<Usuario>
    {
        void AtualizarTabelaExportada(string userName = "");
    }
}
