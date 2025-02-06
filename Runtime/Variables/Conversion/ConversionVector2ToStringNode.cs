using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nVector2 to String")]
    [NodeMenuName("Variable: Vector2 to String")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("Vector2Value", BBVariableType.Vector2)]


    [System.Serializable]
    public class ConversionVector2ToStringNode : ActionNode
    {
        public NodeProperty<Vector2> Vector2Value;
        [BlackboardValueOnly]
        public NodeProperty<string> saveValue;


        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {

            saveValue.Value = Vector2Value.Value.ToString();
            state =State.Success;

            return state;
        }
        
        public override void UpdateDescription()
        {
            errored = false;
            
            if (saveValue.reference != null)
            {

                description =
                    $"Saves the string of 'Vector2Value' in the 'SaveValue'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }
            
        }  
    }
}