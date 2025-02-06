using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("String")]
    [NodeTitle("String:\nConcatenate String")]
    [NodeMenuName("String: Concatenate String")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseStringValue", BBVariableType.String)]
    [CreateBBVariable("AddStringValue", BBVariableType.String)]
    [CreateBBVariable("SaveStringValue", BBVariableType.String)]
    [Serializable]
    public class ConcatenateStringNode : ActionNode
    {

     
        public NodeProperty<string> baseString;
        public NodeProperty<string> addString;
        public NodeProperty<string> saveString;
        
        protected override void OnStart()
        { }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            
            saveString.Value = baseString.Value + addString.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            if (saveString.reference != null)
            {
                description = $"'{baseString.Value}{addString.Value}' will be saved in '{saveString.reference.name}'";
            }
            else
            {
                description = $"'{baseString.Value}{addString.Value}' will be saved in 'saveString'";
            }
        }
    }
}