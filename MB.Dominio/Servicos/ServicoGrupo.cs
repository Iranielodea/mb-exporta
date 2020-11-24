using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoGrupo : ServiceBase<Grupo>, IServicoGrupo
    {
        private readonly IRepositorioGrupo _repositorio;
        private readonly string _controller = "/grupo";
        private string _url = "";

        public ServicoGrupo(IRepositorioGrupo repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;

            //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
            var lista = _repositorio.GetAll();

            string nomeArquivo = "Grupo.txt";
            if (lista.Count() > 0)
                nomeArquivo = "Grupo" + lista.FirstOrDefault().Cod_Grupo + ".txt";
            try
            {
                var retorno = new ServicoJson<Grupo[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
            }
            catch(Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
            }

            //new ServicoJson<Grupo[]>().Insert(_url, lista);
        }

        public override void ExcluirNet(int id)
        {
            var grupo = _repositorio.GetAll().Where(x => x.Cod_Grupo == id).ToList();
            ExcluirNet(grupo);
        }

        public async override void ExcluirNet(IEnumerable<Grupo> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
