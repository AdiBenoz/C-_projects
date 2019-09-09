using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            B =1,
            A2 = 2,
            A1 = 3,
            A = 4
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        internal Motorcycle(Dictionary<string, string> i_MotorcycleInfo, Engine i_Engine) : base(i_MotorcycleInfo, i_Engine)
        {
            m_LicenseType = PropertiesValidation.EnumTryParse<eLicenseType>(i_MotorcycleInfo["License type:"], "License type");
            m_EngineCapacity = int.Parse(i_MotorcycleInfo["Engine capacity:"]);
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public override string GetVehicleData()
        {
            string motorcycleData = string.Format(@"{0}
{1}
Motorcycle License Type: {2}
Motorcycle Engine capacity: {3}", base.GetVehicleData(), base.Engine.ToString(), m_LicenseType, m_EngineCapacity);

            return motorcycleData;
        }

        public static List<string> GetMotorcycleProperties()
        {
            List<string> motorcycleProperties = GetVehicleProperties();
            motorcycleProperties.Add("License type:");
            motorcycleProperties.Add("Engine capacity:");

            return motorcycleProperties;
        }
    }
}