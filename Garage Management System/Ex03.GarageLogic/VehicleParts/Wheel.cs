using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaximalAirPressure;
        internal Dictionary<string, string> m_VehicleInfo;

        internal Wheel(Dictionary<string, string> i_VehicleInfo)
        {
            m_VehicleInfo = i_VehicleInfo;
            m_ManufacturerName = i_VehicleInfo["Wheel manufacturer's name:"];
            m_CurrentAirPressure = float.Parse(i_VehicleInfo["Wheel current air pressure:"]);
            m_MaximalAirPressure = float.Parse(i_VehicleInfo["Wheel maximal air pressure:"]);
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

        }

        public float MaximalAirPressure
        {
            get
            {
                return m_MaximalAirPressure;
            }
        }

        public void InflatingWheel(float i_AirToAdd)
        {
          
            if (m_CurrentAirPressure + i_AirToAdd <= m_MaximalAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, (m_MaximalAirPressure - m_CurrentAirPressure));
            }
        }

        public override string ToString()
        {
            String wheelInfo = string.Format(@"Wheels: manufacturer name: {0},  current air pressure: {1}, maximal air pressure: {2}", m_ManufacturerName, m_CurrentAirPressure, m_MaximalAirPressure);

            return wheelInfo;
        }

        public static List<string> GetWheelProperties()
        {
            List<string> wheelProperties = new List<string>();
            wheelProperties.Add("Wheel manufacturer's name:");
            wheelProperties.Add("Wheel current air pressure:");

            return wheelProperties;
        }
    }
}