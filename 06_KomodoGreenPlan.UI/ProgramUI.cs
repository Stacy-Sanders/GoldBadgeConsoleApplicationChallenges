using _06_KomodoGreenPlan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.UI
{
    public class ProgramUI
    {
        private VehicleRepository _vehicleRepo = new VehicleRepository();

        //Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the KI employee
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Vehicle\n" +
                    "2. View All Vehicles\n" +
                    "3. View Items By Fuel Source\n" +
                    "4. Update Existing Vehicles\n" +
                    "5. Delete Existing Vehicles\n" +
                    "6. Exit");

                // Get KI employee's input
                string input = Console.ReadLine();

                // Evaluate KI employee's input and proceed as directed
                switch (input)
                {
                    case "1":
                        // Create New Vehicle
                        CreateNewVehicle();
                        break;
                    case "2":
                        // View All Vehicle
                        DisplayAllVehicles();
                        break;
                    case "3":
                        // View Vehicle By Fuel Source
                        DisplayAllVehiclesByFuelSource();
                        break;
                    case "4":
                        // Update Existing Vehicles
                        UpdateExistingVehicles();
                        break;
                    case "5":
                        // Delete Existing Vehicles
                        DeleteExistingVehicles();
                        break;
                    case "6":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Create new Menu Content
        private void CreateNewVehicle()
        {
            Console.Clear();
            VehicleContent newVehicle = new VehicleContent();

            // Fuel Source
            Console.WriteLine("Enter the fuel source number:\n" +
                "1. Standard Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            string fuelSourceAsString = Console.ReadLine();
            int fuelSourceAsInt = int.Parse(fuelSourceAsString);
            newVehicle.TypeOfFuelSource = (FuelType)fuelSourceAsInt;

            // Price of Vehicle
            Console.WriteLine("Enter the Price of the Vehicle:");
            string priceOfVehicleAsString = Console.ReadLine();
            newVehicle.PriceOfVehicle = decimal.Parse(priceOfVehicleAsString);

            // MPG
            Console.WriteLine("Enter the vehicle's MPG:");
            string mPGAsString = Console.ReadLine();
            newVehicle.MPG = double.Parse(mPGAsString);

            // Price of Batteries
            Console.WriteLine("Enter the Price of Batteries for the vehicle:");
            string priceOfBatteriesAsString = Console.ReadLine();
            newVehicle.PriceOfBatteries = decimal.Parse(priceOfBatteriesAsString);

            // Price of Fuel
            Console.WriteLine("Enter the Price of Fuel for the vehicle:");
            string priceOfFuelAsString = Console.ReadLine();
            newVehicle.PriceOfFuel = decimal.Parse(priceOfFuelAsString);

            // Vehicle Type
            Console.WriteLine("Enter the vehicle Type number:\n" +
                "1. Car\n" +
                "2. Truck\n" +
                "3. SUV\n" +
                "4. Van\n" +
                "5. Motorcycle");

            string vehicleTypeAsString = Console.ReadLine();
            int vehicleTypeAsInt = int.Parse(vehicleTypeAsString);
            newVehicle.TypeOfVehicle = (VehicleType)vehicleTypeAsInt;

            // Make
            Console.WriteLine("Enter the vehicle Make:");
            newVehicle.Make = Console.ReadLine();

            // Model
            Console.WriteLine("Enter the vehicle Model:");
            newVehicle.Model = Console.ReadLine();

            // Year
            Console.WriteLine("Enter the Vehicle Year:");
            string yearAsString = Console.ReadLine();
            newVehicle.Year = int.Parse(yearAsString);

            _vehicleRepo.AddContentToList(newVehicle);
        }

        // View current Vehicle content
        private void DisplayAllVehicles()
        {
            Console.Clear();

            List<VehicleContent> vehicleContent = _vehicleRepo.GetContentList();

            foreach (VehicleContent content in vehicleContent)
            {
                Console.WriteLine($"Fuel Source:  {content.TypeOfFuelSource}\n" +
                    $"Make: {content.Make}\n" +
                    $"Model: {content.Model}");
            }
        }

        // View existing content by Fuel Source

        private void DisplayAllVehiclesByFuelSource()
        {
            Console.Clear();
            // Prompt the KI employee to supply a Fuel Source
            Console.WriteLine("Enter the Fuel Source Type of the vehicles you'd like to see:\n" +
                "1. Standard Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            // Get the employee's input
            string fuelSourceAsString = Console.ReadLine();
            int fuelSourceAsInt = int.Parse(fuelSourceAsString);
            var fuelSource = (FuelType)fuelSourceAsInt; 

            // Find the content by that title
            VehicleContent content = _vehicleRepo.GetVehicleByFuelSource(fuelSource);

            // Display info if not null
            if (content != null)
            {
                Console.WriteLine($"Fuel Source: {content.TypeOfFuelSource}\n" +
                    $"Price of Vehicle: {content.PriceOfVehicle}\n" +
                    $"MPG: {content.MPG}\n" +
                    $"Price of Batteries: {content.PriceOfBatteries}\n" +
                    $"Price of Fuel: {content.PriceOfFuel}\n" +
                    $"Vehicle Type: {content.TypeOfVehicle}\n" +
                    $"Make: {content.Make}\n" +
                    $"Model: {content.Model}\n" +
                    $"Year: {content.Year}");
            }
            else
            {
                Console.WriteLine("No vehicle by that Fuel Source Type.");
            }
        }
        
        // Update Existing Vehicles
        private void UpdateExistingVehicles()
        {
            // Display all items
            DisplayAllVehicles();

            // Ask for the vehicle model to update
            Console.WriteLine("Enter the Model of the vehicle you would like to update:");

            // Get that title
            string oldModel = Console.ReadLine();

            // Build a new object
            VehicleContent newVehicle = new VehicleContent();

            // Fuel Source
            Console.WriteLine("Enter the fuel source number:\n" +
                "1. Standard Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            string fuelSourceAsString = Console.ReadLine();
            int fuelSourceAsInt = int.Parse(fuelSourceAsString);
            newVehicle.TypeOfFuelSource = (FuelType)fuelSourceAsInt;

            // Price of Vehicle
            Console.WriteLine("Enter the Price of the Vehicle:");
            string priceOfVehicleAsString = Console.ReadLine();
            newVehicle.PriceOfVehicle = decimal.Parse(priceOfVehicleAsString);

            // MPG
            Console.WriteLine("Enter the vehicle's MPG:");
            string mPGAsString = Console.ReadLine();
            newVehicle.MPG = double.Parse(mPGAsString);

            // Price of Batteries
            Console.WriteLine("Enter the Price of Batteries for the vehicle:");
            string priceOfBatteriesAsString = Console.ReadLine();
            newVehicle.PriceOfBatteries = decimal.Parse(priceOfBatteriesAsString);

            // Price of Fuel
            Console.WriteLine("Enter the Price of Fuel for the vehicle:");
            string priceOfFuelAsString = Console.ReadLine();
            newVehicle.PriceOfFuel = decimal.Parse(priceOfFuelAsString);

            // Vehicle Type
            Console.WriteLine("Enter the vehicle Type number:\n" +
                "1. Car\n" +
                "2. Truck\n" +
                "3. SUV\n" +
                "4. Van\n" +
                "5. Motorcycle");

            string vehicleTypeAsString = Console.ReadLine();
            int vehicleTypeAsInt = int.Parse(vehicleTypeAsString);
            newVehicle.TypeOfVehicle = (VehicleType)vehicleTypeAsInt;

            // Make
            Console.WriteLine("Enter the vehicle Make:");
            newVehicle.Make = Console.ReadLine();

            // Model
            Console.WriteLine("Enter the vehicle Model:");
            newVehicle.Model = Console.ReadLine();

            // Year
            Console.WriteLine("Enter the Vehicle Year:");
            string yearAsString = Console.ReadLine();
            newVehicle.Year = int.Parse(yearAsString);

            // Verify the update was successful
            bool wasUpdated = _vehicleRepo.UpdateExistingVehicles(oldModel, newVehicle);

            if (wasUpdated)
            {
                Console.WriteLine("Vehicle successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update vehicle.");
            }
        }
            
        
        // Delete Existing Vehicles
        private void DeleteExistingVehicles()
        {
            DisplayAllVehicles();

            // Get the Model the KI employee wants to remove
            Console.WriteLine("\nEnter the Model of the vehicle you want to remove:");

            string input = Console.ReadLine();

            // Call the delete method
            bool wasDeleted = _vehicleRepo.RemoveContentFromList(input);

            // If the item was deleted - acknowledge true or false statements
            if (wasDeleted)
            {
                Console.WriteLine("The item was succesfully deleted.");
            }
            else
            {
                Console.WriteLine("The vehicle could not be deleted.");
            }
        }
        
            // Seed method - testing
            private void SeedContentList()
            {
                VehicleContent fordMustangMachE = new VehicleContent(FuelType.Electric, 42895m, 108, 250m, 3.30m, VehicleType.Car, "Ford", "Mustang Mach-E", 2021);
                VehicleContent toyotaRav4Hybrid = new VehicleContent(FuelType.Hybrid, 28350m, 41, 4000m, 3.30m, VehicleType.SUV, "Toyota", "RAV4 Hybrid", 2020);
                VehicleContent mazdaCx5 = new VehicleContent(FuelType.StandardGas, 22000m, 24, 120m, 3.30m, VehicleType.SUV, "Mazda", "CX-5", 2017);
                VehicleContent indianScout = new VehicleContent(FuelType.StandardGas, 8999m, 33, 400m, 3.30m, VehicleType.Motorcycle, "Indian", "Scout", 2021);
                VehicleContent ram1500Hybrid = new VehicleContent(FuelType.Hybrid, 36340m, 20, 2472m, 3.58m, VehicleType.Truck, "RAM", "1500 Hybrid", 2021);


                _vehicleRepo.AddContentToList(fordMustangMachE);
                _vehicleRepo.AddContentToList(toyotaRav4Hybrid);
                _vehicleRepo.AddContentToList(mazdaCx5);
                _vehicleRepo.AddContentToList(indianScout);
                _vehicleRepo.AddContentToList(ram1500Hybrid);
            }
    }
}

        

    

    
