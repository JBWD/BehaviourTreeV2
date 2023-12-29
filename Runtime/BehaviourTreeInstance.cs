using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    [AddComponentMenu("TheKiwiCoder/BehaviourTreeInstance")]
    public class BehaviourTreeInstance : MonoBehaviour {



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
        Context context;

        
        //Actions the trigger nodes are subscribed to.
        public Action<KeyCode> OnInputKeyDown;
        public Action<KeyCode> OnInputKeyUp;
        public Action<KeyCode> OnInputKey;

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
        
        
        
        
        
        
        
        // Start is called before the first frame update
        void OnEnable() {

            bool isValid = ValidateTree();
            if (isValid) {
                context = CreateBehaviourTreeContext();
                runtimeTree = behaviourTree.Clone();
                runtimeTree.Bind(context);

                ApplyBlackboardOverrides();
            } else {
                runtimeTree = null;
            }
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
            
            // BehaviourTree.Traverse(runtimeTree.rootNode, (n) => {
            //     if (n.drawGizmos) {
            //         n.OnDrawGizmos();
            //     }
            // });
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


        public void OnTriggerEnter(Collider other)
        {
            On3DTriggerEnter?.Invoke(other);
        }
    }
}