using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Variable")]
    [NodeTitle("Variable:\nVector3 to String")]
    [NodeMenuName("Variable: Vector3 to String")] 
    [NodeIcon(NodeIcons.repeat)]
    [NodeColor(NodeColors.pink)]
    [CreateBBVariable("Vector3Value", BBVariableType.Vector3)]
    [CreateBBVariable("SaveStringValue", BBVariableType.String)]
    [System.Serializable]
    public class ConversionVector3ToStringNode : ActionNode
    {
        public NodeProperty<Vector3> vector3Value;
        [BlackboardValueOnly] public NodeProperty<string> saveValue;


        protected override void OnStart()
        {

        }

        protected override void OnStop()
        {

        }

        protected override State OnUpdate()
        {

            saveValue.Value = vector3Value.Value.ToString();
            state = State.Success;

            return state;
        }

        public override void UpdateDescription()
        {
            errored = false;

            if (saveValue.reference != null)
            {

                description =
                    $"Saves the string of 'Vector3Value' in the 'SaveValue'.";
            }
            else
            {
                description = "Does not save the value";
                errored = true;
            }

        }
    }
}