using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Empresa : EntidadeBase
    {
        [JsonProperty("Codigo")]
        public int Cod_Empresa { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("Endereco")]
        public string Endereco { get; set; }
        [JsonProperty("Bairro")]
        public string Bairro { get; set; }
        [JsonProperty("Numero")]
        public string Numero { get; set; }
        [JsonProperty("NomeCidade")]
        public string Desc_Cidade { get; set; }
        [JsonProperty("CEP")]
        public string CEP { get; set; }
        [JsonProperty("UF")]
        public string Estado { get; set; }
        [JsonProperty("Fone")]
        public string Fone { get; set; }
        [JsonProperty("Fax")]
        public string Fax { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("CNPJ")]
        public string CNPJ { get; set; }
        [JsonProperty("InscEstadual")]
        public string Insc_Estadual { get; set; }
        [JsonProperty("Versao")]
        public string Versao { get; set; }
    }
}
