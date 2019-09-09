using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterial;
        private float m_CarryingCapacity;

        internal Truck(Dictionary<string, string> i_TruckInfo, Engine i_Engine) : base(i_TruckInfo, i_Engine)
        {
            m_IsCarryingDangerousMaterial = (i_TruckInfo["Carry dangerous materials:"].ToLower()).Equals("yes");
            m_CarryingCapacity = float.Parse(i_TruckInfo["Carrying capacity:"]);
        }

        public bool IsCarringDangerousMaterial
        {
            get
            {
                return m_IsCarryingDangerousMaterial;
            }
        }

        public float MaxCarryingWeightAllowed
        {
            get
            {
                return m_CarryingCapacity;
            }
        }

        public override string GetVehicleData()
        {
            string truckData = string.Format(@"{0}
{1}
Truck is carrying dangerous substance? {2}
Truck carrying capacity {3}", base.GetVehicleData(), base.Engine.ToString(), m_IsCarryingDangerousMaterial, m_CarryingCapacity);

            return truckData;
        }

        public static List<string> GetTruckProperties()
        {
            List <string> truckProperties = GetVehicleProperties();
            truckProperties.Add("Carry dangerous materials:");
            truckProperties.Add("Carrying capacity:");

            return truckProperties;
        }
    }
}