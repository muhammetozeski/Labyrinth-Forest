using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
    /// <summary>
    /// This class contains simple tools I made.
    /// Every function has "a_" to locate top of function list.
    /// </summary>
    public class MainTools : MonoBehaviour
    {
        /// <summary>
        /// Equalize the vector2.x to x and y to z of the vector3. returns same y axis in vector3.
        /// Note: If you make "vector3 = vector2" this equalize the x to x but y to y.
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 a_Vector2To3OnFlat(Vector3 vector3, Vector2 vector2)
        {
            vector3.x = vector2.x;
            vector3.z = vector2.y;
            return vector3;
        } 
        
        /// <summary>
          /// Equalize the vector3.x to x and z to y of the vector3.
          /// </summary>
          /// <returns>Vector3</returns>
        public static Vector2 a_Vector3To2OnFlat(Vector3 vector3)
        {

            Vector2 vector2 = new Vector2(vector3.x, vector3.z);
            return vector2;
        }

        /// <summary>
        /// Get the normal to a triangle from the three corner points, a, b and c. 
        /// <br> </br>See <see href="https://docs.unity3d.com/ScriptReference/Vector3.Cross.html">here</see> for more information.
        /// </summary>
        /// <returns>Cross the two side to get a perpendicular vector, then normalize it.</returns>
        Vector3 a_GetNormal(Vector3 rootPos, Vector3 side1, Vector3 side2)
        {
            // Find vectors corresponding to two of the sides of the triangle.
            Vector3 _side1 = side1 - rootPos;
            Vector3 _side2 = side2 - rootPos;

            // Cross the vectors to get a perpendicular vector, then normalize it.
            return Vector3.Cross(_side1, _side2).normalized;
        }
        /// <summary>
        /// gives degree between 360 and 0
        /// </summary>
        public static float a_Vector2toAngle(Vector2 p_vector2)
        {
            float angle = Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
            if (angle < 0)
                return 180f - angle;
            else
                return angle;

        }
        /// <summary>
        /// gives degree between 360 and 0
        /// </summary>
        public static float a_Vector2toAngle(float x, float y)
        {
            float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            if (angle < 0)
                return (180 - Mathf.Abs( angle)) + 180f;
            else
                return angle;
        }
    }
}