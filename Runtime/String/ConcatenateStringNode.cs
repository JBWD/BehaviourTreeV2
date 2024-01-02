using System;
using Unity.Properties;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "String", nodeTitle = "Concatenate Strings", nodeColor = NodeColors.green, nodeIcon = NodeIcons.action)]
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
            Debug.Log(Time.realtimeSinceStartup);
            for(int i = 0;i<10000;i++)
                saveString.Value = baseString.Value + addString.Value;
            Debug.Log(Time.realtimeSinceStartup);
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