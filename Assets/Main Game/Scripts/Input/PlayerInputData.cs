using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add key changer function for "controller menu" to change keys.

namespace MainGame.PlayerInput
{
    [CreateAssetMenu(fileName = "PlayerInputData", menuName = "FPSGame/Input/Player Input Data")]
    public class PlayerInputData : AbstractInputData
    {
        [Header("Axis Base Control")]
        [SerializeField] private bool _axisActive;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [Header("Key Base Control")]

        [Tooltip("Do you wanna a dual key or just want 1 single key?")]
        [SerializeField] private bool _isSingle;
        [Tooltip("Use \"Horizontal\" for this element")]
        [SerializeField] private KeyCode SingleKeyCode;

        [SerializeField] private bool _keyBaseHorizontalActive;
        [SerializeField] private KeyCode PositiveHorizontalKeyCode;
        [SerializeField] private KeyCode NegativeHorizontalKeyCode;

        [SerializeField] private bool _keyBaseVerticalActive;
        [SerializeField] private KeyCode PositiveVerticalKeyCode;
        [SerializeField] private KeyCode NegativeVerticalKeyCode;
        //[Tooltip("Enter 0 if you don't want lerp")]
        [SerializeField] private float _increaseAmount = 0.015f;
        [Tooltip("Enter 0 if you don't want clamp")]
        [SerializeField] private float _clampAmount = 1f;
        public override void ProcessInput()
        {
            if (_axisActive)
            {
                Horizontal = Input.GetAxis(AxisNameHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else if(!_isSingle)
            {
                if (_keyBaseHorizontalActive)
                {
                    KeyBaseAxisControl(ref Horizontal, PositiveHorizontalKeyCode, NegativeHorizontalKeyCode);
                }
                if (_keyBaseVerticalActive)
                {
                    KeyBaseAxisControl(ref Vertical, PositiveVerticalKeyCode, NegativeVerticalKeyCode);
                }
            }
            else
            {
                KeyBaseAxisControl(ref Horizontal, SingleKeyCode);
            }
        }

        private void KeyBaseAxisControl(ref float value, KeyCode positive, KeyCode negative)
        {
            bool positiveActive = Input.GetKey(positive);
            bool negativeActive = Input.GetKey(negative);
            if (positiveActive)
            {
                value += _increaseAmount;
            }
            else if (negativeActive)
            {
                value -= _increaseAmount;
            }
            else
            {
                value = 0;
            }

            if (_clampAmount != 0)
                value = Mathf.Clamp(value, -_clampAmount, _clampAmount);
        }

        private void KeyBaseAxisControl(ref float value, KeyCode singleKey)
        {
            bool singleActive = Input.GetKey(singleKey);
            if (singleActive)
            {
                value += _increaseAmount;
            }
            else
            {
                value = 0;
            }

            if(_clampAmount!=0)
                value = Mathf.Clamp(value, -_clampAmount, _clampAmount);

        }

    }
}