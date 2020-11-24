using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontEmpresa
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id=0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoEmpresa.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoEmpresa.ExcluirNet(id);
        }
    }
}
