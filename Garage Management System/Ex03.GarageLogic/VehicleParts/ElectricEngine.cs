using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        internal ElectricEngine(Dictionary<string, string> i_ElectricEngineInfo) : base(i_ElectricEngineInfo["remaining battery time in hours:"], i_ElectricEngineInfo["max battery time:"])
        {
        }

        public void Recharge(float i_timeOfCharging)
        {
            IncreaseEnergy(i_timeOfCharging);
        }

        public override string ToString()
        {
            return string.Format("Electric Engine: remaining amount of battery time in hours is {0}", CurrentEnergyAmount);
        }

        public static List<string> GetElectricProperties()
        {
            List<string> electricProperties = new List<string>();
            electricProperties.Add("remaining battery time in hours:");

            return electricProperties;
        }
    }
}