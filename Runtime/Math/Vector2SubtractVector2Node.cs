using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector2")]
    [NodeTitle("Math:\nVector2 Subtract")]
    [NodeMenuName("Math: Vector2 Subtract")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("SubtractVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class Vector2SubtractVector2Node : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<Vector2> subtractValue;
        [BlackboardValueOnly]
        public NodeProperty<Vector2> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value - subtractValue.Value;
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
                        $"Adds '{baseValue.Value}' - '{subtractValue.Value}' and saves the total in '{saveValue.reference.name}'";
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