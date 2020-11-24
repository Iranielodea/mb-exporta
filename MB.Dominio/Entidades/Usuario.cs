using Newtonsoft.Json;

namespace MB.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Id = 0;
        }
        [JsonProperty("username")]
        public string Nome { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("id")]
        public virtual int Id { get; set; }
    }
}
