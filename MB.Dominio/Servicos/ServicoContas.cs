using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoContas : ServiceBase<Contas>, IServicoContas
    {
        private readonly IRepositorioContas _repositorio;
        private readonly string _controller = "/conta";
        private string _url = "";

        public ServicoContas(IRepositorioContas repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            //ExportarDados("01.01.2000", "01.01.2000");
        }

        private void ExportarDados(string dataInicial, string dataFinal, int id = 0)
        {
            _url = _controller;
            if (id > 0)
                _url = _controller + "/incluir";

            var lista = new List<Contas>();
            //dataInicial = "01.01.2010";
            //dataFinal = "31.12.2010";
            //var lista = _repositorio.Filtrar("01.01.2010", "31.12.2010") //.Where(x => x.Num_Pedido == 4632 || x.Num_Pedido == 4633)
            //    .ToList();

            if (string.IsNullOrWhiteSpace(dataInicial))
                lista = _repositorio.GetAll().ToList();
            else
            {
                lista = _repositorio.Filtrar(dataInicial, dataFinal)
                    .ToList();
            }

            var propriedade = new PropriedadeRef();
            foreach (var conta in lista)
            {
                conta.Desc_Pagto = Funcoes.ObterStringSemAcentosECaracteresEspeciais(conta.Desc_Pagto);
                conta.Documento = Funcoes.ObterStringSemAcentosECaracteresEspeciais(conta.Documento);
                conta.Nome_Cliente = Funcoes.ObterStringSemAcentosECaracteresEspeciais(conta.Nome_Cliente);
                conta.Nome_Fornecedor = Funcoes.ObterStringSemAcentosECaracteresEspeciais(conta.Nome_Fornecedor);

                propriedade.GetPropertyValues(conta);

                //pedido.Data = DateTime.Parse("01/01/2015");
            }

            string nomeArquivo = "Contas.txt";
            if (lista.Count() > 0)
                nomeArquivo = "Conta" + lista.FirstOrDefault().id_conta + ".txt";

            try
            {
                var retorno = new ServicoJson<Contas[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);

                //_repositorio.AtualizarTabelaExportada();
            }
            catch (Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        public override void ExcluirNet(int id)
        {
            var conta = _repositorio.GetAll().Where(x => x.id_conta == id).ToList();
            ExcluirNet(conta);
        }

        public async override void ExcluirNet(IEnumerable<Contas> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }

        public void Exportar(string dataInicial, string dataFinal, int id = 0)
        {
            ExportarDados(dataInicial, dataFinal, id);
        }
    }
}
