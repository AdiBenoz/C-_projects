using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eColor
        {
            Red = 1,
            Blue = 2,
            Black = 3,
            Grey = 4
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        internal Car(Dictionary<string, string> i_CarInfo, Engine i_Engine) : base(i_CarInfo, i_Engine)
        {
            m_Color = PropertiesValidation.EnumTryParse<eColor>(i_CarInfo["Car's color:"], "Car's color");
            m_NumberOfDoors = (Car.eNumberOfDoors)int.Parse(i_CarInfo["Number of doors:"]);
        }

        public eColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }

        public override string GetVehicleData()
        {
            string carData = string.Format(@"{0}
{1}
Car color: {2}
Car number of doors: {3}", base.GetVehicleData(), base.Engine.ToString(), this.m_Color, this.m_NumberOfDoors);
            return carData;
        }

        public static List<string> GetCarProperties()
        {
            List<string> carProperties = GetVehicleProperties();
            carProperties.Add("Car's color:");
            carProperties.Add("Number of doors:");

            return carProperties;
        }
    }
}