# OptimalRouteApi

## Description
OptimalRouteApi is an API designed to calculate the optimal route between two cities using Dijkstra's algorithm to find the shortest path in terms of time. The API receives a list of cities and roads, along with a starting city and destination, and returns the optimal route and total travel time.

## Approach
The project uses ASP.NET Core to implement a RESTful API. A model for the requests includes the cities, roads, and the origin and destination cities. The `RouteCalculator` service implements Dijkstra's algorithm to calculate the shortest route.

## Challenges and Solutions
- **Dependency Management**: The `dockerfile` was used to ensure all necessary dependencies are present and to build a consistent environment for the application.
- **Implementing Dijkstra's Algorithm**: The challenge of efficiently implementing the algorithm was faced. Data structures such as dictionaries were chosen to maintain quick access time during the algorithm operations.

## Instructions for Running the Project Locally

### Prerequisites
- Docker
- .NET SDK 8.0

### Steps to Run
1. Clone the repository:
   ```
   git clone https://github.com/carlos-2790/OptimalRouteApi.git
   ```
2. Navigate to the project directory:
   ```
   cd [Project Directory Name]
   ```
3. Build the Docker image:
   ```
   docker build -t optimalrouteapi .
   ```
4. Run the image as a container:
   ```
   docker run -p 8080:80 optimalrouteapi
   ```
5. Access the API via `http://localhost:5000/api/OptimalRoute/optimal-route`.

### Testing Instructions
1. Navigate to the test directory:
   ```
   cd \OptimalRouteApi\OptimalRouteAPI.Tests
   ```
2. Execute the tests:
   ```
   dotnet test
   ```

## Contact
For more information, contact [Carlos Yaben] at [carlosyaben@gmail.com].
