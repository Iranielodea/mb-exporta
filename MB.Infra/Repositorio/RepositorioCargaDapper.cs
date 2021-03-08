using System.Linq;
using System.Text;
using Dapper;
using MB.Dominio.Entidades;
using MB.Dominio.Interfaces.Repositorio;
using MB.Dominio.Shared;
using MB.Infra.DataBase;

namespace MB.Infra.Repositorio
{
    public class RepositorioCargaDapper : RepositoryBase<Carga>, IRepositorioCarga
    {
        private readonly IUnitOfWork _uow;

        public RepositorioCargaDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Add(Carga entidade)
        {
            Salvar(entidade);
        }

        public void AtualizarTabelaExportada(int id = 0)
        {
            string instrucaoSQL = "";
            if (id > 0)
                instrucaoSQL = $"UPDATE CARGA SET EXPORTAR_NET = 'N' WHERE Id_Carga = {id}";
            else
                instrucaoSQL = $"UPDATE CARGA SET EXPORTAR_NET = 'N' WHERE EXPORTAR_NET = 'S'";
            _uow.Connection.Execute(instrucaoSQL, null, _uow.Transaction);
        }

        public override IQueryable<Carga> GetAll()
        {
            var sb = new StringBuilder();
            sb.AppendLine(RetornarSQL());
            sb.AppendLine(" WHERE CAR.EXPORTAR_NET = 'S'");

            //var dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = dados.Select(new Pedido(), "PEDIDO");

            return _uow.Connection.Query<Carga>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        public IQueryable<Carga> Filtrar(string dataInicial, string dataFinal)
        {
            var sb = new StringBuilder();

            sb.AppendLine(RetornarSQL());
            sb.AppendLine($" WHERE CAR.DATA BETWEEN '{dataInicial}' and '{dataFinal}'");
            //sb.AppendLine(" AND PED.NUM_PEDIDO = 3166");

            return _uow.Connection.Query<Carga>(sb.ToString(), null, _uow.Transaction).AsQueryable();
        }

        private string RetornarSQL()
        {
            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.AppendLine(" CAR.ID_CARGA,");
            sb.AppendLine(" CLI.NOME AS NOME_CLIENTE, ");
            sb.AppendLine(" CON.NOME AS NOME_CONTATO,");
            sb.AppendLine(" CAR.NUM_CARGA,");
            sb.AppendLine(" CAR.LETRA,");
            sb.AppendLine(" CAR.DATA,");
            sb.AppendLine(" CAR.VISTO,");
            sb.AppendLine(" CAR.QTDE,");
            sb.AppendLine(" CAR.VALOR_PEDIDO,");
            sb.AppendLine(" CAR.VALOR_CARREGA,");
            sb.AppendLine(" CAR.VALOR_FRETE,");
            sb.AppendLine(" FO.NOME AS NOME_FORNECEDOR,");
            sb.AppendLine(" MOT.NOME AS NOME_MOTORISTA,");
            sb.AppendLine(" '' AS NOME_AGENCIA,");
            sb.AppendLine(" CAR.QTDE_PEDIDO,");
            sb.AppendLine(" CAR.PLACA,");
            sb.AppendLine(" CAR.OBS,");
            sb.AppendLine(" CAR.SITUACAO,");
            sb.AppendLine(" CAR.FINANCEIRO,");
            sb.AppendLine(" CAR.COMPLEMENTO,");
            sb.AppendLine(" CAR.CONTATO_INDICACAO,");
            sb.AppendLine(" CAR.SALDO,");
            sb.AppendLine(" CAR.ARMAZEM,");
            sb.AppendLine(" CAR.UNIDADE,");
            sb.AppendLine(" CAR.COMPLUNIDADE,");
            sb.AppendLine(" CAR.OBS2,");
            sb.AppendLine(" CAR.NUM_NF,");
            sb.AppendLine(" CAR.DATA_NF,");
            sb.AppendLine(" MAN.NOME AS NOME_MANIFESTO,");
            sb.AppendLine(" CAR.QTDE_CADA,");
            sb.AppendLine(" UNI.SIGLA AS SIGLA_UNIDADE,");
            sb.AppendLine(" BAN.AGENCIA AS AGENCIA_BANCO,");
            sb.AppendLine(" CAR.CNPJ_CPF,");
            sb.AppendLine(" CAR.CREDITO_NF,");
            sb.AppendLine(" CAR.NUM_NOTA2,");
            sb.AppendLine(" CAR.IR,");
            sb.AppendLine(" CAR.VALOR_NOTA2,");
            sb.AppendLine(" USI.NOME AS NOME_USINA");

            sb.AppendLine(" FROM CARGA CAR");
            sb.AppendLine(" LEFT JOIN CLIENTE CLI ON CAR.cod_cliente = CLI.cod_cliente");
            sb.AppendLine(" LEFT JOIN MOTORISTA MOT ON CAR.cod_motorista = MOT.cod_motorista");
            sb.AppendLine(" LEFT JOIN FORNECEDOR FO ON CAR.cod_for = FO.cod_for");
            sb.AppendLine(" LEFT JOIN CLIENTE CON ON CAR.cod_contato = CON.cod_cliente");
            sb.AppendLine(" LEFT JOIN FORNECEDOR USI ON CAR.cod_usina = USI.cod_For");
            sb.AppendLine(" LEFT JOIN TRANSPORTADOR MAN ON CAR.cod_manifesto = MAN.cod_trans");
            sb.AppendLine(" LEFT JOIN UNIDADE UNI ON CAR.ID_UNIDADE = UNI.ID_UNIDADE");
            sb.AppendLine(" LEFT JOIN CONTABANCO BAN ON CAR.ID_CONTABANCO = BAN.ID_CONTABANCO");
            return sb.ToString();
        }

        public override void Update(Carga entidade)
        {
            Salvar(entidade);
        }

        private void Salvar(Carga entidade)
        {
            string instrucaoSQL = "";
            var dados = new PersistenciaFactory().Instanciar();
            if (entidade.Num_Pedido > 0)
                instrucaoSQL = dados.Update(new Carga(), "CARGA", "Id_Carga", entidade.Id_Carga);
            else
                instrucaoSQL = dados.Inserir(new Carga(), "CARGA", "Id_Carga");
            _uow.Connection.Execute(instrucaoSQL, entidade, _uow.Transaction);
        }
    }
}
