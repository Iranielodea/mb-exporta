using MB.Dominio.Entidades;
using MB.Dominio.Shared;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MB.Dominio.Interfaces.API
{
    public interface IApiEstado
    {
        //[Post("/api/estado")]
        [Post("/api/values")]
        Task Salvar([Body] List<Estado> estados);

        [Delete("/api/estado")]
        Task Excluir([Body] List<Estado> estados);

        [Get("/api/estado")]
        Task<IEnumerable<Estado>> Retornartodas();

        [Get("/api/estado/{id}")]
        Task<Estado> RetornarPorId(int id);
    }

    public class ApiEstado
    {
        public async Task Salvar(List<Estado> estados)
        {
            try
            {
                var lista = RestService.For<IApiEstado>(Constantes.URL);
                await lista.Salvar(estados);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Excluir(List<Estado> estados)
        {
            var lista = RestService.For<IApiEstado>(Constantes.URL);
            await lista.Excluir(estados);
        }

        public IEnumerable<Estado> RetornarEstado()
        {
            var lista = RestService.For<IApiEstado>(Constantes.URL);
            return lista.Retornartodas().Result;
        }

        public Estado RetornarPorId(int id)
        {
            var lista = RestService.For<IApiEstado>(Constantes.URL);
            return lista.RetornarPorId(id).Result;
        }
    }
}
