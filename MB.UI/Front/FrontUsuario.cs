using MB.Dominio.Servicos;
using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontUsuario
    {
        public void Exportar(IDalSession session, EnAcao enAcao, int id = 0)
        {
            try
            {
                if (enAcao == EnAcao.EXPORTAR)
                    session.ServicoUsuario.ExportNetAsync();
                if (enAcao == EnAcao.EXCLUIR)
                    session.ServicoUsuario.ExcluirNet(id);
            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }
        }
    }
}
