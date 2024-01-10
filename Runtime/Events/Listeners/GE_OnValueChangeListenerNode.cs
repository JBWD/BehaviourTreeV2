using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Halcyon
{

    [BehaviourTreeNode(menuPath = "Triggers & Events/Global Events/Listener", menuName = "Event Listener: On Float Change",nodeTitle  = "Event Listener:\nOn Float Change", nodeColor = NodeColors.white, nodeIcon = NodeIcons.trigger)]
    [Serializable]
    public class GE_OnValueChangeListenerNode : TriggerNode
    {
        public override void OnInit()
        {
            base.OnInit();

            GlobalEvents.OnValueChange += OnValueChange;
        }

        public override void OnDisable()
        {
            GlobalEvents.OnValueChange -= OnValueChange;
        }


        public NodeProperty<string> activationName;

        public NodeProperty<float> saveFloatValue;
        
        
        
        public void OnValueChange(string activationName, float activationValue)
        {
            if (this.activationName.Value == activationName)
            {
                saveFloatValue.Value = activationValue;
                OnUpdate();
            }

           
        }
    }
}