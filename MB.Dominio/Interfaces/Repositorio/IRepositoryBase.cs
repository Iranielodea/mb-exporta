using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Interfaces.Repositorio
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetId(int id);
        IQueryable<T> GetAll();
        void Add(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        void Dispose();
    }
}
