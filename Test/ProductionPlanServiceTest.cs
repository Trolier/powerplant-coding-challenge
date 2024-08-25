using ApplicationCore.Interfaces;
using ApplicationCore.Services;

namespace Test
{
    public class Tests
    {
        private IProductionPlanService _productionPlanService;

        [SetUp]
        public void Setup()
        {
            _productionPlanService = new ProductionPlanService(); ;
        }

        [Test]
        public void CalculateProductionPlan_Return_Only_WindTurbine()
        {
            // Arrange
            decimal load = 130;

            // Act
            Dictionary<string, decimal> result = _productionPlanService.CalculateProductionPlan(load, TestDataSet.GetPowerPlants());

            // Assert
            Assert.That(result, Has.Exactly(6).Items);
            CollectionAssert.AllItemsAreUnique(result);
            CollectionAssert.AllItemsAreNotNull(result);
            Assert.That(result["WindturbineNorth"] == 100m);
            Assert.That(result["Windturbine"] == 30m);
            Assert.That(result["GasFired"] == 0);
            Assert.That(result["GasFiredNorth"] == 0);
            Assert.That(result["TurboJet"] == 0);
            Assert.That(result["TurboJetNorth"] == 0);
        }

        [Test]
        public void CalculateProductionPlan_Return_Partial_Energy()
        {
            // Arrange
            decimal load = 135.6M;

            // Act
            Dictionary<string, decimal> result = _productionPlanService.CalculateProductionPlan(load, TestDataSet.GetPowerPlants());

            // Assert
            Assert.That(result, Has.Exactly(6).Items);
            CollectionAssert.AllItemsAreUnique(result);
            CollectionAssert.AllItemsAreNotNull(result);
            Assert.That(result["WindturbineNorth"] == 100m);
            Assert.That(result["Windturbine"] == 30m);
            Assert.That(result["GasFired"] == 0);
            Assert.That(result["GasFiredNorth"] == 0);
            Assert.That(result["TurboJet"] == 5.6m);
            Assert.That(result["TurboJetNorth"] == 0);
        }

        [Test]
        public void CalculateProductionPlan_Return_Only_WindTurbine_And_GasFired()
        {
            // Arrange
            decimal load = 310;

            // Act
            Dictionary<string, decimal> result = _productionPlanService.CalculateProductionPlan(load, TestDataSet.GetPowerPlants());

            // Assert
            CollectionAssert.AllItemsAreUnique(result);
            CollectionAssert.AllItemsAreNotNull(result);

            Assert.That(result, Has.Exactly(6).Items);
            Assert.That(result["WindturbineNorth"] == 100m);
            Assert.That(result["Windturbine"] == 30m);
            Assert.That(result["GasFired"] == 100m);
            Assert.That(result["GasFiredNorth"] == 80m);
            Assert.That(result["TurboJet"] == 0);
            Assert.That(result["TurboJetNorth"] == 0);
        }

        [Test]
        public void CalculateProductionPlan_Return_AllPowerPlants()
        {
            // Arrange
            decimal load = 600M;

            // Act
            Dictionary<string, decimal> result = _productionPlanService.CalculateProductionPlan(load, TestDataSet.GetPowerPlants());

            // Assert
            CollectionAssert.AllItemsAreUnique(result);
            CollectionAssert.AllItemsAreNotNull(result);

            Assert.That(result, Has.Exactly(6).Items);
            Assert.That(result["WindturbineNorth"] == 100m);
            Assert.That(result["Windturbine"] == 30m);
            Assert.That(result["GasFired"] == 100m);
            Assert.That(result["GasFiredNorth"] == 200m);
            Assert.That(result["TurboJet"] == 50m);
            Assert.That(result["TurboJetNorth"] == 50m);
        }

        [Test]
        public void CalculateProductionPlan_Return_NoPowerPlants()
        {
            // Arrange
            decimal load = 0;

            // Act
            Dictionary<string, decimal> result = _productionPlanService.CalculateProductionPlan(load, TestDataSet.GetPowerPlants());

            // Assert
            Assert.That(result["WindturbineNorth"] == 0);
            Assert.That(result["Windturbine"] == 0);
            Assert.That(result["GasFired"] == 0);
            Assert.That(result["GasFiredNorth"] == 0);
            Assert.That(result["TurboJet"] == 0);
            Assert.That(result["TurboJetNorth"] == 0);
        }
    }
}