using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioTransportadoraDapper : RepositoryBase<Transportadora>, IRepositorioTransportadora
    {
        private readonly IUnitOfWork _uow;

        public RepositorioTransportadoraDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Transportadora entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE TRANSPORTADORA SET EXPORTARNET = 'N' WHERE Cod_Trans = {id}";
            else
                instrucaoSQL = $"UPDATE TRANSPORTADORA SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Transportadora> GetAll()
        {
            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Transportadora(), "TRANSPORTADORA");
            var sb = new StringBuilder();

            sb.AppendLine("SELECT");
            sb.AppendLine(" TRA.BAIRRO,");
            sb.AppendLine(" TRA.CEP,");
            sb.AppendLine(" TRA.CNPJ,");
            sb.AppendLine(" TRA.COD_TRANS,");
            sb.AppendLine(" TRA.CPF_TRANSP,");
            sb.AppendLine(" TRA.EMAIL,");
            sb.AppendLine(" TRA.ENDERECO,");
            sb.AppendLine(" TRA.FAX,");
            sb.AppendLine(" TRA.FONE1,");
            sb.AppendLine(" TRA.FONE2,");
            sb.AppendLine(" TRA.INSC_ESTADUAL,");
            sb.AppendLine(" TRA.NOME,");
            sb.AppendLine(" CID.DESC_CIDADE,");
            sb.AppendLine(" EST.SIGLA AS UF,");
            sb.AppendLine(" TRA.OBS,");
            sb.AppendLine(" TRA.DDD,");
            sb.AppendLine(" TRA.CONTATO,");
            sb.AppendLine(" TRA.NUM_BANCO,");
            sb.AppendLine(" TRA.NOME_BANCO,");
            sb.AppendLine(" TRA.NUM_AGENCIA,");
            sb.AppendLine(" TRA.NUM_CONTA,");
            sb.AppendLine(" TRA.NOME_TITULAR");
            sb.AppendLine(" FROM TRANSPORTADOR TRA");
            sb.AppendLine(" LEFT JOIN CIDADE CID ON TRA.COD_CIDADE = CID.COD_CIDADE");
            sb.AppendLine(" LEFT JOIN ESTADO EST ON CID.ID_ESTADO = EST.ID_ESTADO");

            return _uow.Connection.Query<Transportadora>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Transportadora entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Transportadora entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Trans > 0)
                instrucaoSQL = dados.Update(new Transportadora(), "TRANSPORTADOR", "Cod_Trans", entidade.Cod_Trans);
            else
                instrucaoSQL = dados.Inserir(new Transportadora(), "TRANSPORTADOR", "Cod_Trans");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
