using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("Please insert values between: {0} to {1}", i_MinValue, i_MaxValue))
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public float MinValue
        {
            get { return this.m_MinValue; }
            set { this.m_MinValue = value; }
        }

        public float MaxValue
        {
            get { return this.m_MaxValue; }
            set { this.m_MaxValue = value; }
        }
    }
}
