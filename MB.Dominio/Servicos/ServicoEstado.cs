using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;

namespace MB.Dominio.Servicos
{
    public class ServicoEstado : ServiceBase<Estado>, IServicoEstado
    {
        private readonly IRepositorioEstado _repositorio;
        private readonly string _controller = "/api/Estado/";
        private string _url = "";

        public ServicoEstado(IRepositorioEstado repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override void ExportNetAsync()
        {
            _url = _controller + "IncluirVarios";

            //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
            var lista = _repositorio.GetAll();

            new ServicoJson<Estado[]>().Insert(_url, lista);

            //_repositorio.AtualizarTabelaExportada();

        }

        public override void ExcluirNet(int id)
        {
            _url = _controller + "Excluir/{0}";
            //var model = _repositorio.GetAll().FirstOrDefault(x => x.Id_Estado == id);
            new ServicoJson<Estado>().Delete(string.Format(_url, id));
        }
    }
}
