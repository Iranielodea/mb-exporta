using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioFornecedor : IRepositoryBase<Fornecedor>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
