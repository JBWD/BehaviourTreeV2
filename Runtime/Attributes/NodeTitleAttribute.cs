using System;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeTitleAttribute: Attribute
    {
        public string _title = "";

        public NodeTitleAttribute(string title)
        {
            _title = title;
        }
        
        public string GetTitle()
        {
            return _title;
        }
    }
}