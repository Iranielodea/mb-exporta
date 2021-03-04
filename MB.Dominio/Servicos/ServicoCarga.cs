using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using MB.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoCarga : ServiceBase<Carga>, IServicoCarga
    {
        private readonly IRepositorioCarga _repositorio;
        private readonly string _controller = "/carga";
        private string _url = "";

        public ServicoCarga(IRepositorioCarga repositorio) : base(repositorio)
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

            var lista = new List<Carga>();
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

            foreach (var carga in lista)
            {
                carga.Nome_Contato = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Contato);
                carga.Nome_Fornecedor = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Fornecedor);
                carga.Nome_Usina = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Usina);
                carga.Obs = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Obs);
                carga.Agencia_Banco = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Agencia_Banco);
                carga.Armazen = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Armazen);
                carga.Complemento = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Complemento);
                carga.ComplUnidade = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.ComplUnidade);
                carga.Contato_Indicacao = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Contato_Indicacao);
                carga.Nome_Agencia = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Agencia);
                carga.Nome_Cliente = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Cliente);
                carga.Nome_Manifesto = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Manifesto);
                carga.Nome_Motorista = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Nome_Motorista);
                carga.Obs2 = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Obs2);
                carga.Sigla_Unidade = Funcoes.ObterStringSemAcentosECaracteresEspeciais(carga.Sigla_Unidade);
                //pedido.Data = DateTime.Parse("01/01/2015");
            }

            string nomeArquivo = "Carga.txt";
            if (lista.Count() > 0)
                nomeArquivo = "Carga" + lista.FirstOrDefault().Id_Carga + ".txt";

            try
            {
                var retorno = new ServicoJson<Carga[]>().Insert(_url, lista);
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
            var cidade = _repositorio.GetAll().Where(x => x.Id_Carga == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Carga> entidades)
        {
            //await _api.Excluir(entidades.ToList());
        }

        public void Exportar(string dataInicial, string dataFinal, int id = 0)
        {
            ExportarDados(dataInicial, dataFinal);
        }
    }
}
