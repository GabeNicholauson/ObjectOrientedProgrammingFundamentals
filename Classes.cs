using System;
using System.Collections.Generic;
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
            MoneyFloat = new Dictionary<int, int>()
            {
                { 1, 15 },
                { 2, 15 },
                { 5, 15 },
                { 10, 15 },
                { 20, 15 },
            };
            Inventory = new Dictionary<string, int>()
            {
                { "A", 3 },
                { "B", 2 },
                { "C", 1 },
                { "D", 4}
            };
        }
    }

    public class Product 
    {

    }


}
