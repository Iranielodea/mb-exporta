using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioContaBancoDapper : RepositoryBase<ContaBanco>, IRepositorioContaBanco
    {
        private readonly IUnitOfWork _uow;

        public RepositorioContaBancoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(ContaBanco entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE CONTABANCO SET EXPORTAR_NET = 'N' WHERE id_ContaBanco = {id}";
            else
                instrucaoSQL = $"UPDATE CONTABANCO SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<ContaBanco> GetAll()
        {
            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new ContaBanco(), "CONTABANCO");

            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine(" Id_CONTABANCO,");
            sb.AppendLine(" NUM_CONTA,");
            sb.AppendLine(" AGENCIA,");
            sb.AppendLine(" BANCO,");
            sb.AppendLine(" ATIVO,");
            sb.AppendLine(" CNPJ_CPF");
            sb.AppendLine(" FROM CONTABANCO");

            return _uow.Connection.Query<ContaBanco>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public override void Update(ContaBanco entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(ContaBanco entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.id_ContaBanco > 0)
                instrucaoSQL = dados.Update(new ContaBanco(), "CONTABANCO", "id_ContaBanco", entidade.id_ContaBanco);
            else
                instrucaoSQL = dados.Inserir(new ContaBanco(), "CONTABANCO", "id_ContaBanco");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
