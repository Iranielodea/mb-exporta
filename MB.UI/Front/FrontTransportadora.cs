using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontTransportadora
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoTransportadora.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoTransportadora.ExcluirNet(id);
        }
    }
}
