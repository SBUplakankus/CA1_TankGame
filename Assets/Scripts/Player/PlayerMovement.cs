using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Stats")] 
        public float forwardSpeed;
        public float backwardSpeed;
        public float torque;
        private float _horizontalInput;
        private float _verticalInput;

        [Header("Components")] 
        public WheelJoint2D wheelFront;
        public WheelJoint2D wheelBack;
        private Rigidbody _rb;
        private JointMotor2D _frontMotor, _backMotor;
        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            
            if(_horizontalInput > 0)
                HandleForwardMovement();
            else if (_horizontalInput < 0)
                HandleBackwardMovement();
            else
            {
                PauseMovement();
            }
        }

        private void HandleForwardMovement()
        {
            _backMotor.motorSpeed = forwardSpeed;
            _frontMotor.motorSpeed = forwardSpeed;
            _backMotor.maxMotorTorque = torque;
            _frontMotor.maxMotorTorque = torque;
            wheelFront.motor = _frontMotor;
            wheelBack.motor = _backMotor;
        }
        
        private void HandleBackwardMovement()
        {
            _backMotor.motorSpeed = backwardSpeed;
            _frontMotor.motorSpeed = backwardSpeed;
            _backMotor.maxMotorTorque = torque;
            _frontMotor.maxMotorTorque = torque;
            wheelFront.motor = _frontMotor;
            wheelBack.motor = _backMotor;
        }

        private void PauseMovement()
        {
            _backMotor.motorSpeed = 0;
            _frontMotor.motorSpeed = 0;
            wheelFront.motor = _frontMotor;
            wheelBack.motor = _backMotor;
        }
    }
}
