using System;
using UnityEngine;

namespace Halcyon{
    [AttributeUsage(AttributeTargets.Field , AllowMultiple = true)]
    public class ShowIfEnumAttribute : PropertyAttribute
    {
        public string EnumFieldName { get; private set; }
        public object EnumValue { get; private set; }

        public ShowIfEnumAttribute(string enumFieldName, object enumValue)
        {
            EnumFieldName = enumFieldName;
            EnumValue = enumValue;
        }
    }
}