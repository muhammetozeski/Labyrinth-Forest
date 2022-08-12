using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame.NPCs.Nature.Birds
{
    [CreateAssetMenu(fileName = "BirdAISettings", menuName = "FPSGame/NPCs/Nature/Birds")]
    public class BirdAISettings : ScriptableObject
    {
        public Vector2 FlyingBorderCorner1;
        public Vector2 FlyingBorderCorner2;

        //if you don't want to enter FlyingBorderCorner, make this true and just enter BorderSquare
        public bool IsSquare;
        public float BorderSquare;

        public float FlyingSpeed;

        public float RotationChangingTimeRange1;
        public float RotationChangingTimeRange2;

        public float AnimationMaxStartingTime;
    }
}
