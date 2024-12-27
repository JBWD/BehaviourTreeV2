using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Halcyon.BT {

    public class NodePort : Port {
        public int connectionCapacity = int.MaxValue;
        
        // GITHUB:UnityCsReference-master\UnityCsReference-master\Modules\GraphViewEditor\Elements\Port.cs
        private class DefaultEdgeConnectorListener : IEdgeConnectorListener {
            private GraphViewChange m_GraphViewChange;
            private List<Edge> m_EdgesToCreate;
            private List<GraphElement> m_EdgesToDelete;
           
            
            public DefaultEdgeConnectorListener() {
                m_EdgesToCreate = new List<Edge>();
                m_EdgesToDelete = new List<GraphElement>();

                m_GraphViewChange.edgesToCreate = m_EdgesToCreate;
            }

            public void OnDropOutsidePort(Edge edge, Vector2 position) {
                NodeView nodeSource = null;
                bool isSourceParent = false;
                
                if (edge.output != null) {
                    nodeSource = edge.output.node as NodeView;
                    isSourceParent = true;
                }
                if (edge.input != null) {
                    nodeSource = edge.input.node as NodeView;
                    isSourceParent = false;
                }
                CreateNodeWindow.Show(position, nodeSource, isSourceParent);
            }

            
            public void OnDrop(GraphView graphView, Edge edge) {
                
                m_EdgesToCreate.Clear();
                m_EdgesToCreate.Add(edge);
                
                
                // We can't just add these edges to delete to the m_GraphViewChange
                // because we want the proper deletion code in GraphView to also
                // be called. Of course, that code (in DeleteElements) also
                // sends a GraphViewChange.
                m_EdgesToDelete.Clear();
                if (edge.input.capacity == Capacity.Single)
                    foreach (Edge edgeToDelete in edge.input.connections)
                        if (edgeToDelete != edge)
                            m_EdgesToDelete.Add(edgeToDelete);
                if (edge.output.capacity == Capacity.Single)
                    foreach (Edge edgeToDelete in edge.output.connections)
                        if (edgeToDelete != edge)
                            m_EdgesToDelete.Add(edgeToDelete);

                NodePort outputPort = edge.output as NodePort;
                NodePort inputPort = edge.input as NodePort;
                //This takes into account nodes with specific number of outputs required.
                if (edge.output.capacity == Capacity.Multi && outputPort.connectionCapacity < outputPort.connections.Count() + 1)
                {
                    List<Edge> extraEdges = outputPort.connections.ToList();
                    int amountToRemove = outputPort.connections.Count() + 1- outputPort.connectionCapacity;
                    for (int i = 0; i < amountToRemove; i++)
                    {
                        m_EdgesToDelete.Add(extraEdges[extraEdges.Count - 1 - i]);
                    }
                    
                }

                if (edge.input.capacity == Capacity.Multi && inputPort.connectionCapacity <  inputPort.connections.Count() + 1)
                {
                    List<Edge> extraEdges = inputPort.connections.ToList();
                    int amountToRemove = inputPort.connections.Count() + 1- inputPort.connectionCapacity;
                    for (int i = 0; i < amountToRemove; i++)
                    {
                        m_EdgesToDelete.Add(extraEdges[extraEdges.Count - 1 - i]);
                    }
                }
                
                if (m_EdgesToDelete.Count > 0)
                    graphView.DeleteElements(m_EdgesToDelete);

                var edgesToCreate = m_EdgesToCreate;
                if (graphView.graphViewChanged != null) {
                    edgesToCreate = graphView.graphViewChanged(m_GraphViewChange).edgesToCreate;
                }

                foreach (Edge e in edgesToCreate) {
                    graphView.AddElement(e);
                    edge.input.Connect(e);
                    edge.output.Connect(e);
                }
            }
        }

        public NodePort(Direction direction, Capacity capacity, int numericCapacity = Int32.MaxValue) : base(Orientation.Vertical, direction, capacity, typeof(bool))
        {
            connectionCapacity = numericCapacity;
            var connectorListener = new DefaultEdgeConnectorListener();
            m_EdgeConnector = new EdgeConnector<Edge>(connectorListener);
            this.AddManipulator(m_EdgeConnector);
            if (direction == Direction.Input) {
                style.width = 100;
            } else {
                style.width = 40;
            }
        }

        public override bool ContainsPoint(Vector2 localPoint) {
            Rect rect = new Rect(0, 0, layout.width, layout.height);
            return rect.Contains(localPoint);
        }
    }
}