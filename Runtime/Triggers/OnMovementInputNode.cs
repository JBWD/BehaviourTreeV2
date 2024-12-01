using System;
using UnityEngine;

namespace Halcyon.BT
{
    [NodeMenuPath("Triggers/Input")]
    [NodeTitle("Input:\nOn Movement Input")]
    [NodeMenuName("Input: On Movement Input")] 
    [System.Serializable]
    public class OnMovementInputNode : TriggerNode
    {
        public MovementInputType inputType;
        [BlackboardValueOnly] public NodeProperty<Vector2> vector2Value;
        public enum V3SaveMode
        {
            XY,
            XZ,
            YZ,
        }

        public V3SaveMode v3SaveMode = V3SaveMode.XZ;
        [BlackboardValueOnly] public NodeProperty<Vector3> vector3Value;


        private Vector2 _inputSystemValue;
        public override void OnInit()
        {
            context.BehaviourTreeRunner.OnInputKey += OnInput;
            context.BehaviourTreeRunner.OnMovementInputAction += OnMovement;
        }
        
        public override void OnDisable()
        {
            context.BehaviourTreeRunner.OnInputKey -= OnInput;
            context.BehaviourTreeRunner.OnMovementInputAction -= OnMovement;
        }

        public void OnMovement(Vector2 direction)
        {
            _inputSystemValue = direction;
            OnUpdate();
        }

     
        public enum MovementInputType
        {
            WASD,
            Arrows,
            Joystick,
            InputSystem,
        }

        public void OnInput()
        {
            OnUpdate();
            
        }
        
        protected override State OnUpdate()
        {

            vector2Value.Value = GetInputValue().normalized;
            switch (v3SaveMode)
            {
                case V3SaveMode.XY:
                    vector3Value.Value = vector2Value.Value;
                    break;
                case V3SaveMode.XZ:
                    vector3Value.Value = new Vector3(vector2Value.Value.x, 0,vector2Value.Value.y);
                    break;
                case V3SaveMode.YZ:
                    vector3Value.Value = new Vector3(0,vector2Value.Value.x,vector2Value.Value.y);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
                case MovementInputType.InputSystem:
                    return _inputSystemValue;
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