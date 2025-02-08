namespace OptimalRouteAPI.Models
{
    public class OptimalRouteResponse
    {
        public List<string> Route { get; set; } = new List<string>();
        public int TotalTime { get; set; }
    }
}