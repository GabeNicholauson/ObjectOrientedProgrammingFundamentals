using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_park
{
    public class CarPark
    {
        /*****************************/
        /**** Properties / Fields ****/
        /*****************************/
        private int _spotsTaken = 0; // tacks how many spots are taken
        private int _capacity { get; } // the max amount of vehicles allowed in the car park
        public HashSet<Vehicle> Vehicles = new HashSet<Vehicle>(); // all vehicles
        public HashSet<ParkingSpot> ParkingSpots = new HashSet<ParkingSpot>(); // all spots

        /*****************************/
        /**** Methods ****************/
        /*****************************/
        public void ParkVehicle(Vehicle vehicle) // will park a vehicle in the closest spot
        {
            if (_spotsTaken == _capacity) // if all the spots are taken
            {
                throw new Exception("The car park is currently full. Please remove" +
                " a car and try again");
            }

            foreach (ParkingSpot spot in ParkingSpots) // check each parking spot
            {
                if (spot.Vehicle == null) // if the spot isn't taken
                {
                    spot.Vehicle = vehicle; // add the vehicle to the spot
                    vehicle.ParkingSpots.Add(spot); // add the spot to the vehicle
                    _spotsTaken++; // one more spot taken
                    Console.WriteLine($"{vehicle.LicenseNumber} added to spot {spot.Number}");
                    return;
                }
            }
        }

        public void RemoveVehicle(string license) // removes a vehicle from all spots it occupies
        {
            bool noCar = true; // tracks if that vehicle has taken a spot
            foreach (ParkingSpot spot in ParkingSpots) // go through each parking spot
            {
                if (spot.Vehicle != null && spot.Vehicle.LicenseNumber == license) // if the vehicle is found
                {
                    spot.Vehicle.ParkingSpots.Remove(spot); // remove it from the spot
                    spot.Vehicle = null; // set the spot to empty
                    _spotsTaken--; // one less spot taken
                    Console.WriteLine($"Removed {license} from spot {spot.Number}.");
                    noCar = false; // that car was in the car park
                }
            }
            if (noCar)
            {
                throw new Exception("That car isn't in the car park. Please try again");
            }
        }

        public void addVehicle(Vehicle vehicle) // adds vahicles to park
        {
            foreach(Vehicle v in Vehicles) // checks each vehicle
            {
                if (v.LicenseNumber == vehicle.LicenseNumber) // if that vehicle exists
                {
                    throw new Exception("That vehicle already exists");
                }
            }
            Vehicles.Add(vehicle);
        }

        /*****************************/
        /**** Constructors ***********/
        /*****************************/
        public CarPark()
        {
            _capacity = 2; // max capacity
            for (int i = 1; i <= _capacity; i++) // creates parking spots
            {
                ParkingSpots.Add(new ParkingSpot(i.ToString(), null, this));
            }
        }
    }

    public class Vehicle
    {
        /*****************************/
        /**** Properties / Fields ****/
        /*****************************/
        private string _licenseNumber;
        public HashSet<ParkingSpot> ParkingSpots = new HashSet<ParkingSpot>(); // Parking spots this vehicle is using
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

        /*****************************/
        /**** Constructors ***********/
        /*****************************/
        public Vehicle(string licenseNumber)
        {
            LicenseNumber = licenseNumber;
        }
    }

    public class ParkingSpot
    {
        /*****************************/
        /**** Properties / Fields ****/
        /*****************************/
        public string Number { get;}
        public Vehicle? Vehicle { get; set; }
        public CarPark ChosenCarPark { get; set; }

        /*****************************/
        /**** Constructors ***********/
        /*****************************/
        public ParkingSpot(string number, Vehicle vehicle, CarPark carPark)
        {
            Number = number;
            Vehicle = vehicle;
            ChosenCarPark = carPark;
        }
    }
}
