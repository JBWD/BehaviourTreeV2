using System;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeIconAttribute : Attribute
    {
        /// <summary>
        /// Changes the icon that is shown, this helps distinguish between nodes.
        /// </summary>
        public NodeIcons _nodeIcon = NodeIcons.none;

        public NodeIconAttribute(NodeIcons nodeIcon)
        {
            _nodeIcon = nodeIcon;
            
        }
        
        public string GetNodeIcon()
        {
            return _nodeIcon.ToString();
        }
    }
}