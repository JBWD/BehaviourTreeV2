using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector3")]
    [NodeTitle("Math:\nVector3 Normalize")]
    [NodeMenuName("Math: Vector3 Normalize")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class Vector3NormalizeNode: ActionNode
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