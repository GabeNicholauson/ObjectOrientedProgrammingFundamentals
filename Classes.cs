using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_park
{
    static class CarPark
    {
        private static HashSet<Vehicle> _vehicles = new HashSet<Vehicle>();

        public static void Park(Vehicle vehicle)
        {
            if (_vehicles.Count >= Capacity)
            {
                throw new Exception("No remaining capacity in carpark");
            }
            else if (vehicle.ParkingSpot != null)
            {
                throw new Exception($"Vehicle parked in spot {vehicle.ParkingSpot}");
            }
            else
            {
                _vehicles.Add(vehicle);
                vehicle.ParkingSpot = _spotCount.ToString();
                _spotCount++;

                Console.WriteLine($"Vehicle with liscense {vehicle.LicenseNumber}" +
                    $"parking in spot {vehicle.ParkingSpot}");
                Console.WriteLine($"{Capacity - _vehicles.Count} spots remaining");
            }
        }

        public static int Capacity { get; }
        private static int _spotCount = 1;

        // static class constructor is invoked when the program runs

        static CarPark()
        {
            Capacity = 300;
        }
    }

    public class Vehicle
    {
        private string _licenseNumber;
        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set
            {
                if (value.Length < 2 || value.Length > 7 || value.Contains(" "))
                {
                    throw new Exception("Plate must be alphanumeric between 3 and 7 characters");
                }
                else
                {
                    _licenseNumber = value;
                }
            }

        }

        private string? _parkingSpot;
        public string ParkingSpot
        {
            get { return _parkingSpot; }
            set { _parkingSpot = value; }
        }

        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }
    }
}
