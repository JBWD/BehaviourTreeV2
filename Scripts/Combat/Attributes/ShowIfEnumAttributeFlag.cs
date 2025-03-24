using System;
using UnityEngine;

namespace Halcyon
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfEnumFlagAttribute : PropertyAttribute
    {
        public string EnumFieldName { get; }
        public int EnumFlagValue { get; }

        public ShowIfEnumFlagAttribute(string enumFieldName, int enumFlagValue)
        {
            EnumFieldName = enumFieldName;
            EnumFlagValue = enumFlagValue;
        }
    }
}
