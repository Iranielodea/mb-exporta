using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.API;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Interfaces.Servico;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MB.Dominio.Servicos
{
    public class ServicoProduto : ServiceBase<Produto>, IServicoProduto
    {
        private readonly IRepositorioProduto _repositorio;
        private readonly ApiProduto _api;

        public ServicoProduto(IRepositorioProduto repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
            _api = new ApiProduto();
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
            var cidade = _repositorio.GetAll().Where(x => x.Cod_Produto == id).ToList();
            ExcluirNet(cidade);
        }

        public async override void ExcluirNet(IEnumerable<Produto> entidades)
        {
            await _api.Excluir(entidades.ToList());
        }
    }
}
