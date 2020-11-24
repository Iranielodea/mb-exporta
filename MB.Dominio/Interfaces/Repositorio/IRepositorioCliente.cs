using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioCliente : IRepositoryBase<Cliente>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
