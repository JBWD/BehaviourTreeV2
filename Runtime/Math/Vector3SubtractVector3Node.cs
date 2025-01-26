using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector3")]
    [NodeTitle("Math:\nVector3 Subtract")]
    [NodeMenuName("Math: Vector3 Subtract")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("SubtractVector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("SaveVector3Value", BBVariableType.Vector3)]
    [System.Serializable]
    public class Vector3SubtractVector3Node : ActionNode
    {

        public NodeProperty<Vector3> baseValue;
        public NodeProperty<Vector3> subtractValue;
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
            saveValue.Value = baseValue.Value - subtractValue.Value;
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
                        $"Subtracts '{baseValue.Value}' - '{subtractValue.Value}' and saves the total in '{saveValue.reference.name}'";
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