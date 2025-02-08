namespace OptimalRouteAPI.Models
{
    public class OptimalRouteRequest
    {
        public List<string> Cities { get; set; } = new List<string>();
        public List<Road> Roads { get; set; } = new List<Road>();
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
    }
}