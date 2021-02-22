using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontContaBanco
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoContaBanco.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoContaBanco.ExcluirNet(id);
        }
    }
}
