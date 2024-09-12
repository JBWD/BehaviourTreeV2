using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Math/Vector2", menuName = "Vector2: Add Vector2", nodeTitle = "Vector2 Math:\nAdd Vector2", 
        nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector2AddVector2Node : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<Vector2> addValue;
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