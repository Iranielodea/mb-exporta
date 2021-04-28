using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoContaBanco : ServiceBase<ContaBanco>, IServicoContaBanco
    {
        private readonly IRepositorioContaBanco _repositorio;
        private readonly string _controller = "/contaBanco";
        private string _url = "";

        public ServicoContaBanco(IRepositorioContaBanco repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;

            //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
            var lista = _repositorio.GetAll(); //.Where(x => x.id_ContaBanco == 1);
            var propriedade = new PropriedadeRef();
            foreach (var tra in lista)
            {
                tra.Agencia = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Agencia);
                tra.Banco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Banco);
                tra.Num_Conta = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Num_Conta);

                propriedade.GetPropertyValues(tra);
            }

            string nomeArquivo = "contaBanco.txt";
            if (lista.Count() > 0)
                nomeArquivo = "contaBanco" + lista.FirstOrDefault().id_ContaBanco + ".txt";
            try
            {
                var retorno = new ServicoJson<ContaBanco[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
            }
            catch (Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
            }
            _repositorio.AtualizarTabelaExportada();
        }

        public override void ExcluirNet(int id)
        {
            var contaBanco = _repositorio.GetAll().Where(x => x.id_ContaBanco == id).ToList();
            ExcluirNet(contaBanco);
        }

        public async override void ExcluirNet(IEnumerable<ContaBanco> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
