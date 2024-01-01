using System;

namespace TheKiwiCoder
{
    
    [BehaviourTreeNode(menuFolder = "String", nodeTitle = "Append Float", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
    [Serializable]
    public class AppendFloatNode : ActionNode
    {

        public NodeProperty<string> originalString;
        public NodeProperty<float> appendedValue;
        public NodeProperty<string> saveString;
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveString.Value = originalString.Value + appendedValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            
            description = $"'{originalString.Value}{appendedValue.Value}' will be saved in '{saveString.reference.name}'";
        }
    }
}