using MB.Dominio.Interfaces.Servico;

namespace MB.Dominio.Shared
{
    public interface IDalSession
    {
        IUnitOfWork UnitOfWork { get; }
        IServicoCidade ServicoCidade { get; }
        IServicoEstado ServicoEstado { get; }
        IServicoEmpresa ServicoEmpresa { get; }
        IServicoCliente ServicoCliente { get; }
        IServicoFornecedor ServicoFornecedor { get; }
        IServicoGrupo ServicoGrupo { get; }
        IServicoPedido ServicoPedido { get; }
        IServicoProduto ServicoProduto { get; }
        IServicoTransportadora ServicoTransportadora { get; }
        IServicoUnidade ServicoUnidade { get; }
        IServicoVendedor ServicoVendedor { get; }
        IServicoUsuario ServicoUsuario { get; }

        void Dispose();
    }
}
