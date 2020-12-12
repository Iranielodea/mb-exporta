﻿using MB.Dominio.Entidades;

namespace MB.Dominio.Interfaces.Servico
{
    public interface IServicoPedido : IServiceBase<Pedido>
    {
        void Exportar(string dataInicial, string dataFinal);
    }
}
