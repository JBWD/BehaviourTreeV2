using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Transform to GameObject", 
        nodeTitle = "Conversion:\nTransform to GameObject", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]
    [System.Serializable]
    public class ConversionTranformToGameObjectNode : ActionNode
    {

        [BlackboardValueOnly]
        public NodeProperty<Transform> transformValue;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveGameObject;



        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            if (saveGameObject.Value == null || transformValue.Value == null)
                state = State.Failure;
            else
            {
                saveGameObject.Value = transformValue.Value.gameObject;
                state = State.Success;
            }

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;
            
            if (saveGameObject.reference != null && transformValue.Value != null)
            {

                description =
                    $"Saves the GameObject of 'TransformValue' in '{saveGameObject.reference.name}'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        }  
    }
}