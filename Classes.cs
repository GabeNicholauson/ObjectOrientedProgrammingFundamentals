using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_park
{
    static class CarPark
    {
        private static int _spotsTaken = 0;
        private static HashSet<Vehicle> _vehicles = new HashSet<Vehicle>();
        public static HashSet<ParkingSpot> ParkingSpots = new HashSet<ParkingSpot>();

        public static void ParkVehicle(Vehicle vehicle)
        {
            if (_spotsTaken == Capacity)
            {
                throw new Exception("The car park is currently full. Please remove" +
                " a car and try again");
            }

            foreach (ParkingSpot spot in ParkingSpots) 
            {
                if (spot.Vehicle == null) 
                {
                    spot.Vehicle = vehicle;
                    vehicle.ParkingSpots.Add(spot);
                    _spotsTaken++;
                    Console.WriteLine($"{vehicle.LicenseNumber} added to spot {spot.Number}");
                    return;
                }
            }
        }

        public static void RemoveVehicle(string license)
        {
            bool noCar = true;
            foreach (ParkingSpot spot in ParkingSpots)
            {
                if (spot.Vehicle != null && spot.Vehicle.LicenseNumber == license)
                {
                    spot.Vehicle.ParkingSpots.Remove(spot);
                    spot.Vehicle = null;
                    _spotsTaken--;
                    Console.WriteLine($"Removed {license} from spot {spot.Number}.");
                    noCar = false;
                }
            }
            if (noCar)
            {
                throw new Exception("That car isn't in the car park. Please try again");
            }
        }

        public static int Capacity { get; }

        // static class constructor is invoked when the program runs

        static CarPark()
        {
            Capacity = 2;
            for (int i = 1; i <= Capacity; i++)
            {
                ParkingSpots.Add(new ParkingSpot(i.ToString(), null));
            }
        }
    }

    public class Vehicle
    {
        private string _licenseNumber;
        public HashSet<ParkingSpot> ParkingSpots = new HashSet<ParkingSpot>();
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

        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }
    }

    public class ParkingSpot
    {
        public string Number { get; set; }
        public Vehicle? Vehicle { get; set; }

        public ParkingSpot(string number, Vehicle vehicle)
        {
            Number = number;
            Vehicle = vehicle;
        }
    }
}
