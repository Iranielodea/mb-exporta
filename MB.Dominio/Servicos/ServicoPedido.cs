using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoPedido : ServiceBase<Pedido>, IServicoPedido
    {
        private readonly IRepositorioPedido _repositorio;
        private readonly string _controller = "/pedido";
        private string _url = "";

        public ServicoPedido(IRepositorioPedido repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            ExportarDados("01.01.2000", "01.01.2000");
        }

        private void ExportarDados(string dataInicial, string dataFinal)
        {
            _url = _controller;

            var lista = new List<Pedido>();
            dataInicial = "01.01.2010";
            dataFinal = "31.12.2010";
            //var lista = _repositorio.Filtrar("01.01.2010", "31.12.2010") //.Where(x => x.Num_Pedido == 4632 || x.Num_Pedido == 4633)
            //    .ToList();

            if (string.IsNullOrWhiteSpace(dataInicial))
                lista = _repositorio.GetAll().ToList();
            else
            {
                lista = _repositorio.Filtrar(dataInicial, dataFinal)
                    .ToList();
            }

            foreach (var pedido in lista)
            {
                pedido.Nome_Contato = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Nome_Contato);
                pedido.Nome_Fornecedor = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Nome_Fornecedor);
                pedido.Nome_Usina = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Nome_Usina);
                pedido.Nome_Vendedor = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Nome_Vendedor);
                pedido.Obs = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Obs);
            }

            string nomeArquivo = "Pedido.txt";
            if (lista.Count() > 0)
                nomeArquivo = "Pedido" + lista.FirstOrDefault().Num_Pedido + ".txt";

            try
            {
                //var retorno = new ServicoJson<Pedido[]>().Insert(_url, lista);
                //if (retorno.mensagem != "OK")
                //    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);
            }
            catch (Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Num_Pedido == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Pedido> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }

        public void Exportar(string dataInicial, string dataFinal)
        {
            ExportarDados(dataInicial, dataFinal);
        }
    }
}
