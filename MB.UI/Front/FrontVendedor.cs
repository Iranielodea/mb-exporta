using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontVendedor
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoVendedor.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoVendedor.ExcluirNet(id);
        }
    }
}
