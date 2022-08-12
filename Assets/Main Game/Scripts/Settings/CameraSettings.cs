using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.GameCamera
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "FPSGame/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        //[Header("Speed")]
        [SerializeField] private float _MouseSpeed = 1000f;
        public float MouseSpeed { get { return _MouseSpeed; } set { _MouseSpeed = value; } }
    }
}
