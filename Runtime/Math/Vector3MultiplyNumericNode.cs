using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector3")]
    [NodeTitle("Math:\nVector3 Multiply Numeric")]
    [NodeMenuName("Math: Vector3 Multiply Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("MultiplyNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class Vector3MultiplyNumericNode : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<NumericProperty> multiplyValue;
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
            saveValue.Value = baseValue.Value * multiplyValue.Value.FloatValue;
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
                        $"Multiplies '{baseValue.Value}' * '{multiplyValue.Value.FloatValue}' and saves the total in '{saveValue.reference.name}'";
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