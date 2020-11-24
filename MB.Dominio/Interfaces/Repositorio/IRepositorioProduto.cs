using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioProduto : IRepositoryBase<Produto>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
