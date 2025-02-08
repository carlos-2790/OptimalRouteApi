using Microsoft.AspNetCore.Mvc;
using OptimalRouteAPI.Models;
using OptimalRouteAPI.Services;

namespace OptimalRouteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptimalRouteController : ControllerBase
    {
        private readonly RouteCalculator _routeCalculator;

        public OptimalRouteController(RouteCalculator routeCalculator)
        {
            _routeCalculator = routeCalculator;
        }

        [HttpPost("optimal-route")]
        public IActionResult CalculateOptimalRoute([FromBody] OptimalRouteRequest request)
        {
            var response = _routeCalculator.CalculateOptimalRoute(request);
            return Ok(response);
        }
    }
}