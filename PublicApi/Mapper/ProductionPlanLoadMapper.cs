using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using PublicApi.Data;
using PublicApi.Enum;
using PublicApi.Mapper.Interfaces;

namespace PublicApi.Mapper
{
    public class ProductionPlanLoadMapper : IProductionPlanLoadMapper
    {
        public IEnumerable<IPowerplant> MapGasFiredPowerplant(ProductionPlanLoad productionPlanLoad)
        {
            foreach (Powerplant pw in productionPlanLoad.PowerPlants.Where(p => string.Equals(p.Type, PowerPlantTypeEnum.GasFired.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                GasFiredPowerplant gasFiredPowerplant = new GasFiredPowerplant()
                {
                    Pmax = pw.Pmax.Value,
                    Pmin = pw.Pmin.Value,
                    Efficiency = pw.Efficiency.Value,
                    Type = pw.Type,
                    Name = pw.Name
                };
                gasFiredPowerplant.Co2EuroTon = productionPlanLoad.Fuels.Co2EuroPerTon.Value;
                gasFiredPowerplant.GaseuroMWh = productionPlanLoad.Fuels.GasEuroPerMWh.Value;
                yield return gasFiredPowerplant;
            }
        }

        public IEnumerable<IPowerplant> MapWindTurbinePowerplant(ProductionPlanLoad productionPlanLoad)
        {

            foreach (Powerplant pw in productionPlanLoad.PowerPlants.Where(p => string.Equals(p.Type, PowerPlantTypeEnum.Turbojet.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                TurboJetPowerplant turboJetPowerplant = new TurboJetPowerplant()
                {
                    Pmax = pw.Pmax.Value,
                    Pmin = pw.Pmin.Value,
                    Efficiency = pw.Efficiency.Value,
                    Type = pw.Type,
                    Name = pw.Name
                };
                turboJetPowerplant.KerosineEuroMWh = productionPlanLoad.Fuels.KerosineEuroPerMWh.Value;
                yield return turboJetPowerplant;
            }
        }

        public IEnumerable<IPowerplant> MapTurboJetPowerplant(ProductionPlanLoad productionPlanLoad)
        {
            foreach (Powerplant pw in productionPlanLoad.PowerPlants.Where(p => string.Equals(p.Type, PowerPlantTypeEnum.WindTurbine.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                WindTurbinePowerplant windTurbinePowerplant = new WindTurbinePowerplant
                {
                    Pmax = pw.Pmax.Value,
                    Pmin = pw.Pmin.Value,
                    Efficiency = pw.Efficiency.Value,
                    Type = pw.Type,
                    Name = pw.Name
                };
                windTurbinePowerplant.WindPercentage = productionPlanLoad.Fuels.WindPercentage.Value;
                yield return windTurbinePowerplant;
            }
        }
    }
}
