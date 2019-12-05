using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : VehicleType
    {
        private readonly float r_MaxBatteryTimeInHours; // This field is set in the object creation constructor and can't never change 
        private float m_BatteryTimeLeftInHours;
   
        public ElectricVehicle(string i_StrMaxBatteryTimeInHours) : base(eVehicleType.Electric)
        {
            this.r_MaxBatteryTimeInHours = float.Parse(i_StrMaxBatteryTimeInHours);
        }

        public float BatteryTimeLeftInHours
        {
            get { return this.m_BatteryTimeLeftInHours; }
            set { m_BatteryTimeLeftInHours = value; }
        }

        public float MaxBatteryTimeInHours
        {
            get { return this.r_MaxBatteryTimeInHours; }  
        }

        public override void FillPowerSource(params string[] i_DataToFillEnergySource)
        {
            const bool v_ValidAmountOfHoursToAdd = true;

            float numOfHoursAddToChargeTheBattary = float.Parse(i_DataToFillEnergySource[0]);

            if (checkIfValidAmountOfHoursToAdd(numOfHoursAddToChargeTheBattary) == v_ValidAmountOfHoursToAdd)
            {
                this.m_BatteryTimeLeftInHours += numOfHoursAddToChargeTheBattary;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxBatteryTimeInHours - m_BatteryTimeLeftInHours);
            }
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase)
        public override void UpdateCurrentStatusOfEnergySource(string i_strLeftEnergy)
        {
            float floatLeftEnergy = float.Parse(i_strLeftEnergy);

            if (floatLeftEnergy <= r_MaxBatteryTimeInHours && floatLeftEnergy >= 0)
            {
                m_BatteryTimeLeftInHours = floatLeftEnergy;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxBatteryTimeInHours);
            }
        }

        private bool checkIfValidAmountOfHoursToAdd(float i_NumOfHoursAddToChargeTheBattary)
        {
            bool isValidAmountOfHoursToAdd = true;

            if ((i_NumOfHoursAddToChargeTheBattary <= 0) || (i_NumOfHoursAddToChargeTheBattary > (r_MaxBatteryTimeInHours - m_BatteryTimeLeftInHours)))
            {
                isValidAmountOfHoursToAdd = !isValidAmountOfHoursToAdd;
            }

            return isValidAmountOfHoursToAdd;
        }

        public override string ToString()    
        {
            string newLine = Environment.NewLine;
            StringBuilder electricVehicleDetails = new StringBuilder();

            electricVehicleDetails.AppendFormat("Electric Vehicle -  Currrent battery power source: {0} {1}", m_BatteryTimeLeftInHours, newLine);
            electricVehicleDetails.AppendFormat("Electric Vehicle -  Max battery power source: {0} {1}", r_MaxBatteryTimeInHours, newLine);

            return electricVehicleDetails.ToString();
        }
    }
}
