using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


namespace playerAndJump {
    public class AnimTruck : MonoBehaviour
    {
        public SkeletonAnimation suicideAnim;
        public AnimationReferenceAsset run, shoot, death, takeDamage;
        private string currentAnimation;


        bool isHit, isShot, isDeath;
        private void Start()
        {
            
        }


        private void Update()
        {
            isDeath = gameObject.GetComponent<takeDamage>().isDeath;
            moveAnim();
         }


        public void setAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
        {
            if (animation.name.Equals(currentAnimation))
            {
                return;
            }

            suicideAnim.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
            currentAnimation = animation.name;
        }

        public void setCharacterState(string state)
        {


            if (state.Equals("run"))
            {
                setAnimation(run, true, 1f);
            }
            else if(state.Equals("takeDamage"))
            {
                setAnimation(takeDamage, false, 1f);
            }
            else if(state.Equals("shoot"))
            {
                setAnimation(shoot, false, 2f);
            }
            else if (state.Equals("death"))
            {
                setAnimation(death, false, 1f);
            }




        }

        public void moveAnim()
        {
            isDeath = GetComponent<takeDamage>().isDeath;
            isHit = GetComponent<NewEnemyBehaviorLong>().isKick;
            isShot = GetComponent<NewEnemyBehaviorLong>().shot;
               if (isShot == true && isDeath == false)
               {
                setCharacterState("shoot");
               }
               else if (isHit == true && isDeath == false)
               { 
                setCharacterState("takeDamage");
               }
               else if(isDeath == true)
               {
                StartCoroutine(startDeath());

                }else
                {
                setCharacterState("run");
                }
            

           
        }

        IEnumerator startDeath()
        {
            setCharacterState("death");

            yield return new WaitForSeconds(0.5f);

            Destroy(gameObject);
        }

        

    }
}