using System;

namespace Ex03.GarageLogic
{
    public class CheckInputsFromUserCorrect
    {
        public static void CheckInputFromUserIsPositiveNumber(string i_StrInputFromUserToCheck)
        {
            int intInputFromUserToCheck;
            const bool v_SuccessToParseFromStringToInt = true;

            if (int.TryParse(i_StrInputFromUserToCheck, out intInputFromUserToCheck) != v_SuccessToParseFromStringToInt)
            {
                throw new FormatException("Wrong Input!!! You can insert only number!");
            }
            else if (intInputFromUserToCheck < 0)
            {
                throw new FormatException("Wrong Input!!! You can insert only positive number!");
            }
        }

        public static void CheckIntegerInputFromUserIsInCorrectRange(string i_StrInputFromUserToCheck, int i_StartInputValue, int i_EndInputValue)
        {
            int intInputFromUserToCheck;
            const bool v_SuccessToParseFromStringToInt = true;

            if (int.TryParse(i_StrInputFromUserToCheck, out intInputFromUserToCheck) != v_SuccessToParseFromStringToInt)
            {
                throw new FormatException("Wrong Input!!! You can insert only number");
            }
            else
            {
                if (intInputFromUserToCheck > i_EndInputValue || intInputFromUserToCheck < i_StartInputValue)
                {
                    throw new ValueOutOfRangeException(i_StartInputValue, i_EndInputValue);
                }
            }
        }

        public static void CheckFloatInputFromUserIsInCorrectRange(string i_StrInputFromUserToCheck, float i_StartInputValue, float i_EndInputValue)
        {
            float floatInputFromUserToCheck;
            const bool v_SuccessToParseFromStringToInt = true;

            if (float.TryParse(i_StrInputFromUserToCheck, out floatInputFromUserToCheck) != v_SuccessToParseFromStringToInt)
            {
                throw new FormatException("Wrong Input!!! You can insert only number");
            }
            else
            {
                if (floatInputFromUserToCheck > i_EndInputValue || floatInputFromUserToCheck < i_StartInputValue)
                {
                    throw new ValueOutOfRangeException(i_StartInputValue, i_EndInputValue);
                }
            }
        }

        public static void CheckInputFromUserIsPositiveFloatNumberType(string i_StrInputFromUserToCheck)
        {
            float floatInputFromUserToCheck;
            const bool v_SuccessToParseFromStringToFloat = true;

            if (float.TryParse(i_StrInputFromUserToCheck, out floatInputFromUserToCheck) != v_SuccessToParseFromStringToFloat)
            {
                throw new FormatException("Wrong Input!!! You can insert only float number!");
            }
            else if (floatInputFromUserToCheck < 0)
            {
                throw new FormatException("Wrong Input!!! You can insert only positive number!");
            }
        }

        public static void CheckInputLicenceNumberFromUserIsCorrectAndChangeStatusInGarage(string i_StrInputFromUserToCheck)
        {
            int intInputFromUserToCheck;
            const bool v_VehicleToAddAlreadyExistInGarage = true;

            if (!int.TryParse(i_StrInputFromUserToCheck, out intInputFromUserToCheck))
            {
                throw new FormatException("Wrong Input!!! You can insert only digits!");
            }
            else if (intInputFromUserToCheck < 0)
            {
                throw new FormatException("Wrong Input!!! You can insert only positive number!");
            }
            else
            {
                if (VehicleGarage.CheckIfVehicleExistInGarage(i_StrInputFromUserToCheck) == v_VehicleToAddAlreadyExistInGarage)
                {
                    // Change this vehicle status to 'Infix'
                    VehicleGarage.ChangeVehicleStatusInTheGarage(i_StrInputFromUserToCheck, Vehicle.eVehicleStatusInGarage.Infix);
                    throw new ArgumentException("Wrong licence number!!! This ID is already exist in garage - His status was change to 'Infix'!");
                }
            }
        }

        public static void CheckInputLicenceNumberFromUserIsCorrect(string i_StrInputFromUserToCheck)
        {
            int intInputFromUserToCheck;

            if (!int.TryParse(i_StrInputFromUserToCheck, out intInputFromUserToCheck))
            {
                throw new FormatException("Wrong Input!!! You can insert only digits!");
            }
            else if (intInputFromUserToCheck < 0)
            {
                throw new FormatException("Wrong Input!!! You can insert only positive number!");
            }
        }

        public static void CheckInputFromUserContainsOnlyLetters(string i_StrInputFromUserToCheck)
        {
            for (int i = 0; i < i_StrInputFromUserToCheck.Length; i++)
            {
                if (!char.IsLetter(i_StrInputFromUserToCheck[i]))
                {
                    throw new FormatException("Wrong Input!!! You can insert only letters!");
                }
            }
        }

        public static void CheckInputFromUserIsOnlyBooleanValue(string i_StrInputFromUserToCheck)
        {
            const string k_TrueBoolValue = "true";
            const string k_FalseBoolValue = "false";

            if (i_StrInputFromUserToCheck != k_TrueBoolValue && i_StrInputFromUserToCheck != k_FalseBoolValue)
            {
                throw new FormatException("Wrong Input!!! You can insert only 'true' or 'false' string!");
            }
        }
    }
}
