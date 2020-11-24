using System.Linq;
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
                instrucaoSQL = $"UPDATE FORNECEDOR SET EXPORTARNET = 'N' WHERE Cod_For = {id}";
            else
                instrucaoSQL = $"UPDATE FORNECEDOR SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Fornecedor> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Fornecedor(), "FORNECEDOR");
            return _uow.Connection.Query<Fornecedor>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
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
