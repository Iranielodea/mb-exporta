using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiVendedor
    {
        [Post("/api/vendedor")]
        Task Salvar([Body] List<Vendedor> vendedors);

        [Delete("/api/vendedor")]
        Task Excluir([Body] List<Vendedor> vendedors);

        [Get("/api/vendedor")]
        Task<IEnumerable<Vendedor>> Retornartodas();

        [Get("/api/vendedor/{id}")]
        Task<Vendedor> RetornarPorId(int id);
    }

    public class ApiVendedor
    {
        public async Task Salvar(List<Vendedor> vendedors)
        {
            var lista = RestService.For<IApiVendedor>(Constantes.URL);
            await lista.Salvar(vendedors);
        }

        public async Task Excluir(List<Vendedor> vendedors)
        {
            var lista = RestService.For<IApiVendedor>(Constantes.URL);
            await lista.Excluir(vendedors);
        }

        public IEnumerable<Vendedor> RetornarVendedor()
        {
            var lista = RestService.For<IApiVendedor>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Vendedor RetornarPorId(int id)
        {
            var lista = RestService.For<IApiVendedor>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
