using Car_park;

Vehicle vehicle1 = new Vehicle("1212");
Vehicle vehicle2 = new Vehicle("fbhefb");

CarPark.ParkVehicle(vehicle1);

Console.WriteLine(String.Join(", ", vehicle1.ParkingSpots));