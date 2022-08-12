using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame.Player
{
    [CreateAssetMenu(fileName = "PlayerMovingSettings", menuName = "FPSGame/Player/Player Moving Settings")]
    public class PlayerMovingSettings : ScriptableObject
    {
        [Tooltip("Moving speed of player.")]
        [SerializeField]private float _speed = 10f;
        public float Speed { get { return _speed; } set { _speed = value; } }

        [Tooltip("Gravity force for player.")]
        [SerializeField] private float _gravity = -10f;
        public float Gravity { get { return _gravity; } set { _gravity = value; } }

        [Tooltip("Jump force of player.")]
        [SerializeField] private float _jumpHeight = 5f;
        public float JumpHeight { get { return _jumpHeight; } set { _jumpHeight = value; } }

        /*
         * use these later
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
         */
    }
}
