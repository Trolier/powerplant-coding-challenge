namespace ApplicationCore.Domain
{
    public abstract class BasePowerplant
    {
        public string Type { get; init; }
        public decimal Efficiency { get; init; }
        public int Pmin { get; init; }
        public int Pmax { get; init; }
    }
}
