using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Servico
{
    public interface IServicoContas : IServiceBase<Contas>
    {
        void Exportar(string dataInicial, string dataFinal);
    }
}
