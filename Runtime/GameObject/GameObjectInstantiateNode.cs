using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuName = "GameObject: Instantiate", menuPath = "GameObject", nodeTitle = "GameObject:\nInstantiate", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [Serializable]
    public class GameObjectInstantiateNode : ActionNode
    {

        public NodeProperty<GameObject> objectPrefab;
        public NodeProperty<Vector3> spawnPosition;
        public NodeProperty<Vector3> spawnRotation;
        

        protected override void OnStart()
        {
            MonoBehaviour.Instantiate(objectPrefab.Value, spawnPosition.Value, Quaternion.Euler(spawnRotation.Value));
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            
            if (objectPrefab.Value == null)
            {
                state = State.Failure;
            }
            else
            {
                
                state = State.Success;
            }

            return state;


        }
    }
}