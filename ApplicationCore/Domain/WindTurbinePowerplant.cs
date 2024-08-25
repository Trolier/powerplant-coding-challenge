using ApplicationCore.Interfaces;

namespace ApplicationCore.Domain
{
    public class WindTurbinePowerplant : BasePowerplant, IPowerplant
    {
        public string Name { get; init; }

        public decimal WindPercentage { get; set; }
        public decimal CostPerMWh => 0;
        public decimal MaxEnergy => Math.Round(Pmax * WindPercentage / 100m, 1, MidpointRounding.ToZero);
        public decimal MinEnergy => Pmin * WindPercentage / 100m;
    }
}
