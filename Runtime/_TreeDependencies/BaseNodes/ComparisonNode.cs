using System.Linq;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeColor(NodeColors.yellow)]
    [NodeIcon(NodeIcons.condition)]
    public abstract class ComparisonNode : CompositeNode
    {
        [HideInInspector]
        public bool onlyChildIsTrue = true;
      

        protected override State OnUpdate()
        {
            if (children.Count == 0)
                return State.Failure;
            
            if (children.Count() == 1)
            {
                if (CheckComparison() == onlyChildIsTrue) //only child is true is updated based on whether the child is true or false.
                {
                    children[0]?.Update();
                    return State.Success;
                }
                
                return State.Failure;
            }
           
            switch (CheckComparison())
            {
                case true:
                    children[0]?.Update();
                    return State.Success;
                default:
                    children[1]?.Update();
                    return State.Success;
            }
            
        }

        public abstract bool CheckComparison();
    }
}