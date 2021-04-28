using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioFornecedorDapper : RepositoryBase<Fornecedor>, IRepositorioFornecedor
    {
        private readonly IUnitOfWork _uow;

        public RepositorioFornecedorDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Fornecedor entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE FORNECEDOR SET EXPORTAR_NET = 'N' WHERE Cod_For = {id}";
            else
                instrucaoSQL = $"UPDATE FORNECEDOR SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Fornecedor> GetAll()
        {
            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Fornecedor(), "FORNECEDOR");
            //return _uow.Connection.Query<Fornecedor>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" FO.COD_FOR,");
            sb.AppendLine(" FO.NOME,");
            sb.AppendLine(" FO.BAIRRO,");
            sb.AppendLine(" FO.ENDERECO,");
            sb.AppendLine(" FO.CEP,");
            sb.AppendLine(" FO.CNPJ,");
            sb.AppendLine(" FO.EMAIL,");
            sb.AppendLine(" FO.FAX,");
            sb.AppendLine(" FO.INSC_ESTADUAL,");
            sb.AppendLine(" CID.DESC_CIDADE AS NOMECIDADE,");
            sb.AppendLine(" FO.OBS,");
            sb.AppendLine(" EST.SIGLA AS UF,");
            sb.AppendLine(" FO.COMPLEMENTO,");
            sb.AppendLine(" FO.FANTASIA,");
            sb.AppendLine(" FO.FONE,");
            sb.AppendLine(" FO.NUMERO");
            
            //sb.AppendLine(" FO.NUM_BANCO,");
            //sb.AppendLine(" FO.NOME_BANCO,");
            //sb.AppendLine(" FO.NUM_AGENCIA,");
            //sb.AppendLine(" FO.NUM_CONTA,");
            //sb.AppendLine(" FO.NOME_TITULAR,");
            //sb.AppendLine(" FO.CPF,");
            //sb.AppendLine(" FO.NOME_DESPOSITANTE,");
            //sb.AppendLine(" FO.MARCAR,");
            //sb.AppendLine(" FO.ID_TIPO_EMPRESA");
            sb.AppendLine(" FROM FORNECEDOR FO");

            sb.AppendLine(" LEFT JOIN CIDADE CID ON FO.COD_CIDADE = CID.COD_CIDADE");
            sb.AppendLine(" LEFT JOIN ESTADO EST ON CID.ID_ESTADO = EST.ID_ESTADO");
            sb.AppendLine(" WHERE FO.EXPORTAR_NET = 'S'");

            return _uow.Connection.Query<Fornecedor>(sb.ToString(), null, _uow.Transaction).AsQueryable();

        }

        public override void Update(Fornecedor entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Fornecedor entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_For > 0)
                instrucaoSQL = dados.Update(new Fornecedor(), "FORNECEDOR", "Cod_For", entidade.Cod_For);
            else
                instrucaoSQL = dados.Inserir(new Fornecedor(), "FORNECEDOR", "Cod_For");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
