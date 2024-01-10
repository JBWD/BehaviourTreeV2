using System;
using Unity.Properties;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "String", nodeTitle = "Concatenate Strings", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
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