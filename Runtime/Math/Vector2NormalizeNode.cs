using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector2")]
    [NodeTitle("Math:\nVector2 Normalize")]
    [NodeMenuName("Math: Vector2 Normalize")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class Vector2NormalizeNode: ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        [BlackboardValueOnly]
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