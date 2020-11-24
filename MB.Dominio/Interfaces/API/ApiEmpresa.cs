using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiEmpresa
    {
        [Post("/api/empresa")]
        Task Salvar([Body] List<Empresa> empresas);

        [Delete("/api/empresa/")]
        Task Excluir([Body] List<Empresa> empresas);

        [Get("/api/empresa")]
        Task<IEnumerable<Empresa>> Retornartodas();

        [Get("/api/empresa/{id}")]
        Task<Empresa> RetornarPorId(int id);
    }

    public class ApiEmpresa
    {
        public async Task Salvar(List<Empresa> empresas)
        {
            var lista = RestService.For<IApiEmpresa>(Constantes.URL);
            await lista.Salvar(empresas);
        }

        public async Task Excluir(List<Empresa> empresas)
        {
            var lista = RestService.For<IApiEmpresa>(Constantes.URL);
            await lista.Excluir(empresas);
        }

        public IEnumerable<Empresa> RetornarEmpresa()
        {
            var lista = RestService.For<IApiEmpresa>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Empresa RetornarPorId(int id)
        {
            var lista = RestService.For<IApiEmpresa>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
