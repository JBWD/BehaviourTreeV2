using UnityEngine.UI;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode("Triggers & Events", menuName = "UI Button: On Button Click", nodeTitle = "UI Button:\nOn Button Click",
        nodeIcon = NodeIcons.trigger,nodeColor = NodeColors.purple)]
    [System.Serializable]
    public class OnButtonClickNode : TriggerNode
    {
        [Header("Note: Needs to be overriden value in instance.")]
        [BlackboardValueOnly]
        public NodeProperty<Button> buttonValue;


        
        
        public override void OnInit()
        {
            if (buttonValue.reference != null && buttonValue.Value  != null)
            {
                buttonValue.Value.onClick.AddListener(OnButtonClick);
            }
        }

        public override void OnDisable()
        {
            if (buttonValue.reference != null && buttonValue.Value  != null)
            {
                buttonValue.Value.onClick.RemoveListener(OnButtonClick);
            }
        }

        public void OnButtonClick()
        {
            Debug.Log("Clicking button");
            state = State.Success;
            child.Update();
        }

    }
}