using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Estado
    {
        [JsonProperty("Codigo")]
        public int Id_Estado { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("Sigla")]
        public string Sigla { get; set; }
        [JsonProperty("Nome")]
        public string Desc_Estado { get; set; }
        [JsonProperty("ICMS")]
        public decimal ICMS { get; set; }
    }
}
