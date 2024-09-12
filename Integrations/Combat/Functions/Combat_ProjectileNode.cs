using Halcyon.BT.Integrations.Combat;
using Halcyon.BT;
using UnityEngine;

namespace Halcyon.BT.Integrations.Combat
{
    
    [BehaviourTreeNode(menuName = "Combat: Fire Projectile", menuPath = "Combat", nodeIcon = NodeIcons.combat, nodeColor = NodeColors.green, nodeTitle = "Combat\nFire Projectile")]
    public class Combat_ProjectileNode : ActionNode 
    {
        
        public NodeProperty<Transform> target;
        public NodeProperty<Vector3> spawnPositionOffset;
        public NodeProperty<Projectile> projectile;

        public AnimationProperty animationProperty;

        private float currentTime = 0;
        
        protected override void OnStart()
        {
            currentTime +=0;
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (projectile.Value == null)
            {
                return State.Failure; 
            }
            Vector3 spawnPosition = context.transform.position + context.transform.rotation * spawnPositionOffset.Value;
            Projectile obj = (Projectile)Object.Instantiate(projectile.Value, spawnPosition , Quaternion.identity);
            obj.Instantiate(target.Value);
          
            SetAnimation();
            currentTime = 0;
            
            return State.Success;
        }


        public void SetAnimation()
        {
            if (context.animator == null)
            {
                state = State.Failure;
            }
            switch (animationProperty.parameterType)
            {
                case AnimationParameterType.Boolean:
                    context.animator.SetBool(animationProperty.animationName, animationProperty.booleanParameter);
                    state = State.Success;
                    break;
                case AnimationParameterType.Float:
                    context.animator.SetFloat(animationProperty.animationName, animationProperty.floatParameter);
                    state = State.Success;
                    break;
                case AnimationParameterType.Integer:
                    context.animator.SetInteger(animationProperty.animationName, animationProperty.integerParameter);
                    state = State.Success;
                    break;
                case AnimationParameterType.Trigger:
                    context.animator.SetTrigger(animationProperty.animationName);
                    state = State.Success;
                    break;
                default:
                    state = State.Failure;
                    break;
            }
        }
    }
}