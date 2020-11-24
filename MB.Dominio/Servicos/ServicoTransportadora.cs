﻿using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoTransportadora : ServiceBase<Transportadora>, IServicoTransportadora
    {
        private readonly IRepositorioTransportadora _repositorio;
        private readonly string _controller = "/transportadora";
        private string _url = "";

        public ServicoTransportadora(IRepositorioTransportadora repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;

            //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
            var lista = _repositorio.GetAll().Where(x => x.Cod_Trans == 2);

            foreach (var tra in lista)
            {
                tra.Nome_Banco = "nao tem";
                tra.Nome = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Nome);
                tra.Endereco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Endereco);
                tra.Bairro = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Bairro);
                tra.NomeCidade = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.NomeCidade);
                tra.Obs = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Obs);
                tra.Contato = Funcoes.ObterStringSemAcentosECaracteresEspeciais(tra.Contato);
            }

            string nomeArquivo = "transportadora.txt";
            if (lista.Count() > 0)
                nomeArquivo = "transportadora" + lista.FirstOrDefault().Cod_Trans + ".txt";
            try
            {
                var retorno = new ServicoJson<Transportadora[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
            }
            catch (Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
            }
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Cod_Trans == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Transportadora> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
