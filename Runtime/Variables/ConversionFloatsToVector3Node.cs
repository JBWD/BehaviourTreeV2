using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Variable/Conversion", menuName = "Conversion: Floats to Vector3", 
        nodeTitle = "Conversion:\nFloats to Vector3", nodeColor = NodeColors.pink, nodeIcon = NodeIcons.repeat)]
    [System.Serializable]
    public class ConversionFloatsToVector3Node: ActionNode
    {
        
        public NodeProperty<float> xValue;
        public NodeProperty<float> yValue;
        public NodeProperty<float> zValue;
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
            saveValue.Value = new Vector3(xValue.Value, yValue.Value, zValue.Value);
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
                        $"Saves X:'{xValue.Value}', Y:'{yValue.Value}', and Z:{zValue.Value} in the 'SaveValue'.";
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