using System;
using UnityEngine;

namespace Halcyon
{
    [BehaviourTreeNode(menuPath = "Triggers & Events/Input", menuName = "Input: On Movement Input", nodeTitle = "Input:\nOn Movement Input",
        nodeColor = NodeColors.purple, nodeIcon = NodeIcons.input)]
    [System.Serializable]
    public class OnMovementInputNode : TriggerNode
    {
        public MovementInputType inputType;
        [BlackboardValueOnly] public NodeProperty<Vector2> vector2Value;

        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKey += OnInput;
        }

        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKey -= OnInput;
        }

        public enum MovementInputType
        {
            WASD,
            Arrows,
            Joystick,
        }

        public void OnInput()
        {
            OnUpdate();
            
        }
        
        protected override State OnUpdate()
        {

            vector2Value.Value = GetInputValue().normalized;
            return child.Update();;
        }

        public Vector2 GetInputValue()
        {
            switch (inputType)
            {
                case MovementInputType.WASD:
                    return GetWASDInput();
                case MovementInputType.Arrows:
                    return GetArrowInput();
                case MovementInputType.Joystick:
                    return GetJoyStickInput();
            }
            return Vector2.zero;
        }

        public Vector2 GetWASDInput()
        {
            Vector2 inputValue = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                inputValue.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputValue.y -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputValue.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputValue.x += 1;
            }

            return inputValue;
        }

        public Vector2 GetArrowInput()
        {
            Vector2 inputValue = Vector2.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                inputValue.y += 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                inputValue.y -= 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                inputValue.x -= 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                inputValue.x += 1;
            }

            return inputValue;
        }

        public Vector2 GetJoyStickInput()
        {
            Vector2 inputValue = Vector2.zero;

            inputValue.y = Input.GetAxis("Vertical");
            inputValue.x = Input.GetAxis("Horizontal");

            return inputValue;
        }
        
    }
    
}