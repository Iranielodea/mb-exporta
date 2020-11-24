using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Cidade
    {
        [JsonProperty("Codigo")]
        public int Cod_Cidade { get; set; }
        [JsonProperty("Nome")]
        public string Desc_Cidade { get; set; }
        [JsonProperty("CEP")]
        public string CEP { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("CodEstado")]
        public int Id_Estado { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
