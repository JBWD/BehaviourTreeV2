using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath( "Math/Vector2")]
    [NodeTitle("Math:\nVector2 Add")]
    [NodeMenuName("Math: Vector2 Add")]
    [NodeColor(NodeColors.pink)]
    [NodeIcon(NodeIcons.math)]
    [CreateBBVariable("BaseVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("AddVector2Value", BBVariableType.Vector2)]
    [CreateBBVariable("SaveVector2Value", BBVariableType.Vector2)]
    [System.Serializable]
    public class Vector2AddVector2Node : ActionNode
    {

        public NodeProperty<Vector2> baseValue;
        public NodeProperty<Vector2> addValue;
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
            saveValue.Value = baseValue.Value + addValue.Value;
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
                        $"Adds '{baseValue.Value}' + '{addValue.Value}' and saves the total in '{saveValue.reference.name}'";
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