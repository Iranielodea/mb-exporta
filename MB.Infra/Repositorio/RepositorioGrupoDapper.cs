using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioGrupoDapper : RepositoryBase<Grupo>, IRepositorioGrupo
    {
        private readonly IUnitOfWork _uow;

        public RepositorioGrupoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Grupo entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE GRUPO SET EXPORTARNET = 'N' WHERE Cod_Grupo = {id}";
            else
                instrucaoSQL = $"UPDATE GRUPO SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Grupo> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Grupo(), "GRUPO");
            return _uow.Connection.Query<Grupo>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Grupo entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Grupo entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Grupo > 0)
                instrucaoSQL = dados.Update(new Grupo(), "GRUPO", "Cod_Grupo", entidade.Cod_Grupo);
            else
                instrucaoSQL = dados.Inserir(new Grupo(), "GRUPO", "Cod_Grupo");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
