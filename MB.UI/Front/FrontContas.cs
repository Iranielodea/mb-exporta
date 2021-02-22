﻿using MB.Dominio.Shared;
using MB.UI.Enumerador;

namespace MB.UI.Front
{
    public class FrontContas
    {
        public void Exportar(IDalSession session, EnAcao enAcao, string dataInicial, string dataFinal, int id = 0)
        {
            if (enAcao == EnAcao.EXPORTAR)
                session.ServicoContas.Exportar(dataInicial, dataFinal);

            if (enAcao == EnAcao.EXCLUIR)
                session.ServicoContas.ExcluirNet(id);
        }
    }
}
