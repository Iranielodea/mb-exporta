using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontCliente
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id=0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoCliente.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoCliente.ExcluirNet(id);
        }
    }
}
