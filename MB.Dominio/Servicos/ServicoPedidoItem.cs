using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoPedidoItem : ServiceBase<PedidoItem>, IServicoPedidoItem
    {
        private readonly IRepositorioPedidoItem _repositorio;
        private readonly string _controller = "/pedido-item";
        private string _url = "";

        public ServicoPedidoItem(IRepositorioPedidoItem repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override async void ExportNetAsync()
        {
            ExportarDados("01.01.2000", "01.01.2000");
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Num_Pedido == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<PedidoItem> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }

        private void ExportarDados(string dataInicial, string dataFinal)
        {
            _url = _controller;

            //dataInicial = "01.01.2010";
            //dataFinal = "31.12.2010";

            var lista = new List<PedidoItem>();

            if (string.IsNullOrWhiteSpace(dataInicial))
                lista = _repositorio.GetAll().ToList();
            else
            {
                lista = _repositorio.Filtrar(dataInicial, dataFinal)
                    .ToList();
            }

            foreach (var pedido in lista)
            {
                pedido.Sigla = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Sigla);
                pedido.Desc_Produto = Funcoes.ObterStringSemAcentosECaracteresEspeciais(pedido.Desc_Produto);
            }

            string nomeArquivo = "PedidoItem.txt";
            if (lista.Count() > 0)
                nomeArquivo = "PedidoItem" + lista.FirstOrDefault().Num_Pedido + ".txt";

            try
            {
                var retorno = new ServicoJson<PedidoItem[]>().Insert(_url, lista);
                if (retorno.mensagem != "OK")
                    Funcoes.GravarArquivo(nomeArquivo, retorno.mensagem);

                _repositorio.AtualizarTabelaExportada();
            }
            catch (Exception ex)
            {
                Funcoes.GravarArquivo(nomeArquivo, ex.Message);
                //Console.WriteLine(ex.Message);
            }
        }

        public void Exportar(string dataInicial, string dataFinal)
        {
            ExportarDados(dataInicial, dataFinal);
        }
    }
}
