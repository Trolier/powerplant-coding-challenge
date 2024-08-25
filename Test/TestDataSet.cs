using ApplicationCore.Domain;
using ApplicationCore.Interfaces;

namespace Test
{
    public class TestDataSet
    {
        public static IEnumerable<IPowerplant> GetPowerPlants() => new List<IPowerplant>
            {
                new GasFiredPowerplant{
                    Name = "GasFired",
                    Efficiency = 0.5m,
                    Pmax = 100,
                    Pmin = 50,
                    Co2EuroTon = 10,
                    GaseuroMWh = 15
                },
                new GasFiredPowerplant{
                    Name = "GasFiredNorth",
                    Efficiency = 0.4m,
                    Pmax = 200,
                    Pmin = 80,
                    Co2EuroTon = 10,
                    GaseuroMWh = 15
                },
                new TurboJetPowerplant{
                    Name = "TurboJet",
                    Efficiency = 0.3m,
                    Pmax = 50,
                    Pmin = 5,
                    KerosineEuroMWh = 100
                },
                new TurboJetPowerplant{
                    Name = "TurboJetNorth",
                    Efficiency = 0.2m,
                    Pmax = 50,
                    Pmin = 5,
                    KerosineEuroMWh = 100
                },
                new WindTurbinePowerplant
                {
                    Name = "Windturbine",
                    Efficiency = 1,
                    Pmax = 50,
                    Pmin = 0,
                    WindPercentage = 60
                },
                new WindTurbinePowerplant
                {
                    Name = "WindturbineNorth",
                    Efficiency = 1,
                    Pmax = 100,
                    Pmin = 0,
                    WindPercentage = 100
                },
            };
    }
}
