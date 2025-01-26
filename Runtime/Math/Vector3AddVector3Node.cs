using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector3")]
    [NodeTitle("Math:\nVector3 Multiply Numeric")]
    [NodeMenuName("Math: Vector3 Multiply Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseNumericValue", BBVariableType.Number)]
    [CreateBBVariable("MultiplyNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveNumericValue", BBVariableType.Number)]
    [System.Serializable]
    public class Vector3AddVector2Node : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<Vector3> addValue;
        [BlackboardValueOnly]
        public NodeProperty<Vector3> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value + addValue.Value;
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
                        $"Adds '{baseValue.Value}' + '{addValue.Value}' and saves the total in '{saveValue.reference.name}'";
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