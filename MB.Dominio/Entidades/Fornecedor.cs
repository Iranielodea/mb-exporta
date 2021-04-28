using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Fornecedor : PessoaBase
    {
        [JsonProperty("codigo")]
        public int Cod_For { get; set; }
        [JsonProperty("fantasia")]
        public string Fantasia { get; set; }
        [JsonProperty("numero")]
        public string Numero { get; set; }
        [JsonProperty("complemento")]
        public string Complemento { get; set; }
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }
        [JsonProperty("inscEstadual")]
        public string Insc_Estadual { get; set; }
        [JsonProperty("fone")]
        public string Fone { get; set; }
        [JsonProperty("fax")]
        public string Fax { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("obs")]
        public string Obs { get; set; }

        //[JsonProperty("NumBanco")]
        //public string Num_Banco { get; set; }
        //[JsonProperty("NomeBanco")]
        //public string Nome_Banco { get; set; }
        //[JsonProperty("NumAgencia")]
        //public string Num_Agencia { get; set; }
        //[JsonProperty("NumConta")]
        //public string Num_Conta { get; set; }
        //[JsonProperty("NomeTitular")]
        //public string Nome_Titular { get; set; }
        //[JsonProperty("CPF")]
        //public string CPF { get; set; }
        //[JsonProperty("NomeDepositante")]
        //public string Nome_Despositante { get; set; }
        //[JsonProperty("Marcar")]
        //public string Marcar { get; set; }
        //[JsonProperty("IdEmpresa")]
        //public int? Id_Tipo_Empresa { get; set; }
    }
}
