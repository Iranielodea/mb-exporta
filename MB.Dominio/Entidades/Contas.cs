using Newtonsoft.Json;
using System;

namespace MB.Dominio.Entidades
{
    public class Contas
    {
        public Contas()
        {
            Id = 0;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("codigo")]
        public int id_conta { get; set; }

        [JsonProperty("numPedido")]
        public int Num_Pedido { get; set; }

        [JsonProperty("nomeCliente")]
        public string Nome_Cliente { get; set; }

        [JsonProperty("nomeFornecedor")]
        public string Nome_Fornecedor { get; set; }

        [JsonProperty("dataEmissao")]
        public DateTime Data_Emissao { get; set; }

        [JsonProperty("valorPagar")]
        public decimal Valor_Pagar { get; set; }

        [JsonProperty("dataVencto")]
        public DateTime Data_Vencto { get; set; }

        [JsonProperty("dias")]
        public int Dias { get; set; }

        [JsonProperty("dataPago")]
        public DateTime? Data_Pago { get; set; }

        [JsonProperty("valorPago")]
        public int Valor_Pago { get; set; }

        [JsonProperty("seqConta")]
        public int Seq_Conta { get; set; }

        [JsonProperty("valorOriginal")]
        public decimal Valor_Original { get; set; }

        [JsonProperty("tipoConta")]
        public int Tipo_Conta { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("documento")]
        public string Documento{ get; set; }

        [JsonProperty("nomeFormaPagto")]
        public string Desc_Pagto { get; set; }

        [JsonProperty("contaBancoId")]
        public int? Id_ContaBanco { get; set; }

        [JsonProperty("pedidoId")]
        public int? Id_Pedido { get; set; }
    }
}
