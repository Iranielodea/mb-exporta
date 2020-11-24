using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoVendedor : ServiceBase<Vendedor>, IServicoVendedor
    {
        private readonly IRepositorioVendedor _repositorio;
        private readonly ApiVendedor _api;

        public ServicoVendedor(IRepositorioVendedor repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
            _api = new ApiVendedor();
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
            var cidade = _repositorio.GetAll().Where(x => x.Cod_Vendedor == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Vendedor> entidades)
        {
            await _api.Excluir(entidades.ToList());
        }
    }
}
