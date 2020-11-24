using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Unidade : EntidadeBase
    {
        [JsonProperty("Codigo")]
        public int Id_Unidade { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("Sigla")]
        public string Sigla { get; set; }
        [JsonProperty("Nome")]
        public string Desc_Unidade { get; set; }
        [JsonProperty("ComplUnidade")]
        public string Compl_Unidade { get; set; }
        [JsonProperty("FatorConversao")]
        public decimal Fator_Conversao { get; set; }
        [JsonProperty("IdTexto")]
        public int? Id_Texto { get; set; }
    }
}
