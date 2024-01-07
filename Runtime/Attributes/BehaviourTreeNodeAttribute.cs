using System;
using Unity.VisualScripting;
using UnityEngine;


namespace Halcyon
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BehaviourTreeNodeAttribute : Attribute
    {
        /// <summary>
        /// Name of the folder that will be used in the Context Menu (Right Clicking in the Tree View)
        /// </summary>
        public string menuPath = "";
        /// <summary>
        /// (Optional) If the 'menuName' is left blank the 'nodeTitle' will be used in it's place.
        /// </summary>
        public string menuName = "";
        /// <summary>
        ///  Name of the node and will be used to identify the node within the tree. Alternate Usage: If the 'menuName' is left blank the 'nodeTitle' will be used in it's place.
        /// </summary>
        public string nodeTitle = "";
        /// <summary>
        /// Changes the color of the top of the node, this helps distinguish between nodes.
        /// </summary>
        public NodeColors nodeColor = NodeColors.Default;
        /// <summary>
        /// Changes the icon that is shown, this helps distinguish between nodes.
        /// </summary>
        public NodeIcons nodeIcon = NodeIcons.none;


        public BehaviourTreeNodeAttribute()
        {}

        public BehaviourTreeNodeAttribute(string menuPath, string menuName = "",string nodeTitle = "")
        {
            this.menuPath = menuPath;
            this.nodeTitle = nodeTitle;
            this.menuName = menuName;
        }

        public string GetMenuPath()
        {
            return menuPath;
        }

        public string GetNodeTitle()
        {
            return nodeTitle;
        }

        public string GetMenuName()
        {
            return menuName;
        }

        public string GetColor()
        {
            return nodeColor.ToString();
        }

        public string GetIcon()
        {
            return nodeIcon.ToString();
        }

        
    }
}