using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleOwner
    {
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;

        public VehicleOwner(string i_VehicleOwnerName, string i_VehicleOwnerPhone)
        {
            this.VehicleOwnerName = i_VehicleOwnerName;
            this.VehicleOwnerPhone = i_VehicleOwnerPhone;
        }

        public string VehicleOwnerName
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        public string VehicleOwnerPhone
        {
            get { return m_VehicleOwnerPhone; }
            set { m_VehicleOwnerPhone = value; }
        }

        public override string ToString()
        {
            string newLine = Environment.NewLine;
            StringBuilder vehicleOwnerDetails = new StringBuilder();

            vehicleOwnerDetails.AppendFormat("Vehicle Owner - Name : {0} {1}", VehicleOwnerName, newLine);
            vehicleOwnerDetails.AppendFormat("Vehicle Owner - Phone : {0} {1}", m_VehicleOwnerPhone, newLine);

            return vehicleOwnerDetails.ToString();
        }
    }
}
