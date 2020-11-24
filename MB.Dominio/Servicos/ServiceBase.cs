using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T entidade)
        {
            _repositoryBase.Add(entidade);
        }

        public void Delete(T entidade)
        {
            _repositoryBase.Delete(entidade);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public virtual void ExcluirNet(IEnumerable<T> entidade)
        {
            //throw new NotImplementedException();
        }

        public virtual void ExcluirNet(int id)
        {
            //throw new NotImplementedException();
        }

        public virtual void ExportNetAsync()
        {
            //
        }

        public IQueryable<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public T GetId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
