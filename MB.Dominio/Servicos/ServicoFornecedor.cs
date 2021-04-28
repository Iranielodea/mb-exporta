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
    public class ServicoFornecedor : ServiceBase<Fornecedor>, IServicoFornecedor
    {
        private readonly IRepositorioFornecedor _repositorio;
        private readonly string _controller = "/fornecedor";
        private string _url = "";

        public ServicoFornecedor(IRepositorioFornecedor repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            _url = _controller;

            using (var db = new TransactionScope())
            {
                //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
                var lista = _repositorio.GetAll().ToList();

                var propriedade = new PropriedadeRef();

                foreach (var cli in lista)
                {
                    cli.Nome = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Nome);
                    cli.Fantasia = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Fantasia);
                    cli.Endereco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Endereco);
                    cli.Bairro = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Bairro);
                    cli.Complemento = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Complemento);
                    cli.Numero = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Numero);
                    cli.NomeCidade = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.NomeCidade);
                    cli.Obs = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Obs);
                    cli.Email = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Email);

                    propriedade.GetPropertyValues(cli);
                    //cli.Num_Agencia = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Num_Agencia);
                    //cli.Num_Banco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Num_Banco);
                    //cli.Num_Conta = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Num_Conta);
                    //cli.Nome_Titular = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Nome_Titular);
                    //cli.Nome_Despositante = Funcoes.ObterStringSemAcentosECaracteresEspeciais(cli.Nome_Despositante);
                }

                string nomeArquivo = "Fornecedor.txt";
                if (lista.Count() > 0)
                    nomeArquivo = "Fornecedor" + lista.FirstOrDefault().Cod_For + ".txt";
                try
                {
                    var retorno = new ServicoJson<Fornecedor[]>().Insert(_url, lista);
                    if (retorno.mensagem != "OK")
                        Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
                }
                catch (Exception ex)
                {
                    Funcoes.GravarArquivo(nomeArquivo, ex.Message);
                }

                _repositorio.AtualizarTabelaExportada();

                db.Complete();
            }
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Cod_For == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Fornecedor> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }
    }
}
