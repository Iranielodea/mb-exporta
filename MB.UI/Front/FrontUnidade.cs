using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontUnidade
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoUnidade.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoUnidade.ExcluirNet(id);
        }
    }
}
