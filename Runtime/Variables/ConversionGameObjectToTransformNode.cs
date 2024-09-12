using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: GameObject to Transform", 
        nodeTitle = "Conversion:\nGameObject to Transform", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]
    [System.Serializable]
    public class ConversionGameObjectToTransformNode : ActionNode
    {

        [BlackboardValueOnly]
        public NodeProperty<GameObject> gameObjectValue;
        [BlackboardValueOnly]
        public NodeProperty<Transform> saveTransform;

        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            if (saveTransform.reference == null || gameObjectValue.Value == null)
                state = State.Failure;
            else
            {
                saveTransform.Value = gameObjectValue.Value.transform;
                state = State.Success;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;
            
            if (saveTransform.reference != null && gameObjectValue.Value != null)
            {

                description =
                    $"Saves the GameObject of 'TransformValue' in '{saveTransform.reference.name}'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        } 
    }
}