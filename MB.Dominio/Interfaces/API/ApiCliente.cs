using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiCliente
    {
        [Post("/api/cliente")]
        Task Salvar([Body] List<Cliente> clientes);

        [Delete("/api/cliente/")]
        Task Excluir([Body] List<Cliente> clientes);

        [Get("/api/cliente")]
        Task<IEnumerable<Cliente>> Retornartodas();

        [Get("/api/cliente/{id}")]
        Task<Cliente> RetornarPorId(int id);
    }

    public class ApiCliente
    {
        public async Task Salvar(List<Cliente> clientes)
        {
            var lista = RestService.For<IApiCliente>(Constantes.URL);
            await lista.Salvar(clientes);
        }

        public async Task Excluir(List<Cliente> clientes)
        {
            var lista = RestService.For<IApiCliente>(Constantes.URL);
            await lista.Excluir(clientes);
        }

        public IEnumerable<Cliente> RetornarCliente()
        {
            var lista = RestService.For<IApiCliente>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Cliente RetornarPorId(int id)
        {
            var lista = RestService.For<IApiCliente>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
