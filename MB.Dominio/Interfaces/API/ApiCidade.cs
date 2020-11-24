using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiCidade
    {
        [Post("/api/cidade")]
        Task Salvar([Body] List<Cidade> cidades);

        [Delete("/api/cidade")]
        Task Excluir([Body] List<Cidade> cidades);

        [Get("/api/cidade")]
        Task<IEnumerable<Cidade>> Retornartodas();

        [Get("/api/cidade/{id}")]
        Task<Cidade> RetornarPorId(int id);
    }

    public class ApiCidade
    {
        public async Task Salvar(List<Cidade> cidades)
        {
            var lista = RestService.For<IApiCidade>(Constantes.URL);
            await lista.Salvar(cidades);
        }

        public async Task Excluir(List<Cidade> cidades)
        {
            var lista = RestService.For<IApiCidade>(Constantes.URL);
            await lista.Excluir(cidades);
        }

        public IEnumerable<Cidade> RetornarCidade()
        {
            var lista = RestService.For<IApiCidade>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Cidade RetornarPorId(int id)
        {
            var lista = RestService.For<IApiCidade>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
