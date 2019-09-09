using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private Engine m_Engine;
        private float m_EnergyPercentage;
        private readonly List<Wheel> r_Wheels;
        internal Dictionary<string, string> m_VehicleInfo;

        internal Vehicle(Dictionary<string, string> i_VehicleInfo, Engine i_Engine)
        {
            m_VehicleInfo = i_VehicleInfo;
            m_ModelName = i_VehicleInfo["Model's name:"];
            m_LicenseNumber = i_VehicleInfo["Lisence number:"];
            m_Engine = i_Engine;
            m_EnergyPercentage = (i_Engine.CurrentEnergyAmount * 100 / i_Engine.MaxEnergyAmount);
            r_Wheels = CreateWheelsList();
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public Dictionary<string, string> VehicleInfo
        {
            get
            {
                return m_VehicleInfo;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        internal List<Wheel> SetOfWheels
        {
            get
            {
                return r_Wheels;
            }
        }

        public List<Wheel> CreateWheelsList()
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            string numberOfWheelsAsString = this.m_VehicleInfo["Number of wheels:"];
            int numberOfWheels = 0;
            int.TryParse(numberOfWheelsAsString, out numberOfWheels);
            for (int i = 0; i < numberOfWheels; i++)
            {
                listOfWheels.Add(new Wheel(m_VehicleInfo));
            }

            return listOfWheels;
        }

        public static List<string> GetVehicleProperties()
        {
            List<string> vehicleProperties = new List<string>();
            vehicleProperties.Add("Model's name:");
            vehicleProperties.Add("Lisence number:");
            vehicleProperties.AddRange(Wheel.GetWheelProperties());

            return vehicleProperties;
        }

        public virtual string GetVehicleData()
        {
            string vehicleData = string.Format(@"Vehicle information:
Model's name: {0}
Lisence number: {1}
Energy precentage: {2}
Manufacturer name: {3}
{4}", m_ModelName, m_LicenseNumber, m_EnergyPercentage, r_Wheels[0].ManufacturerName, r_Wheels[0].ToString());

            return vehicleData;
        }
    }
}



