using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CreateBBVariableAttribute: Attribute
    {
        private string variableName;
        private BBVariableType variableType;
        
            
            
        public CreateBBVariableAttribute(string variableName, BBVariableType variableType)
        {
            this.variableName = variableName;
            this.variableType = variableType;
        }

        public string GetVariableName()
        {
            return variableName;
            
        }

        public string GetVariableType()
        {
            return variableType.ToString();
        }
    }

    [Serializable]
    public class BBVariableKey
    {
        public string VariableName;
        public BBVariableType VariableType;
    }

    public enum BBVariableType
    {
        Boolean,
        String,
        Vector2,
        Vector3,
        Vector4,
        Vector2Int,
        Vector3Int,
        Gradient,
        Color,
        Layer,
        LayerMask,
        Tag,
        Curve,
        Bounds,
        BoundsInt,
        GameObject,
        Material,
        RigidBody,
        Collider,
        TextMeshProUGUI,
        Light,
        UnityEvent,
        Transform,
        Button,
        Quaternion,
        Scene,
        PathList,
        Number
    }
}