using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Vector3", menuName = "Vector3: Multiply Float", nodeTitle = "Vector3 Math:\nMultiply Float", 
        nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector3MultiplyFloatNode : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<float> multiplyValue;
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