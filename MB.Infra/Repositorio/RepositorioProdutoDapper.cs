using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioProdutoDapper : RepositoryBase<Produto>, IRepositorioProduto
    {
        private readonly IUnitOfWork _uow;

        public RepositorioProdutoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Produto entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE PRODUTO SET EXPORTARNET = 'N' WHERE Cod_Produto = {id}";
            else
                instrucaoSQL = $"UPDATE PRODUTO SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Produto> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Produto(), "PRODUTO");
            return _uow.Connection.Query<Produto>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Produto entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Produto entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Produto > 0)
                instrucaoSQL = dados.Update(new Produto(), "PRODUTO", "Cod_Produto", entidade.Cod_Produto);
            else
                instrucaoSQL = dados.Inserir(new Produto(), "PRODUTO", "Cod_Produto");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
