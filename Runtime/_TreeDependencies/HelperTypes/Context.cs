using System;
using System.Collections;
using System.Collections.Generic;
using Halcyon.BT.Integrations.Combat;
using Halcyon.Combat;
using UnityEngine;
using UnityEngine.AI;

namespace Halcyon.BT {

    // The context is a shared object every node has access to.
    // Commonly used components and subsytems should be stored here
    // It will be somewhat specfic to your game exactly what to add here.
    // Feel free to extend this class 
    [Serializable]
    
    
    public partial class Context {
        /// <summary>
        /// Local GameObject
        /// </summary>
        [Header("Unity Scripts")]
        public GameObject gameObject;
        /// <summary>
        /// Local Transform
        /// </summary>
        public Transform transform;
        /// <summary>
        /// Local Animator
        /// </summary>
        public Animator animator;
        /// <summary>
        /// Local RigidBody
        /// </summary>
        public Rigidbody rigidBody;
        /// <summary>
        /// Local Navmesh Agent
        /// </summary>
        public NavMeshAgent agent;
        public CharacterController characterController;
        [Header("Colliders")]
        public SphereCollider sphereCollider;
        public BoxCollider boxCollider;
        public CapsuleCollider capsuleCollider;
        /// <summary>
        /// Local Behaviour Tree Runner
        /// </summary>
        [HideInInspector]
        public BehaviourTreeRunner BehaviourTreeRunner;

        [Header("AI Information")]
        //Navmesh AI Information and Triggers
        public AIPhases CurrentPhase;
        public AIStates CurrentState;
        public AIConditions CurrentConditions;
        
        public Action<AIPhases> OnPhaseChange;
        public Action<AIStates> OnStateChange;
        public Action<AIConditions> OnConditionAdd;
        public Action<AIConditions> OnConditionRemove;

        [Header("Navmesh AI: Combat")]
        public Health health;
        public EffectManager effectManager;
        public AbilityManager abilityManager;
        
        // Add other game specific systems here

        
        public static Context CreateFromGameObject(GameObject gameObject) {
            // Fetch all commonly used components
            Context context = new Context();
            context.gameObject = gameObject;
            context.transform = gameObject.transform;
            context.animator = gameObject.GetComponentInChildren<Animator>();
            context.rigidBody = gameObject.GetComponent<Rigidbody>();
            context.agent = gameObject.GetComponent<NavMeshAgent>();
            context.sphereCollider = gameObject.GetComponent<SphereCollider>();
            context.boxCollider = gameObject.GetComponent<BoxCollider>();
            context.capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            context.characterController = gameObject.GetComponent<CharacterController>();
            context.BehaviourTreeRunner = gameObject.GetComponent<BehaviourTreeRunner>();
            context.abilityManager = gameObject.GetComponent<AbilityManager>();
            context.effectManager = gameObject.GetComponent<EffectManager>();
            context.health = gameObject.GetComponent<Health>();
           
            return context;
        }

        
    }
}