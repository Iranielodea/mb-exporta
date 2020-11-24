using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontCidade
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id=0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoCidade.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoCidade.ExcluirNet(id);
        }
    }
}
