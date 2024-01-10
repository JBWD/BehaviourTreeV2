using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable",menuName = "Variable: Set Vector 3", nodeTitle = "Variables:\nSet Vector3",
        nodeIcon = NodeIcons.save, nodeColor = NodeColors.pink)]
    [System.Serializable]
    public class SetVector3Node : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
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
            saveValue.Value = baseValue.Value;
            state = State.Success;
            return state;
        }
    }
}