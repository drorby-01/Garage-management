using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxWheelPressureManufacturerSuggested; // This field is set in the object creation constructor and can't never change 
        private string m_WheelManufacturerName;
        private float m_CurrentWheelPressure;

        public Wheel(string i_WheelManufacturerName, float i_MaxWheelPressureManufacturerSuggested)
        {
            this.m_WheelManufacturerName = i_WheelManufacturerName;
            this.r_MaxWheelPressureManufacturerSuggested = i_MaxWheelPressureManufacturerSuggested;
        }

        public string ManufacturerName
        {
            get { return m_WheelManufacturerName; }
            set { this.m_WheelManufacturerName = value; }
        }

        public float CurrentWheelPressure
        {
            get { return this.m_CurrentWheelPressure; }
            set { this.m_CurrentWheelPressure = value; }
        }

        public float MaxWheelPressureManufacturerSuggested
        {
            get { return this.r_MaxWheelPressureManufacturerSuggested; }
        }

        public void WheelInflate(float i_PressureToAdd)
        {
            if (m_CurrentWheelPressure + i_PressureToAdd > r_MaxWheelPressureManufacturerSuggested)
            {
                throw new ValueOutOfRangeException(0, r_MaxWheelPressureManufacturerSuggested - m_CurrentWheelPressure);
            }
            else
            {
                this.m_CurrentWheelPressure += i_PressureToAdd;
            }
        }

        public void InflateSingelWheelToMax()
        {
            this.m_CurrentWheelPressure = r_MaxWheelPressureManufacturerSuggested;
        }

        public override string ToString()
        {
            string newLine = Environment.NewLine;
            StringBuilder wheelDetails = new StringBuilder();

            wheelDetails.AppendFormat("Wheel -  Model: {0} {1}", ManufacturerName, newLine);
            wheelDetails.AppendFormat("Wheel - Current pressure: {0} {1}", CurrentWheelPressure, newLine);
            wheelDetails.AppendFormat("Wheel - max Pressure: {0} {1}", r_MaxWheelPressureManufacturerSuggested, newLine);

            return wheelDetails.ToString();
        }
    }
}
