using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleGarage
    {
        private static readonly Dictionary<Vehicle, VehicleOwner> sr_DictuonaryOfVehicleAndTheirOwners = new Dictionary<Vehicle, VehicleOwner>();

        public static void InsertNewVehicleToGarage(VehicleCreation.eVehicleTypes i_CreateVehicle, string i_VehicleModelName, string i_VehicleLicenceId, string i_WheelManufacturerName, float i_CurrentWheelPressure, string i_VehicleFirstParameter, string i_VehicleSecondParameter, string i_VehicleOwnerName, string i_VehicleOwnerPhone)
        {
            Vehicle newVehicle = VehicleCreation.CreateVehicle(i_CreateVehicle, i_VehicleModelName, i_VehicleLicenceId, i_WheelManufacturerName, i_VehicleFirstParameter, i_VehicleSecondParameter);
            VehicleOwner VehicleOwner = new VehicleOwner(i_VehicleOwnerName, i_VehicleOwnerPhone);

            newVehicle.UpdateAllCurrentWheelPressureOfVehicle(i_CurrentWheelPressure);

            sr_DictuonaryOfVehicleAndTheirOwners.Add(newVehicle, VehicleOwner); // Add to the 'VehicleGarage' dictionary
        }

        public static void PrintAllVehiclesIdNumbersInGarage()
        {
            PrintAllVehiclesIdNumbersAccordingToStatusInGarage(Vehicle.eVehicleStatusInGarage.Infix);
            PrintAllVehiclesIdNumbersAccordingToStatusInGarage(Vehicle.eVehicleStatusInGarage.Fixed);
            PrintAllVehiclesIdNumbersAccordingToStatusInGarage(Vehicle.eVehicleStatusInGarage.Paid);
        }

        public static void PrintAllVehiclesIdNumbersAccordingToStatusInGarage(Vehicle.eVehicleStatusInGarage i_VehicleStatusInGarage)
        {
            Console.WriteLine("Vehicle ID number with '{0}' status in the garage :", i_VehicleStatusInGarage);

            foreach (Vehicle vehicle in sr_DictuonaryOfVehicleAndTheirOwners.Keys)
            {
                if (vehicle.VehicleStatusInGarage == i_VehicleStatusInGarage)
                {
                    Console.WriteLine(vehicle.LicenceId);
                }
            }
        }

        public static bool ChangeVehicleStatusInTheGarage(string i_VehicleIdNumber, Vehicle.eVehicleStatusInGarage i_VehicleNewStatus)
        {
            bool vehicleStatusInGarageNoChanged = true, successChangedVehicleStatusInTheGarage = true;
            const bool v_VehicleStatusInGarageWasChanged = true;

            foreach (Vehicle vehicle in sr_DictuonaryOfVehicleAndTheirOwners.Keys)
            {
                if (vehicle.LicenceId == i_VehicleIdNumber)
                {
                    vehicle.VehicleStatusInGarage = i_VehicleNewStatus;
                    vehicleStatusInGarageNoChanged = !vehicleStatusInGarageNoChanged;
                }
            }

            if (vehicleStatusInGarageNoChanged == v_VehicleStatusInGarageWasChanged)
            {
                Console.WriteLine("No ID Vehicle like this number in the garage!!!");
                successChangedVehicleStatusInTheGarage = !successChangedVehicleStatusInTheGarage;
            }

            return successChangedVehicleStatusInTheGarage;
        }

        public static void InflateTheVehicleWheelsToMax(string i_VehicleIdNumber)
        {
            Vehicle vehicleToInflateHisWheels = GetVehicleByLicenseNumber(i_VehicleIdNumber);

            vehicleToInflateHisWheels.InFlateAllWheelsVehicleToMax();
        }

        public static void FuelGasolineVehicle(string i_IdVehicleNumberToAddFuel, string i_FuelTypeToAdd, string i_FuelAmountInLitersToAdd)
        {
            Vehicle vehicleToAddFuel = GetVehicleByLicenseNumber(i_IdVehicleNumberToAddFuel);

            vehicleToAddFuel.FillVehiclePowerSource(i_FuelAmountInLitersToAdd, i_FuelTypeToAdd);
        }

        public static void ChargeElectricVehicle(string i_IdVehicleNumberToCharge, string i_StrNumbersOfHoursToChargeVehicle)
        {
            Vehicle vehicleToUpdate = GetVehicleByLicenseNumber(i_IdVehicleNumberToCharge);

            vehicleToUpdate.FillVehiclePowerSource(i_StrNumbersOfHoursToChargeVehicle);
        }

        public static Vehicle GetVehicleByLicenseNumber(string i_VehicleIdNumber)
        {
            Vehicle theVehicleToReturn = null;

            foreach (Vehicle vehicle in sr_DictuonaryOfVehicleAndTheirOwners.Keys)
            {
                if (i_VehicleIdNumber == vehicle.LicenceId)
                {
                    theVehicleToReturn = vehicle;
                }
            }

            return theVehicleToReturn;
        }

        public static string PrintAllDictionaryDetails(string i_LicenseNumber)
        {
            StringBuilder detailsOfTheVehicleToPrint = new StringBuilder();
            Vehicle vehicleFromGarageToPrintHisDetails = GetVehicleByLicenseNumber(i_LicenseNumber);

            if (vehicleFromGarageToPrintHisDetails != null)
            {
                detailsOfTheVehicleToPrint.Append(vehicleFromGarageToPrintHisDetails.ToString());
                detailsOfTheVehicleToPrint.AppendLine(sr_DictuonaryOfVehicleAndTheirOwners[vehicleFromGarageToPrintHisDetails].ToString());
                detailsOfTheVehicleToPrint.AppendLine();
                return detailsOfTheVehicleToPrint.ToString();
            }
            else
            {
                throw new FormatException("No found this ID number in the garage!!!");
            }
        }

        public static bool CheckIfVehicleExistInGarage(string i_VehicleLicenceNumber)
        {
            int foundThisLicenceNumberInGarage = 0;
            bool vehicleAlreadyExistInGarage = true;

            foreach (Vehicle vehicle in sr_DictuonaryOfVehicleAndTheirOwners.Keys)
            {
                if (i_VehicleLicenceNumber == vehicle.LicenceId)
                {
                    foundThisLicenceNumberInGarage = 1;
                    break;
                }
            }

            if(foundThisLicenceNumberInGarage == 0)
            {
                vehicleAlreadyExistInGarage = !vehicleAlreadyExistInGarage;
            }

            return vehicleAlreadyExistInGarage;
        }

        public static void UpdateVehicleCurrentEnergy(string i_VehicleLicenseNumber, string i_CurrentAmountOfEnergy)   
        {
            Vehicle vehicleToUpdateHisCurrentEnergy = GetVehicleByLicenseNumber(i_VehicleLicenseNumber);

            vehicleToUpdateHisCurrentEnergy.UpdateCurrentEnergyPercentage(i_CurrentAmountOfEnergy);
        }

        public static bool CheckIfElectricVehicle(string i_LicenseNumber) 
        {
            bool isItElectronicVehicle = true;

            Vehicle theVehicleToReturn = GetVehicleByLicenseNumber(i_LicenseNumber);

            if (theVehicleToReturn.VehicleType.Type != VehicleType.eVehicleType.Electric)
            {
                isItElectronicVehicle = !isItElectronicVehicle;
            }

            return isItElectronicVehicle;
        }
    }
}
