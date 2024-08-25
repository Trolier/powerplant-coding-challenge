using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PublicApi.Data
{
    public class ProductionPlanLoad
    {
        [Required]
        [JsonPropertyName("fuels")]
        public Fuel Fuels { get; set; }

        [Required]
        [JsonPropertyName("powerplants")]
        public List<Powerplant> PowerPlants { get; set; }

        [Required]
        [JsonPropertyName("load")]
        [Range(0, double.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal? Load { get; set; }
    }
}