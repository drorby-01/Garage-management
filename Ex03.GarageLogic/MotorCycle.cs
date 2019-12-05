using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        public enum eLicenceType
        {
            A = 1,
            A1 = 2,
            A2 = 3,
            B = 4,
        }

        private int m_MotorCycleEngineCapacity;
        private eLicenceType m_MotorCycleLicenceType;
        
        public MotorCycle(string i_ModelName, string i_LicenceId, string i_WheelManufacturerName, float i_MaxWheelPressureManufacturerSuggested, int i_NumberOfWheels, VehicleType.eVehicleType i_VehicleType, string i_StrMotorCycleLicenceType, string i_StrMotorCycleEngineCapacity, params string[] i_DataToFillEnergySource)
           : base(i_ModelName, i_LicenceId, i_WheelManufacturerName, i_MaxWheelPressureManufacturerSuggested, i_NumberOfWheels, i_VehicleType, i_DataToFillEnergySource)
        {
            m_MotorCycleLicenceType = (eLicenceType)Enum.Parse(typeof(eLicenceType), i_StrMotorCycleLicenceType);
            m_MotorCycleEngineCapacity = int.Parse(i_StrMotorCycleEngineCapacity);
        }

        public int MotorCycleEngineCapacity
        {
            get { return m_MotorCycleEngineCapacity; }
            set { m_MotorCycleEngineCapacity = value; }
        }

        public eLicenceType MotorCycleLicenceType
        {
            get { return m_MotorCycleLicenceType; }
            set { m_MotorCycleLicenceType = value; }
        }

        public override string ToString() 
        {
            string newLine = Environment.NewLine;
            StringBuilder motorCycleDetails = new StringBuilder();

            motorCycleDetails.AppendLine(base.ToString());
            motorCycleDetails.AppendLine();
            motorCycleDetails.AppendFormat("MotorCycle  -  Engine capacity: {0} {1}", MotorCycleEngineCapacity, newLine);
            motorCycleDetails.AppendFormat("MotorCycle  -  Licence Type: {0} {1}", MotorCycleLicenceType, newLine);

            return motorCycleDetails.ToString();
        }
    }
}
