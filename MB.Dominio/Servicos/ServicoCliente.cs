using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoCliente : ServiceBase<Cliente>, IServicoCliente
    {
        private readonly IRepositorioCliente _repositorio;
        private readonly string _controller = "/cliente";
        private string _url = "";

        public ServicoCliente(IRepositorioCliente repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;

            //DateTime dataInicial = new DateTime(2014, 01, 01);
            //DateTime dataFinal = new DateTime(2020, 12, 31);
            using (var db = new TransactionScope())
            {
                //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
                var lista = _repositorio.GetAll()
                    .ToList();

                foreach(var cli in lista)
                {
                    cli.Nome = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Nome);
                    cli.Fantasia = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Fantasia);
                    cli.Endereco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Endereco);
                    cli.Bairro = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Bairro);
                    cli.Complemento = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Complemento);
                    cli.Numero = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Numero);
                    cli.NomeCidade = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.NomeCidade);
                    cli.Obs = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Obs);
                }

                string nomeArquivo = "Cliente.txt";
                if (lista.Count() > 0)
                    nomeArquivo = "Cliente" + lista.FirstOrDefault().Cod_Cliente + ".txt";
                try
                {
                    var retorno = new ServicoJson<Cliente[]>().Insert(_url, lista);
                    if (retorno.mensagem != "OK")
                        Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
                }
                catch (Exception ex)
                {
                    Funcoes.GravarArquivo(nomeArquivo, ex.Message);
                }
                //_repositorio.AtualizarTabelaExportada();

                db.Complete();
            }
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Cod_Cliente == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Cliente> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
