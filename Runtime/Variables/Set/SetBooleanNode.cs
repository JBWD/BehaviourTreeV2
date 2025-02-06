namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nSet Boolean")]
    [NodeMenuName("Variable: Set Boolean")] 
    [NodeIcon(NodeIcons.save)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("BaseBooleanValue", BBVariableType.Boolean)]
    [CreateBBVariable("SaveBooleanValue", BBVariableType.Boolean)]
    [System.Serializable]
    public class SetBooleanNode : ActionNode
    {

        public NodeProperty<bool> baseValue;
        [BlackboardValueOnly] public NodeProperty<bool> saveValue;




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