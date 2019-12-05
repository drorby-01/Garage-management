using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDangerousMaterials; 
        private float m_TrunkChargerCapacity;

        public Truck(string i_ModelName, string i_LicenceId, string i_WheelManufacturerName, float i_MaxWheelPressureManufacturerSuggested, int i_NumberOfWheels, VehicleType.eVehicleType i_VehicleType, string i_StrIsDangerousMaterials, string i_StrTrunkChargerCapacity, params string[] i_DataToFillEnergySource)
            : base(i_ModelName, i_LicenceId, i_WheelManufacturerName, i_MaxWheelPressureManufacturerSuggested, i_NumberOfWheels, i_VehicleType, i_DataToFillEnergySource)
        {
            this.m_IsDangerousMaterials = bool.Parse(i_StrIsDangerousMaterials);
            this.m_TrunkChargerCapacity = float.Parse(i_StrTrunkChargerCapacity);
        }
        
        public bool IsDangerousMaterials
        {
            get { return this.m_IsDangerousMaterials; }
            set { this.m_IsDangerousMaterials = value; }
        }

        public float TrunkChargerCapacity
        {
            get { return this.m_TrunkChargerCapacity; }
            set { this.m_TrunkChargerCapacity = value; }
        }

        public override string ToString()
        {
            string newLine = Environment.NewLine;
            StringBuilder TruckDetails = new StringBuilder();

            TruckDetails.AppendLine(base.ToString());
            TruckDetails.AppendLine();
            TruckDetails.AppendFormat("Truck  -  Dangrous materials? {0} {1}", IsDangerousMaterials, newLine);
            TruckDetails.AppendFormat("Truck  -  Charger capacity: {0} {1}", TrunkChargerCapacity, newLine);

            return TruckDetails.ToString();
        }
    }
}
