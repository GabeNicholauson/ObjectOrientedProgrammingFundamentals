using Car_park;
List<CarPark> allCarParks = new List<CarPark>()
{
    new CarPark(),
    new CarPark()
};
// Creates the vehicles the user can add park
allCarParks[0].addVehicle(new Vehicle("1212"));
allCarParks[0].addVehicle(new Vehicle("fbhefb"));
allCarParks[0].addVehicle(new Vehicle("grgni3o"));
allCarParks[0].addVehicle(new Vehicle("grbub3"));

allCarParks[1].addVehicle(new Vehicle("1212"));
allCarParks[1].addVehicle(new Vehicle("fbhefb"));
allCarParks[1].addVehicle(new Vehicle("grgni3o"));
allCarParks[1].addVehicle(new Vehicle("grbub3"));

// Enter an invalid input to start interaction from beginning

while (true)
{
    string userInput;
    int selectedCarPark;

    Console.WriteLine("Which car park would you like to access? 1 or 2?");
    userInput = Console.ReadLine();

    if (userInput.Trim() == "1" || userInput.Trim() == "2")
    {
        selectedCarPark = Int32.Parse(userInput) - 1;
    } else
    {
        Console.WriteLine(userInput);
        Console.WriteLine("Sorry, that car park doesn't exist");
        continue;
    }

    Console.WriteLine("Would you like to add or remove a car from the car park?");
    userInput = Console.ReadLine();

    if (userInput.Trim().ToLower() == "add")
    {
        Console.WriteLine("Which license would you like to add");
        userInput = Console.ReadLine();

        foreach(Vehicle vehicle in allCarParks[selectedCarPark].Vehicles)
        {
            if (vehicle.LicenseNumber == userInput)
            {
                try
                {
                    allCarParks[selectedCarPark].ParkVehicle(vehicle);
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
            allCarParks[selectedCarPark].RemoveVehicle(userInput);
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

