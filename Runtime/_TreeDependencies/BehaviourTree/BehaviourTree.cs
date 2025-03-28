using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

namespace Halcyon.BT {
    [CreateAssetMenu(menuName = "Halcyon/Behaviour Tree/Tree", fileName = "New Behaviour Tree")]
    public class BehaviourTree : ScriptableObject
    {
        public bool hasBeenDestroyed = false;
        [SerializeReference]
        public RootNode rootNode;
        [SerializeReference]
        public List<Node> nodes = new List<Node>();
        public Node.State treeState = Node.State.Running;
        public Blackboard blackboard = new Blackboard();
        public Context Context = new Context();
        
        #region  EditorProperties 
        [HideInInspector]
        public Vector3 viewPosition = new Vector3(600, 300);
        [HideInInspector]
        public Vector3 viewScale = Vector3.one;
        #endregion

        public BehaviourTree() {
            rootNode = new RootNode();
            nodes.Add(rootNode);
        }

        private void OnEnable() {
            // Validate the behaviour tree on load, removing all null children
            nodes.RemoveAll(node => node == null);
            Traverse(rootNode, node => {
                if (node is CompositeNode composite) {
                    composite.children.RemoveAll(child => child == null);
                }
            });
        }

        public Node.State Update() {
            if (treeState == Node.State.Running) {
                treeState = rootNode.Update();
            }
            return treeState;
        }

        public static List<Node> GetChildren(Node parent) {
            List<Node> children = new List<Node>();

            if (parent is DecoratorNode decorator && decorator.child != null) {
                children.Add(decorator.child);
            }

            if (parent is RootNode rootNode && rootNode.child != null) {
                children.Add(rootNode.child);
            }

            if (parent is CompositeNode composite) {
                return composite.children;
            }

            return children;
        }

        public static void Traverse(Node node, System.Action<Node> visiter) {
            if (node != null) {
                visiter.Invoke(node);
                var children = GetChildren(node);
                children.ForEach((n) => Traverse(n, visiter));
            }
        }

        public BehaviourTree Clone() {
            BehaviourTree tree = Instantiate(this);
            return tree;
        }

        public void Bind(Context context) {
            //Changed to a for loop for all nodes in the in the tree (Including Trigger Nodes)
            this.Context = context;
            foreach (var node in nodes)
            {
                node.context = context;
                node.blackboard = blackboard;
            }
            
        }

        public void InitializeNodes()
        {
            foreach (var node in nodes)
            {
                node.OnInit();
            }
        }


        public void UpdateDescriptions()
        {
            
            foreach (var node in nodes)
            {
                if (hasBeenDestroyed)
                    return;
                node.UpdateDescription();
            }
        }
        
    }
}