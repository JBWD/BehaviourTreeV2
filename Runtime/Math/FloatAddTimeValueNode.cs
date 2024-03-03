using System;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Float", menuName = "Float: Add Time", nodeTitle = "Float Math:\nAdd Time", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class FloatAddTimeValueNode : ActionNode
    {

        public TimeTypes timeType;
        
        
        public NodeProperty<float> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;


        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {

            if (saveValue.reference == null)
            {
                state = State.Failure;
                return state;
            }

            switch (timeType)
            {
                case TimeTypes.Delta:
                    saveValue.Value = baseValue.Value + Time.deltaTime;
                    break;
                case TimeTypes.Fixed:
                    saveValue.Value = baseValue.Value = Time.fixedTime;
                    break;
                case TimeTypes.UnscaledDelta:
                    saveValue.Value = baseValue.Value + Time.unscaledDeltaTime;
                    break;
                case TimeTypes.UnscaledFixed:
                    saveValue.Value = baseValue.Value + Time.fixedUnscaledDeltaTime;
                    break;
            }



            
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            try
            {
                if (saveValue.reference != null)
                {
                    
                    description =
                        $"Adds '{baseValue.Value}' + '[TimeValue]' and saves the total in '{saveValue.reference.name}'";
                }
                else
                {
                    description = "Does not save the value";
                    errored = true;
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}