using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace TheKiwiCoder
{
    [BehaviourTreeNode(menuFolder = "UI: Text Mesh Pro", menuName = "Update Text", nodeTitle = "Text Mesh Pro:\n Update Text", nodeIcon = NodeIcons.action, nodeColor = NodeColors.green)]
    [System.Serializable]
    public class UpdateUITextNode: ActionNode
    {

        [Header("Note: Needs to be overriden value in instance.")]
        public NodeProperty<TextMeshProUGUI> textContainer;
        public NodeProperty<string> text;
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            if (textContainer.Value == null)
            {
                state = State.Failure;
            }
            else
            {
                textContainer.Value.text = text.Value;
                state = State.Success;
            }

            return state;
        }
    }
}