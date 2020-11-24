using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class PedidoItem
    {
        [JsonProperty("CodProduto")]
        public int Cod_Produto { get; set; }
        [JsonProperty("NumPedido")]
        public int Num_Pedido { get; set; }
        [JsonProperty("Seq")]
        public int Seq { get; set; }
        [JsonProperty("Qtde")]
        public decimal Qtde { get; set; }
        [JsonProperty("Valor")]
        public decimal Valor { get; set; }
        [JsonProperty("ValorTotal")]
        public decimal Valor_Total { get; set; }
        [JsonProperty("IdUnidade")]
        public int Id_Unidade { get; set; }
        [JsonProperty("CodEmpresa")]
        public int? Cod_Empresa { get; set; }
        [JsonProperty("PrecoVenda")]
        public decimal Preco_Venda { get; set; }
        [JsonProperty("ValorLucro")]
        public decimal Valor_Lucro { get; set; }
        [JsonProperty("TotalLucro")]
        public decimal Total_Lucro { get; set; }
        [JsonProperty("TotalVenda")]
        public decimal Total_Venda { get; set; }
        [JsonProperty("UsuInc")]
        public string Usu_Inc { get; set; }
        [JsonProperty("UsuAlt")]
        public string Usu_Alt { get; set; }
    }
}
