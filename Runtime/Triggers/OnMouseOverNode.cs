﻿namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers/Mouse", nodeTitle = "On Mouse Over", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.trigger)]
    public class OnMouseOverNode : TriggerNode
    {
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnMouseOverCollider += RunMouseEvent;
        }
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnMouseOverCollider -= RunMouseEvent;
        }
        public void RunMouseEvent()
        {
            OnUpdate();
        }
    }
}