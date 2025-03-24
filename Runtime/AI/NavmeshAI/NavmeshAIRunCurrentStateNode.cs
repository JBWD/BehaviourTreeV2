using Halcyon.BT;
using UnityEngine;

[NodeTitle("Navmesh AI:\nRun Current State\nActivator")]
[NodeMenuPath("AI/NavMesh")]
[NodeMenuName("Navmesh AI: Run Current State Activator")]
[NodeIcon(NodeIcons.ai)]
[NodeColor(NodeColors.grey)]
public class NavmeshAIRunCurrentStateNode : ActionNode
{
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        
        context.OnStateChange?.Invoke(context.CurrentState);
        return State.Success;
    }

    public override void UpdateDescription()
    {
        description = "Uses an action to run a local event calling the Current State. This state is located in the Context Variable.";
    }
}
