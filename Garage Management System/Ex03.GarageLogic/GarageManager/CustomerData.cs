using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.GarageManager
{
    public class CustomerData
    {
        public enum eVehicleGarageStatus
        {
            InRepair = 1,
            FixedAndUnpaid = 2,
            FixedAndPaid = 3,
        }

        private string m_CustomerName;
        private string m_PhoneNumber;
        readonly Vehicle m_CustomerVehicle;
        private eVehicleGarageStatus m_CurrentVehicleStatus;

        public CustomerData(string i_customerNamer, string i_phoneNumber, Vehicle i_CustomerVehicle)
        {
            m_CustomerName = i_customerNamer;
            m_PhoneNumber = i_phoneNumber;
            m_CustomerVehicle = i_CustomerVehicle;
            m_CurrentVehicleStatus = eVehicleGarageStatus.InRepair;
        }

        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
        }

        public eVehicleGarageStatus GarageStatus
        {
            get
            {
                return m_CurrentVehicleStatus;
            }

            set
            {
                m_CurrentVehicleStatus = value;
            }
        }

        public Vehicle CustomerVehicle
        {
            get
            {
                return m_CustomerVehicle;
            }
        }

        public override string ToString()
        {
            string customerData = string.Format(@"{0}
Owner's name: {1}
Vehical status: {2} ", m_CustomerVehicle.GetVehicleData(), m_CustomerName, m_CurrentVehicleStatus);

            return customerData;
        }
    }
}