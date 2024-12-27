using System;
using UnityEngine;

namespace Halcyon.BT
{
    [Serializable]
    public class NumericProperty
    {
        [SerializeField]
        private double doubleValue = 0;

        public float FloatValue
        {
            get
            {
                return (float)doubleValue;
            }
            set
            {

                doubleValue = (double)value;

            }
        }
        
        public double DoubleValue
        {
            get
            {
                return doubleValue;
            }
            set
            {
                doubleValue = (double)value;
            }
        }
        
        
        public int IntegerValue
        {
            get
            {
                return (int)doubleValue;
            }
            set
            {
                doubleValue = (double)value;

            }
        }
        
        
        /*public void AddValue(NumericProperty property)
        {
            property.doubleValue += doubleValue;
        }
        public void AddValue(float value)
        {
            floatValue += value;
        }
        public void AddValue(double value)
        {
            doubleValue += value;
        }
        public void AddValue(int value)
        {
            integerValue += value;
        }
        public void AddValue(long value)
        {
            longValue += value;
        }
        
        
        public void SubtractValue(NumericProperty property)
        {
            property.doubleValue -= doubleValue;
        }
        public void SubtractValue(float value)
        {
            floatValue -= value;
        }
        public void SubtractValue(double value)
        {
            doubleValue -= value;
        }
        public void SubtractValue(int value)
        {
            integerValue -= value;
        }
        public void SubtractValue(long value)
        {
            longValue -= value;
        }
        public void MultiplyValue(NumericProperty property)
        {
            property.doubleValue *= doubleValue;
        }
        public void MultiplyValue(float value)
        {
            floatValue *= value;
        }
        public void MultiplyValue(double value)
        {
            doubleValue*= value;
        }
        public void MultiplyValue(int value)
        {
            integerValue*= value;
        }
        public void MultiplyValue(long value)
        {
            longValue *= value;
        }
        public void DivideValue(NumericProperty property)
        {
            property.doubleValue /= doubleValue;
        }
        public void DivideValue(float value)
        {
            floatValue /= value;
        }
        public void DivideValue(double value)
        {
            doubleValue/= value;
        }
        public void DivideValue(int value)
        {
            integerValue/= value;
        }
        public void DivideValue(long value)
        {
            longValue /= value;
        }*/
    }
}


