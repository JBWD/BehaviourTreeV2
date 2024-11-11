using System;

namespace Halcyon.BT
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeMenuNameAttribute : Attribute
    {
        public string _menuName = "";

        public NodeMenuNameAttribute(string menuName)
        {
            _menuName = menuName;
        }
        
        public string GetMenuName()
        {
            return _menuName;
        }
    }
}