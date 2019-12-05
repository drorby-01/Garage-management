using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        public enum eVehicleStatusInGarage
        {
            Infix = 1,
            Fixed = 2,
            Paid = 3,
        }

        private const float k_InitPressureInVehicleWheel = 0;
        private string m_ModelName;
        private string m_LicenceId;
        private eVehicleStatusInGarage m_VehicleStatusInGarage;
        // $G$ DSN-999 (-3) This List should be readonly.
        private Wheel[] m_VehicleWheelsArray;
        private float m_CurrentEnergyPercentage;
        private VehicleType m_VehicleType;

        public Vehicle(string i_ModelName, string i_LicenceId, string i_WheelManufacturerName, float i_MaxWheelPressureManufacturerSuggested, int i_NumberOfWheels, VehicleType.eVehicleType i_VehicleType, params string[] i_DataToFillEnergySource)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenceId = i_LicenceId;
            m_VehicleStatusInGarage = eVehicleStatusInGarage.Infix; // The first status of the Vehicle is 'Infix'
            createVehicleWheelsArray(i_WheelManufacturerName, i_NumberOfWheels, i_MaxWheelPressureManufacturerSuggested);
            updateTheCurrentPressureInVehicleWheelsArray(k_InitPressureInVehicleWheel);
            updateVehicleType(i_VehicleType, i_DataToFillEnergySource);
        }

        public string LicenceId
        {
            get { return this.m_LicenceId; }
            set { this.m_LicenceId = value; }
        }

        public VehicleType VehicleType
        {
            get { return m_VehicleType; }
        }

        public float CurrentEnergyPercentage 
        {
            get { return m_CurrentEnergyPercentage; }
            set { m_CurrentEnergyPercentage = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public Wheel[] VehicleWheelsArray
        {
            get { return m_VehicleWheelsArray; }
            set { m_VehicleWheelsArray = value; }
        }

        public eVehicleStatusInGarage VehicleStatusInGarage
        {
            get { return this.m_VehicleStatusInGarage; }
            set { this.m_VehicleStatusInGarage = value; }
        }

        public void UpdateAllCurrentWheelPressureOfVehicle(float i_CurrentWheelPressure)
        {
            if (i_CurrentWheelPressure >= 0 && i_CurrentWheelPressure <= m_VehicleWheelsArray[0].MaxWheelPressureManufacturerSuggested)
            {
                foreach (Wheel wheel in m_VehicleWheelsArray)
                {
                    wheel.CurrentWheelPressure = i_CurrentWheelPressure;
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_VehicleWheelsArray[0].MaxWheelPressureManufacturerSuggested - m_VehicleWheelsArray[0].CurrentWheelPressure);
            }
        }

        public void InFlateAllWheelsVehicleToMax()  
        {
            foreach (Wheel wheel in m_VehicleWheelsArray)
            {
                wheel.InflateSingelWheelToMax();
            }
        }

        public void FillVehiclePowerSource(params string[] i_DataToFillVehiclePowerSource) 
        {
            float maxPowerSource;
            float currentPowerSource;

            VehicleType.FillPowerSource(i_DataToFillVehiclePowerSource);

            // Update the current energy percentage of the vehicle, according to his type ( Gasoline or Electric )
            if (m_VehicleType.Type == VehicleType.eVehicleType.Electric)
            {
                maxPowerSource = (VehicleType as ElectricVehicle).MaxBatteryTimeInHours;
                currentPowerSource = (VehicleType as ElectricVehicle).BatteryTimeLeftInHours;
            }
            else
            { // If it's 'Gasoline' vehicle
                maxPowerSource = (VehicleType as GasolineVehicle).MaxFuelQuantityInLiters;
                currentPowerSource = (VehicleType as GasolineVehicle).CurrentFuelQuantityInLiters;
            }
            
            CurrentEnergyPercentage = (currentPowerSource * 100f) / maxPowerSource;
        }

        public void UpdateCurrentEnergyPercentage(string i_CurrentAmountOfEnergy)  
        {
            float maxAmountOfEnergy = 1, currentAmountOfEnergy = 1;

            m_VehicleType.UpdateCurrentStatusOfEnergySource(i_CurrentAmountOfEnergy);

            if (VehicleType is ElectricVehicle)
            {
                currentAmountOfEnergy = ((ElectricVehicle)VehicleType).BatteryTimeLeftInHours;
                maxAmountOfEnergy = ((ElectricVehicle)VehicleType).MaxBatteryTimeInHours;
            }
            else
            {
                if (VehicleType is GasolineVehicle)
                {
                    currentAmountOfEnergy = ((GasolineVehicle)VehicleType).CurrentFuelQuantityInLiters;
                    maxAmountOfEnergy = ((GasolineVehicle)VehicleType).MaxFuelQuantityInLiters;
                }
            }

            CurrentEnergyPercentage = (currentAmountOfEnergy / maxAmountOfEnergy) * 100;
        }
        
        private void createVehicleWheelsArray(string i_WheelManufacturerName, int i_NumberOfWheels, float i_MaxWheelPressureManufacturerSuggested)
        {
            m_VehicleWheelsArray = new Wheel[i_NumberOfWheels];

            for(int i = 0; i < i_NumberOfWheels; i++)
            {
                m_VehicleWheelsArray[i] = new Wheel(i_WheelManufacturerName, i_MaxWheelPressureManufacturerSuggested);
            }
        }

        private void updateTheCurrentPressureInVehicleWheelsArray(float i_UpdatedWheelPressure)
        {
            if (i_UpdatedWheelPressure >= 0 && i_UpdatedWheelPressure <= m_VehicleWheelsArray[0].MaxWheelPressureManufacturerSuggested)
            {
                foreach (Wheel wheel in m_VehicleWheelsArray)
                {
                    wheel.CurrentWheelPressure = i_UpdatedWheelPressure;
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_VehicleWheelsArray[0].MaxWheelPressureManufacturerSuggested - m_VehicleWheelsArray[0].CurrentWheelPressure);
            }
        }

        private void updateVehicleType(VehicleType.eVehicleType i_VehicleType, params string[] i_DataToFillEnergySource)
        {
            switch (i_VehicleType)
            {
                case VehicleType.eVehicleType.Electric:
                    m_VehicleType = new ElectricVehicle(i_DataToFillEnergySource[0]); // Insert to the constructor of 'ElectricVehicle' the MaxBatteryTime
                    break;
                case VehicleType.eVehicleType.Gasoline:
                    m_VehicleType = new GasolineVehicle(i_DataToFillEnergySource[0], i_DataToFillEnergySource[1]); // Insert to the constructor of 'GasolineVehicle' the GasolineType and the MaxFuelQuantity 
                    break;
            }
        }

        public override string ToString()   
        {
            string newLine = Environment.NewLine;
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendFormat("Vehicle - Model name: {0} {1}", ModelName, newLine);
            vehicleDetails.AppendFormat("Vehicle - Licence Id: {0} {1}", LicenceId, newLine);
            vehicleDetails.AppendFormat("Vehicle - Wheels: {0} {1}", VehicleWheelsArray[0].ToString(), newLine);
            vehicleDetails.AppendFormat("Vehicle - Number of Wheels: {0} {1}", m_VehicleWheelsArray.Length, newLine);
            vehicleDetails.AppendLine();
            vehicleDetails.AppendFormat("Vehicle - Status in the garage: {0} {1}", VehicleStatusInGarage, newLine);
            vehicleDetails.AppendLine();
            vehicleDetails.AppendFormat("Vehicle - Current energy percentage: {0} {1}", CurrentEnergyPercentage, newLine);  
            vehicleDetails.AppendLine();
            vehicleDetails.AppendFormat("Vehicle - Type: {0} {1}", VehicleType.ToString(), newLine);

            return vehicleDetails.ToString();
        }
    }
}
