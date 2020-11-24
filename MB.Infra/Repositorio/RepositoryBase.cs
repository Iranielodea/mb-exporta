using Dommel;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using System.Linq;

namespace MB.Infra.Repositorio
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _uow;
        public RepositoryBase(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public virtual void Add(TEntity entidade)
        {
            _uow.Connection.Insert(entidade, _uow.Transaction);
        }

        public virtual void Update(TEntity entidade)
        {
            _uow.Connection.Update(entidade, _uow.Transaction);
        }

        public void Delete(TEntity entidade)
        {
            _uow.Connection.Delete(entidade, _uow.Transaction);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public virtual TEntity GetId(int id)
        {
            return _uow.Connection.Get<TEntity>(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _uow.Connection.GetAll<TEntity>().AsQueryable();
        }

        public void RollBack()
        {
            _uow.Rollback();
        }

        protected string SequencialFB(string generator)
        {
            return "SELECT GEN_ID(" + generator + ", 0) FROM RDB$DATABASE";
        }
    }
}
