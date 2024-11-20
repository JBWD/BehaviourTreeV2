using UnityEngine.UI;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeColor(NodeColors.purple),
     NodeIcon(NodeIcons.trigger),
     NodeTitle("UI Button:\nOn Button Click"),
    NodeMenuName("UI Button: On Button Click"),
    NodeMenuPath("UI")]
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
            state = State.Success;
            child.Update();
        }

    }
}