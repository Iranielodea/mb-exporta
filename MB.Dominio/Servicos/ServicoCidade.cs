using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;

namespace MB.Dominio.Servicos
{
    public class ServicoCidade : ServiceBase<Cidade>, IServicoCidade
    {
        private readonly string _controller = "/api/Cidade/";
        private string _url = "";
        private readonly IRepositorioCidade _repositorio;

        public ServicoCidade(IRepositorioCidade repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public override void ExportNetAsync()
        {
            _url = _controller + "Importar";

            //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
            var lista = _repositorio.GetAll();

            new ServicoJson<Cidade[]>().Insert(_url, lista);

            //await _api.Salvar(lista);

            //_repositorio.AtualizarTabelaExportada();
        }

        public override void ExcluirNet(int id)
        {
            _url = _controller + "Excluir/{0}";
            //var model = _repositorio.GetAll().FirstOrDefault(x => x.Cod_Cidade == id);
            new ServicoJson<Cidade>().Delete(string.Format(_url, id));

            //var cidade = _repositorio.GetAll().Where(x => x.Cod_Cidade == id).ToList();
            //ExcluirNet(cidade);
        }

        //public async override void ExcluirNet(IEnumerable<Cidade> entidades)
        //{
        //    await _api.Excluir(entidades.ToList());
        //}
    }
}
