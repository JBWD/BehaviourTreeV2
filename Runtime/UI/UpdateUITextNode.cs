using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeColor(NodeColors.green),
     NodeIcon(NodeIcons.dialog),
     NodeTitle("Text Mesh Pro:\n Update Text"),
     NodeMenuName("TMP: Update Text"),
     NodeMenuPath("UI/Text Mesh Pro")]
    [System.Serializable]
    public class UpdateUITextNode: ActionNode
    {
        
        [Header("Note: Needs to be overriden value in instance.")]
        [BlackboardValueOnly]
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
            if (textContainer.reference == null)
            {
                state = State.Failure;
                return state;
            }
            
            if (textContainer.Value == null)
            {
                state = State.Failure;
            }
            else
            {
                string textToDisplay = "";
                //foreach (var t in text)
                {
                    textToDisplay += text.Value.Trim();
                }
                textContainer.Value.text = textToDisplay;
                state = State.Success;
            }

            return state;
        }
    }
}