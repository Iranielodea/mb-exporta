using Newtonsoft.Json;
using System;

namespace MB.Dominio.Entidades
{
    public class Cliente : PessoaBase
    {
        [JsonProperty("codigo")]
        public int Cod_Cliente { get; set; }

        //[JsonProperty("CodCondicao")]
        //public int? Cod_Condicao { get; set; }

        //[JsonProperty("CodPagto")]
        //public int? Cod_Pagto { get; set; }

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

        [JsonProperty("tipoPessoa")]
        public string Tipo_Pessoa { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("rg")]
        public string RG { get; set; }

        [JsonProperty("obs")]
        public string Obs { get; set; }

        [JsonProperty("dataCadastro")]
        public DateTime? Data_Cadastro { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        //[JsonProperty("DataAbertura")]
        //public DateTime? Data_Abertura { get; set; }

        //[JsonProperty("Comprador")]
        //public string Comprador { get; set; }

        //[JsonProperty("NomeFunc")]
        //public int? Num_Func { get; set; }

        //[JsonProperty("NomeAnterior")]
        //public string Nome_Anterior { get; set; }

        //[JsonProperty("EnderecoPagamento")]
    //    public string End_Pagamento { get; set; }

    //    [JsonProperty("EnderecoEntrega")]
    //    public string End_Entrega { get; set; }

    //    [JsonProperty("PredioProprio")]
    //    public string Predio_Proprio { get; set; }

    //    [JsonProperty("ValorAluguel")]
    //    public decimal Valor_Aluguel { get; set; }

    //    [JsonProperty("ConsumoMensal")]
    //    public decimal Consumo_Mensal { get; set; }

    //    [JsonProperty("Segmento")]
    //    public string Segmento { get; set; }

    //    [JsonProperty("Categoria")]
    //    public string Categoria { get; set; }

    //    [JsonProperty("Classificacao")]
    //    public string Classificacao { get; set; }

    //    [JsonProperty("QtdeCompraSemana")]
    //    public decimal Qtde_Compra_Semana { get; set; }

    //    [JsonProperty("DiasAprazo")]
    //    public int Dias_Aprazo { get; set; }

    //    [JsonProperty("ValorPedido")]
    //    public decimal Valor_Pedido { get; set; }

    //    [JsonProperty("FichaCadastral")]
    //    public string Ficha_Cadastral { get; set; }

    //    [JsonProperty("CartaoCadastral")]
    //    public string Cartao_Cadastral { get; set; }

    //    [JsonProperty("ContratoSocial")]
    //    public string Contrato_Social { get; set; }

    //    [JsonProperty("DocumentoProprietario")]
    //    public string Doc_Proprietario { get; set; }

    //    [JsonProperty("TipoFicha")]
    //    public string Tipo_Ficha { get; set; }

    //    [JsonProperty("Marcar")]
    //    public string Marcar { get; set; }

    //    [JsonProperty("CodVendedor")]
    //    public int? Cod_Vendedor { get; set; }
    }
}
