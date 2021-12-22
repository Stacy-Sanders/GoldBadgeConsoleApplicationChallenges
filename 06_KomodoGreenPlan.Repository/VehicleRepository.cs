using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository
{
    public class VehicleRepository
    {
        private List<VehicleContent> _vehicleContent = new List<VehicleContent>();

        // Create
        public void AddContentToList(VehicleContent content)
        {
            _vehicleContent.Add(content);
        }

        // Read
        public List<VehicleContent> GetContentList()
        {
            return _vehicleContent;
        }

        // Read - Helper Methods
        // 1
        public VehicleContent GetVehicleByFuelSource(FuelType fuelSource)
        {
            foreach (VehicleContent content in _vehicleContent)
            {
                if (content.TypeOfFuelSource == fuelSource)
                {
                    return content;
                }
            }

            return null;
        }
        // 2
        public VehicleContent GetVehicleByModel(string model)
        {
            foreach (VehicleContent content in _vehicleContent)
            {
                if (content.Model.ToLower() == model.ToLower())
                {
                    return content;
                }
            }

            return null;
        }

        // Update
        public bool UpdateExistingVehicles(string originalVehicle, VehicleContent newVehicle)
        {
            // Find the content
            VehicleContent oldVehicle = GetVehicleByModel(originalVehicle);

            // Update the vehicle
            if (oldVehicle != null)
            {
                oldVehicle.TypeOfFuelSource = newVehicle.TypeOfFuelSource;
                oldVehicle.PriceOfVehicle = newVehicle.PriceOfVehicle;
                oldVehicle.MPG = newVehicle.MPG;
                oldVehicle.PriceOfBatteries = newVehicle.PriceOfBatteries;
                oldVehicle.PriceOfFuel = newVehicle.PriceOfFuel;
                oldVehicle.TypeOfVehicle = newVehicle.TypeOfVehicle;
                oldVehicle.Make = newVehicle.Make;
                oldVehicle.Model = newVehicle.Model;
                oldVehicle.Year = newVehicle.Year;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveContentFromList(string model)
        {
            VehicleContent content = GetVehicleByModel(model);
            if (content == null)
            {
                return false;
            }

            int initialCount = _vehicleContent.Count;
            _vehicleContent.Remove(content);

            if (initialCount > _vehicleContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
