using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public enum eUserInputOperationChoise
        {
            AddNewVehicleToTheGarage = 1,
            DisplayAllVehiclesLicenseNumbersFilteredByStatusInGarage = 2,
            ChangeVehicleStatusInGarage = 3,
            InflateVehicleWheelToMax = 4,
            FillFuelToGasolineVehicle = 5,
            ChargeElectricVehicle = 6,
            DisplayAllSpecificVehicleDetailsInTheGarage = 7,
            ExitFromVehicleGarage = 8,
        }

        private bool m_ContinueBeingInTheVehicleGarage = true;

        public void StartUserInterface()
        {
            Console.WriteLine("Hello:) Welcome to the garage!");

            displayTheGarageMenuOptionsToUser();
           
            getAndCheckTheUserOperationChoise();
        }

        private void displayTheGarageMenuOptionsToUser()
        {
            string strDisplayMenuToUser;

            Console.WriteLine();
            strDisplayMenuToUser = string.Format(
            @"Please choose one of the following operations :
            1. To add an new vehicle to the garage
            2. To display all vehicles IDs filtered by status in the garage
            3. To change vehicle status in the garage
            4. To inflate vehicle wheel to max air
            5. To fill fuel to gasoline vehicle 
            6. To charge an electric vehicle
            7. To display all details about a specific vehicle in the garage
            8. To exit from the garage");

            // Display menu options and get the choise from user
            Console.WriteLine(strDisplayMenuToUser);
        }

        private void getAndCheckTheUserOperationChoise()
        {
            const int k_FirstOptionValueInMenu = 1;
            const bool v_BeingInTheVehicleGarage = true;
            string strUserOperationChoiseInGarage;
            int lastOptionValueInMenu = Enum.GetNames(typeof(eUserInputOperationChoise)).Length;
            
            while (m_ContinueBeingInTheVehicleGarage = v_BeingInTheVehicleGarage)
            {
                try
                {
                    strUserOperationChoiseInGarage = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(strUserOperationChoiseInGarage, k_FirstOptionValueInMenu, lastOptionValueInMenu);

                    doTheUserSelectedOperation(strUserOperationChoiseInGarage);

                    displayTheGarageMenuOptionsToUser();
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                }
            }
        }

        private void doTheUserSelectedOperation(string i_StrUserOperationChoiseInGarage)
        {
            bool continueBeingInTheVehicleGarage = true;

            try
            {
                // Convert from string to enum type
                eUserInputOperationChoise enumeUserOperationChoise = (eUserInputOperationChoise)Enum.Parse(typeof(eUserInputOperationChoise), i_StrUserOperationChoiseInGarage);

                switch (enumeUserOperationChoise)
                {
                    case eUserInputOperationChoise.AddNewVehicleToTheGarage:
                        addNewVehicleToTheGarage();
                        break;

                    case eUserInputOperationChoise.DisplayAllVehiclesLicenseNumbersFilteredByStatusInGarage:
                         displayAllVehiclesLicenseNumbersFilteredByStatusInGarage();
                        break;

                    case eUserInputOperationChoise.ChangeVehicleStatusInGarage:
                        changeVehicleStatusInGarage();
                        break;

                    case eUserInputOperationChoise.InflateVehicleWheelToMax:
                        inflateVehicleWheelToMax(); 
                        break;

                    case eUserInputOperationChoise.FillFuelToGasolineVehicle:
                        fillFuelToGasolineVehicle();
                        break;

                    case eUserInputOperationChoise.ChargeElectricVehicle:
                        chargeElectricVehicle();
                        break;

                    case eUserInputOperationChoise.DisplayAllSpecificVehicleDetailsInTheGarage:
                        displayAllSpecificVehicleDetailsInTheGarage();
                        break;

                    case eUserInputOperationChoise.ExitFromVehicleGarage:
                        this.m_ContinueBeingInTheVehicleGarage = !continueBeingInTheVehicleGarage;
                        Environment.Exit(1);
                        break;
                }
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine(formatEx.Message);
            }
            catch (ArgumentException argumentEx)
            {
                Console.WriteLine(argumentEx.Message);
            }
            catch (ValueOutOfRangeException valueOutOfRangeEx)
            {
                Console.WriteLine(valueOutOfRangeEx.Message);
            }
        }

        private void addNewVehicleToTheGarage()
        {
            VehicleCreation.eVehicleTypes vehicleType;
            float weelCurrentAirPressureFromUser;
            string vehicleLicenceNumberFromUser, vehicleModelNameFromUser, weelManufacturerNameFromUser, vehicleOwnerNameFromUser, vehicleOwnerPhoneNumber, currentEnergyPercentage;
               
            vehicleLicenceNumberFromUser = getAndCheckVehicleLicenceNumber();

            vehicleModelNameFromUser = getVehicleModelName();

            vehicleType = getVehicleType();

            weelManufacturerNameFromUser = getWeelManufacturerName();

            weelCurrentAirPressureFromUser = getWeelCurrentAirPressure(vehicleType);

            vehicleOwnerNameFromUser = getVehicleOwnerName();

            vehicleOwnerPhoneNumber = getVehicleOwnerPhoneNumber();

            string firstVehicleValue, secondVehicleValue;

            getTwoAdditionValuesAccordingToVehicleType(out firstVehicleValue, out secondVehicleValue, vehicleType);

            currentEnergyPercentage = getCurrentEnergyPercentageOFVehicle(vehicleType);

            VehicleGarage.InsertNewVehicleToGarage(vehicleType, vehicleModelNameFromUser, vehicleLicenceNumberFromUser, weelManufacturerNameFromUser, weelCurrentAirPressureFromUser, firstVehicleValue, secondVehicleValue, vehicleOwnerNameFromUser, vehicleOwnerPhoneNumber);
            VehicleGarage.UpdateVehicleCurrentEnergy(vehicleLicenceNumberFromUser, currentEnergyPercentage);

            Console.WriteLine("########## The required vehicle was added successfully to the garage:)))))) ##########");
        }

        private string getAndCheckVehicleLicenceNumber()
        {
            string strInputLicenceNumberFromUserToCheck = null;
            bool userEnteredCorrectInput = true;
            const bool v_CorrectInput = true;

            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the licence number of the vehicle you want add to garage :");
                    strInputLicenceNumberFromUserToCheck = Console.ReadLine();
                    CheckInputsFromUserCorrect.CheckInputLicenceNumberFromUserIsCorrectAndChangeStatusInGarage(strInputLicenceNumberFromUserToCheck);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

           return strInputLicenceNumberFromUserToCheck;
        }

        private string getVehicleModelName()
        {
            string strInputVehicleModelNameFromUser = null;
      
            Console.WriteLine("Please enter the model name of the vehicle you want add to garage :");
            strInputVehicleModelNameFromUser = Console.ReadLine();

            return strInputVehicleModelNameFromUser;
        }

        private VehicleCreation.eVehicleTypes getVehicleType()
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;
            string strUserVehicleTypeChoise;
            VehicleCreation.eVehicleTypes vehicleType = VehicleCreation.eVehicleTypes.ElectricCar;
            string strDisplayMenuToUser = string.Format(@"Please choose one of the vehicle types :
                                                        1. Gas MotorCycle
                                                        2. Electric Motorcycle
                                                        3. Gas Car
                                                        4. Electric Car
                                                        5. Truck");
            
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine(strDisplayMenuToUser);
                    strUserVehicleTypeChoise = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(strUserVehicleTypeChoise, 1, Enum.GetNames(typeof(VehicleCreation.eVehicleTypes)).Length);

                    // Convert user type choise to enum 
                    vehicleType = (VehicleCreation.eVehicleTypes)int.Parse(strUserVehicleTypeChoise);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

                return vehicleType;
        }

        private string getWeelManufacturerName()
        {
            string weelManufacturerNameFromUser = null;
            
            Console.WriteLine("Please enter wheel manufacturer name :");
            weelManufacturerNameFromUser = Console.ReadLine();

            return weelManufacturerNameFromUser;
        }

        private float getWeelCurrentAirPressure(VehicleCreation.eVehicleTypes i_VehicleType)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;
            string strCurrentWheelAirPressureFromUser;
            float floatCurrentWheelAirPressureFromUser = 0;

            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine("Please enter the wheel current pressure :");
                    strCurrentWheelAirPressureFromUser = Console.ReadLine();

                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveFloatNumberType(strCurrentWheelAirPressureFromUser);
                    floatCurrentWheelAirPressureFromUser = float.Parse(strCurrentWheelAirPressureFromUser);

                    // Check the air pressure is less than the max 
                    CheckInputsFromUserCorrect.CheckFloatInputFromUserIsInCorrectRange(strCurrentWheelAirPressureFromUser, 0, VehicleCreation.GetMaxWheelPressureAccordingToVehicleType(i_VehicleType));
                    
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

            return floatCurrentWheelAirPressureFromUser;
        }

        private string getVehicleOwnerName()
        {
            string vehicleOwnerNameFromUser = null;
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine("Please enter vehicle owner name :");
                    vehicleOwnerNameFromUser = Console.ReadLine();

                    CheckInputsFromUserCorrect.CheckInputFromUserContainsOnlyLetters(vehicleOwnerNameFromUser);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

            return vehicleOwnerNameFromUser;
        }

        private string getVehicleOwnerPhoneNumber()
        {
            string vehicleOwnerPhoneNumber = null;
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine("Please enter vehicle owner phone number :");
                    vehicleOwnerPhoneNumber = Console.ReadLine();

                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveNumber(vehicleOwnerPhoneNumber);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

            return vehicleOwnerPhoneNumber;
        }

        private void getTwoAdditionValuesAccordingToVehicleType(out string o_FirstVehicleValue, out string o_SecondVehicleValue, VehicleCreation.eVehicleTypes i_VehicleType)
        {
            o_FirstVehicleValue = null;
            o_SecondVehicleValue = null;

            switch (i_VehicleType)
            {
                case VehicleCreation.eVehicleTypes.ElectricMotorCycle: getLicenceTypeAndEngineCapacityForMotorCycle(out o_FirstVehicleValue, out o_SecondVehicleValue);
                    break;

                case VehicleCreation.eVehicleTypes.GasMotorCycle: getLicenceTypeAndEngineCapacityForMotorCycle(out o_FirstVehicleValue, out o_SecondVehicleValue);
                    break;

                case VehicleCreation.eVehicleTypes.ElectricCar:
                    getColorAndNumOfDoorsForCar(out o_FirstVehicleValue, out o_SecondVehicleValue);
                    break;

                case VehicleCreation.eVehicleTypes.GasCar:
                    getColorAndNumOfDoorsForCar(out o_FirstVehicleValue, out o_SecondVehicleValue);
                    break;

                case VehicleCreation.eVehicleTypes.Truck:
                    getIfDangrousMaterialsAndChagerCapacityForTruck(out o_FirstVehicleValue, out o_SecondVehicleValue);
                    break;
            }
        }

        private void getLicenceTypeAndEngineCapacityForMotorCycle(out string o_FirstVehicleValue, out string o_SecondVehicleValue)
        {
            o_FirstVehicleValue = null;
            o_SecondVehicleValue = null;

            getLicenceTypeForMotorCycle(out o_FirstVehicleValue);

            getEngineCapacityForMotorCycle(out o_SecondVehicleValue);
        }

        private void getLicenceTypeForMotorCycle(out string o_FirstVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;
            string strDisplayMenuToUser = string.Format(@"Please choose Licence type of motorCycle :
                                                        1. A
                                                        2. A1
                                                        3. A2
                                                        4. B ");
            o_FirstVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the first value
                    Console.WriteLine(strDisplayMenuToUser);
                    o_FirstVehicleValue = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(o_FirstVehicleValue, 1, Enum.GetNames(typeof(MotorCycle.eLicenceType)).Length);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void getEngineCapacityForMotorCycle(out string o_SecondVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_SecondVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the second value
                    Console.WriteLine("Please enter the motorcycle engine capacity : ");
                    o_SecondVehicleValue = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveNumber(o_SecondVehicleValue);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void getColorAndNumOfDoorsForCar(out string o_FirstVehicleValue, out string o_SecondVehicleValue)
        {
            o_FirstVehicleValue = null;
            o_SecondVehicleValue = null;

            getColorForCar(out o_FirstVehicleValue);

            getNumOfDoorsForCar(out o_SecondVehicleValue); 
        }

        private void getColorForCar(out string o_FirstVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_FirstVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            string strFirstDisplayMenuToUser = string.Format(@"Please choose color of car :
                                                            1. Red
                                                            2. Blue
                                                            3. Black
                                                            4. Grey ");

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the first value
                    Console.WriteLine(strFirstDisplayMenuToUser);
                    o_FirstVehicleValue = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(o_FirstVehicleValue, 1, Enum.GetNames(typeof(Car.eCarColor)).Length);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void getNumOfDoorsForCar(out string o_SecondVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_SecondVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            string strSecondDisplayMenuToUser = string.Format(@"Please choose number of doors in car :
                                                            1. Two
                                                            2. Three
                                                            3. Four
                                                            4. Five ");

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the second value
                    Console.WriteLine(strSecondDisplayMenuToUser);
                    o_SecondVehicleValue = Console.ReadLine();

                    // Check the user enter correct number
                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveNumber(o_SecondVehicleValue);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void getIfDangrousMaterialsAndChagerCapacityForTruck(out string o_FirstVehicleValue, out string o_SecondVehicleValue)
        {
            o_FirstVehicleValue = null;
            o_SecondVehicleValue = null;

            getIfDangrousMaterialsForTruck(out o_FirstVehicleValue);

            getChagerCapacitysForTruck(out o_SecondVehicleValue);
        }

        private void getIfDangrousMaterialsForTruck(out string o_FirstVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_FirstVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the first value
                    Console.WriteLine("Is Dangrous Materials trunk?  Insert 'true' or 'false' value : ");
                    o_FirstVehicleValue = Console.ReadLine();

                    // Check the user enter correct value
                    CheckInputsFromUserCorrect.CheckInputFromUserIsOnlyBooleanValue(o_FirstVehicleValue);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void getChagerCapacitysForTruck(out string o_SecondVehicleValue)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_SecondVehicleValue = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    // Get the second value
                    Console.WriteLine("Please enter the trunk charger capacity : ");
                    o_SecondVehicleValue = Console.ReadLine();

                    // Check the user enter correct value
                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveFloatNumberType(o_SecondVehicleValue);
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private string getCurrentEnergyPercentageOFVehicle(VehicleCreation.eVehicleTypes i_VehicleType)   
        {                                                                                         
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;
            string strCurrentAmountOfFuelOrBatteryFromUser = null;

            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine("Please enter current energy amount of the vehicle : ");
                    strCurrentAmountOfFuelOrBatteryFromUser = Console.ReadLine();

                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveFloatNumberType(strCurrentAmountOfFuelOrBatteryFromUser);

                    // Check the energy source power is less than the max 
                    CheckInputsFromUserCorrect.CheckFloatInputFromUserIsInCorrectRange(strCurrentAmountOfFuelOrBatteryFromUser, 0, VehicleCreation.GetMaxEnergyPowerSourceAccordingToVehicleType(i_VehicleType));
                    
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }

            return strCurrentAmountOfFuelOrBatteryFromUser;
        }

        private void displayAllVehiclesLicenseNumbersFilteredByStatusInGarage()
        {
            VehicleGarage.PrintAllVehiclesIdNumbersInGarage();
        }

        private void changeVehicleStatusInGarage()
        {
            const bool v_ChangeVehicleStatusInTheGarage = true;
            string strInputVehicleLicenceNumber, vehicleStatusYouWantToChange;
            
            getTheVehicleLicenceNumber(out strInputVehicleLicenceNumber);

            getTheVehicleStatusYouWantToChange(out vehicleStatusYouWantToChange);

            if(VehicleGarage.ChangeVehicleStatusInTheGarage(strInputVehicleLicenceNumber, (Vehicle.eVehicleStatusInGarage)Enum.Parse(typeof(Vehicle.eVehicleStatusInGarage), vehicleStatusYouWantToChange)) == v_ChangeVehicleStatusInTheGarage)
            {
                Console.WriteLine("######### The vehicle status was changed successfully :))))))) #########");
            }
        }

        private void getTheVehicleStatusYouWantToChange(out string o_VehicleStatusYouWantToChange)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_VehicleStatusYouWantToChange = null; 
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    string vehicleNewStatusStr = string.Format(@"Please enter one of this options to change to :
                                                                 1.InFix 
                                                                 2.Fixed
                                                                 3.Paid");
                    Console.WriteLine(vehicleNewStatusStr);
                    o_VehicleStatusYouWantToChange = Console.ReadLine();

                    // Check it's a good input licence number
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(o_VehicleStatusYouWantToChange, 1, Enum.GetNames(typeof(Vehicle.eVehicleStatusInGarage)).Length);
                    
                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }
    
        private void getTheVehicleLicenceNumber(out string i_VehicleStatus)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            i_VehicleStatus = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the vehicle licence number you want :");
                    i_VehicleStatus = Console.ReadLine();

                    // Check it's a good input licence number
                    CheckInputsFromUserCorrect.CheckInputLicenceNumberFromUserIsCorrect(i_VehicleStatus);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void inflateVehicleWheelToMax() 
        {
            string strInputVehicleLicenceNumber;
            const bool v_VehicleExistInGarage = true;

            getTheVehicleLicenceNumber(out strInputVehicleLicenceNumber);

            if (VehicleGarage.CheckIfVehicleExistInGarage(strInputVehicleLicenceNumber) == v_VehicleExistInGarage)
            {
                VehicleGarage.InflateTheVehicleWheelsToMax(strInputVehicleLicenceNumber);

                Console.WriteLine("########## Vehicle Wheels was inflated to max successfully :)))))))) ##########");
            }
            else
            {
                Console.WriteLine("########## No vehicle licence number in the garage !!! ##########");
            }
        }

        private void fillFuelToGasolineVehicle()
        {
            string strInputVehicleLicenceNumber;
            const bool v_VehicleExistInGarage = true;
            const bool v_ItIsGasolineVehicle = true;
            string strFuelTypeChoise, strInputFuelQuantity;

            getTheVehicleLicenceNumber(out strInputVehicleLicenceNumber);

            if (VehicleGarage.CheckIfVehicleExistInGarage(strInputVehicleLicenceNumber) == v_VehicleExistInGarage && VehicleGarage.CheckIfElectricVehicle(strInputVehicleLicenceNumber) != v_ItIsGasolineVehicle)
            {
                chooseFuelTypeToFill(out strFuelTypeChoise);
                
                chooseFuelQuantityToFill(out strInputFuelQuantity);
                    
                VehicleGarage.FuelGasolineVehicle(strInputVehicleLicenceNumber, strFuelTypeChoise, strInputFuelQuantity);
                    
                Console.WriteLine("########## Filling fuel for required vehicle was successfully :)))))))) ##########");
            }
            else
            {
                Console.WriteLine("########## No vehicle licence number in the garage or it's an electric vehicle !!! ##########");
            }
        }
        
        private void chooseFuelTypeToFill(out string o_StrFuelTypeChoise)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            o_StrFuelTypeChoise = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    string strfuelTypeMsg = string.Format(
                                                        @"Please choose type of gasoline :
                                                        1. Octan95
                                                        2. Octan96
                                                        3. Octan98
                                                        4. Soler");
                    Console.WriteLine(strfuelTypeMsg);
                    o_StrFuelTypeChoise = Console.ReadLine();

                    // Check it's a good input fuel choise
                    CheckInputsFromUserCorrect.CheckIntegerInputFromUserIsInCorrectRange(o_StrFuelTypeChoise, 1, Enum.GetNames(typeof(GasolineVehicle.eFuelTypes)).Length);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }

        private void chooseFuelQuantityToFill(out string i_StrInputFuelQuantity)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            i_StrInputFuelQuantity = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    string strfuelTypeMsg = string.Format("Please insert the fuel quantity you want to fill");
                    Console.WriteLine(strfuelTypeMsg);
                    i_StrInputFuelQuantity = Console.ReadLine();

                    // Check it's a good input fuel quantity choise
                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveFloatNumberType(i_StrInputFuelQuantity);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        } 
        
        private void displayAllSpecificVehicleDetailsInTheGarage()
        {
            string strInputVehicleLicenceNumber;

            getTheVehicleLicenceNumber(out strInputVehicleLicenceNumber);
  
            Console.WriteLine(VehicleGarage.PrintAllDictionaryDetails(strInputVehicleLicenceNumber));
        }

        private void chargeElectricVehicle()
        {
            string strInputVehicleLicenceNumber;
            const bool v_VehicleExistInGarage = true;
            const bool v_ItIsGasolineVehicle = true;
            string strInputBatteryTimeInHours;

            getTheVehicleLicenceNumber(out strInputVehicleLicenceNumber);

            if (VehicleGarage.CheckIfVehicleExistInGarage(strInputVehicleLicenceNumber) == v_VehicleExistInGarage && VehicleGarage.CheckIfElectricVehicle(strInputVehicleLicenceNumber) == v_ItIsGasolineVehicle)
            {
                chooseTimeToChargeBattery(out strInputBatteryTimeInHours);

                VehicleGarage.ChargeElectricVehicle(strInputVehicleLicenceNumber, strInputBatteryTimeInHours);

                Console.WriteLine("########## Battery Charge for required vehicle was successfully :)))))))) ##########");
            }
            else
            {
                Console.WriteLine("########## No vehicle licence number in the garage or it's not an electric vehicle !!! ##########");
            }
        }

        private void chooseTimeToChargeBattery(out string i_StrInputBatteryTimeInHours)
        {
            const bool v_CorrectInput = true;
            bool userEnteredCorrectInput = true;

            i_StrInputBatteryTimeInHours = null;
            userEnteredCorrectInput = !userEnteredCorrectInput;

            while (userEnteredCorrectInput != v_CorrectInput)
            {
                try
                {
                    Console.WriteLine();
                    string strfuelTypeMsg = string.Format("Please insert how many houres you want to charge vehicle battery :");
                    Console.WriteLine(strfuelTypeMsg);
                    i_StrInputBatteryTimeInHours = Console.ReadLine();

                    // Check it's a good input number of hours choise
                    CheckInputsFromUserCorrect.CheckInputFromUserIsPositiveFloatNumberType(i_StrInputBatteryTimeInHours);

                    userEnteredCorrectInput = v_CorrectInput;
                }
                catch (FormatException formatEx)
                {
                    Console.WriteLine(formatEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(argumentEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
                catch (ValueOutOfRangeException valueOutOfRangeEx)
                {
                    Console.WriteLine(valueOutOfRangeEx.Message);
                    userEnteredCorrectInput = !v_CorrectInput;
                }
            }
        }
    }
}
