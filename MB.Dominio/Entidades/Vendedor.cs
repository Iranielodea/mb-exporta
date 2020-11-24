using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Vendedor : EntidadeBase
    {
        [JsonProperty("Codigo")]
        public int Cod_Vendedor { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("PercComissao")]
        public decimal Perc_Comissao { get; set; }
        [JsonProperty("ValorComissao")]
        public decimal Valor_Comissao { get; set; }
    }
}
