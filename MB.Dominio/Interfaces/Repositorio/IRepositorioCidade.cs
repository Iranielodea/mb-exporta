using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioCidade : IRepositoryBase<Cidade>
    {
        void AtualizarTabelaExportada(int id = 0);
    }
}
