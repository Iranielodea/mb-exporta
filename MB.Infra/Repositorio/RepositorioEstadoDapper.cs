using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioEstadoDapper : RepositoryBase<Estado>, IRepositorioEstado
    {
        private readonly IUnitOfWork _uow;

        public RepositorioEstadoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Estado entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE ESTADO SET EXPORTARNET = 'N' WHERE ID_Estado = {id}";
            else
                instrucaoSQL = $"UPDATE ESTADO SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Estado> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Estado(), "ESTADO");
            return _uow.Connection.Query<Estado>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Estado entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Estado entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Id_Estado > 0)
                instrucaoSQL = dados.Update(new Estado(), "ESTADO", "ID_Estado", entidade.Id_Estado);
            else
                instrucaoSQL = dados.Inserir(new Estado(), "ESTADO", "ID_Estado");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
