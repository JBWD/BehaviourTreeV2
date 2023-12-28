using System;
using Unity.VisualScripting;
using UnityEngine;


namespace TheKiwiCoder
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BehaviourTreeNodeAttribute : Attribute
    {
        public string menuPath = "";
        public string nodeTitle = "";
        public NodeColors nodeColor = NodeColors.grey;
        public NodeIcons nodeIcon = NodeIcons.none;


        public BehaviourTreeNodeAttribute()
        {}
        
        public BehaviourTreeNodeAttribute(string menuPath, string nodeTitle = "")
        {
            this.menuPath = menuPath;
            this.nodeTitle = nodeTitle;
        }

        public string GetMenuPath()
        {
            return menuPath;
        }

        public string GetNodeTitle()
        {
            return nodeTitle;
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