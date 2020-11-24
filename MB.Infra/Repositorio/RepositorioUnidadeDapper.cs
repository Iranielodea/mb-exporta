using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioUnidadeDapper : RepositoryBase<Unidade>, IRepositorioUnidade
    {
        private readonly IUnitOfWork _uow;

        public RepositorioUnidadeDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Unidade entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE UNIDADE SET EXPORTARNET = 'N' WHERE Id_Unidade = {id}";
            else
                instrucaoSQL = $"UPDATE UNIDADE SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Unidade> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Unidade(), "UNIDADE");
            return _uow.Connection.Query<Unidade>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Unidade entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Unidade entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Id_Unidade > 0)
                instrucaoSQL = dados.Update(new Unidade(), "UNIDADE", "Id_Unidade", entidade.Id_Unidade);
            else
                instrucaoSQL = dados.Inserir(new Unidade(), "UNIDADE", "Id_Unidade");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
