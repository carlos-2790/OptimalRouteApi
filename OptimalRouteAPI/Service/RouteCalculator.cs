using System;
using OptimalRouteAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OptimalRouteAPI.Services
{
    public class RouteCalculator
    {
        public OptimalRouteResponse CalculateOptimalRoute(OptimalRouteRequest request)
        {
            var cities = request.Cities;
            var roads = request.Roads;
            var origin = request.Origin;
            var destination = request.Destination;

            // Crear un grafo con las ciudades y carreteras
            var graph = new Dictionary<string, Dictionary<string, int>>();
            foreach (var city in cities)
            {
                graph[city] = new Dictionary<string, int>();
            }

            foreach (var road in roads)
            {
                graph[road.From][road.To] = road.Time;
            }

            // Dijkstra's algorithm
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string?>();
            var unvisited = new List<string>();

            foreach (var city in cities)
            {
                distances[city] = int.MaxValue;
                previous[city] = null;
                unvisited.Add(city);
            }

            distances[origin] = 0;

            while (unvisited.Any())
            {
                var current = unvisited.OrderBy(c => distances[c]).First();
                unvisited.Remove(current);

                if (current == destination)
                    break;

                foreach (var neighbor in graph[current])
                {
                    var alt = distances[current] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = current;
                    }
                }
            }

            // Reconstruir la ruta
            var route = new List<string>();
            var currentCity = destination;

            while (currentCity != null && previous.ContainsKey(currentCity))
            {
                route.Insert(0, currentCity);
                currentCity = previous[currentCity];
            }

            return new OptimalRouteResponse
            {
                Route = route,
                TotalTime = distances[destination]
            };
        }
    }
}