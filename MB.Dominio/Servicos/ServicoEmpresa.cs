using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoEmpresa : ServiceBase<Empresa>, IServicoEmpresa
    {
        private readonly IRepositorioEmpresa _repositorio;
        private readonly ApiEmpresa _api;

        public ServicoEmpresa(IRepositorioEmpresa repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
            _api = new ApiEmpresa();
        }

        public override async void ExportNetAsync()
        {
            using (var db = new TransactionScope())
            {
                var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();

                await _api.Salvar(lista);

                _repositorio.AtualizarTabelaExportada();

                db.Complete();
            }
        }

        public override void ExcluirNet(int id)
        {
            var cidade = _repositorio.GetAll().Where(x => x.Cod_Empresa == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Empresa> entidades)
        {
            await _api.Excluir(entidades.ToList());
        }
    }
}
