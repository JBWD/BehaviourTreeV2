using System;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeColorAttribute: Attribute
    {
        NodeColors _nodeColor;

        public NodeColorAttribute(NodeColors nodeColor)
        {
            _nodeColor = nodeColor;
            
        }
        
        public string GetNodeColor()
        {
            return _nodeColor.ToString();
        }
    }
}