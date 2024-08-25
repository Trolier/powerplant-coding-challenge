namespace ApplicationCore.Interfaces
{
    public interface IProductionPlanService
    {
        Dictionary<string, decimal> CalculateProductionPlan(decimal load, IEnumerable<IPowerplant> powerplants);
    }
}