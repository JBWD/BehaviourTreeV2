using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nSet Transform")]
    [NodeMenuName("Variable: Set Transform")] 
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseTransformValue", BBVariableType.Transform)]
    [CreateBBVariable("SaveTransformValue", BBVariableType.Transform)]
    [System.Serializable]
    public class SetTransformNode : ActionNode
    {

        public NodeProperty<Transform> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<Transform> saveValue;
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value;
            state = State.Success;
            return state;
        }
        public override void UpdateDescription()
        {
            errored = false;
            if (saveValue.reference == null)
            {
                description = "Does not save any of the values";
                errored = true;
            }
            else
            {
                description = "Sets the 'SaveValue' to the same value or reference as 'BaseValue'";
            }
        }
    }
}