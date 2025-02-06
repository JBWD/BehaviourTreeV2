using System.Collections.Generic;
using Halcyon.BT;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;



[NodeTitle("NavMesh AI:\n Flee")]
[NodeMenuName("NavMesh AI: Run State Listener")]
[NodeMenuPath("NavMesh")]
[NodeColor(NodeColors.white)]
public class NavmeshAIFleeNode : ActionNode
{

    public NodeProperty<Transform> Target;
    public NodeProperty<NumericProperty> NumberOfMovementChanges = new NodeProperty<NumericProperty>()
        {Value =  new NumericProperty() { DoubleValue = 4 } };
    public NodeProperty<NumericProperty> FleeDistance = new NodeProperty<NumericProperty>() 
        { Value =  new NumericProperty() { DoubleValue = 5 } };
    
    
    private Vector3 m_destination;
    private int currentFleeIndex = 0;
    private List<Vector3> fleePoints = new List<Vector3>();
    
    protected override void OnStart()
    {
        fleePoints.Clear();
        currentFleeIndex = 0;
        // Generate flee points
        GenerateFleePoints();

        // Start moving to the first flee point
        MoveToNextFleePoint();
    }


    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        if (context.agent.remainingDistance <= context.agent.stoppingDistance && !context.agent.pathPending)
        {
            if (currentFleeIndex < fleePoints.Count)
            {
                MoveToNextFleePoint();
            }
        }
        if (currentFleeIndex < fleePoints.Count)
            return State.Running;
       
        return State.Success;
        
    }
    

    private Vector3 debugPosition = Vector3.zero;
    public override void OnDrawGizmos()
    {
        Debug.DrawRay(debugPosition, Vector3.down * 10, Color.red);
    }
    
    void GenerateFleePoints()
    {
        Vector3 fleeDirection = (context.transform.position - Target.Value.position).normalized; // Opposite direction of player

        for (int i = 0; i < NumberOfMovementChanges.Value.IntegerValue; i++)
        {
            Vector3 randomPoint = Random.insideUnitSphere * FleeDistance.Value.FloatValue;
            
            Vector3 fleeTarget = Target.Value.position + randomPoint +  fleeDirection * (FleeDistance.Value.FloatValue * (i + 1)); // Place points further each time
            
            // Ensure the flee point is valid using NavMesh.SamplePosition
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(fleeTarget, out navHit, 5f, NavMesh.AllAreas))
            {
                fleePoints.Add(navHit.position);
            }
        }
    }
    
    void MoveToNextFleePoint()
    {
        if (currentFleeIndex < fleePoints.Count)
        {
            Vector3 target = fleePoints[currentFleeIndex];
            context.agent.SetDestination(target);
            currentFleeIndex++;
        }
    }
}
