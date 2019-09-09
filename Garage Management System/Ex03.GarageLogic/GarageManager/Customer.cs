using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        public enum eVehicleGarageStatus
        {
            InRepair = 1,
            FixedAndUnpaid = 2,
            FixedAndPaid = 3,
        }
        private string m_CostumerName;
        private string m_CustomerPhoneNumber;
        private readonly Vehicle r_CustomerVehicle;
        private eVehicleGarageStatus m_CurrentVehicleStatus;

        internal Customer(string i_CustomerName, string i_CustomerPhoneNumber, Vehicle i_Vehicle)
        {
            m_CostumerName = i_CustomerName;
            m_CustomerPhoneNumber = i_CustomerPhoneNumber;
            r_CustomerVehicle = i_Vehicle;
            m_CurrentVehicleStatus = eVehicleGarageStatus.InRepair;
        }

        public string CostumerName
        {
            get
            {
                return m_CostumerName;
            }
            set
            {
                m_CostumerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_CustomerPhoneNumber;
            }

            set
            {
                m_CustomerPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_CustomerVehicle;
            }
        }

        public eVehicleGarageStatus CurrentVehicleStatus
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

        public override string ToString()
        {
            string customerData = string.Format(@"{0}
Owner's name: {1}
Vehical status: {2} {3}",r_CustomerVehicle.GetVehicleData(),
            m_CostumerName,
            m_CurrentVehicleStatus, Environment.NewLine);

            return customerData;
        }
    }
}
