using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreation
    {
        public enum eVehicleTypes
        {
            GasMotorCycle = 1,
            ElectricMotorCycle = 2,
            GasCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        private static readonly int sr_MotorCycleNumberOfWheels = 2;
        private static readonly float sr_MotorCycleMaxWheelPressure = 33;
        private static readonly GasolineVehicle.eFuelTypes sr_GasMotorCycleFuelType = GasolineVehicle.eFuelTypes.Octan95;
        private static readonly float sr_GasMotorCycleMaxFuelInLiters = 8;
        private static readonly float sr_ElectricMotorCycleMaxBatteryTimeInHoures = 1.4f;

        private static readonly int sr_CarNumberOFWheels = 4;
        private static readonly float sr_CarMaxWheelPressure = 31;
        private static readonly GasolineVehicle.eFuelTypes sr_GasCarFuelType = GasolineVehicle.eFuelTypes.Octan96;
        private static readonly float sr_GasCarMaxFuelInLiters = 55;
        private static readonly float sr_ElectricCarMaxBatteryTimeInHoures = 1.8f;
        
        private static readonly int sr_TruckNumberOfWheels = 12;
        private static readonly float sr_TruckMaxWheelsPresssure = 26;
        private static readonly GasolineVehicle.eFuelTypes sr_TruckFuelType = GasolineVehicle.eFuelTypes.Soler;
        private static readonly float sr_TruckMaxFuelInLiters = 110;

        public static float GetMaxEnergyPowerSourceAccordingToVehicleType(VehicleCreation.eVehicleTypes i_VehicleType)
        {
            switch(i_VehicleType) 
            {
                case VehicleCreation.eVehicleTypes.GasMotorCycle: return sr_GasMotorCycleMaxFuelInLiters;

                case VehicleCreation.eVehicleTypes.ElectricMotorCycle: return sr_ElectricMotorCycleMaxBatteryTimeInHoures;

                case VehicleCreation.eVehicleTypes.GasCar: return sr_GasCarMaxFuelInLiters;

                case VehicleCreation.eVehicleTypes.ElectricCar: return sr_ElectricCarMaxBatteryTimeInHoures;

                case VehicleCreation.eVehicleTypes.Truck: return sr_TruckMaxFuelInLiters;
            }

            return sr_MotorCycleMaxWheelPressure;
        }

        public static float GetMaxWheelPressureAccordingToVehicleType(VehicleCreation.eVehicleTypes i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case VehicleCreation.eVehicleTypes.GasMotorCycle: return sr_MotorCycleMaxWheelPressure;

                case VehicleCreation.eVehicleTypes.ElectricMotorCycle: return sr_MotorCycleMaxWheelPressure;

                case VehicleCreation.eVehicleTypes.GasCar: return sr_CarMaxWheelPressure;

                case VehicleCreation.eVehicleTypes.ElectricCar: return sr_CarMaxWheelPressure;

                case VehicleCreation.eVehicleTypes.Truck: return sr_TruckMaxWheelsPresssure;
            }

            return sr_MotorCycleMaxWheelPressure;
        }
        
        public static Vehicle CreateVehicle(eVehicleTypes i_VehicleTypeCreate, string i_ModelName, string i_LicenceId, string i_WheelManufacturerName, string i_VehicleFirstParameter, string i_VehicleSecondParameter)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleTypeCreate)
            {
                case eVehicleTypes.GasMotorCycle:
                    newVehicle = new MotorCycle(i_ModelName, i_LicenceId, i_WheelManufacturerName, sr_MotorCycleMaxWheelPressure, sr_MotorCycleNumberOfWheels, VehicleType.eVehicleType.Gasoline, i_VehicleFirstParameter, i_VehicleSecondParameter, sr_GasMotorCycleMaxFuelInLiters.ToString(), sr_GasMotorCycleFuelType.ToString());
                    break;

                case eVehicleTypes.ElectricMotorCycle:
                    newVehicle = new MotorCycle(i_ModelName, i_LicenceId, i_WheelManufacturerName, sr_MotorCycleMaxWheelPressure, sr_MotorCycleNumberOfWheels, VehicleType.eVehicleType.Electric, i_VehicleFirstParameter, i_VehicleSecondParameter, sr_ElectricMotorCycleMaxBatteryTimeInHoures.ToString());
                    break;

                case eVehicleTypes.GasCar:
                    newVehicle = new Car(i_ModelName, i_LicenceId, i_WheelManufacturerName, sr_CarMaxWheelPressure, sr_CarNumberOFWheels, VehicleType.eVehicleType.Gasoline, i_VehicleSecondParameter, i_VehicleFirstParameter, sr_GasCarMaxFuelInLiters.ToString(), sr_GasCarFuelType.ToString()); 
                    break;
                    
                case eVehicleTypes.ElectricCar:
                    newVehicle = new Car(i_ModelName, i_LicenceId, i_WheelManufacturerName, sr_CarMaxWheelPressure, sr_CarNumberOFWheels, VehicleType.eVehicleType.Electric, i_VehicleSecondParameter, i_VehicleFirstParameter, sr_ElectricCarMaxBatteryTimeInHoures.ToString());
                    break;

                case eVehicleTypes.Truck:
                    newVehicle = new Truck(i_ModelName, i_LicenceId, i_WheelManufacturerName, sr_TruckMaxWheelsPresssure, sr_TruckNumberOfWheels, VehicleType.eVehicleType.Gasoline, i_VehicleFirstParameter, i_VehicleSecondParameter, sr_TruckMaxFuelInLiters.ToString(), sr_TruckFuelType.ToString());
                    break;
            }

            return newVehicle;
        }
    }
}
