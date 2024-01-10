﻿using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Input", menuName = "Input: On Key Down", nodeTitle = "Input:\nOn Key Down", nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    [System.Serializable]
    public class OnKeyDownNode : TriggerNode
    {
        public KeyCode keyCode;
        
        
        
        
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKeyDown += CheckInput;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKeyDown -= CheckInput;
        }

        public void CheckInput()
        {


            if (Input.GetKeyDown(keyCode))
            {
                OnUpdate();
                state = State.Success;
            }
        }

       

        
    }
}