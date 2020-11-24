using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioVendedor : IRepositoryBase<Vendedor>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
