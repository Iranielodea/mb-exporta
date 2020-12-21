using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioClienteDapper : RepositoryBase<Cliente>, IRepositorioCliente
    {
        private readonly IUnitOfWork _uow;

        public RepositorioClienteDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Cliente entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE CLIENTE SET EXPORTAR_NET = 'N' WHERE Cod_Cliente = {id}";
            else
                instrucaoSQL = $"UPDATE CLIENTE SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Cliente> GetAll()
        {
            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Cliente(), "CLIENTE");
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" CLI.BAIRRO,");
            sb.AppendLine(" CLI.CEP,");
            sb.AppendLine(" EST.SIGLA AS UF,");
            sb.AppendLine(" CLI.CNPJ,");
            sb.AppendLine(" CLI.COD_CLIENTE,");
            sb.AppendLine(" CLI.COMPLEMENTO,");
            sb.AppendLine(" CLI.CPF,");
            sb.AppendLine(" CLI.DATA_CADASTRO,");
            sb.AppendLine(" CLI.EMAIL,");
            sb.AppendLine(" CLI.ENDERECO,");
            sb.AppendLine(" CLI.FANTASIA,");
            sb.AppendLine(" CLI.FAX,");
            sb.AppendLine(" CLI.FONE,");
            sb.AppendLine(" CLI.INSC_ESTADUAL,");
            sb.AppendLine(" CLI.NOME,");
            sb.AppendLine(" CID.DESC_CIDADE AS NOMECIDADE,");
            sb.AppendLine(" CLI.NUMERO,");
            sb.AppendLine(" CLI.OBS,");
            sb.AppendLine(" CLI.RG,");
            sb.AppendLine(" CLI.TIPO_PESSOA");

            sb.AppendLine(" FROM CLIENTE CLI");

            sb.AppendLine(" LEFT JOIN CIDADE CID ON CLI.COD_CIDADE = CID.COD_CIDADE");
            sb.AppendLine(" LEFT JOIN ESTADO EST ON CID.ID_ESTADO = EST.ID_ESTADO");
            sb.AppendLine(" WHERE CLI.EXPORTAR_NET = 'S'");
            

            return _uow.Connection.Query<Cliente>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Cliente entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Cliente entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Cliente > 0)
                instrucaoSQL = dados.Update(new Cliente(), "CLIENTE", "Cod_Cliente", entidade.Cod_Cliente);
            else
                instrucaoSQL = dados.Inserir(new Cliente(), "CLIENTE", "Cod_Cliente");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
