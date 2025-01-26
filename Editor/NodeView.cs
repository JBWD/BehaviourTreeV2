using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codice.CM.Common;
using Codice.CM.SEIDInfo;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using Edge = UnityEditor.Experimental.GraphView.Edge;

namespace Halcyon.BT {

    public class NodeView : UnityEditor.Experimental.GraphView.Node {
        public Action<NodeView> OnNodeSelected;
        public Node node { get; private set; }
        public Port input;
        public Port output;
        public Type derivedType;
        public NodeView NodeParent {
            
            get {
                try
                {
                    using (IEnumerator<Edge> iter = input.connections.GetEnumerator()) {
                        iter.MoveNext();
                        return iter.Current?.output.node as NodeView;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }


        public NodeView(Node node, VisualTreeAsset nodeXml) : base(AssetDatabase.GetAssetPath(nodeXml)) {
            this.capabilities &= ~(Capabilities.Snappable); // Disable node snapping
            this.node = node;
            this.title = node.GetType().Name;
            derivedType = node.GetType();
            this.viewDataKey = node.guid;

            style.left = node.position.x;
            style.top = node.position.y;
            
            CreateInputPorts();
            CreateOutputPorts();
            SetupClasses();
            SetupDataBinding();

            this.AddManipulator(new DoubleClickNode());
        }
        
        public void SetupDataBinding() {
            SerializedBehaviourTree serializer = BehaviourTreeEditorWindow.Instance.serializer;
            var nodeProp = serializer.FindNode(serializer.Nodes, node);
            if (nodeProp != null) {
                var descriptionProp = nodeProp.FindPropertyRelative("description");
                if (descriptionProp != null) {
                    Label descriptionLabel = this.Q<Label>("description");
                    descriptionLabel.BindProperty(descriptionProp);
                }
            }
        }

        private void SetupClasses()
        {
            string oldColor = "";
            string oldIcon = "";
            foreach (var attribute in node.GetType().GetCustomAttributes(true))
            {
                if (attribute is BehaviourTreeNodeAttribute behaviourTreeNodeAttribute)
                {
                    AddToClassList(behaviourTreeNodeAttribute.nodeColor.ToString());
                    oldColor = behaviourTreeNodeAttribute.nodeColor.ToString();
                    AddToClassList(behaviourTreeNodeAttribute.nodeIcon.ToString());
                    oldIcon = behaviourTreeNodeAttribute.nodeIcon.ToString();
                    if(behaviourTreeNodeAttribute.nodeTitle != "")
                        title = behaviourTreeNodeAttribute.nodeTitle;
                }
                if (attribute is NodeTitleAttribute nodeTitleAttribute)
                {
                    title = nodeTitleAttribute.GetTitle();
                }

                if (attribute is NodeColorAttribute nodeColorAttribute)
                {
                    if (oldColor != "") 
                        RemoveFromClassList(oldColor);
                    AddToClassList(nodeColorAttribute.GetNodeColor());
                }

                if (attribute is NodeIconAttribute nodeIconAttribute)
                {
                    if(oldIcon != "")
                        RemoveFromClassList(oldIcon);
                    AddToClassList(nodeIconAttribute.GetNodeIcon());
                }
            }
            
            AddToClassList("hideIcon");
            AddToClassList("hide");
        }

        private void CreateInputPorts() {

            if (node is TriggerNode) {
                
            }else if (node is ActionNode) {
                input = new NodePort(Direction.Input, Port.Capacity.Multi);
            } else if (node is CompositeNode) {
                input = new NodePort(Direction.Input, Port.Capacity.Single);
            } else if (node is DecoratorNode) {
                input = new NodePort(Direction.Input, Port.Capacity.Single);
            }else if (node is RootNode) {

            }

            if (input != null) {
                input.portName = "";
                input.style.flexDirection = FlexDirection.Column;
                inputContainer.Add(input);
            }
        }

        private void CreateOutputPorts() {
            if (node is TriggerNode)
            {
                output = new NodePort(Direction.Output, Port.Capacity.Single);
            }else if (node is ComparisonNode) {
                output = new NodePort(Direction.Output, Port.Capacity.Multi, 2);
            }else if (node is ActionNode) {
                // Actions have no outputs
            } else if (node is CompositeNode) {
                output = new NodePort(Direction.Output, Port.Capacity.Multi);
            } else if (node is DecoratorNode) {
                output = new NodePort(Direction.Output, Port.Capacity.Single);
            }else if (node is RootNode) {
                output = new NodePort(Direction.Output, Port.Capacity.Single) ;
            }

            if (output != null) {
                output.portName = "";
                output.style.flexDirection = FlexDirection.ColumnReverse;
                outputContainer.Add(output);
            }
        }

        public override void SetPosition(Rect newPos) {
            newPos.x = EditorUtility.RoundTo(newPos.x, BehaviourTreeView.gridSnapSize);
            newPos.y = EditorUtility.RoundTo(newPos.y, BehaviourTreeView.gridSnapSize);

            base.SetPosition(newPos);

            SerializedBehaviourTree serializer = BehaviourTreeEditorWindow.Instance.serializer;
            Vector2 position = new Vector2(newPos.xMin, newPos.yMin);
            serializer.SetNodePosition(node, position);
        }

        public override void OnSelected() {
            base.OnSelected();
            if (OnNodeSelected != null) {
                OnNodeSelected.Invoke(this);
            }
        }

        public void SortChildren() {
            if (node is CompositeNode composite) {
                composite.children.Sort(SortByHorizontalPosition);
            }

            if (node is ComparisonNode comparison)
            {
                
                if (comparison.children.Count == 1)
                {
                    comparison.onlyChildIsTrue = comparison.position.x + (int)(comparison.size.x * .5f) > comparison.children[0].position.x + (int)(comparison.children[0].size.x * .5f);
                }

                
            }
        }

        private int SortByHorizontalPosition(Node left, Node right) {
            return left.position.x < right.position.x ? -1 : 1;
        }

        public void UpdateState() {

            RemoveFromClassList("running");
            RemoveFromClassList("failure");
            RemoveFromClassList("success");
            
            if (Application.isPlaying) {
                switch (node.state) {
                    case Node.State.Running:
                        if (node.started) {
                            AddToClassList("running");
                        }
                        break;
                    case Node.State.Failure:
                        AddToClassList("failure");
                        break;
                    case Node.State.Success:
                        AddToClassList("success");
                        break;
                }
            }
        }

        public void UpdateDescriptionVisibility(bool visible)
        {
            if (visible && ClassListContains("hide"))
            {
                RemoveFromClassList("hide");
                AddToClassList("show");
            }
            else if(!visible && ClassListContains("show"))
            {
                RemoveFromClassList("show");
                AddToClassList("hide");
            }
            
        }

        public void UpdateErroredNode()
        {
            
            if (node.errored)
            {
                AddToClassList("error");
            }
            else 
            {
                RemoveFromClassList("error");
            }
            
        }

        public void UpdateIconVisibility(bool iconVisibility)
        {
            if (!iconVisibility)
            {
                AddToClassList("hideIcon");
            }
            else
            {
                RemoveFromClassList("hideIcon");
            }
        }

        public void UpdateConditional()
        {
            RemoveFromClassList("trueCondition");
            RemoveFromClassList("falseCondition");
            RemoveFromClassList("hideCondition");
           
            
            if (node is ComparisonNode comparison)
            {
                if (comparison.children.Count == 1 && comparison.children[0] != null)
                {
                    
                        switch (comparison.onlyChildIsTrue)
                        {

                            case true:
                                comparison.children[0].conditionState = Node.ConditionState.True;
                                break;
                            default:
                                comparison.children[0].conditionState = Node.ConditionState.False;
                                break;
                        }
                    
                }

                if (comparison.children.Count == 2)
                {
                    if (comparison.children[0] != null && comparison.children[1] != null)
                    {
                        comparison.children[0].conditionState = Node.ConditionState.True;
                        comparison.children[1].conditionState = Node.ConditionState.False;
                    }
                }
            }
            if (node.conditionState == Node.ConditionState.True) {
                AddToClassList("trueCondition");
            }
            else if (node.conditionState == Node.ConditionState.False){
                AddToClassList("falseCondition");
            }
            else
            {
                AddToClassList("hideCondition");
            }
            
            node.conditionState = Node.ConditionState.None; //If not a conditional node or a child of a conditional node it will turn off.
        }

        public void UpdateSize()
        {

            node.size = new Vector2(GetPosition().width, GetPosition().height);
        }
    }
    
    
    
}