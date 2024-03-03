using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Vector2", menuName = "Vector2: Multiply Float",
        nodeTitle = "Vector2 Math:\nMultiply Float",
        nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector2MultiplyFloatNode : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<float> multiplyValue;
        [BlackboardValueOnly] public NodeProperty<Vector2> saveValue;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value * multiplyValue.Value;
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
                        $"Multiplies '{baseValue.Value}' * '{multiplyValue.Value}' and saves the total in '{saveValue.reference.name}'";
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