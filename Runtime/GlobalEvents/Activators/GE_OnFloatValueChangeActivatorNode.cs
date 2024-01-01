using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

[BehaviourTreeNode(menuFolder = "Global Event Activators", menuName = "On Float Change Activator",nodeTitle  = "Event Activator\nOn Float Change", nodeColor = NodeColors.grey, nodeIcon = NodeIcons.trigger)]
[Serializable]
public class GE_OnFloatValueChangeActivatorNode : ActionNode
{

    public NodeProperty<string> activationName;
    public NodeProperty<float> activationValue;
    
    protected override void OnStart()
    {
       
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        GlobalEvents.OnValueChange.Invoke(activationName.Value, activationValue.Value);
        state = State.Success;
        return state;
    }

    public override void UpdateDescription()
    {
        description = $"Activates a value change event for {activationName.Value} and sends the value: {activationValue.Value}";
    }
}
