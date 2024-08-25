using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
    public class ProductionPlanService : IProductionPlanService
    {
        public Dictionary<string, decimal> CalculateProductionPlan(decimal load, IEnumerable<IPowerplant> powerplants)
        {
            decimal energyToProduce;
            Dictionary<string, decimal> powerplantsRanking = new Dictionary<string, decimal>();

            foreach (IPowerplant powerplant in powerplants.OrderBy(pw => pw.CostPerMWh).ThenByDescending(pw => pw.MaxEnergy))
            {
                energyToProduce = 0M;
                if ((load - powerplant.MinEnergy) >= 0 && load > 0)
                {
                    if (load >= powerplant.MaxEnergy)
                    {
                        energyToProduce = powerplant.MaxEnergy;
                        load -= powerplant.MaxEnergy;
                    }
                    else if (load >= powerplant.MinEnergy && load <= powerplant.MaxEnergy)
                    {
                        energyToProduce = load;
                        load = 0;
                    }
                }
                powerplantsRanking.Add(powerplant.Name, energyToProduce);
            }
            return powerplantsRanking;
        }
    }
}
