using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioVendedorDapper : RepositoryBase<Vendedor>, IRepositorioVendedor
    {
        private readonly IUnitOfWork _uow;

        public RepositorioVendedorDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Vendedor entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE VENDEDOR SET EXPORTARNET = 'N' WHERE Cod_Vendedor = {id}";
            else
                instrucaoSQL = $"UPDATE VENDEDOR SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Vendedor> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Vendedor(), "VENDEDOR");
            return _uow.Connection.Query<Vendedor>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Vendedor entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Vendedor entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Vendedor > 0)
                instrucaoSQL = dados.Update(new Vendedor(), "VENDEDOR", "Cod_Vendedor", entidade.Cod_Vendedor);
            else
                instrucaoSQL = dados.Inserir(new Vendedor(), "VENDEDOR", "Cod_Vendedor");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
