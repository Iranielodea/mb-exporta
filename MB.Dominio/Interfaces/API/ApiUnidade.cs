using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiUnidade
    {
        [Post("/api/unidade")]
        Task Salvar([Body] List<Unidade> unidades);

        [Delete("/api/unidade")]
        Task Excluir([Body] List<Unidade> unidades);

        [Get("/api/unidade")]
        Task<IEnumerable<Unidade>> Retornartodas();

        [Get("/api/unidade/{id}")]
        Task<Unidade> RetornarPorId(int id);
    }

    public class ApiUnidade
    {
        public async Task Salvar(List<Unidade> unidades)
        {
            var lista = RestService.For<IApiUnidade>(Constantes.URL);
            await lista.Salvar(unidades);
        }

        public async Task Excluir(List<Unidade> unidades)
        {
            var lista = RestService.For<IApiUnidade>(Constantes.URL);
            await lista.Excluir(unidades);
        }

        public IEnumerable<Unidade> RetornarUnidade()
        {
            var lista = RestService.For<IApiUnidade>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Unidade RetornarPorId(int id)
        {
            var lista = RestService.For<IApiUnidade>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
