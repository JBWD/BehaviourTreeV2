using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuPath = "Math/Vector3", menuName = "Vector3: Normalize", nodeTitle = "Vector3 Math:\nNormalize", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector3NormalizeNode: ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<Vector3> saveValue;


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