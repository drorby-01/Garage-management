using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Red = 1,
            Blue = 2,
            Black = 3,
            Grey = 4,
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
        }

        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoorsInCar;
        
        public Car(string i_ModelName, string i_LicenceId, string i_WheelManufacturerName, float i_MaxWheelPressureManufacturerSuggested, int i_NumberOfWheels, VehicleType.eVehicleType i_VehicleType, string i_StrNumberOfDoorsInCar, string i_StrCarColor, params string[] i_DataToFillEnergySource)
           : base(i_ModelName, i_LicenceId, i_WheelManufacturerName, i_MaxWheelPressureManufacturerSuggested, i_NumberOfWheels, i_VehicleType, i_DataToFillEnergySource)
        {
            CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_StrCarColor);
            NumberOfDoorsInCar = (eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_StrNumberOfDoorsInCar);
        }

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public eNumberOfDoors NumberOfDoorsInCar
        {
            get { return m_NumberOfDoorsInCar; }
            set { m_NumberOfDoorsInCar = value; }
        }

        public override string ToString() 
        {
            string newLine = Environment.NewLine;
            StringBuilder carDetails = new StringBuilder();

            carDetails.AppendLine(base.ToString());
            carDetails.AppendLine();
            carDetails.AppendFormat("Car - Color: {0} {1}", CarColor, newLine);
            carDetails.AppendFormat("Car - Number of doors: {0} {1}", NumberOfDoorsInCar, newLine);

            return carDetails.ToString();
        }
    }
}
