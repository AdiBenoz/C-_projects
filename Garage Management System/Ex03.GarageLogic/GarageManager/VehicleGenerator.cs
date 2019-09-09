using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        public enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelCar = 3,
            ElectricCar = 4,
            Truck = 5
        }

        public Dictionary<string, string> CreateSuitableVehicleDictionary(eVehicleType i_VechileType)
        {
            Dictionary<string, string> vehicleDictionaryToReturn = new Dictionary<string, string>();
            List<string> vehiclePropertisList = new List<string>();
            switch (i_VechileType)
            {
                case eVehicleType.FuelMotorcycle:
                    vehiclePropertisList = FuelEngine.GetFuelProperties();
                    vehiclePropertisList.AddRange(Motorcycle.GetMotorcycleProperties());
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehiclePropertisList = ElectricEngine.GetElectricProperties();
                    vehiclePropertisList.AddRange(Motorcycle.GetMotorcycleProperties());
                    break;
                case eVehicleType.FuelCar:
                    vehiclePropertisList = FuelEngine.GetFuelProperties();
                    vehiclePropertisList.AddRange(Car.GetCarProperties());
                    break;
                case eVehicleType.ElectricCar:
                    vehiclePropertisList = ElectricEngine.GetElectricProperties();
                    vehiclePropertisList.AddRange(Car.GetCarProperties());
                    break;
                case eVehicleType.Truck:
                    vehiclePropertisList = FuelEngine.GetFuelProperties();
                    vehiclePropertisList.AddRange(Truck.GetTruckProperties());
                    break;
            }

            foreach (string key in vehiclePropertisList)
            {
                vehicleDictionaryToReturn.Add(key, "");
            }

            return vehicleDictionaryToReturn;
        }

        //we get here a completed vehicle dictionary after asking the client all relevant questions regarding his vehicle
        //add constant values to each vehicle data
        //and validate all the values before sending them to the constructor
        public Motorcycle CreateNewFuelMotorcycle(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "2");
            i_VehicleDictionary.Add("Wheel maximal air pressure:", "33");
            i_VehicleDictionary.Add("Fuel type:", "Octan95");
            i_VehicleDictionary.Add("max fuel amount:", "8");
            validationOfFuelEngine(i_VehicleDictionary);
            validationOfMotorcycle(i_VehicleDictionary);
            validationOfWheels(i_VehicleDictionary);
            FuelEngine fuelEngine = new FuelEngine(i_VehicleDictionary);
            Motorcycle fueledMotorcycle = new Motorcycle(i_VehicleDictionary, fuelEngine);

            return fueledMotorcycle;
        }

        public Motorcycle CreateNewElectricMotorcycle(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "2");
            i_VehicleDictionary.Add("Wheel maximal air pressure:", "33");
            i_VehicleDictionary.Add("max battery time:", "1.4");
            validationOfEngine(i_VehicleDictionary["remaining battery time in hours:"], i_VehicleDictionary["max battery time:"]);
            validationOfMotorcycle(i_VehicleDictionary);
            validationOfWheels(i_VehicleDictionary);
            ElectricEngine electricEngine = new ElectricEngine(i_VehicleDictionary);
            Motorcycle electricMotorcycle = new Motorcycle(i_VehicleDictionary, electricEngine);

            return electricMotorcycle;
        }

        public Car CreateNewFuelCar(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "4");
            i_VehicleDictionary.Add("Wheel maximal air pressure:", "31");
            i_VehicleDictionary.Add("Fuel type:", "Octan96");
            i_VehicleDictionary.Add("max fuel amount:", "55");
            validationOfFuelEngine(i_VehicleDictionary);
            validationOfCar(i_VehicleDictionary);
            validationOfWheels(i_VehicleDictionary);
            FuelEngine fuelEngine = new FuelEngine(i_VehicleDictionary);
            Car fueledCar = new Car(i_VehicleDictionary, fuelEngine);

            return fueledCar;
        }

        public Car CreateNewElectricCar(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "4");
            i_VehicleDictionary.Add("Wheel maximal air pressure:", "31");
            i_VehicleDictionary.Add("max battery time:", "1.8");
            validationOfEngine(i_VehicleDictionary["remaining battery time in hours:"], i_VehicleDictionary["max battery time:"]);
            validationOfCar(i_VehicleDictionary);
            validationOfWheels(i_VehicleDictionary);
            ElectricEngine electricEngine = new ElectricEngine(i_VehicleDictionary);
            Car electricCar = new Car(i_VehicleDictionary, electricEngine);

            return electricCar;
        }

        public Truck CreateNewTruck(Dictionary<string, string> i_VehicleDictionary)
        {
            i_VehicleDictionary.Add("Number of wheels:", "12");
            i_VehicleDictionary.Add("Wheel maximal air pressure:", "26");
            i_VehicleDictionary.Add("Fuel type:", "Soler");
            i_VehicleDictionary.Add("max fuel amount:", "110");
            validationOfFuelEngine(i_VehicleDictionary);
            validationOfTruck(i_VehicleDictionary);
            validationOfWheels(i_VehicleDictionary);
            FuelEngine fuelEngine = new FuelEngine(i_VehicleDictionary);
            Truck fueledTruck = new Truck(i_VehicleDictionary, fuelEngine);

            return fueledTruck;
        }

        public Vehicle CreateNewVehicle(eVehicleType i_VechileType, Dictionary<string, string> i_VehicleDictionary)
        {
            Vehicle newVehicle = null;
            switch (i_VechileType)
            {
                case eVehicleType.FuelMotorcycle:
                    newVehicle = CreateNewFuelMotorcycle(i_VehicleDictionary);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = CreateNewElectricMotorcycle(i_VehicleDictionary);
                    break;
                case eVehicleType.FuelCar:
                    newVehicle = CreateNewFuelCar(i_VehicleDictionary);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = CreateNewElectricCar(i_VehicleDictionary);
                    break;
                case eVehicleType.Truck:
                    newVehicle = CreateNewTruck(i_VehicleDictionary);
                    break;
            }

            return newVehicle;
        }

        private static void validationOfEngine(string i_CurrentEnergyAmount, string i_MaxEnergyAmount)
        {
            float MaxEnergyAmount = PropertiesValidation.PositiveFloatValidation(i_MaxEnergyAmount);
            try
            {
                float CurrentEnergyAmount = PropertiesValidation.PositiveFloatValidation(i_CurrentEnergyAmount);
                PropertiesValidation.ValidateCurrentAmount(CurrentEnergyAmount, MaxEnergyAmount);
            }
            catch (Exception ecxeption)
            {
                throw new ArgumentException("impossible current energy amount. " + ecxeption.Message);
            }
        }

        private static void validationOfFuelEngine(Dictionary<string, string> i_FuelEngineInfo)
        {
            validationOfEngine(i_FuelEngineInfo["Current fuel amount:"], i_FuelEngineInfo["max fuel amount:"]);
            PropertiesValidation.EnumValidation<FuelEngine.eFuelType>(i_FuelEngineInfo["Fuel type:"], "fuel");
        }

        private void validationOfMotorcycle(Dictionary<string, string> i_MotorcycleInfo)
        {
            PropertiesValidation.ValidateLisenceNumber(i_MotorcycleInfo["Lisence number:"]);
            PropertiesValidation.EnumValidation<Motorcycle.eLicenseType>(i_MotorcycleInfo["License type:"], "license");
            PropertiesValidation.PositiveIntEngineCapaityValidation(i_MotorcycleInfo["Engine capacity:"]);
        }

        private void validationOfCar(Dictionary<string, string> i_CarInfo)
        {
            PropertiesValidation.ValidateLisenceNumber(i_CarInfo["Lisence number:"]);
            PropertiesValidation.EnumValidation<Car.eColor>(i_CarInfo["Car's color:"], "Car's color:");
            PropertiesValidation.ValidateNumberOfDoors(i_CarInfo["Number of doors:"]);
        }

        private void validationOfTruck(Dictionary<string, string> i_TruckInfo)
        {
            PropertiesValidation.ValidateLisenceNumber(i_TruckInfo["Lisence number:"]);
            PropertiesValidation.CheckeIfAnswerIsYesOrNo(i_TruckInfo["Carry dangerous materials:"]);
            PropertiesValidation.PositiveFloatValidation(i_TruckInfo["Carrying capacity:"]);
        }

        private void validationOfWheels(Dictionary<string, string> i_VehicleInfo)
        {
            float maximalAirPressure = PropertiesValidation.PositiveFloatValidation(i_VehicleInfo["Wheel maximal air pressure:"]);
            try
            {
                float currentAirPressure = PropertiesValidation.PositiveFloatValidation(i_VehicleInfo["Wheel current air pressure:"]);
                PropertiesValidation.ValidateCurrentAmount(currentAirPressure, maximalAirPressure);
            }
            catch (Exception ecxeption)
            {
                throw new ArgumentException("impossible wheel current air pressure. " + ecxeption.Message);
            }
        }
    }
}