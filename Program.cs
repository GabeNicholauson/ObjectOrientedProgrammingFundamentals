using Car_park;

Vehicle vehicle1 = new Vehicle("1212");
Vehicle vehicle2 = new Vehicle("fbhefb");
Vehicle vehicle3 = new Vehicle("grgni3o");
Vehicle vehicle4 = new Vehicle("grbub3");

HashSet<Vehicle> allVehicles = new HashSet<Vehicle>()
{
    vehicle1,
    vehicle2, 
    vehicle3, 
    vehicle4
};

while (true)
{
    Console.WriteLine("Would you like to add or remove a car from the car park?");
    string userInput = Console.ReadLine();

    if (userInput.ToLower() == "add")
    {
        Console.WriteLine("Which license would you like to add");
        userInput = Console.ReadLine();

        foreach(Vehicle vehicle in allVehicles)
        {
            if (vehicle.LicenseNumber == userInput)
            {
                try
                {
                    CarPark.ParkVehicle(vehicle);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    } else if (userInput.ToLower() == "remove")
    {
        Console.WriteLine("Which license would you like to remove");
        userInput = Console.ReadLine();

        try
        {
            CarPark.RemoveVehicle(userInput);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

