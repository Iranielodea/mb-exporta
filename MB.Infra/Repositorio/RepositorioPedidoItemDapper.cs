using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioPedidoItemDapper : RepositoryBase<PedidoItem>, IRepositorioPedidoItem
    {
        private readonly IUnitOfWork _uow;

        public RepositorioPedidoItemDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(PedidoItem entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE PEDIDO SET EXPORTAR_NET = 'N' WHERE Num_Pedido = {id}";
            else
                instrucaoSQL = $"UPDATE PEDIDO SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<PedidoItem> GetAll()
        {
            var sb = new StringBuilder();
            sb.AppendLine(RetornarSQL());

            sb.AppendLine(" WHERE PED.EXPORTAR_NET = 'S'");

            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new PedidoItem(), "ITENS_PEDIDO");

            return _uow.Connection.Query<PedidoItem>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public IQueryable<PedidoItem> Filtrar(string dataInicial, string dataFinal)
        {
            var sb = new StringBuilder();
            sb.AppendLine(RetornarSQL());
            sb.AppendLine($" WHERE PED.DATA BETWEEN '{dataInicial}' and '{dataFinal}'");

            return _uow.Connection.Query<PedidoItem>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        private string RetornarSQL()
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" ITE.cod_produto,");
            sb.AppendLine(" PRO.desc_produto,");
            sb.AppendLine(" ITE.num_pedido,");
            sb.AppendLine(" ITE.seq,");
            sb.AppendLine(" ITE.qtde,");
            sb.AppendLine(" ITE.valor,");
            sb.AppendLine(" ITE.valor_total,");
            sb.AppendLine(" UNI.sigla,");
            sb.AppendLine(" ITE.preco_venda, ");
            sb.AppendLine(" ITE.valor_lucro,");
            sb.AppendLine(" ITE.total_lucro,");
            sb.AppendLine(" ITE.total_venda");

            sb.AppendLine(" FROM PEDIDO PED");
            sb.AppendLine(" INNER JOIN ITENS_PEDIDO ITE ON PED.num_pedido = ITE.num_pedido");
            sb.AppendLine(" INNER JOIN PRODUTO PRO ON ITE.cod_produto = PRO.cod_produto");
            sb.AppendLine(" LEFT JOIN UNIDADE UNI ON ITE.id_unidade = UNI.id_unidade");
            return sb.ToString();
        }

        public override void Update(PedidoItem entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(PedidoItem entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Num_Pedido > 0)
                instrucaoSQL = dados.Update(new Pedido(), "ITENS_PEDIDO", "Num_Pedido", entidade.Num_Pedido);
            else
                instrucaoSQL = dados.Inserir(new Pedido(), "ITENS_PEDIDO", "Num_Pedido");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
