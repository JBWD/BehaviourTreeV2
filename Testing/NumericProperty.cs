using System;
using UnityEngine;

namespace Halcyon.BT
{
    [Serializable]
    public class NumericProperty
    {
        [SerializeField]
        private NumericParameterType parameterType;
        [SerializeField]
        private NodeProperty<int> integerValue;
        [SerializeField]
        private NodeProperty<float> floatValue;
        [SerializeField]
        private NodeProperty<double> doubleValue;
        //public NodeProperty<long> longValue;
        
        public Type GetNumericType()
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    return typeof(int);
                case NumericParameterType.Float:
                    return typeof(float);
                case NumericParameterType.Double:
                    return typeof(double);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetValue(float value)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value = (int)value;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value = (float)value;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value = (double)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void SetValue(int value)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value = (int)value;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value = (float)value;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value = (double)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void SetValue(double value)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value = (int)value;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value = (float)value;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value = (double)value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
        public float FloatValue
        {
            get
            {
                switch (parameterType)
                {
                    case NumericParameterType.Integer:
                        return integerValue.Value;
                    case NumericParameterType.Float:
                        return floatValue.Value;
                    case NumericParameterType.Double:
                        return Convert.ToInt32(doubleValue.Value);   
                    default:
                        return 0;
                }
            }
        }
        
        public double DoubleValue
        {
            get
            {
                switch (parameterType)
                {
                    case NumericParameterType.Integer:
                        return integerValue.Value;
                    case NumericParameterType.Float:
                        return floatValue.Value;
                    case NumericParameterType.Double:
                        return doubleValue.Value;   
                    default:
                        return 0;
                }
            }
        }
        
        
        public int IntegerValue
        {
            get
            {
                switch (parameterType)
                {
                    case NumericParameterType.Integer:
                        return integerValue.Value;
                    case NumericParameterType.Float:
                        return (int)floatValue.Value;
                    case NumericParameterType.Double:
                        return (int)doubleValue.Value;   
                    default:
                        return 0;
                }
            }
        }

        public BlackboardKey Reference()
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    return integerValue.reference;
                case NumericParameterType.Float:
                    return floatValue.reference;    
                case NumericParameterType.Double:
                    return doubleValue.reference;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void AddValue(NumericProperty property)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value += property.IntegerValue;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value += property.FloatValue;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value += property.DoubleValue; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void SubtractValue(NumericProperty property)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value -= property.IntegerValue;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value -= property.FloatValue;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value -= property.DoubleValue; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void MultiplyValue(NumericProperty property)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value *= property.IntegerValue;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value *= property.FloatValue;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value *= property.DoubleValue; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void DivideValue(NumericProperty property)
        {
            switch (parameterType)
            {
                case NumericParameterType.Integer:
                    integerValue.Value /= property.IntegerValue;
                    break;
                case NumericParameterType.Float:
                    floatValue.Value /= property.FloatValue;
                    break;
                case NumericParameterType.Double:
                    doubleValue.Value /= property.DoubleValue; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}


