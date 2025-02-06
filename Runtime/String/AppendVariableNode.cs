using System;
using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuPath("String")]
    [NodeTitle("String:\nAppend Variable")]
    [NodeMenuName("String: Append Variable")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("OriginalStringValue", BBVariableType.String)]
    [CreateBBVariable("SaveStringValue", BBVariableType.String)]
    [Serializable]
    public class AppendVariableNode : ActionNode
    {
        
        public NodeProperty<string> originalString;
        public NodeProperty<object> appendedValue;
        public NodeProperty<string> saveString;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveString.Value = originalString.Value + blackboard.GetValueString(appendedValue);
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            
        }
    }
}