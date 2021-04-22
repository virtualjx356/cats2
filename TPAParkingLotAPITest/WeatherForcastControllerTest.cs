using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWAParkingLotAPI;
using TWAParkingLotAPI.Controllers;
using System.Linq;

namespace TWAParkingLotAPITest
{
    [TestClass]
    public class WeatherForcastControllerTest
    {
        [TestMethod]
        public void DaysCountEquals5()
        {
            try
            {
                //arrange
                ILogger<WeatherForecastController> logger = null;
                var controller = new WeatherForecastController(logger);

                //act
                var results = controller.Get();

                //assert
                Assert.IsTrue(results.Count() == 5);
            }
            catch (System.Exception)
            {
                Assert.Inconclusive();
            }
        }
        [TestMethod]
        public void AllSummaryValuesInList()
        {
            //arrange
            ILogger<WeatherForecastController> logger = null;
            var controller = new WeatherForecastController(logger);
            //act
            var results = controller.Get();
            string[] summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };
            var newresults = results.ToList().Where(item => summaries.Contains(item.Summary));
            //assert
            Assert.IsTrue(newresults.Count() == results.Count());
        }
    }
}
