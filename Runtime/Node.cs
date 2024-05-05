using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Halcyon {

    [System.Serializable]
    
    public abstract class Node {
        public enum State {
            Running,
            Failure,
            Success
        }

        [HideInInspector] public State state = State.Running;
        [HideInInspector] public bool started = false;
        [HideInInspector] public string guid = System.Guid.NewGuid().ToString();
        [HideInInspector] public Vector2 position;
        [HideInInspector] public Context context;
        [HideInInspector] public Blackboard blackboard;
        
        [TextArea] public string description;
        [Tooltip("When enabled, the nodes OnDrawGizmos will be invoked")] public bool drawGizmos = false;
        [HideInInspector] public bool errored = false;
        public virtual void OnInit() {
            // Used for Triggers and Global Events (Add the events)
        }

        public virtual void OnDisable() {
            // Used for Triggers and Global Events (Remove the events)
        }
        public State Update() {

            if (!started) {
                OnStart();
                started = true;
            }

            state = OnUpdate();

            if (state != State.Running) {
                OnStop();
                started = false;
            }

            return state;
        }

        public void Abort() {
            BehaviourTree.Traverse(this, (node) => {
                node.started = false;
                node.state = State.Running;
                node.OnStop();
            });
        }
        

        public virtual void OnDrawGizmos() { }

        protected abstract void OnStart();
        protected abstract void OnStop();
        protected abstract State OnUpdate();

        protected virtual void Log(string message) {
            Debug.Log($"[{GetType()}]{message}");
        }

        /// <summary>
        /// Allows for Real time Updating of the description for current variables within the node. This is also used to
        /// change the current state of the node into an error. An error can provide context to the user on what is occuring
        /// and how to fix the issue.
        /// </summary>
        public virtual void UpdateDescription()
        { }
    }
}