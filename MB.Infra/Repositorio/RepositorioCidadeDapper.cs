using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioCidadeDapper : RepositoryBase<Cidade>, IRepositorioCidade
    {
        private readonly IUnitOfWork _uow;

        public RepositorioCidadeDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Cidade entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE CIDADE SET EXPORTARNET = 'N' WHERE Cod_Cidade = {id}";
            else
                instrucaoSQL = $"UPDATE CIDADE SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Cidade> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Cidade(), "CIDADE");
            return _uow.Connection.Query<Cidade>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Cidade entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Cidade entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Cod_Cidade > 0)
                instrucaoSQL = dados.Update(new Cidade(), "CIDADE", "Cod_Cidade", entidade.Cod_Cidade);
            else
                instrucaoSQL = dados.Inserir(new Cidade(), "CIDADE", "Cod_Cidade");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
