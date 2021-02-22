using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class ContaBanco
    {
        [JsonProperty("codigo")]
        public int id_ContaBanco { get; set; }

        [JsonProperty("numConta")]
        public string Num_Conta { get; set; }

        [JsonProperty("agencia")]
        public string Agencia { get; set; }

        [JsonProperty("nomeBanco")]
        public string Banco { get; set; }

        [JsonProperty("ativo")]
        public string Ativo { get; set; }

        [JsonProperty("cnpjCpf")]
        public string CNPJ_CPF { get; set; }
    }
}
