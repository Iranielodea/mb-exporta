using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoUnidade : ServiceBase<Unidade>, IServicoUnidade
    {
        private readonly IRepositorioUnidade _repositorio;
        private readonly ApiUnidade _api;

        public ServicoUnidade(IRepositorioUnidade repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
            _api = new ApiUnidade();
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
            var cidade = _repositorio.GetAll().Where(x => x.Id_Unidade == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Unidade> entidades)
        {
            await _api.Excluir(entidades.ToList());
        }
    }
}
