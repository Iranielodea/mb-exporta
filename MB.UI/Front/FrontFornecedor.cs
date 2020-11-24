using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontFornecedor
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id=0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoFornecedor.ExportNetAsync();
            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoFornecedor.ExcluirNet(id);
        }
    }
}
