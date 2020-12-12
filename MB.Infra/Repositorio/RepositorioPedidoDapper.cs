using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioPedidoDapper : RepositoryBase<Pedido>, IRepositorioPedido
    {
        private readonly IUnitOfWork _uow;

        public RepositorioPedidoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Pedido entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE PEDIDO SET EXPORTARNET = 'N' WHERE Num_Pedido = {id}";
            else
                instrucaoSQL = $"UPDATE PEDIDO SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Pedido> GetAll()
        {
            var sb = new StringBuilder();
            sb.AppendLine(RetornarSQL());
            sb.AppendLine(" WHERE EXPORTARNET = 'S'");

            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Pedido(), "PEDIDO");

            return _uow.Connection.Query<Pedido>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public IQueryable<Pedido> Filtrar(string dataInicial, string dataFinal)
        {
            var sb = new StringBuilder();

            sb.AppendLine(RetornarSQL());
            //sb.AppendLine(" SELECT");
            //sb.AppendLine(" PED.NUM_PEDIDO,");
            //sb.AppendLine(" PED.DATA,");
            //sb.AppendLine(" PED.TOTAL_BRUTO,");
            //sb.AppendLine(" PED.PERC_DESCONTO,");
            //sb.AppendLine(" PED.VALOR_DESCONTO,");
            //sb.AppendLine(" PED.TOTAL_LIQUIDO,");
            //sb.AppendLine(" PED.SITUACAO,");
            //sb.AppendLine(" FO.nome AS NOME_FORNECEDOR,");
            //sb.AppendLine(" CLI.nome AS NOME_CLIENTE, ");
            //sb.AppendLine(" PED.OBS,");
            //sb.AppendLine(" CON.nome AS NOME_CONTATO,");
            //sb.AppendLine(" PED.PERC_COMISSAO,");
            //sb.AppendLine(" PED.ENCERRADO,");
            //sb.AppendLine(" PED.TOTAL_VENDA,");
            //sb.AppendLine(" PED.TOTAL_LUCRO,");
            //sb.AppendLine(" PED.TOTAL_QTDE,");
            //sb.AppendLine(" PED.NUM_CARGA,");
            //sb.AppendLine(" PED.VALOR_LUCRO,");
            //sb.AppendLine(" VEN.nome AS NOME_VENDEDOR,");
            //sb.AppendLine(" PED.VALOR_COMISSAO,");
            //sb.AppendLine(" PED.TOTAL_COMISSAO,");
            //sb.AppendLine(" USI.NOME AS NOME_USINA");

            //sb.AppendLine(" FROM PEDIDO PED");
            //sb.AppendLine(" LEFT JOIN CLIENTE CLI ON PED.cod_cliente = CLI.cod_cliente");
            //sb.AppendLine(" LEFT JOIN FORNECEDOR FO ON PED.cod_for = FO.cod_for");
            //sb.AppendLine(" LEFT JOIN CLIENTE CON ON PED.cod_contato = CON.cod_cliente");
            //sb.AppendLine(" LEFT JOIN VENDEDOR VEN ON PED.cod_vendedor = VEN.cod_vendedor");
            //sb.AppendLine(" LEFT JOIN FORNECEDOR USI ON PED.cod_usina = USI.cod_For");
            sb.AppendLine($" WHERE PED.DATA BETWEEN '{dataInicial}' and '{dataFinal}'");

            return _uow.Connection.Query<Pedido>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        private string RetornarSQL()
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" PED.NUM_PEDIDO,");
            sb.AppendLine(" PED.DATA,");
            sb.AppendLine(" PED.TOTAL_BRUTO,");
            sb.AppendLine(" PED.PERC_DESCONTO,");
            sb.AppendLine(" PED.VALOR_DESCONTO,");
            sb.AppendLine(" PED.TOTAL_LIQUIDO,");
            sb.AppendLine(" PED.SITUACAO,");
            sb.AppendLine(" FO.nome AS NOME_FORNECEDOR,");
            sb.AppendLine(" CLI.nome AS NOME_CLIENTE, ");
            sb.AppendLine(" PED.OBS,");
            sb.AppendLine(" CON.nome AS NOME_CONTATO,");
            sb.AppendLine(" PED.PERC_COMISSAO,");
            sb.AppendLine(" PED.ENCERRADO,");
            sb.AppendLine(" PED.TOTAL_VENDA,");
            sb.AppendLine(" PED.TOTAL_LUCRO,");
            sb.AppendLine(" PED.TOTAL_QTDE,");
            sb.AppendLine(" PED.NUM_CARGA,");
            sb.AppendLine(" PED.VALOR_LUCRO,");
            sb.AppendLine(" VEN.nome AS NOME_VENDEDOR,");
            sb.AppendLine(" PED.VALOR_COMISSAO,");
            sb.AppendLine(" PED.TOTAL_COMISSAO,");
            sb.AppendLine(" USI.NOME AS NOME_USINA");

            sb.AppendLine(" FROM PEDIDO PED");
            sb.AppendLine(" LEFT JOIN CLIENTE CLI ON PED.cod_cliente = CLI.cod_cliente");
            sb.AppendLine(" LEFT JOIN FORNECEDOR FO ON PED.cod_for = FO.cod_for");
            sb.AppendLine(" LEFT JOIN CLIENTE CON ON PED.cod_contato = CON.cod_cliente");
            sb.AppendLine(" LEFT JOIN VENDEDOR VEN ON PED.cod_vendedor = VEN.cod_vendedor");
            sb.AppendLine(" LEFT JOIN FORNECEDOR USI ON PED.cod_usina = USI.cod_For");
            return sb.ToString();
        }

        public override void Update(Pedido entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Pedido entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Num_Pedido > 0)
                instrucaoSQL = dados.Update(new Pedido(), "PEDIDO", "Num_Pedido", entidade.Num_Pedido);
            else
                instrucaoSQL = dados.Inserir(new Pedido(), "PEDIDO", "Num_Pedido");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
