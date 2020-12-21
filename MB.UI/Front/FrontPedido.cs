using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontPedido
    {
        public void Exportar(IDalSession session, EnAcao enAcao, string dataInicial, string dataFinal, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
            {
                session.ServicoPedido.Exportar(dataInicial, dataFinal);
                session.ServicoPedidoItem.Exportar(dataInicial, dataFinal);
            }

            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoPedido.ExcluirNet(id);
        }
    }
}
