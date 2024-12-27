using System;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Input")]
    [NodeTitle("Input:\nOn Jump Input")]
    [NodeMenuName("Input: On Jump Input")] 
    [System.Serializable]
    public class OnJumpInputNode : TriggerNode
    {
        public JumpInputType inputType;
        private bool _jumpInput = false;
        
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKeyDown += OnInput;
            context.BehaviourTreeRunner.OnJumpInputAction += OnInputSystem;
        }
        
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKeyDown -= OnInput;
            context.BehaviourTreeRunner.OnJumpInputAction -= OnInputSystem;
        }

        public void OnInputSystem()
        {
            if(JumpInputType.InputSystem == inputType)
                OnUpdate();
        }
     
        public enum JumpInputType
        {
            SpaceBar,
            SouthGamePadButton,
            InputSystem,
        }

        public void OnInput() //Jumper to Call OnUpdate since it does not have a 
        {
            switch (inputType)
            {
                case JumpInputType.SpaceBar:
                    if(Input.GetKeyDown(KeyCode.Space))
                        OnUpdate();
                    break;
                case JumpInputType.SouthGamePadButton:
                    if(Input.GetKeyDown(KeyCode.Joystick1Button0))
                        OnUpdate();
                    break;
            }
            
        }
        
     

    }
    
}