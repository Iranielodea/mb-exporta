using Newtonsoft.Json;
using System;

namespace MB.Dominio.Entidades
{
    public class Carga
    {
        public Carga()
        {
            Id = 0;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("codigo")]
        public int Id_Carga { get; set; }

        [JsonProperty("nomeCliente")]
        public string Nome_Cliente { get; set; }

        [JsonProperty("nomeContato")]
        public string Nome_Contato { get; set; }

        [JsonProperty("numPedido")]
        public int Num_Pedido { get; set; }

        [JsonProperty("numCarga")]
        public int Num_Carga { get; set; }

        [JsonProperty("letra")]
        public string Letra { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("visto")]
        public string Visto { get; set; }

        [JsonProperty("qtde")]
        public decimal Qtde { get; set; }

        [JsonProperty("valorPedido")]
        public decimal Valor_Pedido { get; set; }

        [JsonProperty("valorCarrega")]
        public decimal Valor_Carrega { get; set; }

        [JsonProperty("valorFrete")]
        public decimal Valor_Frete { get; set; }

        [JsonProperty("nomeFornecedor")]
        public string Nome_Fornecedor { get; set; }

        [JsonProperty("nomeMotorista")]
        public string Nome_Motorista { get; set; }

        [JsonProperty("nomeAgencia")]
        public string Nome_Agencia { get; set; }

        [JsonProperty("qtdePedido")]
        public decimal Qtde_Pedido { get; set; }

        [JsonProperty("placa")]
        public string Placa { get; set; }

        [JsonProperty("obs")]
        public string Obs { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("financeiro")]
        public string Financeiro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("contatoIndicacao")]
        public string Contato_Indicacao { get; set; }

        [JsonProperty("saldo")]
        public decimal Saldo { get; set; }

        [JsonProperty("armazen")]
        public string Armazen { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("complUnidade")]
        public string ComplUnidade { get; set; }

        [JsonProperty("obs2")]
        public string Obs2 { get; set; }

        [JsonProperty("numNf")]
        public string Num_NF { get; set; }

        [JsonProperty("dataNf")]
        public DateTime? Data_Nf { get; set; }

        [JsonProperty("nomeManifesto")]
        public string Nome_Manifesto { get; set; }

        [JsonProperty("qtdeCada")]
        public decimal Qtde_Cada { get; set; }

        [JsonProperty("siglaUnidade")]
        public string Sigla_Unidade { get; set; }

        [JsonProperty("agenciaBanco")]
        public string Agencia_Banco { get; set; }

        [JsonProperty("cnpjCpf")]
        public string CNPJ_CPF { get; set; }

        [JsonProperty("creditoNf")]
        public string Credito_Nf { get; set; }

        [JsonProperty("numNota2")]
        public string Num_Nota2 { get; set; }

        [JsonProperty("ir")]
        public decimal IR { get; set; }

        [JsonProperty("valorNota2")]
        public decimal Valor_Nota2 { get; set; }

        [JsonProperty("nomeUsina")]
        public string Nome_Usina { get; set; }

        [JsonProperty("codCliente")]
        public int? Cod_Cliente { get; set; }

        [JsonProperty("codFor")]
        public int? Cod_For { get; set; }

        [JsonProperty("codContato")]
        public int? Cod_Contato { get; set; }

        [JsonProperty("codMotorista")]
        public int? Cod_Motorista { get; set; }

        [JsonProperty("codManifesto")]
        public int? Cod_Manifesto { get; set; }

        [JsonProperty("idUnidade")]
        public int? Id_Unidade { get; set; }

        [JsonProperty("idContaBanco")]
        public int? Id_Conta_Banco { get; set; }

        [JsonProperty("codUsina")]
        public int? Cod_Usina { get; set; }

    }
}
