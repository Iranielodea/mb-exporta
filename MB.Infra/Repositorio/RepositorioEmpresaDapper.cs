using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioEmpresaDapper : RepositoryBase<Empresa>, IRepositorioEmpresa
    {
        private readonly IUnitOfWork _uow;

        public RepositorioEmpresaDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Empresa entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE EMPRESA SET EXPORTARNET = 'N' WHERE Cod_Empresa = {id}";
            else
                instrucaoSQL = $"UPDATE EMPRESA SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Empresa> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Empresa(), "EMPRESA");
            return _uow.Connection.Query<Empresa>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Empresa entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Empresa entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Empresa > 0)
                instrucaoSQL = dados.Update(new Empresa(), "EMPRESA", "Cod_Empresa", entidade.Cod_Empresa);
            else
                instrucaoSQL = dados.Inserir(new Empresa(), "EMPRESA", "Cod_Empresa");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
