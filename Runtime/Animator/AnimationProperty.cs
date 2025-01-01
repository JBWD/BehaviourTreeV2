using System;
using UnityEngine.Serialization;


namespace Halcyon.BT
{
    
    //
    // //This class in currently not implemented and is to be used to allow for multi-manipulation of animations with parameters.
    // [Serializable]
    // public class AnimationProperty
    // {
    //     public AnimationParameterType parameterType;
    //     [NodePropertyTypeSelector(typeof(string))]
    //     public NodeProperty animationName;
    //     [NodePropertyTypeSelector(typeof(float))]
    //     public NodeProperty floatParameter;
    //     [NodePropertyTypeSelector(typeof(int))]
    //     public NodeProperty integerParameter;
    //     [NodePropertyTypeSelector(typeof(bool))]
    //     public NodeProperty booleanParameter;
    // }

    [Serializable]
    public class AnimationProperty
    {
        public AnimationParameterType parameterType;
        public string parameterName;
        public float floatParameter;
        public int integerParameter;
        public bool booleanParameter;
    }
    

}