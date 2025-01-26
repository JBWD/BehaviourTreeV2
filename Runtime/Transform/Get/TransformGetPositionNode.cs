using UnityEngine;

namespace Halcyon.BT
{
   
    [NodeMenuName("Transform: Get Position"), 
     NodeMenuPath("Transform/Get")]
    [NodeTitle("Transform:\nGet Position")]
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("Transform Value", BBVariableType.Transform)]
    [CreateBBVariable("Position", BBVariableType.Vector3)]
    [System.Serializable]
    public class TransformGetPositionNode : ActionNode
    {
        public NodeProperty<Transform> transformValue;
        public bool self = true;
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
            if (self || transformValue.Value == null)
            {
                saveValue.Value = context.transform.position;
            }
            else
            {
                saveValue.Value = transformValue.Value.position;
            }
            

            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;

            description = "Retrieves the position of the object in World Space and saves the position in [SaveValue]";

            if (saveValue.reference == null)
            {
                description = "Unable to save value.";
            }
        }
    }
}