using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoFornecedor : ServiceBase<Fornecedor>, IServicoFornecedor
    {
        private readonly IRepositorioFornecedor _repositorio;
        private readonly ApiFornecedor _api;

        public ServicoFornecedor(IRepositorioFornecedor repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
            _api = new ApiFornecedor();
        }

        public override async void ExportNetAsync()
        {
            using (var db = new TransactionScope())
            {
                //var lista = _repositorio.GetAll().Where(x => x.ExportarNet == "S").ToList();
                var lista = _repositorio.GetAll().ToList();

                await _api.Salvar(lista);

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
            await _api.Excluir(entidades.ToList());
        }
    }
}
