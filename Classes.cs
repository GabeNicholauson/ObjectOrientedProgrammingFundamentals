using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingFundamentals_Lab1
{
    public class VendingMachine
    {
        /**** Properties ****/
        public int SerialNumber
        {
            get;
        }

        public Dictionary<int, int> MoneyFloat
        {
            get; set;
        }

        public Dictionary<string, int> Inventory
        {
            get; set;
        }
        /**** Methods ****/

        /**** Constructors ****/
        public VendingMachine() 
        {
            SerialNumber = 15434123;
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<string, int>();
        }
    }

    public class Product 
    {
        /**** Properties ****/
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

        /**** Constructors ****/
        public Product(string name, int price, int code  )
        {
            Name = name;
            Price = price;
            Code = code;

        }
    }


}
