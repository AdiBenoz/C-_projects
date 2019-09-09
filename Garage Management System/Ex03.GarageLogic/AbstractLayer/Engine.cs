using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentEnergyAmount;
        private float m_MaxEnergyAmount;

        internal Engine(string i_CurrentEnergyAmount, string i_MaxEnergyAmount)
        {
            m_CurrentEnergyAmount = float.Parse(i_CurrentEnergyAmount);
            m_MaxEnergyAmount = float.Parse(i_MaxEnergyAmount);
        }

        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return m_MaxEnergyAmount;
            }

        }

        public void IncreaseEnergy(float i_EnergyAmountToAdd)
        {
            if (m_CurrentEnergyAmount + i_EnergyAmountToAdd > m_MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergyAmount - m_CurrentEnergyAmount);
            }
            else
            {
                m_CurrentEnergyAmount += i_EnergyAmountToAdd;
            }
        }

        public abstract override string ToString();

        
    }

    }