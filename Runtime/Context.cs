using System.Collections;
using System.Collections.Generic;
using Halcyon.Integrations.Pathlist;
using UnityEngine;
using UnityEngine.AI;

namespace Halcyon {

    // The context is a shared object every node has access to.
    // Commonly used components and subsytems should be stored here
    // It will be somewhat specfic to your game exactly what to add here.
    // Feel free to extend this class 
    public partial class Context {
        /// <summary>
        /// Local GameObject
        /// </summary>
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
        public SphereCollider sphereCollider;
        public BoxCollider boxCollider;
        public CapsuleCollider capsuleCollider;
        public CharacterController characterController;
        /// <summary>
        /// Local Behaviour Tree Runner
        /// </summary>
        public BehaviourTreeRunner BehaviourTreeRunner;
        public PathList pathList;
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
            context.pathList = gameObject.GetComponent<PathList>();
            // Add whatever else you need here...

            return context;
        }
    }
}