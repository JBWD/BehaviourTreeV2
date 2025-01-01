using UnityEngine;

namespace Halcyon.BT
{
    
    [NodeMenuName("Navmesh AI: Wander")]
    [NodeTitle("Navmesh AI:\nWander")]
    [NodeMenuPath("NavMesh")]
    [NodeIcon(NodeIcons.ai)]
    public class NavmeshAIWanderNode: ActionNode
    {

        /**
         * All AI nodes will require the BehaviourTreeAI script to be added in the context menu.
         * This will get initialized in a context integration and through the init calls.
         *
         * Variables:
         * Spawn point
         * Wander Radius
         * Wander Point
         * Time Between Wanders
         * Movement Speed
         * Turn Speed
         *
         * How it works
         * 1 - Saves the Initial Spawn point the enemy was spawned at.
         * 2 - increments the current time between wanders
         * 3 - Once the wander time has extended beyond that time
         * 4 - Selects a random point in the Wander Radius (Radius around spawn point)
         * 5 - Move to the wander point
         * 6 - stops once wander point has been reached
         * 7 - Repeats steps 2-6
         *
         * Since Detection is on a trigger for the player this will not have anything do to with detecting a target.
         * Does not change states internally.
         */
        
        
        public NodeProperty<Vector3> spawnPoint;
        public NodeProperty<NumericProperty> wanderRadius;
        public NodeProperty<Vector3> wanderPoint;
        public NodeProperty<NumericProperty> timeBetweenWanders;
        public NodeProperty<NumericProperty> stoppingDistance;
        public NodeProperty<NumericProperty> moveSpeed;
        public NodeProperty<NumericProperty> turnSpeed;
        
            [SerializeField]
        private float currentTimeBetweenWanders = 0;

        [SerializeField] private Vector3 calculatedDestination;
        
        protected override void OnStart()
        {
            currentTimeBetweenWanders = 0;
            context.agent.speed = moveSpeed.Value.FloatValue;
            context.agent.angularSpeed = turnSpeed.Value.FloatValue;
            context.agent.stoppingDistance = stoppingDistance.Value.FloatValue;
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (context.agent.velocity.magnitude < .1f && currentTimeBetweenWanders <= timeBetweenWanders.Value.FloatValue)
            {
                currentTimeBetweenWanders += Time.deltaTime;
                return State.Running; //Basically Idle
            }

            if (currentTimeBetweenWanders >= timeBetweenWanders.Value.FloatValue)
            {
                currentTimeBetweenWanders = 0;
                wanderPoint.Value = GetRandomWanderPoint();

                if (!context.agent.SetDestination(wanderPoint.Value))
                {
                    Debug.Log("Unable to set destination");
                }
            }
            return State.Running;
        }

        public Vector3 GetRandomWanderPoint()
        {
            float radius = wanderRadius.Value.FloatValue;
            Vector3 centerPoint = spawnPoint.Value;
            Vector2 randomPoint = (Random.insideUnitCircle * radius); 
            calculatedDestination = centerPoint + new Vector3(randomPoint.x, 0, randomPoint.y);
            return calculatedDestination;
        }
    }
}