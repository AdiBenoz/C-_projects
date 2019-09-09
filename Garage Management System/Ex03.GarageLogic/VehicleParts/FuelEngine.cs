using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        private eFuelType m_FuelType;

        internal FuelEngine(Dictionary<string, string> i_FuelEngineInfo) : base(i_FuelEngineInfo["Current fuel amount:"], i_FuelEngineInfo["max fuel amount:"])
        {
            m_FuelType = PropertiesValidation.EnumTryParse<eFuelType>(i_FuelEngineInfo["Fuel type:"], "Fuel type");
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        internal void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if(i_FuelType!= m_FuelType)
            {
                throw new ArgumentException("Fuel type not suitable");
            }
            else
            {
                IncreaseEnergy(i_AmountToAdd);
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel engine: the fuel type is: {0}, remaining amount of fuel is: {1}", m_FuelType, CurrentEnergyAmount);
        }

        public static List<string> GetFuelProperties()
        {
            List<string> fuelProperties = new List<string>();
            fuelProperties.Add("Current fuel amount:");

            return fuelProperties;
        }
    }
}
