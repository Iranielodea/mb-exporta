using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiPedido
    {
        [Post("/api/pedido")]
        Task Salvar([Body] List<Pedido> pedidos);

        [Delete("/api/pedido")]
        Task Excluir([Body] List<Pedido> pedidos);

        [Get("/api/pedido")]
        Task<IEnumerable<Pedido>> Retornartodas();

        [Get("/api/pedido/{id}")]
        Task<Pedido> RetornarPorId(int id);
    }

    public class ApiPedido
    {
        public async Task Salvar(List<Pedido> pedidos)
        {
            var lista = RestService.For<IApiPedido>(Constantes.URL);
            await lista.Salvar(pedidos);
        }

        public async Task Excluir(List<Pedido> pedidos)
        {
            var lista = RestService.For<IApiPedido>(Constantes.URL);
            await lista.Excluir(pedidos);
        }

        public IEnumerable<Pedido> RetornarPedido()
        {
            var lista = RestService.For<IApiPedido>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Pedido RetornarPorId(int id)
        {
            var lista = RestService.For<IApiPedido>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
