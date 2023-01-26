using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_Lab1
{
    public class VendingMachine
    {   /********************/
        /**** Properties ****/
        /********************/
        public int SerialNumber
        {
            get;
        }

        public Dictionary<int, int> MoneyFloat
        {
            get; set;
        }

        public Dictionary<Product, int> Inventory
        {
            get; set;
        }
        /*****************/
        /**** Methods ****/
        /*****************/
        public string StockItem(Product product, int quantity)
        {

            for (int i = 0; i < Inventory.Count; i++)
            {
                Product key = Inventory.ElementAt(i).Key;
                if (key.Name == product.Name && key.Code == product.Code && key.Price == product.Price)
                {
                    Console.WriteLine("hello");
                    Inventory[key] += quantity;
                    return $"\n{key.Name}\nCode: {key.Code}\nPrice: {key.Price}\nStock: {Inventory[key]}\n";
                }
            }
            
            Inventory.Add(product, quantity);
            return $"\n{product.Name}\nCode: {product.Code}\nPrice: {product.Price}\nStock: {quantity}\n";
        }

        public string StockFloat(int moneyDenomination, int quantity)
        {
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
            } else if (MoneyFloat.Count == 0 || moneyDenomination > MoneyFloat.ElementAt(MoneyFloat.Count - 1).Key)
            {
                MoneyFloat.Add(moneyDenomination, quantity);
            } else
            { 
                List<int> keys = MoneyFloat.Keys.ToList();
                List<int> values = MoneyFloat.Values.ToList();
                MoneyFloat.Clear();

                for (int i = 0; i < keys.Count; i ++)
                {
                    if (keys[i] > moneyDenomination)
                    {
                        keys.Insert(i, moneyDenomination);
                        values.Insert(i, quantity);
                        break;
                    }
                }

                for (int i = 0; i < keys.Count; i++)
                {
                    MoneyFloat.Add(keys[i], values[i]);
                }
            }
            return String.Join(": \n", MoneyFloat);
        }

        public string VendItem(string code, List<int> money)
        {
            int moneyInserted = 0;
            int change = 0;
            int index;           
            bool matchingCode = false;
            Product product = null;

            for (int i = 0; i < Inventory.Count; i++)
            {
                product = Inventory.ElementAt(i).Key;

                if (product.Code == code)
                {
                    matchingCode = true; 
                    break;
                }
            }
            if (!matchingCode)
                return $"Sorry, could not find a product with code \"{code}\"\n";

            if (Inventory[product] == 0)
                return "Sorry, that item isn't currently available\n";

            foreach (int coin in money)
                moneyInserted += coin;

            if (moneyInserted < product.Price)
                return "Sorry, you do not have sufficient funds for that item\n";
            else
                moneyInserted -= product.Price;

            if (MoneyFloat.Count == 0) return "Sorry, we don't have enough change, please try again\n";

            index = MoneyFloat.Count - 1;
            while (moneyInserted > 0) // If the user needs change
            {
                for (int i = 0; i < MoneyFloat.Count; i++) // check entire dictionary. Linear O(n).
                {
                    if (MoneyFloat.ElementAt(index).Value <= 0) index--; // if there aren't coins of that type, move on to the next
                    else break; // there are coins of that type, so stop checking

                    if (index < 0) // if there are no more coins in the machine
                    {
                        return "Sorry, we don't have enough change, please try again\n";
                    }
                }

                int coinType = MoneyFloat.ElementAt(index).Key; // makes code more readable
                if (moneyInserted >= coinType) // Will return the highest value coins first
                {
                    moneyInserted -= coinType; // Substracts that amount from the left over money
                    MoneyFloat[coinType]--; // one less coin of that value in the machine
                    change += coinType; // tracks that coin as change
                    continue; // restart loop
                }
                else if (index > 0) // if the coin value is too high
                {
                    index--; // move down a coin
                    continue; // restart the loop
                }
                break;
            }
            return $"Enjoy your {product.Name} and your change of ${change}\n";
        }
        /**********************/
        /**** Constructors ****/
        /**********************/
        public VendingMachine()
        {
            Random random= new Random();
            SerialNumber = random.Next();
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<Product, int>();
        }
    }

    public class Product
    {
        /********************/
        /**** Properties ****/
        /********************/
        public string Code
        {
            get;
        }

        public int Price
        {
            get;
        }

        public string Name
        {
            get;
        }

        /**********************/
        /**** Constructors ****/
        /**********************/
        public Product(string name, int price, string code)
        {
            Name = name;
            Price = price;
            Code = code;

        }
    }
}