using System;
using UnityEngine;

namespace Halcyon
{
    
    [Serializable]
    [BehaviourTreeNode(menuPath = "String", menuName = "(SLOW) Append Variable",nodeTitle = "(SLOW) String\nAppend Variable", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
    public class AppendVariableNode : ActionNode
    {
        
        public NodeProperty<string> originalString;
        public NodeProperty appendedValue;
        public NodeProperty<string> saveString;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            //saveString.Value = originalString.Value + blackboard.GetValueString(appendedValue);
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            
        }
    }
}