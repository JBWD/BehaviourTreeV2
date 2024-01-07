using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Vector2", menuName = "Vector2: Normalize", nodeTitle = "Vector2 Math:\nNormalize", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector2NormalizeNode: ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<Vector2> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        
        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value.normalized;
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
                        $"Retrieves the normalized value of '{baseValue.Value}' and saves it in '{saveValue.reference.name}'";
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