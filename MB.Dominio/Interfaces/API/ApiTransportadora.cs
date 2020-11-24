using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiTransportadora
    {
        [Post("/api/Transportadora")]
        Task Salvar([Body] List<Transportadora> Transportadoras);

        [Delete("/api/Transportadora")]
        Task Excluir([Body] List<Transportadora> Transportadoras);

        [Get("/api/Transportadora")]
        Task<IEnumerable<Transportadora>> Retornartodas();

        [Get("/api/Transportadora/{id}")]
        Task<Transportadora> RetornarPorId(int id);
    }

    public class ApiTransportadora
    {
        public async Task Salvar(List<Transportadora> Transportadoras)
        {
            var lista = RestService.For<IApiTransportadora>(Constantes.URL);
            await lista.Salvar(Transportadoras);
        }

        public async Task Excluir(List<Transportadora> Transportadoras)
        {
            var lista = RestService.For<IApiTransportadora>(Constantes.URL);
            await lista.Excluir(Transportadoras);
        }

        public IEnumerable<Transportadora> RetornarTransportadora()
        {
            var lista = RestService.For<IApiTransportadora>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Transportadora RetornarPorId(int id)
        {
            var lista = RestService.For<IApiTransportadora>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
