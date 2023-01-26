using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
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
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += quantity;
                return $"{product.Name}\nCode: {product.Code}\nPrice: {product.Price}\nStock: {Inventory[product]}";
            } else
            {
                Inventory.Add(product, quantity);
                return $"{product.Name}\nCode: {product.Code}\nPrice: {product.Price}\nStock: {quantity}";
            }  
        }

        public string StockFloat(int moneyDenomination, int quantity)
        {
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
                return $"${moneyDenomination}: {quantity}";
            } else
            {
                MoneyFloat.Add(moneyDenomination, quantity);
                return $"${moneyDenomination}: {MoneyFloat[moneyDenomination]}";
            }
        }

        public void VendItem(string code, List<int> money)
        {

        }
        /**********************/
        /**** Constructors ****/
        /**********************/
        public VendingMachine() 
        {
            SerialNumber = 15434123;
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<Product, int>();
        }
    }

    public class Product 
    {
        /********************/
        /**** Properties ****/
        /********************/
        public int Code
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
        public Product(string name, int price, int code  )
        {
            Name = name;
            Price = price;
            Code = code;

        }
    }


}
