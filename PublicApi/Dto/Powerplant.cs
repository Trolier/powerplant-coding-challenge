using System.ComponentModel.DataAnnotations;

namespace PublicApi.Data
{
    public class Powerplant
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(0.01, 1, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal? Efficiency { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Pmin { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Pmax { get; set; }
    }
}