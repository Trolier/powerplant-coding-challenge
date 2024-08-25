using ApplicationCore.Interfaces;

namespace ApplicationCore.Domain
{
    public class TurboJetPowerplant : BasePowerplant, IPowerplant
    {
        public string Name { get; init; }

        public decimal KerosineEuroMWh { get; set; }
        public decimal CostPerMWh => KerosineEuroMWh / Efficiency;
        public decimal MaxEnergy => Pmax;
        public decimal MinEnergy => Pmin;
    }
}
