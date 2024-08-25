using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PublicApi.Data
{
    public class Fuel
    {
        [Required]
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal? GasEuroPerMWh { get; set; }

        [Required]
        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal? KerosineEuroPerMWh { get; set; }

        [Required]
        [JsonPropertyName("co2(euro/ton)")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal? Co2EuroPerTon { get; set; }

        [Required]
        [JsonPropertyName("wind(%)")]
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? WindPercentage { get; set; }
    }
}
