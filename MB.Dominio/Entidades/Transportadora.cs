using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Transportadora : PessoaBase
    {
        [JsonProperty("codigo")]
        public int Cod_Trans { get; set; }

        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("inscEstadual")]
        public string Insc_Estadual { get; set; }

        [JsonProperty("fone1")]
        public string Fone1 { get; set; }

        [JsonProperty("fone2")]
        public string Fone2 { get; set; }

        [JsonProperty("contato")]
        public string Contato { get; set; }

        //[JsonProperty("CodAgencia")]
        //public int? Cod_Agencia { get; set; }

        [JsonProperty("ddd")]
        public string DDD { get; set; }

        //[JsonProperty("Destaque")]
        //public string Destaque { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        //[JsonProperty("DataNasc")]
        //public DateTime? DataNasc { get; set; }

        [JsonProperty("obs")]
        public string Obs { get; set; }

        [JsonProperty("numBanco")]
        public string Num_Banco { get; set; }

        [JsonProperty("nomeBanco")]
        public string Nome_Banco { get; set; }

        [JsonProperty("numAgencia")]
        public string Num_Agencia { get; set; }

        [JsonProperty("numConta")]
        public string Num_Conta { get; set; }

        [JsonProperty("titular")]
        public string Nome_Titular { get; set; }

        //[JsonProperty("NomeDepositante")]
        //public string Nome_Despositante { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cpfTrans")]
        public string CPF_Transp { get; set; }

        //[JsonProperty("ANTT")]
        //public string ANTT { get; set; }

        //[JsonProperty("RENAVAN")]
        //public string RENAVAN { get; set; }
    }
}
