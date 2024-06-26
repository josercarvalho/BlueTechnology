using System.Text.Json.Serialization;

namespace JC_BlueTec.Domain.Entidades
{
    public class Endereco
    {
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }
        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }
        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }
        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }
        [JsonPropertyName("localidade")]
        public string? Localidade { get; set; }
        [JsonPropertyName("uf")]
        public string? Uf { get; set; }
    }
}