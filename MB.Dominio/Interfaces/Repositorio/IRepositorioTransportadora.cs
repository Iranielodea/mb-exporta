using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioTransportadora : IRepositoryBase<Transportadora>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
