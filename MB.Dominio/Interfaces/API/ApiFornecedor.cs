using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiFornecedor
    {
        [Post("/api/fornecedor")]
        Task Salvar([Body] List<Fornecedor> fornecedors);

        [Delete("/api/fornecedor/")]
        Task Excluir([Body] List<Fornecedor> fornecedors);

        [Get("/api/fornecedor")]
        Task<IEnumerable<Fornecedor>> Retornartodas();

        [Get("/api/fornecedor/{id}")]
        Task<Fornecedor> RetornarPorId(int id);
    }

    public class ApiFornecedor
    {
        public async Task Salvar(List<Fornecedor> fornecedors)
        {
            var lista = RestService.For<IApiFornecedor>(Constantes.URL);
            await lista.Salvar(fornecedors);
        }

        public async Task Excluir(List<Fornecedor> fornecedors)
        {
            var lista = RestService.For<IApiFornecedor>(Constantes.URL);
            await lista.Excluir(fornecedors);
        }

        public IEnumerable<Fornecedor> RetornarFornecedor()
        {
            var lista = RestService.For<IApiFornecedor>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Fornecedor RetornarPorId(int id)
        {
            var lista = RestService.For<IApiFornecedor>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
