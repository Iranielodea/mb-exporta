using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class PedidoItem
    {
        [JsonProperty("codProduto")]
        public int Cod_Produto { get; set; }
        [JsonProperty("nomeProduto")]
        public string Desc_Produto { get; set; }
        [JsonProperty("numPedido")]
        public int Num_Pedido { get; set; }
        [JsonProperty("seq")]
        public int Seq { get; set; }
        [JsonProperty("qtde")]
        public decimal Qtde { get; set; }
        [JsonProperty("valor")]
        public decimal Valor { get; set; }
        [JsonProperty("valorTotal")]
        public decimal Valor_Total { get; set; }
        [JsonProperty("siglaUn")]
        public string Sigla { get; set; }
        //[JsonProperty("CodEmpresa")]
        //public int? Cod_Empresa { get; set; }
        [JsonProperty("precoVenda")]
        public decimal Preco_Venda { get; set; }
        [JsonProperty("valorLucro")]
        public decimal Valor_Lucro { get; set; }
        [JsonProperty("totalLucro")]
        public decimal Total_Lucro { get; set; }
        [JsonProperty("totalVenda")]
        public decimal Total_Venda { get; set; }
        //[JsonProperty("UsuInc")]
        //public string Usu_Inc { get; set; }
        //[JsonProperty("UsuAlt")]
        //public string Usu_Alt { get; set; }
    }
}
