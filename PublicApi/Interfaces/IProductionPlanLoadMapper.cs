using ApplicationCore.Interfaces;
using PublicApi.Data;

namespace PublicApi.Mapper.Interfaces
{
    public interface IProductionPlanLoadMapper
    {
        IEnumerable<IPowerplant> MapGasFiredPowerplant(ProductionPlanLoad productionPlanLoad);
        IEnumerable<IPowerplant> MapTurboJetPowerplant(ProductionPlanLoad productionPlanLoad);
        IEnumerable<IPowerplant> MapWindTurbinePowerplant(ProductionPlanLoad productionPlanLoad);
    }
}

