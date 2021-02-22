using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Servico
{
    public interface IServicoCarga : IServiceBase<Carga>
    {
        void Exportar(string dataInicial, string dataFinal);
    }
}
