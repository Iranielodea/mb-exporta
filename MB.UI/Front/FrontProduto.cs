using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontProduto
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoProduto.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoProduto.ExcluirNet(id);
        }
    }
}
