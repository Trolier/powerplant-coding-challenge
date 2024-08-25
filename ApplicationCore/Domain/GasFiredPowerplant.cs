using ApplicationCore.Interfaces;

namespace ApplicationCore.Domain
{
    public class GasFiredPowerplant : BasePowerplant, IPowerplant
    {
        public string Name { get; init; }

        private const decimal CO2GENERATION = 0.3m;
        public decimal GaseuroMWh { get; set; }
        public decimal Co2EuroTon { get; set; }

        public decimal CostPerMWh => (GaseuroMWh / Efficiency) + (CO2GENERATION * Co2EuroTon);
        public decimal MaxEnergy => Pmax;
        public decimal MinEnergy => Pmin;
    }
}
