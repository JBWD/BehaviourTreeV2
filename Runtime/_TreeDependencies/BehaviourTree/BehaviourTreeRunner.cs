using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Halcyon.BT {

    [AddComponentMenu("Halcyon/BehaviourTreeRunner")]
    public class BehaviourTreeRunner : MonoBehaviour {



        // The main behaviour tree asset
        [Tooltip("BehaviourTree asset to instantiate during Awake")]
        public BehaviourTree behaviourTree;
        BehaviourTree runtimeTree;

        public BehaviourTree RuntimeTree {
            get {
                if (runtimeTree != null) {
                    return runtimeTree;
                } else {
                    return behaviourTree;
                }
            }
        }

        [Tooltip("Run behaviour tree validation at startup (Can be disabled for release)")]
        public bool validate = true;
        // These values override the keys in the blackboard
        public List<BlackboardKeyValuePair> blackboardOverrides = new List<BlackboardKeyValuePair>();

        
        
        // Storage container object to hold game object subsystems
        public Context context;
        
        
        //Actions the trigger nodes are subscribed to.
        public Action OnInputKeyDown;
        public Action OnInputKeyUp;
        public Action OnInputKey;

        public Action<Collision> On3DCollisionEnter;
        public Action<Collision> On3DCollisionExit;
        public Action<Collision> On3DCollisionStay;

        public Action<Collider> On3DTriggerEnter;
        public Action<Collider> On3DTriggerExit;
        public Action<Collider> On3DTriggerStay;
        
        public Action<Collision2D> On2DCollisionEnter;
        public Action<Collision2D> On2DCollisionExit;
        public Action<Collision2D> On2DCollisionStay;

        public Action<Collider2D> On2DTriggerEnter;
        public Action<Collider2D> On2DTriggerExit;
        public Action<Collider2D> On2DTriggerStay;

        public Action OnMouseEnterCollider;
        public Action OnMouseExitCollider;
        public Action OnMouseOverCollider;
        
        public Action OnMouseUpCollider;
        public Action OnMouseDownCollider;
        public Action OnMouseButtonCollider;

        public Action OnDisableEvent;
        public Action OnEnableEvent;

        public Action<Vector2> OnMovementInputAction;
        public Action OnJumpInputAction;
        
        // Start is called before the first frame update
        void OnEnable() {

            bool isValid = ValidateTree();
            if (isValid) {
                context = CreateBehaviourTreeContext();
                runtimeTree = behaviourTree.Clone();
                runtimeTree.Bind(context);
                ApplyBlackboardOverrides();
                runtimeTree.InitializeNodes();
                
            } else {
                runtimeTree = null;
            }
            OnEnableEvent?.Invoke();
        }

     

        private void OnDisable()
        {
            if (runtimeTree == null)
                return;
            foreach (var node in runtimeTree.nodes)
            {
                node.OnDisable();
            }
            OnDisableEvent?.Invoke();
        }

        void ApplyBlackboardOverrides() {
            foreach (var pair in blackboardOverrides) {
                // Find the key from the new behaviour tree instance
                var targetKey = runtimeTree.blackboard.Find(pair.key.name);
                var sourceKey = pair.value;
                if (targetKey != null && sourceKey != null) {
                    targetKey.CopyFrom(sourceKey);
                }
            }
            
        }

        // Update is called once per frame
        void Update() {
            if (runtimeTree) {
                runtimeTree.Update();
            }
            UpdateKeyBoardInputs();
            
        }

        Context CreateBehaviourTreeContext() {
            return Context.CreateFromGameObject(gameObject);
        }

        bool ValidateTree() {
            if (!behaviourTree) {
                Debug.LogWarning($"No BehaviourTree assigned to {name}, assign a behaviour tree in the inspector");
                return false;
            }

            bool isValid = true;
            if (validate) {
                string cyclePath;
                isValid = !IsRecursive(behaviourTree, out cyclePath);

                if (!isValid) {
                    Debug.LogError($"Failed to create recursive behaviour tree. Found cycle at: {cyclePath}");
                }
            }

            return isValid;
        }

        bool IsRecursive(BehaviourTree tree, out string cycle) {

            // Check if any of the subtree nodes and their decendents form a circular reference, which will cause a stack overflow.
            List<string> treeStack = new List<string>();
            HashSet<BehaviourTree> referencedTrees = new HashSet<BehaviourTree>();

            bool cycleFound = false;
            string cyclePath = "";

            System.Action<Node> traverse = null;
            traverse = (node) => {
                if (!cycleFound) {
                    if (node is SubTree subtree && subtree.treeAsset != null) {
                        treeStack.Add(subtree.treeAsset.name);
                        if (referencedTrees.Contains(subtree.treeAsset)) {
                            int index = 0;
                            foreach (var tree in treeStack) {
                                index++;
                                if (index == treeStack.Count) {
                                    cyclePath += $"{tree}";
                                } else {
                                    cyclePath += $"{tree} -> ";
                                }
                            }

                            cycleFound = true;
                        } else {
                            referencedTrees.Add(subtree.treeAsset);
                            BehaviourTree.Traverse(subtree.treeAsset.rootNode, traverse);
                            referencedTrees.Remove(subtree.treeAsset);
                        }
                        treeStack.RemoveAt(treeStack.Count - 1);
                    }
                }
            };
            treeStack.Add(tree.name);

            referencedTrees.Add(tree);
            BehaviourTree.Traverse(tree.rootNode, traverse);
            referencedTrees.Remove(tree);

            treeStack.RemoveAt(treeStack.Count - 1);
            cycle = cyclePath;
            return cycleFound;
        }

        private void OnDrawGizmosSelected() {
            if (!Application.isPlaying) {
                return;
            }

            if (!runtimeTree) {
                return;
            }

            foreach (var node in runtimeTree.nodes)
            {
                if (node.drawGizmos)
                {
                    node.OnDrawGizmos();
                }
            }
            
        }
        

        public BlackboardKey<T> FindBlackboardKey<T>(string keyName) {
            if (runtimeTree) {
                return runtimeTree.blackboard.Find<T>(keyName);
            }
            return null;
        }

        public void SetBlackboardValue<T>(string keyName, T value) {
            if (runtimeTree) {
                runtimeTree.blackboard.SetValue(keyName, value);
            }
        }

        public T GetBlackboardValue<T>(string keyName) {
            if (runtimeTree) {
                return runtimeTree.blackboard.GetValue<T>(keyName);
            }
            return default(T);
        }

        private void OnDestroy()
        {
            if(runtimeTree!= null)
                runtimeTree.hasBeenDestroyed = true;
        }

        #region Triggers Calling
        public void UpdateKeyBoardInputs()
        {
            OnInputKey?.Invoke();
            OnInputKeyDown?.Invoke();
            OnInputKeyUp?.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            On3DTriggerEnter?.Invoke(other);
        }

        public void OnTriggerExit(Collider other)
        {
            On3DTriggerExit?.Invoke(other);
        }

        public void OnTriggerStay(Collider other)
        {
            On3DTriggerStay?.Invoke(other);
        }

        
        public void OnCollisionEnter(Collision collision)
        {
            On3DCollisionEnter?.Invoke(collision);
        }
        public void OnCollisionExit(Collision collision)
        {
            On3DCollisionExit?.Invoke(collision);
        }
        public void OnCollisionStay(Collision collision)
        {
            On3DCollisionStay?.Invoke(collision);
        }

        public void OnMouseEnter()
        {
            OnMouseEnterCollider?.Invoke();
        }

        public void OnMouseOver()
        {
            OnMouseOverCollider?.Invoke();
        }

        public void OnMouseExit()
        {
            OnMouseExitCollider?.Invoke();
        }

        public void OnMouseDown()
        {
            OnMouseDownCollider?.Invoke();
        }

        public void OnMouseUp()
        {
            OnMouseUpCollider?.Invoke();
        }

        public void OnMouseUpAsButton()
        {
            OnMouseButtonCollider?.Invoke();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            On2DTriggerEnter?.Invoke(other);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            On2DTriggerExit?.Invoke(other);
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            On2DTriggerStay?.Invoke(other);
        }

        public void OnCollisionEnter2D(Collision2D col)
        {
            On2DCollisionEnter?.Invoke(col);
        }
        
        public void OnCollisionExit2D(Collision2D col)
        {
            On2DCollisionExit?.Invoke(col);
        }
        
        public void OnCollisionStay2D(Collision2D col)
        {
            On2DCollisionStay?.Invoke(col);
        }

        public void OnMovement(InputValue value)
        {
            OnMovementInputAction?.Invoke(value.Get<Vector2>());
        }

        public void OnJump(InputValue value)
        {
            OnJumpInputAction?.Invoke();
        }
        #endregion
    }
}