using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository
{
    public enum FuelType
    {
        StandardGas = 1,
        Electric,
        Hybrid
    }

    public enum VehicleType
    {
        Car = 1,
        Truck,
        SUV,
        Van,
        Motorcycle
    }

    // Possibly need to create classes for electric, hybrid, standard gas all : Vehicle, need lists
    public class VehicleContent
    {
        public FuelType TypeOfFuelSource { get; set; }
        public decimal PriceOfVehicle { get; set; }
        public double MPG { get; set; } 
        public decimal PriceOfBatteries { get; set; }
        public decimal PriceOfFuel { get; set; }
        public VehicleType TypeOfVehicle { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public VehicleContent() { }

        public VehicleContent(FuelType fuelSource, decimal priceOfVehicle, double mPG, decimal priceOfBatteries, decimal priceOfFuel, VehicleType typeOfVehicle, string make, string model, int year)
        {
            TypeOfFuelSource = fuelSource;
            PriceOfVehicle = priceOfVehicle; // MSRP
            MPG = mPG; // City
            PriceOfBatteries = priceOfBatteries; // Max
            PriceOfFuel = priceOfFuel; // Current
            TypeOfVehicle = typeOfVehicle;
            Make = make;
            Model = model;
            Year = year;
        }
    }



}
