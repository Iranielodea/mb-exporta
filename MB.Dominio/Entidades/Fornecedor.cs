using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Fornecedor : PessoaBase
    {
        [JsonProperty("Codigo")]
        public int Cod_For { get; set; }
        [JsonProperty("Fantasia")]
        public string Fantasia { get; set; }
        [JsonProperty("Numero")]
        public string Numero { get; set; }
        [JsonProperty("Complemento")]
        public string Complemento { get; set; }
        [JsonProperty("CNPJ")]
        public string CNPJ { get; set; }
        [JsonProperty("InscEstadual")]
        public string Insc_Estadual { get; set; }
        [JsonProperty("Fone")]
        public string Fone { get; set; }
        [JsonProperty("Fax")]
        public string Fax { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Obs")]
        public string Obs { get; set; }
        [JsonProperty("NumBanco")]
        public string Num_Banco { get; set; }
        [JsonProperty("NomeBanco")]
        public string Nome_Banco { get; set; }
        [JsonProperty("NumAgencia")]
        public string Num_Agencia { get; set; }
        [JsonProperty("NumConta")]
        public string Num_Conta { get; set; }
        [JsonProperty("NomeTitular")]
        public string Nome_Titular { get; set; }
        [JsonProperty("CPF")]
        public string CPF { get; set; }
        [JsonProperty("NomeDepositante")]
        public string Nome_Despositante { get; set; }
        [JsonProperty("Marcar")]
        public string Marcar { get; set; }
        [JsonProperty("IdEmpresa")]
        public int? Id_Tipo_Empresa { get; set; }
    }
}
