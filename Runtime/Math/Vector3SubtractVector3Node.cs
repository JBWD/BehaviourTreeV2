using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Vector3", menuName = "Vector3: Subtract Vector3", nodeTitle = "Vector3 Math:\nSubtract Vector3", 
        nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector3SubtractVector3Node : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<Vector3> subtractValue;
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
                        $"Subtracts '{baseValue.Value}' - '{subtractValue.Value}' and saves the total in '{saveValue.reference.name}'";
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