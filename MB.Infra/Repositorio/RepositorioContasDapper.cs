using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioContasDapper : RepositoryBase<Contas>, IRepositorioContas
    {
        private readonly IUnitOfWork _uow;

        public RepositorioContasDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Contas entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE CONTAS SET EXPORTAR_NET = 'N' WHERE Id_Conta = {id}";
            else
                instrucaoSQL = $"UPDATE CONTAS SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Contas> GetAll()
        {
            var sb = new StringBuilder();
            sb.AppendLine(RetornarSQL());
            sb.AppendLine(" WHERE CON.EXPORTAR_NET = 'S'");

            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Pedido(), "PEDIDO");

            return _uow.Connection.Query<Contas>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public IQueryable<Contas> Filtrar(string dataInicial, string dataFinal)
        {
            var sb = new StringBuilder();

            sb.AppendLine(RetornarSQL());
            sb.AppendLine($" WHERE CON.DATA_EMISSAO BETWEEN '{dataInicial}' and '{dataFinal}'");
            //sb.AppendLine(" WHERE CON.ID_CONTA = 6811");

            return _uow.Connection.Query<Contas>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        private string RetornarSQL()
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" CON.ID_CONTA,");
            sb.AppendLine(" CON.NUM_PEDIDO,");
            sb.AppendLine(" CLI.nome AS NOME_CLIENTE, ");
            sb.AppendLine(" FO.nome AS NOME_FORNECEDOR,");
            sb.AppendLine(" CON.DATA_EMISSAO,");
            sb.AppendLine(" CON.VALOR_PAGAR,");
            sb.AppendLine(" CON.DATA_VENCTO,");
            sb.AppendLine(" CON.DIAS,");
            sb.AppendLine(" CON.DATA_PAGO,");
            sb.AppendLine(" CON.VALOR_PAGO,");
            sb.AppendLine(" CON.SEQ_CONTA,");
            sb.AppendLine(" CON.VALOR_ORIGINAL,");
            sb.AppendLine(" CON.TIPO_CONTA,");
            sb.AppendLine(" CON.SITUACAO,");
            sb.AppendLine(" CON.DOCUMENTO,");
            sb.AppendLine(" PAGTO.DESC_PAGTO,");
            sb.AppendLine(" CON.ID_CONTABANCO,");
            sb.AppendLine(" CON.ID_PEDIDO,");
            sb.AppendLine(" CON.COD_CLIENTE,");
            sb.AppendLine(" CON.COD_FOR");

            sb.AppendLine(" FROM CONTAS CON");
            sb.AppendLine(" LEFT JOIN CLIENTE CLI ON CON.cod_cliente = CLI.cod_cliente");
            sb.AppendLine(" LEFT JOIN FORNECEDOR FO ON CON.cod_for = FO.cod_for");
            sb.AppendLine(" LEFT JOIN FORMA_PAGTO PAGTO ON CON.cod_pagto = PAGTO.cod_pagto");
            return sb.ToString();
        }

        public override void Update(Contas entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Contas entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Num_Pedido > 0)
                instrucaoSQL = dados.Update(new Contas(), "CONTAS", "Id_Conta", entidade.id_conta);
            else
                instrucaoSQL = dados.Inserir(new Contas(), "CONTAS", "Id_Conta");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
