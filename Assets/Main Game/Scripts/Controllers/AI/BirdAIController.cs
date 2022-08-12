using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MainGame.NPCs.Nature.Birds
{
    public class BirdAIController : MonoBehaviour
    {
        [SerializeField] private BirdAISettings settings;

        [SerializeField] Animator animator;
        Vector2 FlyingBorderCorner1;
        Vector2 FlyingBorderCorner2;

        Vector3 target;

        float FlyingSpeed;

        float RotationChangingTimeRange;

        float AnimationStartingTime;

        Rigidbody rb;
        private void Awake()
        {
            if (settings.IsSquare)
            {
                settings.FlyingBorderCorner1 = Vector2.one * settings.BorderSquare;
                settings.FlyingBorderCorner2 = - settings.FlyingBorderCorner1;
            }
            RotationChangingTimeRange = Random.Range(settings.RotationChangingTimeRange1, 
                settings.RotationChangingTimeRange2);
            FlyingBorderCorner1 = settings.FlyingBorderCorner1;
            FlyingBorderCorner2 = settings.FlyingBorderCorner2;
            FlyingSpeed = settings.FlyingSpeed;
            AnimationStartingTime = Random.Range(0, settings.AnimationMaxStartingTime);
        }
        // Start is called before the first frame update
        void Start()
        {
            rb = transform.GetComponent<Rigidbody>();
            InvokeRepeating("goTo", 0, RotationChangingTimeRange);
            StartCoroutine(StartAnimation(AnimationStartingTime));
        }

        private void goTo()
        {
            target = getRandomTarget(FlyingBorderCorner1, FlyingBorderCorner2, transform.position.y);
            birdLookAt(target);
            rb.velocity = transform.forward.normalized * FlyingSpeed;
        }

        //with this function, every bird flaps in different times. it would be weird if every bird flaps same time :D
        IEnumerator StartAnimation(float time)
        {
            yield return new WaitForSeconds(time);
            animator.SetBool("Start Animation", true);
        }
        
        //tools:

        private Vector3 getRandomTarget(Vector2 border1, Vector2 border2, float high)
        {
            return new Vector3(Random.Range(border1.x, border2.x), high, Random.Range(border1.y, border2.y));
        }
        private void birdLookAt(Vector3 target)
        {
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        }

    }
}
