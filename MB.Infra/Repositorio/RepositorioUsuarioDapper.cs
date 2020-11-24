using System.Linq;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioUsuarioDapper : RepositoryBase<Usuario>, IRepositorioUsuario
    {
        private readonly IUnitOfWork _uow;

        public RepositorioUsuarioDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Usuario entidade)
        {
            //Salvar(entidade);
        }

        public void AtualizarTabelaExportada(string userName = "")
        {
            string instrucaoSQL = "";
            if (!string.IsNullOrWhiteSpace(userName))
                instrucaoSQL = $"UPDATE CAD_USUARIO SET EXPORTARNET = 'N' WHERE NOME = {userName}";
            else
                instrucaoSQL = $"UPDATE CAD_USUARIO SET EXPORTARNET = 'N' WHERE EXPORTARNET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Usuario> GetAll()
        {
            var dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = dados.Select(new Usuario(), "CAD_USUARIO");
            return _uow.Connection.Query<Usuario>(instrucaoSQL, null, _uow.Transaction).AsQueryable();
        }

        public override void Update(Usuario entidade)
        {
            //Salvar(entidade);
        }

        //private void Salvar(Usuario entidade)
        //{
        //    string instrucaoSQL = "";
        //    var dados = new PersistenciaFactory().Instanciar();
        //    if (entidade.Cod_Usuario > 0)
        //        instrucaoSQL = dados.Update(new Usuario(), "GRUPO", "Cod_Usuario", entidade.Cod_Usuario);
        //    else
        //        instrucaoSQL = dados.Inserir(new Usuario(), "GRUPO", "Cod_Usuario");
        //    _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        //}
    }
}
