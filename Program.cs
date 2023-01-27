using Car_park;

// Creates the vehicles the user can add park
CarPark.addVehicle(new Vehicle("1212"));
CarPark.addVehicle(new Vehicle("fbhefb"));
CarPark.addVehicle(new Vehicle("grgni3o"));
CarPark.addVehicle(new Vehicle("grbub3"));

while (true)
{
    Console.WriteLine("Would you like to add or remove a car from the car park?");
    string userInput = Console.ReadLine();

    if (userInput.Trim().ToLower() == "add")
    {
        Console.WriteLine("Which license would you like to add");
        userInput = Console.ReadLine();

        foreach(Vehicle vehicle in CarPark.Vehicles)
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
    } else if (userInput.Trim().ToLower() == "remove")
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

