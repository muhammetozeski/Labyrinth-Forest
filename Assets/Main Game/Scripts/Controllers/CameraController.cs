using System.Collections;
using System.Collections.Generic;
using MainGame.PlayerInput;
using UnityEngine;
namespace MainGame.GameCamera
{
    public class CameraController : MonoBehaviour
    {
        
        [SerializeField] private CameraSettings _cameraSettings;
        [SerializeField] private AbstractInputData _input;
        [SerializeField] private AbstractInputData _ESCKey;
        [SerializeField] private Transform _playerBody;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _cameraCenter;
        [SerializeField] private UITriggers uITriggers;
        void Update()
        {
            float mouseX = _input.Horizontal * _cameraSettings.MouseSpeed * Time.deltaTime;
            float mouseY = _input.Vertical * _cameraSettings.MouseSpeed * Time.deltaTime;
            
            _playerBody.Rotate(Vector3.up * mouseX);
           _cameraCenter.Rotate(Vector3.left * mouseY);

            if(_ESCKey.Horizontal > 0)
            {
                Cursor.lockState = CursorLockMode.None;
                uITriggers.showUI();
            }
        }
    }
}
