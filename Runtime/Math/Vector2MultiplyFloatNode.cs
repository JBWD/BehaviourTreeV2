using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector2")]
    [NodeTitle("Math:\nVector2 Multiply Numeric")]
    [NodeMenuName("Math: Vector2 Multiply Numeric")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("MultiplyNumericValue", BBVariableType.Number)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class Vector2MultiplyFloatNode : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<NumericProperty> multiplyValue;
        [BlackboardValueOnly] public NodeProperty<Vector2> saveValue;


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