using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontEstado
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoEstado.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoEstado.ExcluirNet(id);
        }
    }
}
