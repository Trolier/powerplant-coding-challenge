using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PublicApi.Data;
using PublicApi.Dto;
using PublicApi.Mapper.Interfaces;

namespace TestEngie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;
        private readonly IProductionPlanService _productionPlanService;
        private readonly IProductionPlanLoadMapper _productionPlanLoadMapper;

        public ProductionPlanController(ILogger<ProductionPlanController> logger,
                                        IProductionPlanService productionPlanService,
                                        IProductionPlanLoadMapper productionPlanLoadMapper)
        {
            this._logger = logger;
            this._productionPlanService = productionPlanService;
            this._productionPlanLoadMapper = productionPlanLoadMapper;
        }

        [HttpPost()]
        public IActionResult Post(ProductionPlanLoad productionPlanLoad)
        {
            Dictionary<string, decimal> powerplan = this._productionPlanService.CalculateProductionPlan(productionPlanLoad.Load.Value,
                                                                                                   [.. this._productionPlanLoadMapper.MapTurboJetPowerplant(productionPlanLoad),
                                                                                                    .. this._productionPlanLoadMapper.MapGasFiredPowerplant(productionPlanLoad),
                                                                                                    .. this._productionPlanLoadMapper.MapWindTurbinePowerplant(productionPlanLoad)]);

            return Ok(powerplan.Select(p => new ProductionPlan() { Name = p.Key, P = p.Value }));
        }
    }
}
