using System.Text.Json.Serialization;

namespace PublicApi.Dto
{
    public class ProductionPlan
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("p")]
        public decimal P { get; set; }
    }
}
