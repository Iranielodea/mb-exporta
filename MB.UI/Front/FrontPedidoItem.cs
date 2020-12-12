using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontPedidoItem
    {
        public void Exportar(IDalSession session, EnAcao enAcao, string dataInicial, string dataFinal, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoPedidoItem.Exportar(dataInicial, dataFinal);
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoPedidoItem.ExcluirNet(id);
        }
    }
}
