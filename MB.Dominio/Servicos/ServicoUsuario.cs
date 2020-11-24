using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoUsuario : ServiceBase<Usuario>, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly string _controller = "/usuario";
        private string _url = "";

        public ServicoUsuario(IRepositorioUsuario repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;
            var lista = _repositorio.GetAll();

            string nomeArquivo = "Usuario.txt";
            if (lista.Count() > 0)
                nomeArquivo = "Usuario" + lista.FirstOrDefault().Nome + ".txt";
            try
            {
                var retorno = new ServicoJson<Usuario[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
            }
            catch(Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
            }
        }

        public override void ExcluirNet(int id)
        {
            var grupo = _repositorio.GetAll().Where(x => x.Nome == id.ToString()).ToList();
            ExcluirNet(grupo);
        }

        public async override void ExcluirNet(IEnumerable<Usuario> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
