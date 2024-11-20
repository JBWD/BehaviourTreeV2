using TMPro;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeColor(NodeColors.green),
     NodeIcon(NodeIcons.dialog),
     NodeTitle("TMP:\n Update Score Text"),
     NodeMenuName("TMP: Update Score Text"),
     NodeMenuPath("UI/Text Mesh Pro")]
    [System.Serializable]
    public class DisplayScoreNode: ActionNode
    {
        
        [Header("Note: Needs to be overriden value in instance.")]
        [BlackboardValueOnly]
        public NodeProperty<TextMeshProUGUI> textContainer;
        public NodeProperty<string> text;
        public bool scoreIsPrefix = false;
        public NumericProperty score;
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
                if (scoreIsPrefix)
                {
                    textContainer.Value.text =  score.IntegerValue + text.Value;
                }
                else
                {
                    textContainer.Value.text = text.Value + score.IntegerValue;
                }
                state = State.Success;
            }

            return state;
        }
    }
}