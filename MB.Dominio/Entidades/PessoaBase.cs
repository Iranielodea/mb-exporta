using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class PessoaBase
    {
        public PessoaBase()
        {
            Id = 0;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("endereco")]
        public string Endereco { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("nomeCidade")]
        public string NomeCidade { get; set; }

        [JsonProperty("cep")]
        public string CEP { get; set; }

        [JsonProperty("uf")]
        public string UF { get; set; }

        //public virtual int Cod_Empresa { get; set; }
        //public virtual int? Cod_Cidade { get; set; }
    }
}
