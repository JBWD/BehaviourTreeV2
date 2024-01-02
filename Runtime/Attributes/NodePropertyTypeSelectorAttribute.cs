using System;

namespace TheKiwiCoder
{
    [AttributeUsage(AttributeTargets.Field)]
    public class NodePropertyTypeSelectorAttribute : Attribute
    {
        private System.Type m_SelectionType;

        public NodePropertyTypeSelectorAttribute(Type type)
        {
            m_SelectionType = type;
        }

        public Type GetSelectionType()
        {
            return m_SelectionType;
        }
    }
}