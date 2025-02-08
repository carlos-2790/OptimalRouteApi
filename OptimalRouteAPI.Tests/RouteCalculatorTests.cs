using OptimalRouteAPI.Models;
using OptimalRouteAPI.Services;
using Xunit;

namespace OptimalRouteAPI.Tests
{
    public class RouteCalculatorTests
    {
        [Fact]
        public void CalculateOptimalRoute_ShouldReturnCorrectRoute()
        {
            // Arrange
            var request = new OptimalRouteRequest
            {
                Cities = new List<string> { "A", "B", "C", "D" },
                Roads = new List<Road>
                {
                    new Road { From = "A", To = "B", Time = 10 },
                    new Road { From = "B", To = "C", Time = 15 },
                    new Road { From = "A", To = "C", Time = 30 },
                    new Road { From = "C", To = "D", Time = 5 },
                    new Road { From = "B", To = "D", Time = 25 }
                },
                Origin = "A",
                Destination = "D"
            };

            var routeCalculator = new RouteCalculator();

            // Act
            var result = routeCalculator.CalculateOptimalRoute(request);

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result.Route);
            Assert.Equal(30, result.TotalTime);
        }
    }
}