using UnityEngine;

namespace Halcyon.BT
{
    [BehaviourTreeNode(menuName = "GameObject: Instantiate", menuPath = "GameObject", nodeTitle = "GameObject:\nInstantiate", nodeColor = NodeColors.green, nodeIcon = NodeIcons.destination)]
    [System.Serializable]
    public class GameObjectInstantiateNode : ActionNode
    {

        public NodeProperty<GameObject> objectPrefab;
        public bool spawnInWorldSpace = false;
        public NodeProperty<Vector3> spawnPosition;
        public NodeProperty<Quaternion> spawnRotation;
        [BlackboardValueOnly]
        public NodeProperty<Transform> parent;
        [BlackboardValueOnly]
        [Space] public NodeProperty<GameObject> saveGameObject;
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
            
            if (objectPrefab.Value == null)
            {
                state = State.Failure;
            }
            else
            {
                var gameObject = spawnInWorldSpace
                    ? Object.Instantiate(objectPrefab.Value, spawnPosition.Value, Quaternion.identity)
                    : Object.Instantiate(objectPrefab.Value, context.transform.position + spawnPosition.Value, Quaternion.identity);
                gameObject.transform.rotation = spawnRotation.Value;
                saveGameObject.Value = gameObject;
                saveTransform.Value = gameObject.transform;
                if (parent.Value != null)
                {
                    gameObject.transform.SetParent(parent.Value);
                    gameObject.transform.localPosition = spawnPosition.Value;
                    gameObject.transform.localRotation = spawnRotation.Value;
                }

                state = State.Success;
            }

            return state;


        }

        public override void UpdateDescription()
        {
            errored = false;

            description =
                $"Creates a clone of [ObjectPrefab] at the specified location and will save the created object in the corresponding fields.";
            if (objectPrefab.reference == null && objectPrefab.Value == null)
            {
                errored = true;
                description = "Object not found, please assign an [ObjectPrefab].";
            }
        }
    }
}