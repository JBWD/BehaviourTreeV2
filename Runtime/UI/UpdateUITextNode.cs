using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "UI/Text Mesh Pro", menuName = "Update Text", nodeTitle = "Text Mesh Pro:\n Update Text", nodeIcon = NodeIcons.action, nodeColor = NodeColors.green)]
    [System.Serializable]
    public class UpdateUITextNode: ActionNode
    {
        
        [Header("Note: Needs to be overriden value in instance.")]
        [NodePropertyTypeSelector(typeof(TextMeshProUGUI))]
        public NodeProperty textContainer;
        public NodeProperty<string> text;

        private TextMeshProUGUI m_text;
        protected override void OnStart()
        {
            m_text = blackboard.GetValue<TextMeshProUGUI>(textContainer.reference.name);
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (textContainer.reference == null)
            {
                state = State.Failure;
                return state;
            }
            
            
            
            if (m_text == null)
            {
                state = State.Failure;
            }
            else
            {
                m_text.text = text.Value;
                state = State.Success;
            }

            return state;
        }
    }
}