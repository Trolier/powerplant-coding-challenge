namespace ApplicationCore.Interfaces
{
    public interface IPowerplant
    {
        public string Name { get; init; }
        public decimal CostPerMWh { get; }
        public decimal MaxEnergy { get; }
        public decimal MinEnergy { get; }
    }
}