using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nSet GameObject")]
    [NodeMenuName("Variable: Set GameObject")] 
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseGameObjectValue", BBVariableType.GameObject)]
    [CreateBBVariable("SaveGameObjectValue", BBVariableType.GameObject)]
    [System.Serializable]
    public class SetGameObjectNode : ActionNode
    {

        public NodeProperty<GameObject> baseValue;
        [BlackboardValueOnly]
        public NodeProperty<GameObject> saveValue;
        
        
        
        
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
           
        }

        protected override State OnUpdate()
        {
            saveValue.Value = baseValue.Value;
            state = State.Success;
            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;
            if (saveValue.reference == null)
            {
                description = "Does not save any of the values";
                errored = true;
            }
            else
            {
                description = "Sets the 'SaveValue' to the same value or reference as 'BaseValue'";
            }
        }
    }
}