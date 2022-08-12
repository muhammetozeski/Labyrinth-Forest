using System.Collections;
using System.Collections.Generic;
using MainGame.PlayerInput;
using UnityEngine;
namespace MainGame.Player
{
    public class PlayerMoving : MonoBehaviour
    {
        [SerializeField] private AbstractInputData _playerMovingInput;
        [SerializeField] private PlayerMovingSettings _settings;
        [SerializeField] private CharacterController _characterController;

        private Vector3 velocity;
        void Update()
        {
            if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
            {
                velocity.y = Mathf.Sqrt(_settings.JumpHeight * -2f * _settings.Gravity);
            }

            if (_characterController.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = _playerMovingInput.Horizontal;
            float z = _playerMovingInput.Vertical;

            Vector3 move = transform.right * x + transform.forward * z;

            _characterController.Move(move * _settings.Speed * Time.deltaTime);



            velocity.y += _settings.Gravity * Time.deltaTime;

            _characterController.Move(velocity * Time.deltaTime);

        }
    }
}
