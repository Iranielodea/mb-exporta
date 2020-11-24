using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiProduto
    {
        [Post("/api/produto")]
        Task Salvar([Body] List<Produto> produtos);

        [Delete("/api/produto")]
        Task Excluir([Body] List<Produto> produtos);

        [Get("/api/produto")]
        Task<IEnumerable<Produto>> Retornartodas();

        [Get("/api/produto/{id}")]
        Task<Produto> RetornarPorId(int id);
    }

    public class ApiProduto
    {
        public async Task Salvar(List<Produto> produtos)
        {
            var lista = RestService.For<IApiProduto>(Constantes.URL);
            await lista.Salvar(produtos);
        }

        public async Task Excluir(List<Produto> produtos)
        {
            var lista = RestService.For<IApiProduto>(Constantes.URL);
            await lista.Excluir(produtos);
        }

        public IEnumerable<Produto> RetornarProduto()
        {
            var lista = RestService.For<IApiProduto>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Produto RetornarPorId(int id)
        {
            var lista = RestService.For<IApiProduto>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
