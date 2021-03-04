using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontCarga
    {
        public void Exportar(IDalSession session, EnAcao enAcao, string dataInicial, string dataFinal, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoCarga.Exportar(dataInicial, dataFinal, id);
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoCarga.ExcluirNet(id);
        }
    }
}
