using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolineVehicle : VehicleType
    {
        public enum eFuelTypes
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4,
        }

        private readonly float r_MaxFuelQuantityInLiters; // This field is set in the object creation constructor and can't never change 
        private eFuelTypes m_FuelType;
        private float m_CurrentFuelQuantityInLiters;

        public GasolineVehicle(string i_StrMaxGasolineAmount, string i_StrGasolineType) : base(eVehicleType.Gasoline)
        {
            this.r_MaxFuelQuantityInLiters = float.Parse(i_StrMaxGasolineAmount);
            this.m_FuelType = (eFuelTypes)Enum.Parse(typeof(eFuelTypes), i_StrGasolineType);
        }

        public float CurrentFuelQuantityInLiters
        {
            get { return this.m_CurrentFuelQuantityInLiters; }
            set { this.m_CurrentFuelQuantityInLiters = value; }
        }

        public float MaxFuelQuantityInLiters
        {
            get { return this.r_MaxFuelQuantityInLiters; }
        }

        public GasolineVehicle.eFuelTypes FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public override void FillPowerSource(params string[] i_DataToFillEnergySource)
        {
            const bool v_ValidAmountOfFuelToAdd = true, v_ValidFuelTypeToAdd = true;

            float floatAmountOfFuelToAdd = float.Parse(i_DataToFillEnergySource[0]);
            eFuelTypes fuelTypeToAdd = (eFuelTypes)Enum.Parse(typeof(eFuelTypes), i_DataToFillEnergySource[1]);

            if(checkIfValidFuelTypeToAdd(fuelTypeToAdd) != v_ValidFuelTypeToAdd)
            {
                throw new ArgumentException("Wrong Fuel Type Selected!!!");
            }
            else 
            {
                if (r_MaxFuelQuantityInLiters - m_CurrentFuelQuantityInLiters == 0)
                {
                    throw new ArgumentException("The fuel tank is over!!!");
                }
                else if(checkIfTheAmountOfFuelToAddIsInTheRange(floatAmountOfFuelToAdd) != v_ValidAmountOfFuelToAdd)
                {
                    // In case it's a right fuel type, so now check the amount
                    throw new ValueOutOfRangeException(0, r_MaxFuelQuantityInLiters - m_CurrentFuelQuantityInLiters);
                }
                else
                {
                    m_CurrentFuelQuantityInLiters += floatAmountOfFuelToAdd;
                }
            }
        }

        public override void UpdateCurrentStatusOfEnergySource(string i_strLeftEnergy)
        {
            float floatLeftEnergy = float.Parse(i_strLeftEnergy);

            if (floatLeftEnergy <= r_MaxFuelQuantityInLiters && floatLeftEnergy >= 0)
            {
                m_CurrentFuelQuantityInLiters = floatLeftEnergy;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxFuelQuantityInLiters);
            }
        }

        private bool checkIfTheAmountOfFuelToAddIsInTheRange(float i_AmountOfFuelToAdd)
        {
            bool isValidAmountOfFuelToAdd = true;

            if ((i_AmountOfFuelToAdd <= 0) || (i_AmountOfFuelToAdd + m_CurrentFuelQuantityInLiters > r_MaxFuelQuantityInLiters))
            {
                isValidAmountOfFuelToAdd = !isValidAmountOfFuelToAdd;
            }

            return isValidAmountOfFuelToAdd;
        }

        private bool checkIfValidFuelTypeToAdd(eFuelTypes i_FuelTypeToAdd)
        {
            bool isValidFuelTypeToAdd = true;

            if (i_FuelTypeToAdd != m_FuelType)
            {
                isValidFuelTypeToAdd = !isValidFuelTypeToAdd;
            }

            return isValidFuelTypeToAdd;
        }

        public override string ToString()   
        {
            string newLine = Environment.NewLine;
            StringBuilder gasolineVehicleDetails = new StringBuilder();

            gasolineVehicleDetails.AppendFormat("Gasoline Vehicle - Fuel type: {0} {1}", FuelType, newLine);
            gasolineVehicleDetails.AppendFormat("Gasoline Vehicle - Current fuel power source: {0} {1}", m_CurrentFuelQuantityInLiters, newLine);
            gasolineVehicleDetails.AppendFormat("Gasoline Vehicle - Max fuel power source: {0} {1}", r_MaxFuelQuantityInLiters, newLine);

            return gasolineVehicleDetails.ToString();
        }
    }
}
