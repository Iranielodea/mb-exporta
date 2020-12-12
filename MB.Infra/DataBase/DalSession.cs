using FirebirdSql.Data.FirebirdClient;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Servicos;
using MB.Dominio.Shared;
using MB.Infra.Repositorio;
using System;
using System.Data;

namespace MB.Infra.DataBase
{
    public sealed class DalSession : IDalSession, IDisposable
    {
        IDbConnection _connection = null;
        UnitOfWork _unitOfWork = null;
        private string connection = "";

        public DalSession()
        {
            //string conexaoSql = "Data Source=" + servidor + ";Initial Catalog=" + nomeBanco
            //    + ";User ID=" + usuario
            //    + ";Password=" + password;

            connection = RetornarStringConexao();
            _connection = new FbConnection(connection);
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }

        private string RetornarStringConexao()
        {
            if (!System.IO.File.Exists("Conexao.txt"))
                throw new Exception("Aquivo de Conexão não encontrado");

            connection = System.IO.File.ReadAllText("Conexao.txt");
            //connection = "User=SYSDBA;Password=masterkey;Database=C:\\Clientes\\MB\\loja.fdb;DataSource=localhost;" +
            //    "Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;Packet Size=8192;ServerType=0";
            return connection;
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }

        private IServicoCidade _servicoCidade;
        public IServicoCidade ServicoCidade => _servicoCidade = _servicoCidade ?? new ServicoCidade(new RepositorioCidadeDapper(_unitOfWork));
        //=====================================================================
        private IServicoEstado _servicoEstado;
        public IServicoEstado ServicoEstado => _servicoEstado = _servicoEstado ?? new ServicoEstado(new RepositorioEstadoDapper(_unitOfWork));
        //=====================================================================
        private IServicoEmpresa _servicoEmpresa;
        public IServicoEmpresa ServicoEmpresa => _servicoEmpresa = _servicoEmpresa ?? new ServicoEmpresa(new RepositorioEmpresaDapper(_unitOfWork));
        //=====================================================================
        private IServicoCliente _servicoCliente;
        public IServicoCliente ServicoCliente => _servicoCliente = _servicoCliente ?? new ServicoCliente(new RepositorioClienteDapper(_unitOfWork));
        //=====================================================================
        private IServicoFornecedor _servicoFornecedor;
        public IServicoFornecedor ServicoFornecedor => _servicoFornecedor = _servicoFornecedor ?? new ServicoFornecedor(new RepositorioFornecedorDapper(_unitOfWork));
        //=====================================================================
        private IServicoGrupo _servicoGrupo;
        public IServicoGrupo ServicoGrupo => _servicoGrupo = _servicoGrupo ?? new ServicoGrupo(new RepositorioGrupoDapper(_unitOfWork));
        //=====================================================================
        private IServicoPedido _servicoPedido;
        public IServicoPedido ServicoPedido => _servicoPedido = _servicoPedido ?? new ServicoPedido(new RepositorioPedidoDapper(_unitOfWork));
        //=====================================================================
        private IServicoProduto _servicoProduto;
        public IServicoProduto ServicoProduto => _servicoProduto = _servicoProduto ?? new ServicoProduto(new RepositorioProdutoDapper(_unitOfWork));
        //=====================================================================
        private IServicoTransportadora _servicoTransportadora;
        public IServicoTransportadora ServicoTransportadora => _servicoTransportadora = _servicoTransportadora ?? new ServicoTransportadora(new RepositorioTransportadoraDapper(_unitOfWork));
        //=====================================================================
        private IServicoUnidade _servicoUnidade;
        public IServicoUnidade ServicoUnidade => _servicoUnidade = _servicoUnidade ?? new ServicoUnidade(new RepositorioUnidadeDapper(_unitOfWork));
        //=====================================================================
        private IServicoVendedor _servicoVendedor;
        public IServicoVendedor ServicoVendedor => _servicoVendedor = _servicoVendedor ?? new ServicoVendedor(new RepositorioVendedorDapper(_unitOfWork));
        //=====================================================================
        private IServicoUsuario _servicoUsuario;
        public IServicoUsuario ServicoUsuario => _servicoUsuario = _servicoUsuario ?? new ServicoUsuario(new RepositorioUsuarioDapper(_unitOfWork));
        //=====================================================================
        private IServicoPedidoItem _servicoPedidoItem;
        public IServicoPedidoItem ServicoPedidoItem => _servicoPedidoItem = _servicoPedidoItem ?? new ServicoPedidoItem(new RepositorioPedidoItemDapper(_unitOfWork));
        //=====================================================================
        IUnitOfWork IDalSession.UnitOfWork => new UnitOfWork(_connection);
    }
}
