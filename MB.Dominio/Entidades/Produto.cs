using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        [JsonProperty("Codigo")]
        public int Cod_Produto { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("IdUnidade")]
        public int Id_Unidade { get; set; }
        [JsonProperty("CodGrupo")]
        public int? Cod_Grupo { get; set; }
        [JsonProperty("Nome")]
        public string Desc_Produto { get; set; }
        [JsonProperty("ValorVenda")]
        public decimal Valor_Venda { get; set; }
        [JsonProperty("Referencia")]
        public string Referencia { get; set; }
    }
}
