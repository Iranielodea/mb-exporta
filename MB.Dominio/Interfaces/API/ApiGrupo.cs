using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiGrupo
    {
        [Post("/api/grupo")]
        Task Salvar([Body] List<Grupo> grupos);

        [Delete("/api/grupo")]
        Task Excluir([Body] List<Grupo> grupos);

        [Get("/api/grupo")]
        Task<IEnumerable<Grupo>> Retornartodas();

        [Get("/api/grupo/{id}")]
        Task<Grupo> RetornarPorId(int id);
    }

    public class ApiGrupo
    {
        public async Task Salvar(List<Grupo> grupos)
        {
            var lista = RestService.For<IApiGrupo>(Constantes.URL);
            await lista.Salvar(grupos);
        }

        public async Task Excluir(List<Grupo> grupos)
        {
            var lista = RestService.For<IApiGrupo>(Constantes.URL);
            await lista.Excluir(grupos);
        }

        public IEnumerable<Grupo> RetornarGrupo()
        {
            var lista = RestService.For<IApiGrupo>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Grupo RetornarPorId(int id)
        {
            var lista = RestService.For<IApiGrupo>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
