using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Math/Vector2", menuName = "Vector2: Magnitude", nodeTitle = "Vector2 Math:\nMagnitude", nodeColor = NodeColors.green, nodeIcon = NodeIcons.math)]
    [System.Serializable]
    public class Vector2MagnitudeNode: ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<float> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        
        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value.magnitude;
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
                        $"Retrieves the magnitude of '{baseValue.Value}' and saves the total in '{saveValue.reference.name}'";
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