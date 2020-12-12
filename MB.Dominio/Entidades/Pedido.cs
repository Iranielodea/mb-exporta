using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MB.Dominio.Entidades
{
    public class Pedido
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("numPedido")]
        public int Num_Pedido { get; set; }
        [JsonProperty("data")]
        public DateTime Data { get; set; }
        [JsonProperty("totalBruto")]
        public decimal Total_Bruto { get; set; }
        [JsonProperty("percDesconto")]
        public decimal Perc_Desconto { get; set; }
        [JsonProperty("valorDesconto")]
        public decimal Valor_Desconto { get; set; }
        [JsonProperty("totalLiquido")]
        public decimal Total_Liquido { get; set; }
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        [JsonProperty("nomeFornecedor")]
        public string Nome_Fornecedor { get; set; }
        //[JsonProperty("codFor")]
        //public int Cod_For { get; set; }
        //[JsonProperty("CodEmpresa")]
        //public int Cod_Empresa { get; set; }
        //[JsonProperty("CodCliente")]
        //public int Cod_Cliente { get; set; }
        [JsonProperty("obs")]
        public string Obs { get; set; }
        //[JsonProperty("CodContato")]
        //public int? Cod_Contato { get; set; }
        [JsonProperty("nomeCliente")]
        public string Nome_Cliente { get; set; }
        [JsonProperty("nomeContato")]
        public string Nome_Contato { get; set; }
        [JsonProperty("percComissao")]
        public decimal Perc_Comissao { get; set; }
        [JsonProperty("encerrado")]
        public string Encerrado { get; set; }
        [JsonProperty("totalVenda")]
        public decimal Total_Venda { get; set; }
        [JsonProperty("totalLucro")]
        public decimal Total_Lucro { get; set; }
        [JsonProperty("totalQtde")]
        public decimal Total_Qtde { get; set; }
        [JsonProperty("numCarga")]
        public int? Num_Carga { get; set; }
        [JsonProperty("valorLucro")]
        public decimal Valor_Lucro { get; set; }
        //[JsonProperty("ImpLogo")]
        //public string Imp_Logo { get; set; }
        //[JsonProperty("CodVendeor")]
        //public int? Cod_Vendedor { get; set; }
        [JsonProperty("nomeVendedor")]
        public string Nome_Vendedor { get; set; }
        [JsonProperty("valorComissao")]
        public decimal Valor_Comissao { get; set; }
        [JsonProperty("totalComissao")]
        public decimal Total_Comissao { get; set; }
        [JsonProperty("nomeUsina")]
        public string Nome_Usina { get; set; }
        //[JsonProperty("CodUsina")]
        //public int? Cod_Usina { get; set; }

        public ICollection<PedidoItem> PedidoItens { get; set; }
    }
}
