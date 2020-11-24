using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Interfaces.Servico
{
    public interface IServiceBase<T> where T : class
    {
        T GetId(int id);
        IQueryable<T> GetAll();
        void Add(T entidade);
        void Update(T entidade);
        void Delete(T entidade);
        void ExportNetAsync();
        void ExcluirNet(IEnumerable<T> entidade);
        void ExcluirNet(int id);
        void Dispose();
    }
}
