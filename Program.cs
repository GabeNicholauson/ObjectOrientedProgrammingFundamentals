/*
 * Lab 1
 * Gabriel Nicholauson
 * 
 * Refactor vending machine to be object-oriented
*/
using ObjectOrientedProgrammingFundamentals_Lab1;

VendingMachine machine= new VendingMachine();
string userInput;

while (true) {
    Console.WriteLine("What would you like to do\n1: Stock item\n2: Add money to machine\n3: purchase item\n");
    userInput = Console.ReadLine();

    if (userInput == "1")
    {
        string productName;
        string productCode;
        int productPrice;
        int quantity;

        Console.WriteLine("\nPlease enter the name of the product");
        productName = Console.ReadLine();

        Console.WriteLine("\nPlease enter the code of the product");
        productCode = Console.ReadLine();

        Console.WriteLine("\nPlease enter the price of the product");
        userInput = Console.ReadLine();
        while(!userInput.All(char.IsDigit) || Int32.Parse(userInput) <= 0)
        {
            Console.WriteLine("\nPlease enter a whole number above 0");
            userInput = Console.ReadLine();
        }
        productPrice = Int32.Parse(userInput);

        Console.WriteLine("\nPlease enter the quantity of the product");
        userInput = Console.ReadLine();
        while (!userInput.All(char.IsDigit) || Int32.Parse(userInput) <= 0)
        {
            Console.WriteLine("\nPlease enter a whole number above 0");
            userInput = Console.ReadLine();
        }
        quantity = Int32.Parse(userInput);

        Product product = new Product(productName, productPrice, productCode );
        Console.WriteLine(machine.StockItem(product, quantity));
        continue;
    }

    if (userInput == "2")
    {
        int coin;
        int quantity;

        Console.WriteLine("Enter the type of coin you would like to add to the machine\n");
        userInput = Console.ReadLine();
        while (!userInput.All(char.IsDigit) || Int32.Parse(userInput) <= 0)
        {
            Console.WriteLine("\nPlease enter a whole number above 0");
            userInput = Console.ReadLine();
        }
        coin = Int32.Parse(userInput);

        Console.WriteLine("Enter how many you would like to add to the machine\n");
        userInput = Console.ReadLine();
        while (!userInput.All(char.IsDigit) || Int32.Parse(userInput) <= 0)
        {
            Console.WriteLine("\nPlease enter a whole number above 0");
            userInput = Console.ReadLine();
        }
        quantity = Int32.Parse(userInput);

        Console.WriteLine(machine.StockFloat(coin, quantity));
        continue;
    }

    if (userInput == "3")
    {
        List<int> coins = new List<int>();
        string code;
        bool stop = false;

        if (machine.Inventory.Count == 0) 
        {
            Console.WriteLine("There are no items in the machine, please add some and try again\n");
            continue;
        }

        Console.WriteLine("Please enter coins (Enter \"stop\" to move on)");
        userInput = Console.ReadLine();
        while (!stop)
        {
            if (userInput.ToLower() == "stop")
            {
                stop = true;
                continue;
            }
            else if (!userInput.All(char.IsDigit) || userInput.Length == 0)
            {
                Console.WriteLine("\nPlease enter a positive number");
                userInput = Console.ReadLine();
                continue;
            }
            else
            {
                coins.Add(Int32.Parse(userInput));
            }
            userInput = Console.ReadLine();
        }

        Console.WriteLine("Please enter a code");
        code = Console.ReadLine();

        Console.WriteLine(machine.VendItem(code, coins));

    }
}
