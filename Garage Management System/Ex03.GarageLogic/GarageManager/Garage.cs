using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Customer> r_ListOfCostumerByLisenceNumber;
        private VehicleGenerator m_VehicleGenerator;
        private readonly Dictionary<int, string> r_GarageServices = null;

        public Garage()
        {
            r_ListOfCostumerByLisenceNumber = new Dictionary<string, Customer>();
            m_VehicleGenerator = new VehicleGenerator(); 
            r_GarageServices = new Dictionary<int, string>
            {
                { 1, "Add a new vehicle to the garage"},
                { 2, "Display all liscense numbers of the veicles in the garage by given status" },
                { 3, "Update a vehicle status" },
                { 4, "Inflate air to maximum capacity of given vehicle wheels"},
                { 5, "Refuel a Fuel vehicle"},
                { 6, "Recharge an Electric vehicle" },
                { 7, "Display given vehicle information" },
                { 8, "Leave the garage" }
            };
        }

        public Dictionary<int,string> GarageServices
        {
            get
            {
                return r_GarageServices;
            }
        }

        //Incase we would like to offer a new service in the future
        public void AddService(string i_Service)
        {
            r_GarageServices.Add(r_GarageServices.Count + 1, i_Service);
        }

        public bool AddANewVehicle(Vehicle i_Vehicle, string i_CustomerName, string i_CustomerPhone)
        {
            bool isVehicleInTheGarage = r_ListOfCostumerByLisenceNumber.TryGetValue(i_Vehicle.LicenseNumber, out Customer customer);
            if (isVehicleInTheGarage)
            {
                customer.CurrentVehicleStatus = Customer.eVehicleGarageStatus.InRepair;
                isVehicleInTheGarage = true;
            }
            else
            {
                Customer newCustomer = new Customer(i_CustomerName, i_CustomerPhone, i_Vehicle);
                r_ListOfCostumerByLisenceNumber.Add(i_Vehicle.LicenseNumber, newCustomer);
            }

            return isVehicleInTheGarage;
        }

        public string FilterLicneseNumberByGarageStatus(string i_GarageStatus)
            {
            StringBuilder filteredList = new StringBuilder();
            if (i_GarageStatus.Equals("4"))
            {
                foreach (Customer customer in r_ListOfCostumerByLisenceNumber.Values)
                {
                    filteredList.AppendLine(customer.Vehicle.LicenseNumber);
                }
            }
            else
            {
                int optionNumber = int.Parse(i_GarageStatus);
                Customer.eVehicleGarageStatus status = (Customer.eVehicleGarageStatus)optionNumber;
                foreach (Customer customer in r_ListOfCostumerByLisenceNumber.Values)
                {
                    if (customer.CurrentVehicleStatus == status)
                    {
                        filteredList.AppendLine(customer.Vehicle.LicenseNumber);
                    }
                }
            }

            return filteredList.ToString();
        }

        public void UpdateVehicleStatus(string i_LicesnseNumber, string i_GarageStatus)
        {
            int optionNumber = int.Parse(i_GarageStatus);
            Customer customer = GetCustomer(i_LicesnseNumber);
            Customer.eVehicleGarageStatus updatedStatus = (Customer.eVehicleGarageStatus)optionNumber;
            customer.CurrentVehicleStatus = updatedStatus;
        }

        public void InflateWheelsToMaxAirPressure(string i_LicenseNumber)
        {
            Customer customer = GetCustomer(i_LicenseNumber);
            foreach (Wheel wheel in customer.Vehicle.SetOfWheels)
            {
                    wheel.InflatingWheel(wheel.MaximalAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void Refuel(string i_LicenseNumber, string i_FuelType, string i_FuelAmountToAdd)
        {
            Customer customer = GetCustomer(i_LicenseNumber);
            if(!(customer.Vehicle.Engine is FuelEngine))
            {
                throw new ArgumentException("Cannot refuel electric engine");
            }

            int optionNumber = int.Parse(i_FuelType);
            FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)optionNumber;
            float amountToAdd = PropertiesValidation.PositiveFloatValidation(i_FuelAmountToAdd);
            ((FuelEngine)(customer.Vehicle.Engine)).Refuel(amountToAdd, fuelType);
        }

        public void Recharge(string i_LicenseNumber, string i_MinuetsToCharge)
        {
            Customer customer = GetCustomer(i_LicenseNumber);
            if(!(customer.Vehicle.Engine is ElectricEngine))
            {
                throw new ArgumentException("Cannot recharge fuel engine");
            }

            float minuetsToAddToBattery = PropertiesValidation.PositiveFloatValidation(i_MinuetsToCharge);
            ((ElectricEngine)(customer.Vehicle.Engine)).Recharge(minuetsToAddToBattery/ 60);
        }

        public string DisplayVeichelData(string i_LicenseNumber)
        {
            Customer customer = GetCustomer(i_LicenseNumber);

            return customer.ToString();
        }

        public Customer GetCustomer(string i_LicesnseNumber)
        {
           Customer customer = null;
           bool costumerIsInGarage = r_ListOfCostumerByLisenceNumber.TryGetValue(i_LicesnseNumber, out customer);
           if (!costumerIsInGarage)
           {
               throw new ArgumentException("You are not in our system, please add your vehicle to the garage");
           }

           return customer;
        }
    }
}
