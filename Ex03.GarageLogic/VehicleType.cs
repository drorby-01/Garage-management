using System;

namespace Ex03.GarageLogic
{
    public abstract class VehicleType
    {
        public enum eVehicleType
        {
            Electric = 1,
            Gasoline = 2,
        }

        private eVehicleType m_VehicleType;

        public VehicleType(eVehicleType i_VehicleType)
        {
            m_VehicleType = i_VehicleType;
        }

        public eVehicleType Type
        {
            get { return this.m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public abstract void FillPowerSource(params string[] i_DataToFillEnergySource);

        public abstract void UpdateCurrentStatusOfEnergySource(string i_LeftEnergy);
    }
}
