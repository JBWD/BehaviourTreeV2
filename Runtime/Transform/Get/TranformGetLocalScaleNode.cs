﻿using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\n Get Local Scale")]
    [NodeMenuName("Transform: Get Local Scale")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("TransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class TranformGetLocalScaleNode :ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
        [BlackboardValueOnly] public NodeProperty<Vector3> saveValue;

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            state = State.Failure;

            
            if (self && context.transform != null)
            {
                state = State.Success;
                saveValue.Value = context.transform.localScale;
            }
            else
            {
                state = State.Success;
                saveValue.Value = transformValue.Value.localScale;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the localScale of the object and saves the localScale in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}