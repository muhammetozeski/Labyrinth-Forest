using UnityEngine;

namespace MainGame.NonInteractiveCharacters.FlyingObjects
{
    public class FlyingObjectsController : MonoBehaviour
    {
        public Transform Target; //to change it in scene, made it public
        Vector3 distance; // sets automotically, you just set the location in scene
        float LerpValue = 0.1f; // sets randomly
        [SerializeField] Animator animator; // animator of this object

        Vector3 playersLastLocation;
        float MaxDistance = 10;
        float currentDistance;
        void Start()
        {
            //player position saving
            playersLastLocation = Target.position;

            //save necessary distance and decide lerp
            distance = transform.position - Target.position;
            LerpValue = Random.Range(0.01f, 0.001f);

            //making a "so late update" function
            InvokeRepeating("update1s", 0f, 1f);
        }


        void Update()
        {
           
            if (Vector3.Distance(Target.position + distance, transform.position) > MaxDistance) {
                
                transform.position = Vector3.Lerp(transform.position, Target.position + distance, 
                    LerpValue + ((0.01f - LerpValue)/100f*90f)
                    );
            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, Target.position + distance, LerpValue);
            }
            transform.LookAt(new Vector3(Target.position.x, Target.position.y + 2, Target.position.z));//look at target
        }

        //alternate for late update, called for every 1 second
        private void update1s()
        {
            #region detecting it is idle or moving

                if (playersLastLocation != Target.position)//if target is moving
                {
                    animator.SetBool("idle", false);// falying object switch to flying animaton
                }
                else
                {
                    animator.SetBool("idle", true);
                }
                playersLastLocation = Target.position; // to detect that if player is moving

            #endregion
        }
    }

}