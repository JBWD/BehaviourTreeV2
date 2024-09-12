using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable",menuName = "Variable: Set Vector 2", nodeTitle = "Variables:\nSet Vector2",
        nodeIcon = NodeIcons.save, nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class SetVector2Node : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
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