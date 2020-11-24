using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Grupo
    {
        public Grupo()
        {
            Ativo = "S";
            Id = 0;
        }
        [JsonProperty("codigo")]
        public int Cod_Grupo { get; set; }
        [JsonProperty("CodEmpresa")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("nome")]
        public string Desc_Grupo { get; set; }

        [JsonProperty("ativo")]
        public virtual string Ativo { get; set; }
        [JsonProperty("id")]
        public virtual int Id { get; set; }
    }
}
