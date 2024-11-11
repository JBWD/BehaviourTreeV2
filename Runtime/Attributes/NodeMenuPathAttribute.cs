using System;

namespace Halcyon.BT
{
    [AttributeUsage((AttributeTargets.Class))]
    public class NodeMenuPathAttribute : Attribute
    {
        /// <summary>
        /// Name of the folder that will be used in the Context Menu (Right Clicking in the Tree View)
        /// </summary>
        public string _menuPath = "";

        public NodeMenuPathAttribute(string menuPath)
        {
            _menuPath = menuPath;
        }
        
        public string GetMenuPath()
        {
            return _menuPath;
        }

    }
}